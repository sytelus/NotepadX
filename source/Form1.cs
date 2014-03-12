using System;
using System.Configuration;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.IO;

using CatNotes;

namespace CatNotes
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.ToolBarButton tbtnAddCategory;
		private System.Windows.Forms.ToolBarButton tbtnRemoveCategory;
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem Copy;
		private System.Windows.Forms.MenuItem Paste;
		private System.Windows.Forms.ToolBarButton tbtnSeperator2;
		private System.Windows.Forms.ToolBarButton tbtnSeperator1;
		private System.Windows.Forms.ToolBarButton tbtnNewDocument;
		private System.Windows.Forms.ToolBarButton tbtnSaveDocument;
		private System.Windows.Forms.ToolBarButton tbtnHelp;
		private System.Windows.Forms.ToolBarButton tbtnOpenDocument;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ToolBarButton tbtnRefreshDocument;
		private System.Windows.Forms.ToolBarButton tbtnNodeProperties;

		
		//Private vars
		private CatNotesDocument m_catNotesDocument;
		private System.Windows.Forms.ToolBarButton tbtnReadOnlyNote;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton tbtnSecuredNote;
		private System.Windows.Forms.TreeView notesNavigatorTreeView;
		private System.Windows.Forms.ToolBarButton tbtnSetReminder;
		private CatApplicationSettings m_catApplicationSettings;
		private System.Windows.Forms.MenuItem exitSysTrayMenu;
		private System.Windows.Forms.NotifyIcon sysTrayNotifyIcon;
		private System.Windows.Forms.ContextMenu sysTrayContextMenu;
		
		static private  Color originalRichTextBoxColor =Color.FromKnownColor(KnownColor.Window);		
		
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.tbtnNewDocument = new System.Windows.Forms.ToolBarButton();
			this.tbtnOpenDocument = new System.Windows.Forms.ToolBarButton();
			this.tbtnSaveDocument = new System.Windows.Forms.ToolBarButton();
			this.tbtnRefreshDocument = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.tbtnNodeProperties = new System.Windows.Forms.ToolBarButton();
			this.tbtnReadOnlyNote = new System.Windows.Forms.ToolBarButton();
			this.tbtnSecuredNote = new System.Windows.Forms.ToolBarButton();
			this.tbtnSetReminder = new System.Windows.Forms.ToolBarButton();
			this.tbtnSeperator1 = new System.Windows.Forms.ToolBarButton();
			this.tbtnAddCategory = new System.Windows.Forms.ToolBarButton();
			this.tbtnRemoveCategory = new System.Windows.Forms.ToolBarButton();
			this.tbtnSeperator2 = new System.Windows.Forms.ToolBarButton();
			this.tbtnHelp = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.notesNavigatorTreeView = new System.Windows.Forms.TreeView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.Copy = new System.Windows.Forms.MenuItem();
			this.Paste = new System.Windows.Forms.MenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.sysTrayNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.sysTrayContextMenu = new System.Windows.Forms.ContextMenu();
			this.exitSysTrayMenu = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.tbtnNewDocument,
																						this.tbtnOpenDocument,
																						this.tbtnSaveDocument,
																						this.tbtnRefreshDocument,
																						this.toolBarButton1,
																						this.tbtnNodeProperties,
																						this.tbtnReadOnlyNote,
																						this.tbtnSecuredNote,
																						this.tbtnSetReminder,
																						this.tbtnSeperator1,
																						this.tbtnAddCategory,
																						this.tbtnRemoveCategory,
																						this.tbtnSeperator2,
																						this.tbtnHelp});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(624, 25);
			this.toolBar1.TabIndex = 0;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// tbtnNewDocument
			// 
			this.tbtnNewDocument.ImageIndex = 7;
			this.tbtnNewDocument.ToolTipText = "Create new document";
			// 
			// tbtnOpenDocument
			// 
			this.tbtnOpenDocument.ImageIndex = 8;
			this.tbtnOpenDocument.ToolTipText = "Open document from file";
			// 
			// tbtnSaveDocument
			// 
			this.tbtnSaveDocument.ImageIndex = 6;
			this.tbtnSaveDocument.ToolTipText = "Save this document to file";
			// 
			// tbtnRefreshDocument
			// 
			this.tbtnRefreshDocument.ImageIndex = 15;
			this.tbtnRefreshDocument.ToolTipText = "Reload document from file (current content will be lost)";
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbtnNodeProperties
			// 
			this.tbtnNodeProperties.ImageIndex = 16;
			this.tbtnNodeProperties.ToolTipText = "View note\'s properties";
			// 
			// tbtnReadOnlyNote
			// 
			this.tbtnReadOnlyNote.ImageIndex = 20;
			this.tbtnReadOnlyNote.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.tbtnReadOnlyNote.ToolTipText = "Make this note read-only or writable";
			// 
			// tbtnSecuredNote
			// 
			this.tbtnSecuredNote.ImageIndex = 21;
			this.tbtnSecuredNote.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.tbtnSecuredNote.ToolTipText = "Make this note secured or normal";
			// 
			// tbtnSetReminder
			// 
			this.tbtnSetReminder.ImageIndex = 14;
			this.tbtnSetReminder.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.tbtnSetReminder.ToolTipText = "Set Reminder For This Note";
			// 
			// tbtnSeperator1
			// 
			this.tbtnSeperator1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbtnAddCategory
			// 
			this.tbtnAddCategory.ImageIndex = 17;
			this.tbtnAddCategory.ToolTipText = "Add new child node";
			// 
			// tbtnRemoveCategory
			// 
			this.tbtnRemoveCategory.ImageIndex = 18;
			this.tbtnRemoveCategory.ToolTipText = "Remove selected note";
			// 
			// tbtnSeperator2
			// 
			this.tbtnSeperator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbtnHelp
			// 
			this.tbtnHelp.ImageIndex = 19;
			this.tbtnHelp.ToolTipText = "Help";
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// statusBar1
			// 
			this.statusBar1.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.statusBar1.Location = new System.Drawing.Point(0, 343);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(624, 22);
			this.statusBar1.TabIndex = 1;
			this.statusBar1.Text = "CatNotes Alpha 1 By Shital Shah - Created During Dec 2k2-Jan 2k3 (Use by public a" +
				"t own risk)";
			// 
			// notesNavigatorTreeView
			// 
			this.notesNavigatorTreeView.AllowDrop = true;
			this.notesNavigatorTreeView.Dock = System.Windows.Forms.DockStyle.Left;
			this.notesNavigatorTreeView.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.notesNavigatorTreeView.ImageIndex = -1;
			this.notesNavigatorTreeView.LabelEdit = true;
			this.notesNavigatorTreeView.Location = new System.Drawing.Point(0, 25);
			this.notesNavigatorTreeView.Name = "notesNavigatorTreeView";
			this.notesNavigatorTreeView.SelectedImageIndex = -1;
			this.notesNavigatorTreeView.Size = new System.Drawing.Size(121, 318);
			this.notesNavigatorTreeView.TabIndex = 2;
			this.notesNavigatorTreeView.DragOver += new System.Windows.Forms.DragEventHandler(this.notesNavigatorTreeView_DragOver);
			this.notesNavigatorTreeView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.notesNavigatorTreeView_KeyUp);
			this.notesNavigatorTreeView.DoubleClick += new System.EventHandler(this.notesNavigatorTreeView_DoubleClick);
			this.notesNavigatorTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.notesNavigatorTreeView_AfterSelect);
			this.notesNavigatorTreeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.notesNavigatorTreeView_AfterLabelEdit);
			this.notesNavigatorTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.notesNavigatorTreeView_ItemDrag);
			this.notesNavigatorTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.notesNavigatorTreeView_DragDrop);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(121, 25);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 318);
			this.splitter1.TabIndex = 3;
			this.splitter1.TabStop = false;
			// 
			// richTextBox1
			// 
			this.richTextBox1.AcceptsTab = true;
			this.richTextBox1.AllowDrop = true;
			this.richTextBox1.AutoWordSelection = true;
			this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBox1.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.richTextBox1.Location = new System.Drawing.Point(124, 25);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ShowSelectionMargin = true;
			this.richTextBox1.Size = new System.Drawing.Size(500, 318);
			this.richTextBox1.TabIndex = 4;
			this.richTextBox1.Text = "richTextBox1";
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.Copy,
																					  this.Paste});
			this.menuItem1.Text = "";
			// 
			// Copy
			// 
			this.Copy.Index = 0;
			this.Copy.Text = "";
			// 
			// Paste
			// 
			this.Paste.Index = 1;
			this.Paste.Text = "";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.DefaultExt = "ctn";
			this.openFileDialog1.Filter = "Cat Notes files|*.ctn|All files|*.*";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.DefaultExt = "ctn";
			// 
			// sysTrayNotifyIcon
			// 
			this.sysTrayNotifyIcon.ContextMenu = this.sysTrayContextMenu;
			this.sysTrayNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("sysTrayNotifyIcon.Icon")));
			this.sysTrayNotifyIcon.Text = "CatNotes (double click to open)";
			this.sysTrayNotifyIcon.Visible = true;
			this.sysTrayNotifyIcon.DoubleClick += new System.EventHandler(this.sysTrayNotifyIcon_DoubleClick);
			// 
			// sysTrayContextMenu
			// 
			this.sysTrayContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							   this.exitSysTrayMenu});
			// 
			// exitSysTrayMenu
			// 
			this.exitSysTrayMenu.Index = 0;
			this.exitSysTrayMenu.Text = "&Exit";
			this.exitSysTrayMenu.Click += new System.EventHandler(this.exitSysTrayMenu_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(624, 365);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.richTextBox1,
																		  this.splitter1,
																		  this.notesNavigatorTreeView,
																		  this.statusBar1,
																		  this.toolBar1});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Move += new System.EventHandler(this.Form1_Move);
			this.Closed += new System.EventHandler(this.Form1_Closed);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void AddNewChildNoteForTreeNode(string noteId, string noteContent)
		{
			//Get child notes
			CatNotesCollection childsForSelectedNote = m_catNotesDocument.GetChildNotes(noteId);
			CatNoteDetail newNote = childsForSelectedNote.Add ();
			newNote.Title = "*New Note*";
			newNote.Content = noteContent;
					
			TreeNode newAddedNode = RefreshTreeFromCatNoteDocument(newNote.Id );
			newAddedNode.Expand();
			newAddedNode.EnsureVisible();
			notesNavigatorTreeView.SelectedNode = newAddedNode;
			newAddedNode.BeginEdit();
		}

		private void AddNewChildNoteForSelectedNode()
		{
			string selectedNoteId = GetIdForSelectedNode();
			
			if (selectedNoteId == string.Empty)
			{
				MessageBox.Show ("Please select a category in to which you wish to add new note");
			}
			else
			{
				AddNewChildNoteForTreeNode(selectedNoteId, string.Empty);
			}
		}

		private void RemoveNoteForSelectedNote()
		{
			string selectedNoteId = GetIdForSelectedNode();

			if (selectedNoteId == string.Empty)
			{
				MessageBox.Show ("Please select a category which you wish to remove");
			}
			else
			{
				//Get this note and delete it
				CatNoteDetail noteDetailToDelete = m_catNotesDocument.GetNoteById(selectedNoteId);
				CatNoteDetail parentNoteDetail = noteDetailToDelete.ParentNote;
				noteDetailToDelete.Remove();
					
				TreeNode parentTreeNode = RefreshTreeFromCatNoteDocument(parentNoteDetail.Id );
				parentTreeNode.Expand();
				parentTreeNode.EnsureVisible();
				notesNavigatorTreeView.SelectedNode = parentTreeNode;
			}
		}

		private string GetIdForSelectedNode()
		{
			string selectedNoteId = string.Empty;
			if (notesNavigatorTreeView.SelectedNode != null)
			{
				selectedNoteId = (string) notesNavigatorTreeView.SelectedNode.Tag;
			}
			
			return selectedNoteId;
		}

		private CatNoteDetail GetCatNoteDetailForSelectedNode()
		{
			string selectedNoteId = GetIdForSelectedNode();
			if (selectedNoteId != string.Empty)
			{
				return m_catNotesDocument.GetNoteById(selectedNoteId);
			}
			else return null;
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button == tbtnAddCategory)
			{
				AddNewChildNoteForSelectedNode();
			}
			else if (e.Button == tbtnHelp)
			{
				MessageBox.Show ("Help is on the way!");
			}
			else if (e.Button == tbtnNewDocument )
			{
				CreateNewCateNotesDocument();
			}
			else if(e.Button == tbtnOpenDocument)
			{
				if (openFileDialog1.ShowDialog() == DialogResult.OK)
				{
					OpenCateNotesDocument(openFileDialog1.FileName);
				}
			}
			else if (e.Button == tbtnRemoveCategory )
			{
				RemoveNoteForSelectedNote();
			}
			else if (e.Button == tbtnSaveDocument )
			{
				SaveCateNoteDocument();
			}
			else if ((e.Button == tbtnNodeProperties) || (e.Button == tbtnSetReminder))
			{
				MessageBox.Show ("This is still yet to be worked");
			}
			else if (e.Button == tbtnRefreshDocument)
			{
				if (m_catNotesDocument.FileName != string.Empty)
				{
					OpenCateNotesDocument(m_catNotesDocument.FileName);
				}
				else
				{
					MessageBox.Show ("This document can not be reloaded because it is not yet saved in file");
				}
			}
			else if (e.Button == tbtnReadOnlyNote)
			{
				CatNoteDetail selectedCatNoteDetail = GetCatNoteDetailForSelectedNode();
				if (selectedCatNoteDetail != null)
				{
					selectedCatNoteDetail.IsReadOnly = !selectedCatNoteDetail.IsReadOnly;
					UpdateNoteEditorForSelectedTreeNode();
				}
			}
			else if (e.Button == tbtnSecuredNote)
			{
				CatNoteDetail selectedCatNoteDetail = GetCatNoteDetailForSelectedNode();
				if (selectedCatNoteDetail != null)
				{
					//Ask password
					string password = null;
					if (GetPasswordFromUser(ref password)==true)
					{
						try
						{
							selectedCatNoteDetail.PasswordForEncryptedNote = password;
							selectedCatNoteDetail.IsEncrypted = !selectedCatNoteDetail.IsEncrypted;

							UpdateNoteEditorForSelectedTreeNode();
						}
						catch (System.Security.SecurityException noteSecurityException)
						{
							MessageBox.Show (noteSecurityException.Message);
						}
					}
				}
			}
		}
		
		
		private bool GetPasswordFromUser(ref string password)
		{
			PasswordInputForm thisPassWordInputForm = new PasswordInputForm();
			if (thisPassWordInputForm.ShowDialog() == DialogResult.OK)
			{
				password = thisPassWordInputForm.Password;
				return true;
			}
			else return false;
		}
		
		private TreeNode CreateTreeNodeForCatNoteDetail(TreeNodeCollection  parentTreeNodeCollection, CatNoteDetail thisCatNoteDetail)
		{
			TreeNode newNode = parentTreeNodeCollection.Add(thisCatNoteDetail.Title);
			newNode.Tag = thisCatNoteDetail.Id;
			
			return newNode;
		}
		
		private TreeNode LoadTreeNodes(CatNotesCollection notesCollectionForCategory, TreeNode rootNodeForCategory, string treeNodeIdToReturn)
		{
			TreeNode treeNodeFoundForId = null;
			if (notesCollectionForCategory != null)
			{
				foreach(DictionaryEntry thisCatNoteDetailDictionaryEntry in notesCollectionForCategory)
				{
					CatNoteDetail  thisCatNoteDetailNode = (CatNoteDetail) thisCatNoteDetailDictionaryEntry.Value;
					
					TreeNode newNode = CreateTreeNodeForCatNoteDetail(rootNodeForCategory.Nodes, thisCatNoteDetailNode);
					
					//Get category childs and recurse to fill childs
					TreeNode treeNodeFoundForIdFromChilds = LoadTreeNodes(m_catNotesDocument.GetChildNotes(thisCatNoteDetailNode.Id), newNode, treeNodeIdToReturn);
					
					if (treeNodeIdToReturn == thisCatNoteDetailNode.Id)
						treeNodeFoundForId = newNode;
					else if (treeNodeFoundForIdFromChilds != null)
						treeNodeFoundForId = treeNodeFoundForIdFromChilds;
				}
			}			
			return treeNodeFoundForId;
		}

		private void OpenCateNotesDocument(string fileName)
		{
			m_catNotesDocument = new CatNotesDocument(fileName);
			RefreshTreeFromCatNoteDocument(string.Empty);
		}

		private void CreateNewCateNotesDocument()
		{
			m_catNotesDocument = new CatNotesDocument();
			RefreshTreeFromCatNoteDocument(string.Empty);
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			const string DEFAULT_SAMPLE_FILE_NAME = "\\SAMPLE.ctn";
			
			m_catApplicationSettings = new CatApplicationSettings(true);
			
			string lastusedFilename = LastUsedFileNameInConfiguration;
			if (lastusedFilename != null)
			{
				if (File.Exists(lastusedFilename)==false)
					lastusedFilename = Application.StartupPath  + DEFAULT_SAMPLE_FILE_NAME;
			}
			else
				lastusedFilename = Application.StartupPath  + DEFAULT_SAMPLE_FILE_NAME;
			
			if (File.Exists(lastusedFilename)==true)
				OpenCateNotesDocument(lastusedFilename);
			else
				CreateNewCateNotesDocument();
				
			try
			{
				this.WindowState = FormWindowState.Normal;
				this.Width = int.Parse (m_catApplicationSettings.GetSetting ("Last Values", "Window Width", this.Width.ToString()));
				this.Height = int.Parse (m_catApplicationSettings.GetSetting ("Last Values", "Window Hight", this.Height.ToString()));
				splitter1.SplitPosition =  int.Parse (m_catApplicationSettings.GetSetting ("Last Values", "Splitter Location", "125"));
				this.WindowState =(FormWindowState) Enum.Parse(this.WindowState.GetType(), m_catApplicationSettings.GetSetting ("Last Values", "Window State", "Normal"));
			}
			catch (Exception e1)
			{
			}
		}

		private void UpdateFormCaption()
		{
			if (m_catNotesDocument.FileName != string.Empty)
			{
				this.Text = Application.ProductName + " - " + "<New Document>";
			}
			{
				this.Text = Application.ProductName + " - " + m_catNotesDocument.FileName;
				LastUsedFileNameInConfiguration = m_catNotesDocument.FileName;
			}
		}

		private string LastUsedFileNameInConfiguration
		{
			get
			{
				return m_catApplicationSettings.GetSetting ("Last Values", "File Name");
			}
			set
			{
				m_catApplicationSettings.SetSetting ("Last Values", "File Name", value, true);
			}
		}
		
		private TreeNode RefreshTreeFromCatNoteDocument(string treeNodeIdToReturn)
		{
			UpdateFormCaption();
			
			notesNavigatorTreeView.Nodes.Clear();
			
			TreeNode rootNode = CreateTreeNodeForCatNoteDetail(notesNavigatorTreeView.Nodes, m_catNotesDocument.GetNoteById(m_catNotesDocument.Configuration.RootNoteId));

			//Populate root node
			TreeNode treeNodeFoundForId = LoadTreeNodes(m_catNotesDocument.GetChildNotes(m_catNotesDocument.Configuration.RootNoteId), notesNavigatorTreeView.Nodes[0], treeNodeIdToReturn);

			notesNavigatorTreeView.ExpandAll();
			UpdateNoteEditorForSelectedTreeNode();
			
			if (treeNodeIdToReturn == rootNode.Tag.ToString())
				return rootNode;
			else
				return treeNodeFoundForId;
		}
		
		private void Form1_Closed(object sender, System.EventArgs e)
		{
			SaveCateNoteDocument();
			m_catNotesDocument = null;
			
			//Save window settings
			m_catApplicationSettings.SetSetting("Last Values", "Window State", this.WindowState.ToString(), false);
			m_catApplicationSettings.SetSetting("Last Values", "Window Width", this.Width.ToString(), false);
			m_catApplicationSettings.SetSetting("Last Values", "Window Hight", this.Height.ToString(), false);
			m_catApplicationSettings.SetSetting("Last Values", "Splitter Location", splitter1.Location.X.ToString(), false);
			m_catApplicationSettings.Save();
			
			m_catApplicationSettings = null;
			
			//sysTrayNotifyIcon.Visible = false;
		}

		private void SaveCateNoteDocument()
		{
			SaveLastCatNoteDetailChanges();
			
			if (m_catNotesDocument.FileName == string.Empty)
			{
				if (saveFileDialog1.ShowDialog()== DialogResult.OK)
				{
					m_catNotesDocument.FileName = saveFileDialog1.FileName;
				}
				else ;
					//throw new Exception("Filename to save for CateNotesDocument is not specified");
			}
			m_catNotesDocument.Save(m_catNotesDocument.FileName);
			UpdateFormCaption();
		}

		private void SaveLastCatNoteDetailChanges()
		{
			//save previously set note's content
			if (m_catNotesDocument.NoteBookmark != "")
			{
				if (richTextBox1.Modified == true)
				{
				CatNoteDetail modifiedCatNoteDetail = m_catNotesDocument.GetNoteById(m_catNotesDocument.NoteBookmark);
				modifiedCatNoteDetail.Content = richTextBox1.Text;
				}
			}
		}

		private void notesNavigatorTreeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			UpdateNoteEditorForSelectedTreeNode();
		}
		
		private void UpdateNoteEditorForSelectedTreeNode()
		{
			SaveLastCatNoteDetailChanges();
			if (notesNavigatorTreeView.SelectedNode != null)
			{
				string nodeId = (string) notesNavigatorTreeView.SelectedNode.Tag;
				CatNoteDetail selectedCatNoteDetail = m_catNotesDocument.GetNoteById(nodeId);
				
				string noteContent = "Failed to show note content. there's something wrong.";
				if (selectedCatNoteDetail.IsEncrypted == true)
				{
					try
					{
						if (selectedCatNoteDetail.PasswordForEncryptedNote == null)
						{
							string password = null;
							if (GetPasswordFromUser(ref password) == true)
							{
								selectedCatNoteDetail.PasswordForEncryptedNote = password;
							}
							else throw new System.Security.SecurityException("Password required for secured notes");
						}
						
						//Get the decrypted content
						noteContent = selectedCatNoteDetail.Content;
					}
					catch (Exception decryptException)
					{
						noteContent = @"This note was secured with a password. 
You must enter the correct password to see it's content.
						
Following error occured:
" + decryptException.Message;
						richTextBox1.ReadOnly = true;
					}
				}
				else
				{
					noteContent = selectedCatNoteDetail.Content;
				}
				
				richTextBox1.Text = noteContent;
				
				richTextBox1.ReadOnly = selectedCatNoteDetail.IsReadOnly;
				if (richTextBox1.ReadOnly == true)
				{
					originalRichTextBoxColor = richTextBox1.BackColor;
					richTextBox1.BackColor = Color.FromKnownColor(KnownColor.Silver);
				}
				else
				{
					richTextBox1.BackColor = originalRichTextBoxColor;
				}
				
				//Update toobar buttons
				tbtnReadOnlyNote.Pushed = richTextBox1.ReadOnly;
				tbtnSecuredNote.Pushed = selectedCatNoteDetail.IsEncrypted;
				
				m_catNotesDocument.NoteBookmark = nodeId;
			}
			else
			{
				richTextBox1.Text = "Select a note to view";
				richTextBox1.ReadOnly = true;
				m_catNotesDocument.NoteBookmark = string.Empty;
			}
		}
		
		private void notesNavigatorTreeView_AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
		{
			if ((e.Node != null) && (e.Label != null))
			{
				//Get Node Id
				string selectedNodeId = (string) e.Node.Tag;
				 
				CatNoteDetail selectedCatNoteDetail = m_catNotesDocument.GetNoteById(selectedNodeId);
				selectedCatNoteDetail.Title = e.Label;
				
				RefreshTreeWithSelectionIntact();

			}
			else ;	//don't know why this should happen but it did once
		}
		
		private void RefreshTreeWithSelectionIntact()
		{
			TreeNode previouslySelectedNode = notesNavigatorTreeView.SelectedNode;
			string previouslySelectedNodeId = null;
			if (previouslySelectedNode != null)
				previouslySelectedNodeId = (string) previouslySelectedNode.Tag;
			TreeNode newNodeToSelect = RefreshTreeFromCatNoteDocument(previouslySelectedNodeId);
			notesNavigatorTreeView.ExpandAll();	
			if (newNodeToSelect != null)
			{
				notesNavigatorTreeView.SelectedNode=newNodeToSelect;
				newNodeToSelect.EnsureVisible();
			}	
		}
		
		private void notesNavigatorTreeView_DoubleClick(object sender, System.EventArgs e)
		{
			if (notesNavigatorTreeView.SelectedNode != null)
			{
				notesNavigatorTreeView.SelectedNode.BeginEdit();
			}
		}

		private void notesNavigatorTreeView_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F2)
			{
				if (notesNavigatorTreeView.SelectedNode != null)
				{
					notesNavigatorTreeView.SelectedNode.BeginEdit();
				}
			}
			else if (e.KeyCode == Keys.Insert)
			{
				AddNewChildNoteForSelectedNode();
			}
			else if (e.KeyCode == Keys.Delete)
			{
				RemoveNoteForSelectedNote();
			}
		}

		private void notesNavigatorTreeView_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
		{
			TreeNode draggedNode = (TreeNode) e.Item;
			notesNavigatorTreeView.DoDragDrop((string) draggedNode.Tag, DragDropEffects.Move);
		}

		private void notesNavigatorTreeView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			string draggedNodeId = (string) e.Data.GetData(String.Empty.GetType());
			TreeNode destinationNode = notesNavigatorTreeView.GetNodeAt(notesNavigatorTreeView.PointToClient(new System.Drawing.Point(e.X, e.Y)));
			
			if (destinationNode != null)
			{
				string destinationNoteId = (string) destinationNode.Tag;
				
				try
				{
					m_catNotesDocument.MoveNote(draggedNodeId,destinationNoteId);
					
					destinationNode = RefreshTreeFromCatNoteDocument(destinationNoteId);
					destinationNode.ExpandAll();
					notesNavigatorTreeView.SelectedNode = destinationNode;
				}
				catch(ArgumentException moveException)
				{
					if (moveException.ParamName == "InvalidSourceId")
					{
						if (MessageBox.Show ("Do you wish to create new note?", "Create Note", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
						{
							AddNewChildNoteForTreeNode(destinationNoteId, draggedNodeId);
						}
					}
					else
						MessageBox.Show("Can not move this note because this note is a parent of the note where you want to move it");
				}
	
			}
		}

		private void notesNavigatorTreeView_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{
			string draggedNodeId = (string) e.Data.GetData(String.Empty.GetType());
			if (draggedNodeId != null)
				e.Effect = DragDropEffects.Move;
			else
				e.Effect = DragDropEffects.None;
			
		}

		private void Form1_Move(object sender, System.EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				this.ShowInTaskbar = false;
			}
		}

		private void sysTrayNotifyIcon_DoubleClick(object sender, System.EventArgs e)
		{
			this.WindowState = FormWindowState.Normal;
		}

		private void exitSysTrayMenu_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}
	}
}

