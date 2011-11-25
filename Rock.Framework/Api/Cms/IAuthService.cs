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
using System.ServiceModel;

namespace Rock.Api.Cms
{
	/// <summary>
	/// Represents a REST WCF service for Auths
	/// </summary>
	[ServiceContract]
    public partial interface IAuthService
    {
		/// <summary>
		/// Gets a Auth object
		/// </summary>
		[OperationContract]
        Rock.Models.Cms.Auth Get( string id );

		/// <summary>
		/// Updates a Auth object
		/// </summary>
        [OperationContract]
        void UpdateAuth( string id, Rock.Models.Cms.Auth Auth );

		/// <summary>
		/// Creates a new Auth object
		/// </summary>
        [OperationContract]
        void CreateAuth( Rock.Models.Cms.Auth Auth );

		/// <summary>
		/// Deletes a Auth object
		/// </summary>
        [OperationContract]
        void DeleteAuth( string id );
    }
}
