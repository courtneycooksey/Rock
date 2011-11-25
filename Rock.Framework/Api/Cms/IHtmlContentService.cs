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
	/// Represents a REST WCF service for HtmlContents
	/// </summary>
	[ServiceContract]
    public partial interface IHtmlContentService
    {
		/// <summary>
		/// Gets a HtmlContent object
		/// </summary>
		[OperationContract]
        Rock.Models.Cms.HtmlContent Get( string id );

		/// <summary>
		/// Updates a HtmlContent object
		/// </summary>
        [OperationContract]
        void UpdateHtmlContent( string id, Rock.Models.Cms.HtmlContent HtmlContent );

		/// <summary>
		/// Creates a new HtmlContent object
		/// </summary>
        [OperationContract]
        void CreateHtmlContent( Rock.Models.Cms.HtmlContent HtmlContent );

		/// <summary>
		/// Deletes a HtmlContent object
		/// </summary>
        [OperationContract]
        void DeleteHtmlContent( string id );
    }
}
