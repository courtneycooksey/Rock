﻿// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Rock;
using Rock.Data;
using Rock.Model;
using Rock.Web.UI;

namespace RockWeb.Blocks.Groups
{
    /// <summary>
    ///
    /// </summary>
    [DisplayName( "Group Scheduler" )]
    [Category( "Groups" )]
    [Description( "Allows volunteer schedules for groups and locations to be managed by a scheduler." )]
    public partial class GroupScheduler : RockBlock
    {
        #region UserPreferenceKeys

        /// <summary>
        /// Keys to use for UserPreferences
        /// </summary>
        protected static class UserPreferenceKey
        {
            /// <summary>
            /// The selected group identifier
            /// </summary>
            public const string SelectedGroupId = "SelectedGroupId";

            /// <summary>
            /// The selected date
            /// </summary>
            public const string SelectedDate = "SelectedDate";

            /// <summary>
            /// The selected schedule id
            /// </summary>
            public const string SelectedScheduleId = "SelectedScheduleId";

            /// <summary>
            /// The selected group location ids
            /// </summary>
            public const string SelectedGroupLocationIds = "SelectedGroupLocationIds";

            /// <summary>
            /// The selected resource list source type
            /// </summary>
            public const string SelectedResourceListSourceType = "SelectedResourceListSourceType";

            /// <summary>
            /// The group member filter type
            /// </summary>
            public const string GroupMemberFilterType = "GroupMemberFilterType";

            /// <summary>
            /// The alternate group identifier
            /// </summary>
            public const string AlternateGroupId = "AlternateGroupId";

            /// <summary>
            /// The data view identifier
            /// </summary>
            public const string DataViewId = "DataViewId";
        }

        #endregion UserPreferanceKeys

        #region enums

        

        #endregion

        #region Base Control Methods

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );

            RockPage.AddScriptLink( "~/Scripts/dragula.min.js", true );
            RockPage.AddCSSLink( "~/Themes/Rock/Styles/group-scheduler.css", true );

            // this event gets fired after block settings are updated. it's nice to repaint the screen if these settings would alter it
            this.BlockUpdated += Block_BlockUpdated;
            this.AddConfigurationUpdateTrigger( upnlContent );

