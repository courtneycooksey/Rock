//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the T4\Model.tt template.
//
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Runtime.Serialization;

using Rock.Data;

namespace Rock.Groups
{
    /// <summary>
    /// Member POCO Entity.
    /// </summary>
    [Table( "groupsMember" )]
    public partial class Member : ModelWithAttributes<Member>, IAuditable
    {
		/// <summary>
		/// Gets or sets the System.
		/// </summary>
		/// <value>
		/// System.
		/// </value>
		[DataMember]
		public bool System { get; set; }
		
		/// <summary>
		/// Gets or sets the Group Id.
		/// </summary>
		/// <value>
		/// Group Id.
		/// </value>
		[DataMember]
		public int GroupId { get; set; }
		
		/// <summary>
		/// Gets or sets the Person Id.
		/// </summary>
		/// <value>
		/// Person Id.
		/// </value>
		[DataMember]
		public int PersonId { get; set; }
		
		/// <summary>
		/// Gets or sets the Group Role Id.
		/// </summary>
		/// <value>
		/// Group Role Id.
		/// </value>
		[DataMember]
		public int GroupRoleId { get; set; }
		
		/// <summary>
		/// Gets or sets the Created Date Time.
		/// </summary>
		/// <value>
		/// Created Date Time.
		/// </value>
		[DataMember]
		public DateTime? CreatedDateTime { get; set; }
		
		/// <summary>
		/// Gets or sets the Modified Date Time.
		/// </summary>
		/// <value>
		/// Modified Date Time.
		/// </value>
		[DataMember]
		public DateTime? ModifiedDateTime { get; set; }
		
		/// <summary>
		/// Gets or sets the Created By Person Id.
		/// </summary>
		/// <value>
		/// Created By Person Id.
		/// </value>
		[DataMember]
		public int? CreatedByPersonId { get; set; }
		
		/// <summary>
		/// Gets or sets the Modified By Person Id.
		/// </summary>
		/// <value>
		/// Modified By Person Id.
		/// </value>
		[DataMember]
		public int? ModifiedByPersonId { get; set; }
		
		/// <summary>
        /// Gets a Data Transfer Object (lightweight) version of this object.
        /// </summary>
        /// <value>
        /// A <see cref="Rock.Groups.DTO.Member"/> object.
        /// </value>
		public Rock.Groups.DTO.Member DataTransferObject
		{
			get 
			{ 
				Rock.Groups.DTO.Member dto = new Rock.Groups.DTO.Member();
				dto.Id = this.Id;
				dto.Guid = this.Guid;
				dto.System = this.System;
				dto.GroupId = this.GroupId;
				dto.PersonId = this.PersonId;
				dto.GroupRoleId = this.GroupRoleId;
				dto.CreatedDateTime = this.CreatedDateTime;
				dto.ModifiedDateTime = this.ModifiedDateTime;
				dto.CreatedByPersonId = this.CreatedByPersonId;
				dto.ModifiedByPersonId = this.ModifiedByPersonId;
				return dto; 
			}
		}

        /// <summary>
        /// Gets the auth entity.
        /// </summary>
		[NotMapped]
		public override string AuthEntity { get { return "Groups.Member"; } }
        
		/// <summary>
        /// Gets or sets the Person.
        /// </summary>
        /// <value>
        /// A <see cref="CRM.Person"/> object.
        /// </value>
		public virtual CRM.Person Person { get; set; }
        
		/// <summary>
        /// Gets or sets the Created By Person.
        /// </summary>
        /// <value>
        /// A <see cref="CRM.Person"/> object.
        /// </value>
		public virtual CRM.Person CreatedByPerson { get; set; }
        
		/// <summary>
        /// Gets or sets the Modified By Person.
        /// </summary>
        /// <value>
        /// A <see cref="CRM.Person"/> object.
        /// </value>
		public virtual CRM.Person ModifiedByPerson { get; set; }
        
		/// <summary>
        /// Gets or sets the Group.
        /// </summary>
        /// <value>
        /// A <see cref="Group"/> object.
        /// </value>
		public virtual Group Group { get; set; }
        
		/// <summary>
        /// Gets or sets the Group Role.
        /// </summary>
        /// <value>
        /// A <see cref="GroupRole"/> object.
        /// </value>
		public virtual GroupRole GroupRole { get; set; }

    }
    /// <summary>
    /// Member Configuration class.
    /// </summary>
    public partial class MemberConfiguration : EntityTypeConfiguration<Member>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberConfiguration"/> class.
        /// </summary>
        public MemberConfiguration()
        {
			this.HasRequired( p => p.Person ).WithMany( p => p.Members ).HasForeignKey( p => p.PersonId );
			this.HasOptional( p => p.CreatedByPerson ).WithMany().HasForeignKey( p => p.CreatedByPersonId );
			this.HasOptional( p => p.ModifiedByPerson ).WithMany().HasForeignKey( p => p.ModifiedByPersonId );
			this.HasRequired( p => p.Group ).WithMany( p => p.Members ).HasForeignKey( p => p.GroupId );
			this.HasRequired( p => p.GroupRole ).WithMany( p => p.Members ).HasForeignKey( p => p.GroupRoleId );
		}
    }
}
