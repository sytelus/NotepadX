using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Sytel.NotepadX
{
	/// <summary>
	/// Summary description for TreePropertyEditor.
	/// </summary>
	public class TreePropertyEditor : System.Windows.Forms.UserControl, INoteEditor
	{
		private System.Windows.Forms.Panel treePanel;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		private TreeEditor m_innerTreeEditor = null;
		private string m_currentFormat = NoteFormat.FORMAT_HTML;
		private string m_currentNoteCaption = "";
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label editorCaptionLabel;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
		private string m_currentNoteID = "";
		
		public TreePropertyEditor()
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
				DisposeTreeEditor();
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
			this.treePanel = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.editorCaptionLabel = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// treePanel
			// 
			this.treePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treePanel.Location = new System.Drawing.Point(0, 23);
			this.treePanel.Name = "treePanel";
			this.treePanel.Size = new System.Drawing.Size(440, 265);
			this.treePanel.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(440, 3);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.editorCaptionLabel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(440, 20);
			this.panel1.TabIndex = 3;
			// 
			// editorCaptionLabel
			// 
			this.editorCaptionLabel.BackColor = System.Drawing.SystemColors.ControlLight;
			this.editorCaptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.editorCaptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.editorCaptionLabel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.editorCaptionLabel.Location = new System.Drawing.Point(0, 0);
			this.editorCaptionLabel.Name = "editorCaptionLabel";
			this.editorCaptionLabel.Size = new System.Drawing.Size(440, 20);
			this.editorCaptionLabel.TabIndex = 1;
			this.editorCaptionLabel.Text = "label1";
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.label1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 288);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(440, 24);
			this.panel2.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.Info;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(438, 22);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tips:     Add - Insert Key                Delete = Delete Key                Rena" +
				"me - F2  Key              Use drag and drop to move around";
			// 
			// TreePropertyEditor
			// 
			this.Controls.Add(this.treePanel);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.groupBox1);
			this.Name = "TreePropertyEditor";
			this.Size = new System.Drawing.Size(440, 312);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		
		private void DisposeTreeEditor()
		{
			if (m_innerTreeEditor != null)
				m_innerTreeEditor.Dispose();
		}
		
		private void ReCreateTreeEditor()
		{
			DisposeTreeEditor();
			m_innerTreeEditor = new TreeEditor();
			this.treePanel.Controls.Add(m_innerTreeEditor);			
			m_innerTreeEditor.Dock = DockStyle.Fill;
			m_innerTreeEditor.Visible = true;
			m_innerTreeEditor.CatNoteDocumentToUse = new NotepadXDocument(); 
		}		
		
		public TreeEditor InnerTreeEditor
		{
			get
			{
				return m_innerTreeEditor;
			}
		}
		
		#region INoteEditor interface implementation
		string INoteEditor.EditorName
		{
			get
			{
				return this.GetType().Name;
			}
		}
		string INoteEditor.CurrentNoteID
		{
			get
			{
				return m_currentNoteID;
			}
			set
			{
				m_currentNoteID = value;
			}
		}
		string INoteEditor.CurrentNoteCaption
		{
			get
			{
				return m_currentNoteCaption;
			}
			set
			{
				m_currentNoteCaption = value;
				editorCaptionLabel.Text = "Hierarchy Editor - " + m_currentNoteCaption;
			}
		}
		bool INoteEditor.IsModified
		{
			get
			{
				return InnerTreeEditor.IsDirty;
			}
		}
		
		bool INoteEditor.IsReadOnly
		{
			get
			{
				return InnerTreeEditor.IsReadOnly;
			}
			set
			{
				InnerTreeEditor.IsReadOnly=false;
			}
		}
		
		bool INoteEditor.IsVisible
		{
			get
			{
				return Visible;
			}
			
			set
			{
				Visible = value;
			}
		}
		
		
		string INoteEditor.EditorUserFriendlyName
		{
			get
			{
				return this.Name;
			}
		}
		
		string INoteEditor.GetNoteContent()
		{
			return m_innerTreeEditor.Xml;
		}
		
		void INoteEditor.SetNoteContent(string noteID, string noteCaption, string noteContent)
		{
			((INoteEditor) this).CurrentNoteID = noteID;
			((INoteEditor) this).CurrentNoteCaption = noteCaption;
			
			((INoteEditor)this).ClearContent();

			if (noteContent != string.Empty)
				m_innerTreeEditor.Xml = noteContent;
			else {};	//contents is already cleared
		}
		void INoteEditor.ClearContent()
		{
			m_innerTreeEditor.Clear();
		}
		void INoteEditor.ResetAll()
		{
			ReCreateTreeEditor();			
			m_currentNoteCaption = "";
			m_currentNoteID = "";
		}
		#endregion

		public string CurrentFormat
		{
			get
			{
				return m_currentFormat;
			}
			set
			{
				if (value == NoteFormat.FORMAT_HIERARCHY)
				{
					m_currentFormat = value;
				}
				else
					throw new ArgumentException("Specified format '"+ value +"' is not recognized by '"+ this.Name + "'. Only '" +  NoteFormat.GetFriendlyNameForFormat(NoteFormat.FORMAT_HIERARCHY) + "' format is acceptable", "CurrentFormat");
			}
		}
		
	}
}
