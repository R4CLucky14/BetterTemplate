using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BetterTemplate.Models.Entities
{
	/// <summary>
	/// An abstract base class representing any Application Object
	/// </summary>
	public class ApplicationObject
	{
		/// <summary>
		/// The Unique Identifier for all objects 
		/// </summary>
		[Key]
		public virtual Guid Id { get; private set; }
		/// <summary>
		/// A Description of the Object.
		/// </summary>
		public virtual String Description { get; set; }
		/// <summary>
		/// Creates a new Application Object with a Unique Identifier.
		/// </summary>
		public ApplicationObject()
			: base()
		{
			this.Id = Guid.NewGuid();
		}
		/// <summary>
		/// Creates a new Application Object with a Unique Identifier and a Description
		/// </summary>
		/// <param name="Description">Description of the Object</param>
		public ApplicationObject( String Description )
			: this()
		{
			this.Description = Description;
		}
	}   
}