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
	/// Represents a REST WCF service for DefinedTypes
	/// </summary>
	[ServiceContract]
    public partial interface IDefinedTypeService
    {
		/// <summary>
		/// Gets a DefinedType object
		/// </summary>
		[OperationContract]
        Rock.Models.Core.DefinedType Get( string id );

		/// <summary>
		/// Updates a DefinedType object
		/// </summary>
        [OperationContract]
        void UpdateDefinedType( string id, Rock.Models.Core.DefinedType DefinedType );

		/// <summary>
		/// Creates a new DefinedType object
		/// </summary>
        [OperationContract]
        void CreateDefinedType( Rock.Models.Core.DefinedType DefinedType );

		/// <summary>
		/// Deletes a DefinedType object
		/// </summary>
        [OperationContract]
        void DeleteDefinedType( string id );
    }
}
