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

using Rock.Models.Util;
using Rock.Repository.Util;

namespace Rock.Services.Util
{
	/// <summary>
	/// Job POCO Service Layer class
	/// </summary>
    public partial class JobService : Rock.Services.Service<Rock.Models.Util.Job>
    {
		/// <summary>
		/// Gets Jobs by Guid
		/// </summary>
		/// <param name="guid">Guid.</param>
		/// <returns>An enumerable list of Job objects.<returns>
	    public IEnumerable<Rock.Models.Util.Job> GetByGuid( Guid guid )
        {
            return Repository.Find( t => t.Guid == guid );
        }
		
    }
}