/*
	Features:
	1. Hierarchical notes - add, remove, edit notes
	2. open, new - document
	3. Remember windows settings
	4. Remember last opened file
	5. Save on exit
	6. Autosave on note change
	7. Reload doc
	8. Resizable explorer style editor with splitter
	9. Shortcut keys for add/remove categories
	10. Multilanguage enabled
*/

/*
Todo:
	1. Read only notes UI implementation
	2. Attachments
	3. Custom note properties
	4. Date time modified & windows user name for each note
	5. Save As
	6. Back up
	7. Save selected nodes as XML
	8. Save selected node as text
	9. HTML editing and formatting toolbar
	10. Edit count
	11. Secured enchrypted notes
	12. Symbol selection
	13. Export to Outlook Notes
	14. Set reminders in Outlook
	15. File type and icon registration
	16. Find utility
	17. Recently opened notes list
	18. Merge two documents
	19. Export to Word, HTML
	20. Import from NoteKeeper
	21. Drag & drop nodes
	22. Drag & drop files  from explore
	23. Drang & drop notes to outlook
	24. Drag & drop notes to explorer as HTML file
	25. Open multiple docs in tabs, enable cross doc drag & drop, cross docs search, copy & paste of nodes
	26. Copy & paste of nodes
	27. Node links - when node is clicked, open associated file/url from HDD/Net
	28. Node processes - when node is clicked, exec command line
	29. implement message store like url support
	30. Priniting
	31. Office XP style menus & look & Office Assistant
	32. Use Word as editor
	33. eMail a note
	34. Find heavy attachments utility
	35. Font, bk color settings
	36. Select icons for note
	37. Picture type nodes
	38. Attachment preview
*/