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
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Rock.REST.CMS
{
	/// <summary>
	/// REST WCF service for BlogCategories
	/// </summary>
    [Export(typeof(IService))]
    [ExportMetadata("RouteName", "CMS/BlogCategory")]
	[AspNetCompatibilityRequirements( RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed )]
    public partial class BlogCategoryService : IBlogCategoryService, IService
    {
		/// <summary>
		/// Gets a BlogCategory object
		/// </summary>
		[WebGet( UriTemplate = "{id}" )]
        public Rock.CMS.DTO.BlogCategory Get( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using (Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope())
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.BlogCategoryService BlogCategoryService = new Rock.CMS.BlogCategoryService();
				Rock.CMS.BlogCategory BlogCategory = BlogCategoryService.Get( int.Parse( id ) );
				if ( BlogCategory.Authorized( "View", currentUser ) )
					return BlogCategory.DataTransferObject;
				else
					throw new WebFaultException<string>( "Not Authorized to View this BlogCategory", System.Net.HttpStatusCode.Forbidden );
            }
        }
		
		/// <summary>
		/// Gets a BlogCategory object
		/// </summary>
		[WebGet( UriTemplate = "{id}/{apiKey}" )]
        public Rock.CMS.DTO.BlogCategory ApiGet( string id, string apiKey )
        {
            using (Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope())
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.BlogCategoryService BlogCategoryService = new Rock.CMS.BlogCategoryService();
					Rock.CMS.BlogCategory BlogCategory = BlogCategoryService.Get( int.Parse( id ) );
					if ( BlogCategory.Authorized( "View", user.Username ) )
						return BlogCategory.DataTransferObject;
					else
						throw new WebFaultException<string>( "Not Authorized to View this BlogCategory", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }
		
		/// <summary>
		/// Updates a BlogCategory object
		/// </summary>
		[WebInvoke( Method = "PUT", UriTemplate = "{id}" )]
        public void UpdateBlogCategory( string id, Rock.CMS.DTO.BlogCategory BlogCategory )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.BlogCategoryService BlogCategoryService = new Rock.CMS.BlogCategoryService();
				Rock.CMS.BlogCategory existingBlogCategory = BlogCategoryService.Get( int.Parse( id ) );
				if ( existingBlogCategory.Authorized( "Edit", currentUser ) )
				{
					uow.objectContext.Entry(existingBlogCategory).CurrentValues.SetValues(BlogCategory);
					BlogCategoryService.Save( existingBlogCategory, currentUser.PersonId() );
				}
				else
					throw new WebFaultException<string>( "Not Authorized to Edit this BlogCategory", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Updates a BlogCategory object
		/// </summary>
		[WebInvoke( Method = "PUT", UriTemplate = "{id}/{apiKey}" )]
        public void ApiUpdateBlogCategory( string id, string apiKey, Rock.CMS.DTO.BlogCategory BlogCategory )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.BlogCategoryService BlogCategoryService = new Rock.CMS.BlogCategoryService();
					Rock.CMS.BlogCategory existingBlogCategory = BlogCategoryService.Get( int.Parse( id ) );
					if ( existingBlogCategory.Authorized( "Edit", user.Username ) )
					{
						uow.objectContext.Entry(existingBlogCategory).CurrentValues.SetValues(BlogCategory);
						BlogCategoryService.Save( existingBlogCategory, user.PersonId );
					}
					else
						throw new WebFaultException<string>( "Not Authorized to Edit this BlogCategory", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Creates a new BlogCategory object
		/// </summary>
		[WebInvoke( Method = "POST", UriTemplate = "" )]
        public void CreateBlogCategory( Rock.CMS.DTO.BlogCategory BlogCategory )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.BlogCategoryService BlogCategoryService = new Rock.CMS.BlogCategoryService();
				Rock.CMS.BlogCategory existingBlogCategory = new Rock.CMS.BlogCategory();
				BlogCategoryService.Add( existingBlogCategory, currentUser.PersonId() );
				uow.objectContext.Entry(existingBlogCategory).CurrentValues.SetValues(BlogCategory);
				BlogCategoryService.Save( existingBlogCategory, currentUser.PersonId() );
            }
        }

		/// <summary>
		/// Creates a new BlogCategory object
		/// </summary>
		[WebInvoke( Method = "POST", UriTemplate = "{apiKey}" )]
        public void ApiCreateBlogCategory( string apiKey, Rock.CMS.DTO.BlogCategory BlogCategory )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.BlogCategoryService BlogCategoryService = new Rock.CMS.BlogCategoryService();
					Rock.CMS.BlogCategory existingBlogCategory = new Rock.CMS.BlogCategory();
					BlogCategoryService.Add( existingBlogCategory, user.PersonId );
					uow.objectContext.Entry(existingBlogCategory).CurrentValues.SetValues(BlogCategory);
					BlogCategoryService.Save( existingBlogCategory, user.PersonId );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Deletes a BlogCategory object
		/// </summary>
		[WebInvoke( Method = "DELETE", UriTemplate = "{id}" )]
        public void DeleteBlogCategory( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.BlogCategoryService BlogCategoryService = new Rock.CMS.BlogCategoryService();
				Rock.CMS.BlogCategory BlogCategory = BlogCategoryService.Get( int.Parse( id ) );
				if ( BlogCategory.Authorized( "Edit", currentUser ) )
				{
					BlogCategoryService.Delete( BlogCategory, currentUser.PersonId() );
					BlogCategoryService.Save( BlogCategory, currentUser.PersonId() );
				}
				else
					throw new WebFaultException<string>( "Not Authorized to Edit this BlogCategory", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Deletes a BlogCategory object
		/// </summary>
		[WebInvoke( Method = "DELETE", UriTemplate = "{id}/{apiKey}" )]
        public void ApiDeleteBlogCategory( string id, string apiKey )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.BlogCategoryService BlogCategoryService = new Rock.CMS.BlogCategoryService();
					Rock.CMS.BlogCategory BlogCategory = BlogCategoryService.Get( int.Parse( id ) );
					if ( BlogCategory.Authorized( "Edit", user.Username ) )
					{
						BlogCategoryService.Delete( BlogCategory, user.PersonId );
						BlogCategoryService.Save( BlogCategory, user.PersonId );
					}
					else
						throw new WebFaultException<string>( "Not Authorized to Edit this BlogCategory", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

    }
}
