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
using System.Linq;
using System.Text;

using Rock.Models.Core;
using Rock.Repository.Core;

namespace Rock.Services.Core
{
	/// <summary>
	/// Field Type POCO Service Layer class
	/// </summary>
    public partial class FieldTypeService : Rock.Services.Service<Rock.Models.Core.FieldType>
    {
		/// <summary>
		/// Gets Field Types by Guid
		/// </summary>
		/// <param name="guid">Guid.</param>
		/// <returns>An enumerable list of FieldType objects.<returns>
	    public IEnumerable<Rock.Models.Core.FieldType> GetByGuid( Guid guid )
        {
            return Repository.Find( t => t.Guid == guid );
        }
		
		/// <summary>
		/// Gets Field Types by Name
		/// </summary>
		/// <param name="name">Name.</param>
		/// <returns>An enumerable list of FieldType objects.<returns>
	    public IEnumerable<Rock.Models.Core.FieldType> GetByName( string name )
        {
            return Repository.Find( t => t.Name == name );
        }
		
    }
}
