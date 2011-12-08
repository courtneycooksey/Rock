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

using Rock.Data;

namespace Rock.Core
{
	/// <summary>
	/// Defined Value POCO Service Layer class
	/// </summary>
    public partial class DefinedValueService : Service<Rock.Core.DefinedValue>
    {
		/// <summary>
		/// Gets Defined Values by Defined Type Id
		/// </summary>
		/// <param name="definedTypeId">Defined Type Id.</param>
		/// <returns>An enumerable list of DefinedValue objects.</returns>
	    public IEnumerable<Rock.Core.DefinedValue> GetByDefinedTypeId( int definedTypeId )
        {
            return Repository.Find( t => t.DefinedTypeId == definedTypeId ).OrderBy( t => t.Order );
        }
		
    }
}
