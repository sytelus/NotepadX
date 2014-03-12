using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using Flobbster.Windows.Forms;

namespace Sytel.NotepadX
{
	/// <summary>
	/// Summary description for NotePropertyEditor.
	/// </summary>
	
	public class NotePropertiesChangedEventArgs : EventArgs
	{
		public readonly CatNoteDetail ChangedNote = null;
		public NotePropertiesChangedEventArgs(CatNoteDetail changedNoteForEvent)
		{
			ChangedNote = changedNoteForEvent;
		}
	}
	
	public delegate void NotePropertiesChangedHandler(object sender, NotePropertiesChangedEventArgs e);
	
	public class NotePropertyEditor : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.PropertyGrid innerPropertyGrid;

		private CatNoteDetail m_noteToDisplay = null;
		
		public event NotePropertiesChangedHandler NotePropertiesChanged;

		protected virtual void OnNotePropertiesChanged(NotePropertiesChangedEventArgs e)
		{
		}
		
		protected void RaiseEventNotePropertiesChanged(NotePropertiesChangedEventArgs e)
		{
			OnNotePropertiesChanged(e);
			if (NotePropertiesChanged != null) 
				NotePropertiesChanged(this, e);		
		}
		
		public NotePropertyEditor()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.innerPropertyGrid = new System.Windows.Forms.PropertyGrid();
			this.SuspendLayout();
			// 
			// innerPropertyGrid
			// 
			this.innerPropertyGrid.CommandsVisibleIfAvailable = true;
			this.innerPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.innerPropertyGrid.LargeButtons = false;
			this.innerPropertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.innerPropertyGrid.Name = "innerPropertyGrid";
			this.innerPropertyGrid.Size = new System.Drawing.Size(180, 188);
			this.innerPropertyGrid.TabIndex = 0;
			this.innerPropertyGrid.Text = "propertyGrid1";
			this.innerPropertyGrid.ViewBackColor = System.Drawing.SystemColors.Window;
			this.innerPropertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
			// 
			// NotePropertyEditor
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.innerPropertyGrid});
			this.Name = "NotePropertyEditor";
			this.Size = new System.Drawing.Size(180, 188);
			this.ResumeLayout(false);

		}
		#endregion
		
		public CatNoteDetail NoteToDisplay
		{
			get
			{
				return m_noteToDisplay;
			}
			set
			{
				m_noteToDisplay = value;
				ConnectNoteToPropertyGrid(m_noteToDisplay);
			}
		}
		
		private void ConnectNoteToPropertyGrid(CatNoteDetail noteToConnect)
		{
			if (noteToConnect != null)
			{
				PropertyBag bag = new PropertyBag();
				bag.GetValue += new PropertySpecEventHandler(this.bag_GetValue);
				bag.SetValue += new PropertySpecEventHandler(this.bag_SetValue);
				
				bag.Properties.Add(new PropertySpec("Back Color", typeof(System.Drawing.Color), "Formatting", "Background color in the hierarchy", noteToConnect.NodeBackColor));
				bag.Properties.Add(new PropertySpec("Font", typeof(System.Drawing.Font), "Formatting", "Font for this note in hierarchy", noteToConnect.NodeFont));
				bag.Properties.Add(new PropertySpec("Fore Color", typeof(System.Drawing.Color), "Formatting", "Forground color in the hierarchy", noteToConnect.NodeForeColor));

				string content;
				try
				{
					content = noteToConnect.Content;
				}
				catch(Exception ex)
				{
					content = "Error occured: " + ex.ToString();
				}
				bag.Properties.Add(new PropertySpec("Content", typeof(string), "Content", "Content of this note", content));
				bag.Properties.Add(new PropertySpec("Title" , typeof(string), "Content", "Title of this note", noteToConnect.Title));
				bag.Properties.Add(new PropertySpec("Content Format", typeof(NoteFormat.NoteFormatEnum), "Internal", "Type of note",NoteFormat.StringToNoteFormatEnum(noteToConnect.Format)));
				bag.Properties.Add(new PropertySpec("Secured", typeof(bool), "Restrictions", "Does this note requires password to view it?", noteToConnect.IsEncrypted));
				bag.Properties.Add(new PropertySpec("Read Only", typeof(bool), "Restrictions", "Is this note marked for no more changes?", noteToConnect.IsReadOnly));
				bag.Properties.Add(new PropertySpec("Id", typeof(string), "Internal", "Unique identification string for this note", noteToConnect.Id));
				bag.Properties.Add(new PropertySpec("Xml" , typeof(string), "Internal", "Internal XML storage of this note", noteToConnect.Xml));
				
				innerPropertyGrid.SelectedObject = bag;
			}
			else
			{
				if (innerPropertyGrid.SelectedObject != null)
				{
					PropertyBag bag = (PropertyBag) innerPropertyGrid.SelectedObject;
					bag.Properties.Clear();
					innerPropertyGrid.SelectedObject = null;
				}
			}
		}
		
		private void bag_GetValue(object sender, PropertySpecEventArgs e)
		{
			switch (e.Property.Name)
			{
				case "Content":
					e.Value = m_noteToDisplay.Content;
					break;
				case "Content Format":
					e.Value = NoteFormat.StringToNoteFormatEnum(m_noteToDisplay.Format);
					break;
				case "Id":
					e.Value =  m_noteToDisplay.Id;
					break;
				case "Secured":
					e.Value =  m_noteToDisplay.IsEncrypted;
					break;
				case "Read Only":
					e.Value =  m_noteToDisplay.IsReadOnly;
					break;
				case "Back Color":
					e.Value =  m_noteToDisplay.NodeBackColor;
					break;
				case "Font":
					e.Value =  m_noteToDisplay.NodeFont;
					break;
				case "Fore Color":
					e.Value =  m_noteToDisplay.NodeForeColor;				
					break;
				case "Title":
					e.Value =  m_noteToDisplay.Title;				
					break;
				case "Xml":
					e.Value =  m_noteToDisplay.Xml;				
					break;
				default:
					//TODO : Put code here for custom properties
					break;
			}
		}
		private void bag_SetValue(object sender, PropertySpecEventArgs e)
		{
			switch (e.Property.Name)
			{
				case "Content":
					e.Value = m_noteToDisplay.Content;
					break;
				case "Content Format":
					m_noteToDisplay.Format = NoteFormat.NoteFormatEnumToString((NoteFormat.NoteFormatEnum) e.Value);
					break;
				case "Id":
					//m_noteToDisplay.Id = (string) e.Value;
					break;
				case "Secured":
					//m_noteToDisplay.IsEncrypted = (bool) e.Value;
					break;
				case "Read Only":
					m_noteToDisplay.IsReadOnly = (bool) e.Value;
					break;
				case "Back Color":
					m_noteToDisplay.NodeBackColor = (System.Drawing.Color) e.Value;
					break;
				case "Font":
					m_noteToDisplay.NodeFont = (System.Drawing.Font) e.Value;
					break;
				case "Fore Color":
					m_noteToDisplay.NodeForeColor = (System.Drawing.Color) e.Value;				
					break;
				case "Title":
					m_noteToDisplay.Title = (string) e.Value;				
					break;
				case "Xml":
					//m_noteToDisplay.Xml = (string) e.Value;				
					break;
				default:
					//TODO : Put code here for custom properties
					break;
			}
			RaiseEventNotePropertiesChanged(new NotePropertiesChangedEventArgs(m_noteToDisplay));
		}
	}
}
