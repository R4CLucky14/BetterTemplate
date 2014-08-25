using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BetterTemplate.Models.Entities
{	
	/// <summary>
	/// The MetaData of an Application Entity
	/// </summary>
	public class MetaData : ApplicationObject
	{
		/// <summary>
		/// The Owner of the Object
		/// </summary>
		public virtual ApplicationUser Owner { get; private set; }

		/// <summary>
		/// Accessor for whether the Object is Deleted
		/// </summary>
		public virtual Boolean Deleted { get { return this.Object.Deleted; } }
		/// <summary>
		/// The Object -> What the MetaData is referring to
		/// </summary>
		[Required]
		public virtual ApplicationEntity Object { get; set; }
		/// <summary>
		/// The last User to Edit the Object
		/// </summary>
		public virtual ApplicationUser Editor
		{
			get
			{
				return this.Audits.OrderBy( c => c.TimeStamp ).Last().Editor;
			}
		}
		/// <summary>
		/// The last Modified TimeStamp
		/// </summary>
		public virtual DateTime Modified
		{
			get
			{
				return this.Audits.OrderBy( c => c.TimeStamp ).Last().TimeStamp;
			}
		}
		/// <summary>
		/// The Timestamp of the Object's creation date.
		/// </summary>
		public virtual DateTime Created
		{
			get
			{
				return this.Audits.OrderBy( c => c.TimeStamp ).FirstOrDefault( c => c.EventType == "Added" ).TimeStamp;
			}
		}


		/// <summary>
		/// Default Constructor for MetaData.
		/// </summary>
		public MetaData()
			: base()
		{
			this.Audits = new Collection<Audit>();
		}
		/// <summary>
		/// Constructor the Populates the Owner field
		/// </summary>
		/// <param name="Owner">The User who created the Object</param>
		public MetaData( ApplicationUser Owner )
			: this()
		{
			this.Owner = Owner;
		}
	}
}