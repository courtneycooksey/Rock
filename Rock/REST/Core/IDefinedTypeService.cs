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

namespace Rock.REST.Core
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
        Rock.Core.DTO.DefinedType Get( string id );

		/// <summary>
		/// Gets a DefinedType object
		/// </summary>
		[OperationContract]
        Rock.Core.DTO.DefinedType ApiGet( string id, string apiKey );

		/// <summary>
		/// Updates a DefinedType object
		/// </summary>
        [OperationContract]
        void UpdateDefinedType( string id, Rock.Core.DTO.DefinedType DefinedType );

		/// <summary>
		/// Updates a DefinedType object
		/// </summary>
        [OperationContract]
        void ApiUpdateDefinedType( string id, string apiKey, Rock.Core.DTO.DefinedType DefinedType );

		/// <summary>
		/// Creates a new DefinedType object
		/// </summary>
        [OperationContract]
        void CreateDefinedType( Rock.Core.DTO.DefinedType DefinedType );

		/// <summary>
		/// Creates a new DefinedType object
		/// </summary>
        [OperationContract]
        void ApiCreateDefinedType( string apiKey, Rock.Core.DTO.DefinedType DefinedType );

		/// <summary>
		/// Deletes a DefinedType object
		/// </summary>
        [OperationContract]
        void DeleteDefinedType( string id );

		/// <summary>
		/// Deletes a DefinedType object
		/// </summary>
        [OperationContract]
        void ApiDeleteDefinedType( string id, string apiKey );
    }
}
