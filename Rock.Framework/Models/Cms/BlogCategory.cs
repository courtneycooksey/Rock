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
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

using Rock.Models;

namespace Rock.Models.Cms
{
    /// <summary>
    /// Blog Category POCO Entity.
    /// </summary>
    [Table( "cmsBlogCategory" )]
    public partial class BlogCategory : ModelWithAttributes<BlogCategory>, IAuditable
    {
        /// <summary>
        /// Gets or sets the Blog Id.
        /// </summary>
        /// <value>
        /// Blog Id.
        /// </value>
		[DataMember]
		public int BlogId { get; set; }
		
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>
        /// Name.
        /// </value>
		[MaxLength( 50 )]
		[DataMember]
		public string Name { get; set; }
		
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
        /// Gets the auth entity.
        /// </summary>
		[NotMapped]
		public override string AuthEntity { get { return "Cms.BlogCategory"; } }
        
		/// <summary>
        /// Gets or sets the Blog Posts.
        /// </summary>
        /// <value>
        /// Collection of Blog Posts.
        /// </value>
		public virtual ICollection<BlogPost> BlogPosts { get; set; }
        
		/// <summary>
        /// Gets or sets the Blog.
        /// </summary>
        /// <value>
        /// A <see cref="Blog"> object.
        /// </value>
		public virtual Blog Blog { get; set; }
        
		/// <summary>
        /// Gets or sets the Created By Person.
        /// </summary>
        /// <value>
        /// A <see cref="Crm.Person"> object.
        /// </value>
		public virtual Crm.Person CreatedByPerson { get; set; }
        
		/// <summary>
        /// Gets or sets the Modified By Person.
        /// </summary>
        /// <value>
        /// A <see cref="Crm.Person"> object.
        /// </value>
		public virtual Crm.Person ModifiedByPerson { get; set; }

    }

    /// <summary>
    /// Blog Category Configuration class.
    /// </summary>
    public partial class BlogCategoryConfiguration : EntityTypeConfiguration<BlogCategory>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogCategoryConfiguration"/> class.
        /// </summary>
        public BlogCategoryConfiguration()
        {
			this.HasMany( p => p.BlogPosts ).WithMany( c => c.BlogCategories ).Map( m => { m.MapLeftKey("BlogPostId"); m.MapRightKey("BlogCategoryId"); m.ToTable("cmsBlogPostCategory" ); } );
			this.HasRequired( p => p.Blog ).WithMany( p => p.BlogCategories ).HasForeignKey( p => p.BlogId );
			this.HasOptional( p => p.CreatedByPerson ).WithMany().HasForeignKey( p => p.CreatedByPersonId );
			this.HasOptional( p => p.ModifiedByPerson ).WithMany().HasForeignKey( p => p.ModifiedByPersonId );
		}
    }
}
