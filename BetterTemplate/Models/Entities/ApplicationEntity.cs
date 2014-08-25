using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetterTemplate.Models.Entities
{
	/// <summary>
	/// A basic Application Entity, an item that will be stored in the database
	/// </summary>

	public abstract class ApplicationEntity : ApplicationObject
	{
		/// <summary>
		/// Detects whether the Application Entity is Deleted
		/// </summary>
		public virtual Boolean Deleted { get; set; }

		/// <summary>
		/// The Metadata for the Entity
		/// </summary>
		public virtual MetaData MetaData { get; set; }

		/// <summary>
		/// Basic constructor for the Entity
		/// </summary>
		public ApplicationEntity()
			: base()
		{
			this.MetaData = new MetaData();
		}
	}
}