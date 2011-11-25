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
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

using Rock.Cms.Security;

namespace Rock.Api.Cms
{
	/// <summary>
	/// REST WCF service for Users
	/// </summary>
    [Export(typeof(IService))]
    [ExportMetadata("RouteName", "api/Cms/User")]
	[AspNetCompatibilityRequirements( RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed )]
    public partial class UserService : IUserService, IService
    {
		/// <summary>
		/// Gets a User object
		/// </summary>
		[WebGet( UriTemplate = "{id}" )]
        public Rock.Models.Cms.User Get( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using (Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope())
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;
				Rock.Services.Cms.UserService UserService = new Rock.Services.Cms.UserService();
                Rock.Models.Cms.User User = UserService.Get( int.Parse( id ) );
                if ( User.Authorized( "View", currentUser ) )
                    return User;
                else
                    throw new FaultException( "Unauthorized" );
            }
        }
		
		/// <summary>
		/// Updates a User object
		/// </summary>
		[WebInvoke( Method = "PUT", UriTemplate = "{id}" )]
        public void UpdateUser( string id, Rock.Models.Cms.User User )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using ( Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope() )
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;

                Rock.Services.Cms.UserService UserService = new Rock.Services.Cms.UserService();
                Rock.Models.Cms.User existingUser = UserService.Get( int.Parse( id ) );
                if ( existingUser.Authorized( "Edit", currentUser ) )
                {
                    uow.objectContext.Entry(existingUser).CurrentValues.SetValues(User);
                    UserService.Save( existingUser, currentUser.PersonId() );
                }
                else
                    throw new FaultException( "Unauthorized" );
            }
        }

		/// <summary>
		/// Creates a new User object
		/// </summary>
		[WebInvoke( Method = "POST", UriTemplate = "" )]
        public void CreateUser( Rock.Models.Cms.User User )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using ( Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope() )
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;

                Rock.Services.Cms.UserService UserService = new Rock.Services.Cms.UserService();
                UserService.Add( User, currentUser.PersonId() );
                UserService.Save( User, currentUser.PersonId() );
            }
        }

		/// <summary>
		/// Deletes a User object
		/// </summary>
		[WebInvoke( Method = "DELETE", UriTemplate = "{id}" )]
        public void DeleteUser( string id )
        {
            var currentUser = System.Web.Security.Membership.GetUser();
            if ( currentUser == null )
                throw new FaultException( "Must be logged in" );

            using ( Rock.Helpers.UnitOfWorkScope uow = new Rock.Helpers.UnitOfWorkScope() )
            {
                uow.objectContext.Configuration.ProxyCreationEnabled = false;

                Rock.Services.Cms.UserService UserService = new Rock.Services.Cms.UserService();
                Rock.Models.Cms.User User = UserService.Get( int.Parse( id ) );
                if ( User.Authorized( "Edit", currentUser ) )
                {
                    UserService.Delete( User, currentUser.PersonId() );
                }
                else
                    throw new FaultException( "Unauthorized" );
            }
        }

    }
}
