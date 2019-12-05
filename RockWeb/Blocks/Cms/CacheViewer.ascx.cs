// <copyright>
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

using System;
using System.ComponentModel;
using System.Linq;
using System.Web.UI.WebControls;

using Rock;
using Rock.Web.Cache;
using Rock.Model;
using Rock.Web.UI;
using System.Reflection;
using Rock.Data;

namespace RockWeb.Blocks.Cms
{
    [DisplayName( "Cache Viewer" )]
    [Category( "CMS" )]
    [Description( "Block used to view a cached entity for debugging purposes." )]
    public partial class CacheManager : RockBlock
    {
        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit( EventArgs e )
        {
            base.OnInit( e );
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Load" /> event.
        /// </summary>
        /// <param name="e">The <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );

            if ( !IsPostBack )
            {
                PopulateCacheTypes();
            }
        }

        #region Cache Types

        /// <summary>
        /// Populates the drop down list with an ordered list of cache type names.
        /// The selected item is used for the button to clear all the cache of
        /// that type.
        /// </summary>
        protected void PopulateCacheTypes()
        {
            ddlCacheTypes.Items.Clear();
            var entityCacheTypes = RockCache.GetAllModelCacheTypes();

            foreach ( var entityCacheType in entityCacheTypes.OrderBy( s => s.Name ) )
            {
                ddlCacheTypes.Items.Add( new ListItem( entityCacheType.Name, entityCacheType.Name ) );
            }
        }

        #endregion Cache Types

        #region Events

        /// <summary>
        /// Handles the Click event of the btnRefresh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnRefresh_Click( object sender, EventArgs e )
        {
            var cacheTypeName = ddlCacheTypes.SelectedValue;
            var modelTypeName = cacheTypeName.Replace( "Cache", string.Empty );
            var cacheType = Type.GetType( string.Format( "Rock.Web.Cache.{0},Rock", cacheTypeName ) );
            var modelType = Type.GetType( string.Format( "Rock.Model.{0},Rock", modelTypeName ) );

            var entityId = rtbEntityId.Text.AsInteger();

            var cacheType = typeof(EntityCache<,>).MakeGenericType(  );
            genMyClass.InvokeMember( "DoX", BindingFlags.Public | BindingFlags.Static, null, null, null );

            /*
            // If the entity id is null or cannot be found, then load the first and show a message
            var cacheTypeName = selectedCacheType;
            var cacheType = Type.GetType( string.Format( "Rock.Web.Cache.{0},Rock", cacheTypeName ) );
            var modelCacheType = cache


            var method = cacheType.GetMethod( "All", BindingFlags.Public | BindingFlags.Static ) ??
                cacheType.BaseType.GetMethod( "All", BindingFlags.Public | BindingFlags.Static );
            var result = method.Invoke( null, null );
            */
            /*
            var cachedItem = result as ItemCache;

            if (cachedItem == null)
            {
                cachedItem = CampusCache.All().FirstOrDefault();
                nbNotification.Visible = true;
            }
            else
            {
                nbNotification.Visible = false;
            }

            preResult.InnerText = cachedItem.ToJson( Newtonsoft.Json.Formatting.Indented );*/
        }

        #endregion Events
    }
}