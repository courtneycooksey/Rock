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

namespace Rock.Api.Core
{
	/// <summary>
	/// Represents a REST WCF service for Attributes
	/// </summary>
	[ServiceContract]
    public partial interface IAttributeService
    {
		/// <summary>
		/// Gets a Attribute object
		/// </summary>
		[OperationContract]
        Rock.Models.Core.Attribute Get( string id );

		/// <summary>
		/// Updates a Attribute object
		/// </summary>
        [OperationContract]
        void UpdateAttribute( string id, Rock.Models.Core.Attribute Attribute );

		/// <summary>
		/// Creates a new Attribute object
		/// </summary>
        [OperationContract]
        void CreateAttribute( Rock.Models.Core.Attribute Attribute );

		/// <summary>
		/// Deletes a Attribute object
		/// </summary>
        [OperationContract]
        void DeleteAttribute( string id );
    }
}
