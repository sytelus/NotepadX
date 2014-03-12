using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace CatNotes
{
	/// <summary>
	/// Summary description for ChildNotesList.
	/// </summary>
	public class ChildNotesList : System.Windows.Forms.ListView 
	{
		public ChildNotesList()
		{
		}

		protected override void OnPaint(PaintEventArgs pe)
		{
			// TODO: Add custom paint code here

			// Calling the base class OnPaint
			base.OnPaint(pe);
		}
	}
}
