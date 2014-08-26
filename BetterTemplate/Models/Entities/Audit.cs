
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BetterTemplate.Models.Entities
{

	/// <summary>
	/// In order to prevent a circular reference, Audit stems from ApplicationObject, not ApplicationEntity.
	/// However, obviously, it is stored in the database.
	/// </summary>
	public class Audit : ApplicationObject
	{
		/// <summary>
		/// User who is editing the object
		/// </summary>
		[Required]
		public virtual ApplicationUser Editor { get; private set; }
		/// <summary>
		/// The time of the Audit 
		/// </summary>
		[Required]
		public virtual DateTime TimeStamp { get; private set; }
		/// <summary>
		/// The Type of Event Occuring
		/// </summary>
		[Required]
		public virtual String EventType { get; private set; }
		/// <summary>
		/// The Property that changed
		/// </summary>
		public virtual String Property { get; private set; }
		/// <summary>
		/// The Original Value of the Property
		/// </summary>
		public virtual String OldValue { get; private set; }
		/// <summary>
		/// The New Value of the Property
		/// </summary>
		public virtual String NewValue { get; private set; }
		/// <summary>
		/// Navigation Property to access the MetaData of the object this Audit is about.
		/// </summary>
		public MetaData MetaData { get; private set; }

		/// <summary>
		/// Basic constructor for an Audit. Initializes the TimeStamp.
		/// </summary>
		public Audit()
			: base()
		{
			this.TimeStamp = DateTime.Now;
		}
		/// <summary>
		/// Creates a new Audit with the Entered Paramters
		/// </summary>
		/// <param name="MetaData">The MetaData of the Object being audited</param>
		/// <param name="Editor">The User performing the action being audited</param>
		/// <param name="EventType">The Type of action being audited</param>
		/// <param name="Property">The property affected by the action being audited</param>
		/// <param name="OldValue">The original value of the property before the action.</param>
		/// <param name="NewValue">The new value of the property after the action.</param>
		public Audit( MetaData MetaData, ApplicationUser Editor, String EventType, String Property, String OldValue, String NewValue )
			: this()
		{
			this.MetaData = MetaData;
			this.Editor = Editor;
			this.EventType = EventType;
			this.Property = Property;
			this.OldValue = OldValue;
			this.NewValue = NewValue;
		}
	}
}