            LoadDropDowns();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );

            if ( !Page.IsPostBack )
            {
                LoadFilterFromUserPreferences();
                ApplyFilter();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads the drop downs.
        /// </summary>
        private void LoadDropDowns()
        {
            bgResourceListSource.BindToEnum<SchedulerResourceListSourceType>();
            rblGroupMemberFilter.BindToEnum<SchedulerResourceGroupMemberFilterType>();
        }

        /// <summary>
        /// Updates the list of schedules for the selected group
        /// </summary>
        private void UpdateScheduleList()
        {
            Group group = GetSelectedGroup();

            nbGroupWarning.Visible = false;
            pnlGroupScheduleLocations.Visible = false;

            if ( group != null )
            {
                var groupLocations = group.GroupLocations.ToList();
                var groupSchedules = groupLocations.SelectMany( a => a.Schedules ).DistinctBy( a => a.Guid ).ToList();
                if ( !groupSchedules.Any() )
                {
                    nbGroupWarning.Text = "Group does not have any locations or schedules";
                    nbGroupWarning.Visible = true;
                }
                else
                {
                    pnlGroupScheduleLocations.Visible = true;
                    rblSchedule.Items.Clear();
                    foreach ( var schedule in groupSchedules )
                    {
                        var listItem = new ListItem();
                        if ( schedule.Name.IsNotNullOrWhiteSpace() )
                        {
                            listItem.Text = schedule.Name;
                        }
                        else
                        {
                            listItem.Text = schedule.FriendlyScheduleText;
                        }

                        listItem.Value = schedule.Id.ToString();
                        rblSchedule.Items.Add( listItem );
                    }
                }
            }
            else
            {
                nbGroupWarning.Text = "Please select a group";
                nbGroupWarning.Visible = true;
            }
        }

        /// <summary>
        /// Gets the selected group.
        /// </summary>
        /// <returns></returns>
        private Group GetSelectedGroup()
        {
            var groupId = hfGroupId.Value.AsIntegerOrNull();
            var rockContext = new RockContext();
            Group group = null;
            if ( groupId.HasValue )
            {
                group = new GroupService( rockContext ).GetNoTracking( groupId.Value );
            }

            return group;
        }

        /// <summary>
        /// Loads the filter from user preferences.
        /// </summary>
        private void LoadFilterFromUserPreferences()
        {
            dpDate.SelectedDate = this.GetBlockUserPreference( UserPreferenceKey.SelectedDate ).AsDateTime();
            hfGroupId.Value = this.GetBlockUserPreference( UserPreferenceKey.SelectedGroupId );
            gpGroup.SetValue( hfGroupId.Value.AsIntegerOrNull() );

            UpdateScheduleList();
            rblSchedule.SetValue( this.GetBlockUserPreference( UserPreferenceKey.SelectedScheduleId ).AsIntegerOrNull() );

            UpdateGroupLocationList();
            cblGroupLocations.SetValues( this.GetBlockUserPreference( UserPreferenceKey.SelectedGroupLocationIds ).SplitDelimitedValues().AsIntegerList() );

            var resouceListSourceType = this.GetBlockUserPreference( UserPreferenceKey.SelectedResourceListSourceType ).ConvertToEnumOrNull<SchedulerResourceListSourceType>() ?? SchedulerResourceListSourceType.Group;
            bgResourceListSource.SetValue( resouceListSourceType.ConvertToInt() );

            var groupMemberFilterType = this.GetBlockUserPreference( UserPreferenceKey.GroupMemberFilterType ).ConvertToEnumOrNull<SchedulerResourceGroupMemberFilterType>() ?? SchedulerResourceGroupMemberFilterType.ShowMatchingPreference;
            rblGroupMemberFilter.SetValue( groupMemberFilterType.ConvertToInt() );

            gpResourceListAlternateGroup.SetValue( this.GetBlockUserPreference( UserPreferenceKey.AlternateGroupId ).AsIntegerOrNull() );
            dvpResourceListDataView.SetValue( this.GetBlockUserPreference( UserPreferenceKey.DataViewId ).AsIntegerOrNull() );
        }

        /// <summary>
        /// Saves the user preferences and updates the resource list and locations based on the filter
        /// </summary>
        private void ApplyFilter()
        {
            this.SetBlockUserPreference( UserPreferenceKey.SelectedGroupId, hfGroupId.Value );
            this.SetBlockUserPreference( UserPreferenceKey.SelectedDate, dpDate.SelectedDate.ToISO8601DateString() );
            this.SetBlockUserPreference( UserPreferenceKey.SelectedGroupLocationIds, cblGroupLocations.SelectedValues.AsDelimited( "," ) );
            this.SetBlockUserPreference( UserPreferenceKey.SelectedScheduleId, rblSchedule.SelectedValue );

            var resourceListSourceType = bgResourceListSource.SelectedValueAsEnum<SchedulerResourceListSourceType>();
            this.SetBlockUserPreference( UserPreferenceKey.SelectedResourceListSourceType, resourceListSourceType.ToString() );

            var groupMemberFilterType = rblGroupMemberFilter.SelectedValueAsEnum<SchedulerResourceGroupMemberFilterType>();
            this.SetBlockUserPreference( UserPreferenceKey.GroupMemberFilterType, groupMemberFilterType.ToString() );

            this.SetBlockUserPreference( UserPreferenceKey.AlternateGroupId, gpResourceListAlternateGroup.SelectedValue );
            this.SetBlockUserPreference( UserPreferenceKey.DataViewId, dvpResourceListDataView.SelectedValue );

            pnlResourceFilterGroup.Visible = resourceListSourceType == SchedulerResourceListSourceType.Group;
            pnlResourceFilterAlternateGroup.Visible = resourceListSourceType == SchedulerResourceListSourceType.AlternateGroup;
            pnlResourceFilterDataView.Visible = resourceListSourceType == SchedulerResourceListSourceType.DataView;

            InitResourceList();
            BindAttendanceOccurrences();
        }

        /// <summary>
        /// Updates the list of group locations for the selected group
        /// </summary>
        private void UpdateGroupLocationList()
        {
            Group group = GetSelectedGroup();

            if ( group != null )
            {
                var groupLocations = group.GroupLocations.OrderBy( a => a.Order ).ThenBy( a => a.Location.Name ).ToList();

                // get the selected group location ids just in case any of them are the same after repopulated
                var selectedGroupLocationIds = cblGroupLocations.SelectedValuesAsInt;

                cblGroupLocations.Items.Clear();
                foreach ( var groupLocation in groupLocations )
                {
                    cblGroupLocations.Items.Add( new ListItem( groupLocation.Location.ToString(), groupLocation.Id.ToString() ) );
                }

                cblGroupLocations.SetValues( selectedGroupLocationIds );
            }
        }

        /// <summary>
        /// Set the Resource List hidden fields which groupScheduler.js uses to populate the Resource List
        /// </summary>
        private void InitResourceList()
        {
            int groupId = hfGroupId.Value.AsInteger();
            int? resourceGroupId = null;
            int? resourceDataViewId = null;
            int scheduleId = rblSchedule.SelectedValue.AsInteger();

            var resourceListSourceType = bgResourceListSource.SelectedValueAsEnum<SchedulerResourceListSourceType>();
            switch ( resourceListSourceType )
            {
                case SchedulerResourceListSourceType.Group:
                    {
                        resourceGroupId = hfGroupId.Value.AsInteger();
                        // todo matching vs all
                        break;
                    }
                case SchedulerResourceListSourceType.AlternateGroup:
                    {
                        resourceGroupId = gpResourceListAlternateGroup.SelectedValue.AsInteger();
                        break;
                    }
                case SchedulerResourceListSourceType.DataView:
                    {
                        resourceDataViewId = dvpResourceListDataView.SelectedValue.AsInteger();
                        break;
                    }
            }

            hfOccurrenceGroupId.Value = hfGroupId.Value;
            hfOccurrenceScheduleId.Value = rblSchedule.SelectedValue;
            hfOccurrenceOccurrenceDate.Value = dpDate.SelectedDate.Value.ToISO8601DateString();

            hfResourceGroupId.Value = resourceGroupId.ToString();
            hfResourceGroupMemberFilterType.Value = rblGroupMemberFilter.SelectedValueAsEnum<SchedulerResourceGroupMemberFilterType>().ConvertToInt().ToString();
            hfResourceDataViewId.Value = resourceDataViewId.ToString();
            hfResourceAdditionalPersonIds.Value = string.Empty;
        }


        /// <summary>
        /// Binds the Attendance Occurrences ( Which shows the Location for the Attendance Occurrence for the selected Group + DateTime + Location ).
        /// groupScheduler.js will populate these with the assigned resources
        /// </summary>
        private void BindAttendanceOccurrences()
        {
            var rockContext = new RockContext();
            var attendanceOccurrenceService = new AttendanceOccurrenceService( rockContext );
            var selectedGroupLocationIds = cblGroupLocations.SelectedValuesAsInt;

            var groupLocationQuery = new GroupLocationService( rockContext ).GetByIds( selectedGroupLocationIds );
            var occurrenceDate = dpDate.SelectedDate.Value.Date;
            var scheduleId = rblSchedule.SelectedValue.AsInteger();

            var attendanceOccurrencesQuery = attendanceOccurrenceService.Queryable()
                .Where( a => a.GroupId.HasValue
                        && a.LocationId.HasValue
                        && groupLocationQuery.Any( gl => gl.GroupId == a.GroupId && gl.LocationId == gl.LocationId )
                        && a.ScheduleId == scheduleId
                        && a.OccurrenceDate == occurrenceDate );

            var missingAttendanceOccurrences = groupLocationQuery.Where( gl => !attendanceOccurrencesQuery.Any( ao => ao.LocationId == gl.LocationId && ao.GroupId == gl.GroupId ) )
                .ToList()
                .Select( gl => new AttendanceOccurrence
                {
                    GroupId = gl.GroupId,
                    Group = gl.Group,
                    LocationId = gl.LocationId,
                    Location = gl.Location,
                    ScheduleId = scheduleId,
                    OccurrenceDate = occurrenceDate
                } ).ToList();

            if ( missingAttendanceOccurrences.Any() )
            {
                attendanceOccurrenceService.AddRange( missingAttendanceOccurrences );
                rockContext.SaveChanges();
            }

            // join with the GroupLocation table so that we can sort the list by GroupLocation.Order and Location.Name
            var attendanceOccurrencesJoinQuery = from ao in attendanceOccurrencesQuery
                                                 join gl in groupLocationQuery
                                                 on new { LocationId = ao.LocationId.Value, GroupId = ao.GroupId.Value } equals new { gl.LocationId, gl.GroupId }
                                                 select new
                                                 {
                                                     AttendanceOccurrence = ao,
                                                     GroupLocationOrder = gl.Order,
                                                     GroupLocationLocationName = gl.Location.Name
                                                 };

            var attendanceOccurrencesOrderedList = attendanceOccurrencesJoinQuery.ToList()
                .OrderBy( a => a.GroupLocationOrder ).ThenBy( a => a.GroupLocationLocationName )
                .Select( a => a.AttendanceOccurrence ).ToList();

            rptAttendanceOccurrences.DataSource = attendanceOccurrencesOrderedList;
            rptAttendanceOccurrences.DataBind();
        }

        /// <summary>
        /// Handles the ItemDataBound event of the rptAttendanceOccurrences control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RepeaterItemEventArgs"/> instance containing the event data.</param>
        protected void rptAttendanceOccurrences_ItemDataBound( object sender, RepeaterItemEventArgs e )
        {
            var attendanceOccurrence = e.Item.DataItem as AttendanceOccurrence;
            var hfAttendanceOccurrenceId = e.Item.FindControl( "hfAttendanceOccurrenceId" ) as HiddenField;
            var lLocationTitle = e.Item.FindControl( "lLocationTitle" ) as Literal;
            hfAttendanceOccurrenceId.Value = attendanceOccurrence.Id.ToString();
            lLocationTitle.Text = attendanceOccurrence.Location.Name;
        }

        #endregion

        #region Events

        /// <summary>
        /// Handles the BlockUpdated event of the control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Block_BlockUpdated( object sender, EventArgs e )
        {
            //
        }

        /// <summary>
        /// Handles the ValueChanged event of the gpGroup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void gpGroup_ValueChanged( object sender, EventArgs e )
        {
            hfGroupId.Value = gpGroup.SelectedValue.AsIntegerOrNull().ToString();
            UpdateScheduleList();
            UpdateGroupLocationList();
            ApplyFilter();
        }

        /// <summary>
        /// Handles the ValueChanged event of the dpDate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void dpDate_ValueChanged( object sender, EventArgs e )
        {
            ApplyFilter();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cblSchedule control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void cblSchedule_SelectedIndexChanged( object sender, EventArgs e )
        {
            UpdateGroupLocationList();
            ApplyFilter();
        }

        protected void cblGroupLocations_SelectedIndexChanged( object sender, EventArgs e )
        {
            ApplyFilter();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the bgResourceListSource control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void bgResourceListSource_SelectedIndexChanged( object sender, EventArgs e )
        {
            ApplyFilter();
        }

        /// <summary>
        /// Handles the ValueChanged event of the gpResourceListAlternateGroup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected void gpResourceListAlternateGroup_ValueChanged( object sender, EventArgs e )
        {
            ApplyFilter();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the rblGroupMemberFilter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void rblGroupMemberFilter_SelectedIndexChanged( object sender, EventArgs e )
        {
            ApplyFilter();
        }

        /// <summary>
        /// Handles the ValueChanged event of the dvpResourceListDataView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void dvpResourceListDataView_ValueChanged( object sender, EventArgs e )
        {
            ApplyFilter();
        }

        #endregion

        protected void btnAddResource_Click( object sender, EventArgs e )
        {

        }

        protected void btnRecompileLess_Click( object sender, EventArgs e )
        {
            // #################DEBUG#################
            // TODO remove this
            var rockTheme = RockTheme.GetThemes().Where( a => a.Name == "Rock" ).FirstOrDefault();
            rockTheme.Compile();
            NavigateToCurrentPageReference();
        }
    }
}