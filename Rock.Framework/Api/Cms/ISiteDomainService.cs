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
	/// Represents a REST WCF service for SiteDomains
	/// </summary>
	[ServiceContract]
    public partial interface ISiteDomainService
    {
		/// <summary>
		/// Gets a SiteDomain object
		/// </summary>
		[OperationContract]
        Rock.Models.Cms.SiteDomain Get( string id );

		/// <summary>
		/// Updates a SiteDomain object
		/// </summary>
        [OperationContract]
        void UpdateSiteDomain( string id, Rock.Models.Cms.SiteDomain SiteDomain );

		/// <summary>
		/// Creates a new SiteDomain object
		/// </summary>
        [OperationContract]
        void CreateSiteDomain( Rock.Models.Cms.SiteDomain SiteDomain );

		/// <summary>
		/// Deletes a SiteDomain object
		/// </summary>
        [OperationContract]
        void DeleteSiteDomain( string id );
    }
}
