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
	/// REST WCF service for HtmlContents
	/// </summary>
    [Export(typeof(IService))]
    [ExportMetadata("RouteName", "CMS/HtmlContent")]
	[AspNetCompatibilityRequirements( RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed )]
    public partial class HtmlContentService : IHtmlContentService, IService
    {
		/// <summary>
		/// Gets a HtmlContent object
		/// </summary>
		[WebGet( UriTemplate = "{id}" )]
        public Rock.CMS.DTO.HtmlContent Get( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using (Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope())
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.HtmlContentService HtmlContentService = new Rock.CMS.HtmlContentService();
				Rock.CMS.HtmlContent HtmlContent = HtmlContentService.Get( int.Parse( id ) );
				if ( HtmlContent.Authorized( "View", currentUser ) )
					return HtmlContent.DataTransferObject;
				else
					throw new WebFaultException<string>( "Not Authorized to View this HtmlContent", System.Net.HttpStatusCode.Forbidden );
            }
        }
		
		/// <summary>
		/// Gets a HtmlContent object
		/// </summary>
		[WebGet( UriTemplate = "{id}/{apiKey}" )]
        public Rock.CMS.DTO.HtmlContent ApiGet( string id, string apiKey )
        {
            using (Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope())
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.HtmlContentService HtmlContentService = new Rock.CMS.HtmlContentService();
					Rock.CMS.HtmlContent HtmlContent = HtmlContentService.Get( int.Parse( id ) );
					if ( HtmlContent.Authorized( "View", user.Username ) )
						return HtmlContent.DataTransferObject;
					else
						throw new WebFaultException<string>( "Not Authorized to View this HtmlContent", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }
		
		/// <summary>
		/// Updates a HtmlContent object
		/// </summary>
		[WebInvoke( Method = "PUT", UriTemplate = "{id}" )]
        public void UpdateHtmlContent( string id, Rock.CMS.DTO.HtmlContent HtmlContent )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.HtmlContentService HtmlContentService = new Rock.CMS.HtmlContentService();
				Rock.CMS.HtmlContent existingHtmlContent = HtmlContentService.Get( int.Parse( id ) );
				if ( existingHtmlContent.Authorized( "Edit", currentUser ) )
				{
					uow.objectContext.Entry(existingHtmlContent).CurrentValues.SetValues(HtmlContent);
					HtmlContentService.Save( existingHtmlContent, currentUser.PersonId() );
				}
				else
					throw new WebFaultException<string>( "Not Authorized to Edit this HtmlContent", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Updates a HtmlContent object
		/// </summary>
		[WebInvoke( Method = "PUT", UriTemplate = "{id}/{apiKey}" )]
        public void ApiUpdateHtmlContent( string id, string apiKey, Rock.CMS.DTO.HtmlContent HtmlContent )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.HtmlContentService HtmlContentService = new Rock.CMS.HtmlContentService();
					Rock.CMS.HtmlContent existingHtmlContent = HtmlContentService.Get( int.Parse( id ) );
					if ( existingHtmlContent.Authorized( "Edit", user.Username ) )
					{
						uow.objectContext.Entry(existingHtmlContent).CurrentValues.SetValues(HtmlContent);
						HtmlContentService.Save( existingHtmlContent, user.PersonId );
					}
					else
						throw new WebFaultException<string>( "Not Authorized to Edit this HtmlContent", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Creates a new HtmlContent object
		/// </summary>
		[WebInvoke( Method = "POST", UriTemplate = "" )]
        public void CreateHtmlContent( Rock.CMS.DTO.HtmlContent HtmlContent )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.HtmlContentService HtmlContentService = new Rock.CMS.HtmlContentService();
				Rock.CMS.HtmlContent existingHtmlContent = new Rock.CMS.HtmlContent();
				HtmlContentService.Add( existingHtmlContent, currentUser.PersonId() );
				uow.objectContext.Entry(existingHtmlContent).CurrentValues.SetValues(HtmlContent);
				HtmlContentService.Save( existingHtmlContent, currentUser.PersonId() );
            }
        }

		/// <summary>
		/// Creates a new HtmlContent object
		/// </summary>
		[WebInvoke( Method = "POST", UriTemplate = "{apiKey}" )]
        public void ApiCreateHtmlContent( string apiKey, Rock.CMS.DTO.HtmlContent HtmlContent )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.HtmlContentService HtmlContentService = new Rock.CMS.HtmlContentService();
					Rock.CMS.HtmlContent existingHtmlContent = new Rock.CMS.HtmlContent();
					HtmlContentService.Add( existingHtmlContent, user.PersonId );
					uow.objectContext.Entry(existingHtmlContent).CurrentValues.SetValues(HtmlContent);
					HtmlContentService.Save( existingHtmlContent, user.PersonId );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Deletes a HtmlContent object
		/// </summary>
		[WebInvoke( Method = "DELETE", UriTemplate = "{id}" )]
        public void DeleteHtmlContent( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new WebFaultException<string>("Must be logged in", System.Net.HttpStatusCode.Forbidden );

            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.CMS.HtmlContentService HtmlContentService = new Rock.CMS.HtmlContentService();
				Rock.CMS.HtmlContent HtmlContent = HtmlContentService.Get( int.Parse( id ) );
				if ( HtmlContent.Authorized( "Edit", currentUser ) )
				{
					HtmlContentService.Delete( HtmlContent, currentUser.PersonId() );
					HtmlContentService.Save( HtmlContent, currentUser.PersonId() );
				}
				else
					throw new WebFaultException<string>( "Not Authorized to Edit this HtmlContent", System.Net.HttpStatusCode.Forbidden );
            }
        }

		/// <summary>
		/// Deletes a HtmlContent object
		/// </summary>
		[WebInvoke( Method = "DELETE", UriTemplate = "{id}/{apiKey}" )]
        public void ApiDeleteHtmlContent( string id, string apiKey )
        {
            using ( Rock.Data.UnitOfWorkScope uow = new Rock.Data.UnitOfWorkScope() )
            {
				Rock.CMS.UserService userService = new Rock.CMS.UserService();
                Rock.CMS.User user = userService.Queryable().Where( u => u.ApiKey == apiKey ).FirstOrDefault();

				if (user != null)
				{
					uow.objectContext.Configuration.ProxyCreationEnabled = false;
					Rock.CMS.HtmlContentService HtmlContentService = new Rock.CMS.HtmlContentService();
					Rock.CMS.HtmlContent HtmlContent = HtmlContentService.Get( int.Parse( id ) );
					if ( HtmlContent.Authorized( "Edit", user.Username ) )
					{
						HtmlContentService.Delete( HtmlContent, user.PersonId );
						HtmlContentService.Save( HtmlContent, user.PersonId );
					}
					else
						throw new WebFaultException<string>( "Not Authorized to Edit this HtmlContent", System.Net.HttpStatusCode.Forbidden );
				}
				else
					throw new WebFaultException<string>( "Invalid API Key", System.Net.HttpStatusCode.Forbidden );
            }
        }

    }
}
