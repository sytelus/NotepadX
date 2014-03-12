using System;
using System.Configuration;
using System.Drawing;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.IO;

using System.Diagnostics;
using Sytel;
using Flobbster.Windows.Forms;
using Sytel.AssemblyCustomProperty;

namespace Sytel.NotepadX
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.ToolBarButton tbtnAddCategory;
		private System.Windows.Forms.ToolBarButton tbtnRemoveCategory;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem Copy;
		private System.Windows.Forms.MenuItem Paste;
		private System.Windows.Forms.ToolBarButton tbtnSeperator2;
		private System.Windows.Forms.ToolBarButton tbtnSeperator1;
		private System.Windows.Forms.ToolBarButton tbtnNewDocument;
		private System.Windows.Forms.ToolBarButton tbtnSaveDocument;
		private System.Windows.Forms.ToolBarButton tbtnHelp;
		private System.Windows.Forms.ToolBarButton tbtnOpenDocument;
		private System.Windows.Forms.ToolBarButton tbtnRefreshDocument;
		private System.Windows.Forms.ToolBarButton tbtnNodeProperties;
		private System.Windows.Forms.ToolBarButton tbtnReadOnlyNote;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton tbtnSecuredNote;
		private System.Windows.Forms.ToolBarButton tbtnSetReminder;
		private System.Windows.Forms.NotifyIcon sysTrayNotifyIcon;
		private System.Windows.Forms.ContextMenu sysTrayContextMenu;
		private System.Windows.Forms.ToolBarButton tbtnExit;
		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.Panel leftPanel;
		private System.Windows.Forms.Panel rightPanel;
		private System.Windows.Forms.Panel editorPanel;
		private System.Windows.Forms.Panel notePropertiesPanel;
		private System.Windows.Forms.Splitter splitter3;
		private System.Windows.Forms.ListView childNotesListView;

		//Private vars
		private NotepadXDocument m_NotepadXDocument;
		private NotepadXApplicationSettings m_NotepadXApplicationSettings;
		private bool m_isAutoSaveWhileExit = false;
		private bool m_rememberWindowLayout = true;
		private bool m_AutoOpenLastDocument = true;
		private bool m_MinimizeOnClose = false;
		private bool m_isNoSaveWhileExit = false;
		private bool m_isNotePropertiesShown = false;
		private INoteEditor m_currentNoteEditor = null;
		private RichTextEditor m_richNoteEditor = null;
		private System.Windows.Forms.StatusBarPanel editorFormatStatusPanel;
		private System.Windows.Forms.ImageList imageList1;
		private TreeEditor m_notesTreeEditor = null;
		private RichTextEditor m_textNoteEditor = null;
		private WorksheetEditor m_worksheetNoteEditor = null;
		private NotepadX.NotePropertyEditor selectedNotePropertyEditor;
		public string[] CommandLineRawArgs = null;
		private bool m_isFullScreenMode = false;
		
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel navigationPanel;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.Panel childNotesViewerPanel;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem25;
		private System.Windows.Forms.MenuItem menuItem30;
		private System.Windows.Forms.MenuItem menuItem36;
		private System.Windows.Forms.MenuItem menuItem40;
		private System.Windows.Forms.MenuItem menuItem42;
		private System.Windows.Forms.MenuItem menuItem46;
		private System.Windows.Forms.MenuItem menuItem48;
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuNew;
		private System.Windows.Forms.MenuItem menuOpen;
		private System.Windows.Forms.MenuItem menuOpenSample;
		private System.Windows.Forms.MenuItem menuRefresh;
		private System.Windows.Forms.MenuItem menuSave;
		private System.Windows.Forms.MenuItem menuSaveAs;
		private System.Windows.Forms.MenuItem menuOpenFolder;
		private System.Windows.Forms.MenuItem menuExit;
		private System.Windows.Forms.MenuItem menuExitWithouSave;
		private System.Windows.Forms.MenuItem menuEdit;
		private System.Windows.Forms.MenuItem menuAddNote;
		private System.Windows.Forms.MenuItem menuRemoveNote;
		private System.Windows.Forms.MenuItem menuMakeSecureNote;
		private System.Windows.Forms.MenuItem menuMakeReadOnlyNote;
		private System.Windows.Forms.MenuItem menuSetReminder;
		private System.Windows.Forms.MenuItem menuNoteProperties;
		private System.Windows.Forms.MenuItem menuView;
		private System.Windows.Forms.MenuItem menuViewNoteProperties;
		private System.Windows.Forms.MenuItem menuViewToolBar;
		private System.Windows.Forms.MenuItem menuFullScreen;
		private System.Windows.Forms.MenuItem menuTools;
		private System.Windows.Forms.MenuItem menuSavePreferences;
		private System.Windows.Forms.MenuItem menuRestorePreferences;
		private System.Windows.Forms.MenuItem menuOptions;
		private System.Windows.Forms.MenuItem menuHelp;
		private System.Windows.Forms.MenuItem menuShowHelpFile;
		private System.Windows.Forms.MenuItem menuTipsFromAuthor;
		private System.Windows.Forms.MenuItem menuSendComments;
		private System.Windows.Forms.MenuItem menuCheckUpdates;
		private System.Windows.Forms.MenuItem menuVisitHomePage;
		private System.Windows.Forms.MenuItem menuAbout;
		private System.Windows.Forms.MenuItem menuAddNormalNote;
		private System.Windows.Forms.MenuItem menuAddPlainTextNote;
		private System.Windows.Forms.MenuItem menuAddWorksheetNote;
		private System.Windows.Forms.MenuItem menuAddHierarchyNote;
		private System.Windows.Forms.ContextMenu treeEditorContextMenu;
		private System.Windows.Forms.MenuItem menuItem2;
		private NotepadX.MRUMenuItem mnuRecentDocuments;
		private System.Windows.Forms.SaveFileDialog saveDocumentDialog;
		private System.Windows.Forms.OpenFileDialog openDocumentDialog;
		private System.Windows.Forms.OpenFileDialog openSettingsFileDialog;
		private System.Windows.Forms.SaveFileDialog saveSettingsFileDialog;
		private System.Windows.Forms.ContextMenu ctxMenuAddNote;
		private System.Windows.Forms.MenuItem openSysTrayMenu;
		private System.Windows.Forms.MenuItem menuSeperator;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuDeletePreferences;
		private System.IO.FileSystemWatcher openDocumentExternalChangeWatcher;
		private TreePropertyEditor m_hierarchyEditor = null;

		public MainForm()
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
				
				//Dispose private components
				if (m_notesTreeEditor != null) m_notesTreeEditor.Dispose();
				if (m_richNoteEditor != null) m_richNoteEditor.Dispose();
				if (m_textNoteEditor != null) m_textNoteEditor.Dispose();
				if (m_worksheetNoteEditor !=null) m_worksheetNoteEditor.Dispose();
				if (m_hierarchyEditor != null) m_hierarchyEditor.Dispose();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
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
			this.ctxMenuAddNote = new System.Windows.Forms.ContextMenu();
			this.tbtnRemoveCategory = new System.Windows.Forms.ToolBarButton();
			this.tbtnSeperator2 = new System.Windows.Forms.ToolBarButton();
			this.tbtnExit = new System.Windows.Forms.ToolBarButton();
			this.tbtnHelp = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.editorFormatStatusPanel = new System.Windows.Forms.StatusBarPanel();
			this.treeEditorContextMenu = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.Copy = new System.Windows.Forms.MenuItem();
			this.Paste = new System.Windows.Forms.MenuItem();
			this.openDocumentDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveDocumentDialog = new System.Windows.Forms.SaveFileDialog();
			this.sysTrayNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.sysTrayContextMenu = new System.Windows.Forms.ContextMenu();
			this.openSysTrayMenu = new System.Windows.Forms.MenuItem();
			this.menuSeperator = new System.Windows.Forms.MenuItem();
			this.mainPanel = new System.Windows.Forms.Panel();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.rightPanel = new System.Windows.Forms.Panel();
			this.editorPanel = new System.Windows.Forms.Panel();
			this.splitter3 = new System.Windows.Forms.Splitter();
			this.childNotesViewerPanel = new System.Windows.Forms.Panel();
			this.childNotesListView = new System.Windows.Forms.ListView();
			this.leftPanel = new System.Windows.Forms.Panel();
			this.navigationPanel = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.notePropertiesPanel = new System.Windows.Forms.Panel();
			this.selectedNotePropertyEditor = new Sytel.NotepadX.NotePropertyEditor();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuFile = new System.Windows.Forms.MenuItem();
			this.menuNew = new System.Windows.Forms.MenuItem();
			this.menuOpen = new System.Windows.Forms.MenuItem();
			this.menuOpenSample = new System.Windows.Forms.MenuItem();
			this.menuRefresh = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuSave = new System.Windows.Forms.MenuItem();
			this.menuSaveAs = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuOpenFolder = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.mnuRecentDocuments = new Sytel.NotepadX.MRUMenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuExit = new System.Windows.Forms.MenuItem();
			this.menuExitWithouSave = new System.Windows.Forms.MenuItem();
			this.menuEdit = new System.Windows.Forms.MenuItem();
			this.menuAddNote = new System.Windows.Forms.MenuItem();
			this.menuAddNormalNote = new System.Windows.Forms.MenuItem();
			this.menuItem30 = new System.Windows.Forms.MenuItem();
			this.menuAddPlainTextNote = new System.Windows.Forms.MenuItem();
			this.menuAddWorksheetNote = new System.Windows.Forms.MenuItem();
			this.menuAddHierarchyNote = new System.Windows.Forms.MenuItem();
			this.menuRemoveNote = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.menuMakeSecureNote = new System.Windows.Forms.MenuItem();
			this.menuMakeReadOnlyNote = new System.Windows.Forms.MenuItem();
			this.menuItem36 = new System.Windows.Forms.MenuItem();
			this.menuSetReminder = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuNoteProperties = new System.Windows.Forms.MenuItem();
			this.menuView = new System.Windows.Forms.MenuItem();
			this.menuViewNoteProperties = new System.Windows.Forms.MenuItem();
			this.menuViewToolBar = new System.Windows.Forms.MenuItem();
			this.menuItem46 = new System.Windows.Forms.MenuItem();
			this.menuFullScreen = new System.Windows.Forms.MenuItem();
			this.menuTools = new System.Windows.Forms.MenuItem();
			this.menuOptions = new System.Windows.Forms.MenuItem();
			this.menuItem42 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuSavePreferences = new System.Windows.Forms.MenuItem();
			this.menuRestorePreferences = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuDeletePreferences = new System.Windows.Forms.MenuItem();
			this.menuHelp = new System.Windows.Forms.MenuItem();
			this.menuShowHelpFile = new System.Windows.Forms.MenuItem();
			this.menuTipsFromAuthor = new System.Windows.Forms.MenuItem();
			this.menuItem48 = new System.Windows.Forms.MenuItem();
			this.menuSendComments = new System.Windows.Forms.MenuItem();
			this.menuItem25 = new System.Windows.Forms.MenuItem();
			this.menuCheckUpdates = new System.Windows.Forms.MenuItem();
			this.menuVisitHomePage = new System.Windows.Forms.MenuItem();
			this.menuItem40 = new System.Windows.Forms.MenuItem();
			this.menuAbout = new System.Windows.Forms.MenuItem();
			this.openSettingsFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveSettingsFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.openDocumentExternalChangeWatcher = new System.IO.FileSystemWatcher();
			((System.ComponentModel.ISupportInitialize)(this.editorFormatStatusPanel)).BeginInit();
			this.mainPanel.SuspendLayout();
			this.rightPanel.SuspendLayout();
			this.childNotesViewerPanel.SuspendLayout();
			this.leftPanel.SuspendLayout();
			this.notePropertiesPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.openDocumentExternalChangeWatcher)).BeginInit();
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
																						this.tbtnExit,
																						this.tbtnHelp});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(808, 28);
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
			this.tbtnNodeProperties.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.tbtnNodeProperties.ToolTipText = "View note\'s properties";
			// 
			// tbtnReadOnlyNote
			// 
			this.tbtnReadOnlyNote.ImageIndex = 23;
			this.tbtnReadOnlyNote.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.tbtnReadOnlyNote.ToolTipText = "Make this note read-only or writable";
			// 
			// tbtnSecuredNote
			// 
			this.tbtnSecuredNote.ImageIndex = 27;
			this.tbtnSecuredNote.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.tbtnSecuredNote.ToolTipText = "Make this note secured or normal";
			// 
			// tbtnSetReminder
			// 
			this.tbtnSetReminder.ImageIndex = 14;
			this.tbtnSetReminder.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton;
			this.tbtnSetReminder.ToolTipText = "Set Reminder For This Note";
			this.tbtnSetReminder.Visible = false;
			// 
			// tbtnSeperator1
			// 
			this.tbtnSeperator1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbtnAddCategory
			// 
			this.tbtnAddCategory.DropDownMenu = this.ctxMenuAddNote;
			this.tbtnAddCategory.ImageIndex = 24;
			this.tbtnAddCategory.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
			this.tbtnAddCategory.ToolTipText = "Add new child node";
			// 
			// tbtnRemoveCategory
			// 
			this.tbtnRemoveCategory.ImageIndex = 26;
			this.tbtnRemoveCategory.ToolTipText = "Remove selected note";
			// 
			// tbtnSeperator2
			// 
			this.tbtnSeperator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// tbtnExit
			// 
			this.tbtnExit.ImageIndex = 22;
			this.tbtnExit.ToolTipText = "Exit without saving";
			// 
			// tbtnHelp
			// 
			this.tbtnHelp.ImageIndex = 29;
			this.tbtnHelp.ToolTipText = "Help";
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// statusBar1
			// 
			this.statusBar1.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.statusBar1.Location = new System.Drawing.Point(0, 515);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.editorFormatStatusPanel});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(808, 22);
			this.statusBar1.TabIndex = 1;
			this.statusBar1.Text = "NotepadX Alpha 1 By Shital Shah - Created During Dec 2k2-Jan 2k3 (Use by public a" +
				"t own risk)";
			// 
			// editorFormatStatusPanel
			// 
			this.editorFormatStatusPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.editorFormatStatusPanel.ToolTipText = "Current editor format";
			this.editorFormatStatusPanel.Width = 792;
			// 
			// treeEditorContextMenu
			// 
			this.treeEditorContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
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
			// openDocumentDialog
			// 
			this.openDocumentDialog.DefaultExt = "ctn";
			this.openDocumentDialog.Filter = "NotepadX files (*.npx)|*.npx|All files (*.*)|*.*";
			// 
			// saveDocumentDialog
			// 
			this.saveDocumentDialog.DefaultExt = "ctn";
			this.saveDocumentDialog.Filter = "NotepadX files (*.npx)|*.npx|All files (*.*)|*.*";
			// 
			// sysTrayNotifyIcon
			// 
			this.sysTrayNotifyIcon.ContextMenu = this.sysTrayContextMenu;
			this.sysTrayNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("sysTrayNotifyIcon.Icon")));
			this.sysTrayNotifyIcon.Text = "NotepadX (double click to open)";
			this.sysTrayNotifyIcon.Visible = true;
			this.sysTrayNotifyIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.sysTrayNotifyIcon_MouseDown);
			this.sysTrayNotifyIcon.DoubleClick += new System.EventHandler(this.sysTrayNotifyIcon_DoubleClick);
			// 
			// sysTrayContextMenu
			// 
			this.sysTrayContextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							   this.openSysTrayMenu,
																							   this.menuSeperator});
			this.sysTrayContextMenu.Popup += new System.EventHandler(this.sysTrayContextMenu_Popup);
			// 
			// openSysTrayMenu
			// 
			this.openSysTrayMenu.DefaultItem = true;
			this.openSysTrayMenu.Index = 0;
			this.openSysTrayMenu.Text = "&Open";
			this.openSysTrayMenu.Click += new System.EventHandler(this.sysTrayNotifyIcon_DoubleClick);
			// 
			// menuSeperator
			// 
			this.menuSeperator.Index = 1;
			this.menuSeperator.Text = "-";
			// 
			// mainPanel
			// 
			this.mainPanel.Controls.Add(this.splitter2);
			this.mainPanel.Controls.Add(this.rightPanel);
			this.mainPanel.Controls.Add(this.leftPanel);
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Location = new System.Drawing.Point(0, 28);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(808, 487);
			this.mainPanel.TabIndex = 2;
			// 
			// splitter2
			// 
			this.splitter2.Location = new System.Drawing.Point(200, 0);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(3, 487);
			this.splitter2.TabIndex = 3;
			this.splitter2.TabStop = false;
			// 
			// rightPanel
			// 
			this.rightPanel.Controls.Add(this.editorPanel);
			this.rightPanel.Controls.Add(this.splitter3);
			this.rightPanel.Controls.Add(this.childNotesViewerPanel);
			this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rightPanel.Location = new System.Drawing.Point(200, 0);
			this.rightPanel.Name = "rightPanel";
			this.rightPanel.Size = new System.Drawing.Size(608, 487);
			this.rightPanel.TabIndex = 2;
			// 
			// editorPanel
			// 
			this.editorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.editorPanel.Location = new System.Drawing.Point(0, 0);
			this.editorPanel.Name = "editorPanel";
			this.editorPanel.Size = new System.Drawing.Size(608, 384);
			this.editorPanel.TabIndex = 0;
			// 
			// splitter3
			// 
			this.splitter3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter3.Location = new System.Drawing.Point(0, 384);
			this.splitter3.Name = "splitter3";
			this.splitter3.Size = new System.Drawing.Size(608, 3);
			this.splitter3.TabIndex = 2;
			this.splitter3.TabStop = false;
			// 
			// childNotesViewerPanel
			// 
			this.childNotesViewerPanel.Controls.Add(this.childNotesListView);
			this.childNotesViewerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.childNotesViewerPanel.Location = new System.Drawing.Point(0, 387);
			this.childNotesViewerPanel.Name = "childNotesViewerPanel";
			this.childNotesViewerPanel.Size = new System.Drawing.Size(608, 100);
			this.childNotesViewerPanel.TabIndex = 1;
			this.childNotesViewerPanel.Visible = false;
			// 
			// childNotesListView
			// 
			this.childNotesListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.childNotesListView.Location = new System.Drawing.Point(0, 0);
			this.childNotesListView.Name = "childNotesListView";
			this.childNotesListView.Size = new System.Drawing.Size(608, 100);
			this.childNotesListView.TabIndex = 0;
			// 
			// leftPanel
			// 
			this.leftPanel.Controls.Add(this.navigationPanel);
			this.leftPanel.Controls.Add(this.splitter1);
			this.leftPanel.Controls.Add(this.notePropertiesPanel);
			this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
			this.leftPanel.Location = new System.Drawing.Point(0, 0);
			this.leftPanel.Name = "leftPanel";
			this.leftPanel.Size = new System.Drawing.Size(200, 487);
			this.leftPanel.TabIndex = 0;
			// 
			// navigationPanel
			// 
			this.navigationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.navigationPanel.Location = new System.Drawing.Point(0, 0);
			this.navigationPanel.Name = "navigationPanel";
			this.navigationPanel.Size = new System.Drawing.Size(200, 280);
			this.navigationPanel.TabIndex = 4;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter1.Location = new System.Drawing.Point(0, 280);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(200, 3);
			this.splitter1.TabIndex = 3;
			this.splitter1.TabStop = false;
			// 
			// notePropertiesPanel
			// 
			this.notePropertiesPanel.Controls.Add(this.selectedNotePropertyEditor);
			this.notePropertiesPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.notePropertiesPanel.Location = new System.Drawing.Point(0, 283);
			this.notePropertiesPanel.Name = "notePropertiesPanel";
			this.notePropertiesPanel.Size = new System.Drawing.Size(200, 204);
			this.notePropertiesPanel.TabIndex = 1;
			this.notePropertiesPanel.Visible = false;
			// 
			// selectedNotePropertyEditor
			// 
			this.selectedNotePropertyEditor.Dock = System.Windows.Forms.DockStyle.Fill;
			this.selectedNotePropertyEditor.Location = new System.Drawing.Point(0, 0);
			this.selectedNotePropertyEditor.Name = "selectedNotePropertyEditor";
			this.selectedNotePropertyEditor.NoteToDisplay = null;
			this.selectedNotePropertyEditor.Size = new System.Drawing.Size(200, 204);
			this.selectedNotePropertyEditor.TabIndex = 0;
			this.selectedNotePropertyEditor.NotePropertiesChanged += new Sytel.NotepadX.NotePropertiesChangedHandler(this.selectedNotePropertyEditor_NotePropertiesChanged);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuFile,
																					  this.menuEdit,
																					  this.menuView,
																					  this.menuTools,
																					  this.menuHelp});
			// 
			// menuFile
			// 
			this.menuFile.Index = 0;
			this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuNew,
																					 this.menuOpen,
																					 this.menuOpenSample,
																					 this.menuRefresh,
																					 this.menuItem7,
																					 this.menuSave,
																					 this.menuSaveAs,
																					 this.menuItem8,
																					 this.menuOpenFolder,
																					 this.menuItem13,
																					 this.mnuRecentDocuments,
																					 this.menuItem2,
																					 this.menuExit,
																					 this.menuExitWithouSave});
			this.menuFile.Text = "&File";
			// 
			// menuNew
			// 
			this.menuNew.Index = 0;
			this.menuNew.Text = "&New";
			this.menuNew.Click += new System.EventHandler(this.menuNew_Click);
			// 
			// menuOpen
			// 
			this.menuOpen.Index = 1;
			this.menuOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.menuOpen.Text = "&Open...";
			this.menuOpen.Click += new System.EventHandler(this.menuOpen_Click);
			// 
			// menuOpenSample
			// 
			this.menuOpenSample.Index = 2;
			this.menuOpenSample.Text = "Open Sa&mple";
			this.menuOpenSample.Click += new System.EventHandler(this.menuOpenSample_Click);
			// 
			// menuRefresh
			// 
			this.menuRefresh.Index = 3;
			this.menuRefresh.Shortcut = System.Windows.Forms.Shortcut.CtrlF5;
			this.menuRefresh.Text = "&Reload";
			this.menuRefresh.Click += new System.EventHandler(this.menuRefresh_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 4;
			this.menuItem7.Text = "-";
			// 
			// menuSave
			// 
			this.menuSave.Index = 5;
			this.menuSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.menuSave.Text = "&Save";
			this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
			// 
			// menuSaveAs
			// 
			this.menuSaveAs.Index = 6;
			this.menuSaveAs.Text = "Save &As...";
			this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 7;
			this.menuItem8.Text = "-";
			// 
			// menuOpenFolder
			// 
			this.menuOpenFolder.Index = 8;
			this.menuOpenFolder.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
			this.menuOpenFolder.Text = "Open Document &Folder...";
			this.menuOpenFolder.Click += new System.EventHandler(this.menuOpenFolder_Click);
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 9;
			this.menuItem13.Text = "-";
			// 
			// mnuRecentDocuments
			// 
			this.mnuRecentDocuments.Index = 10;
			// TODO: Code generation for 'this.mnuRecentDocuments.MaxMRUCount' failed because of Exception 'Invalid Primitive Type: System.UInt32. Only CLS compliant primitive types can be used. Consider using CodeObjectCreateExpression.'.
			this.mnuRecentDocuments.Text = "Recent Documents";
			this.mnuRecentDocuments.MRUClicked += new System.EventHandler(this.mnuRecentDocuments_MRUClicked);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 11;
			this.menuItem2.Text = "-";
			// 
			// menuExit
			// 
			this.menuExit.Index = 12;
			this.menuExit.Text = "E&xit";
			this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
			// 
			// menuExitWithouSave
			// 
			this.menuExitWithouSave.Index = 13;
			this.menuExitWithouSave.Text = "Exit &Without Save";
			this.menuExitWithouSave.Click += new System.EventHandler(this.menuExitWithouSave_Click);
			// 
			// menuEdit
			// 
			this.menuEdit.Index = 1;
			this.menuEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuAddNote,
																					 this.menuRemoveNote,
																					 this.menuItem15,
																					 this.menuMakeSecureNote,
																					 this.menuMakeReadOnlyNote,
																					 this.menuItem36,
																					 this.menuSetReminder,
																					 this.menuItem17,
																					 this.menuNoteProperties});
			this.menuEdit.Text = "&Edit";
			// 
			// menuAddNote
			// 
			this.menuAddNote.Index = 0;
			this.menuAddNote.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						this.menuAddNormalNote,
																						this.menuItem30,
																						this.menuAddPlainTextNote,
																						this.menuAddWorksheetNote,
																						this.menuAddHierarchyNote});
			this.menuAddNote.Text = "&Add Note";
			// 
			// menuAddNormalNote
			// 
			this.menuAddNormalNote.Index = 0;
			this.menuAddNormalNote.Text = "Normal Note";
			this.menuAddNormalNote.Click += new System.EventHandler(this.menuAddNormalNote_Click);
			// 
			// menuItem30
			// 
			this.menuItem30.Index = 1;
			this.menuItem30.Text = "-";
			// 
			// menuAddPlainTextNote
			// 
			this.menuAddPlainTextNote.Index = 2;
			this.menuAddPlainTextNote.Text = "Plain Text Note";
			this.menuAddPlainTextNote.Click += new System.EventHandler(this.menuAddPlainTextNote_Click);
			// 
			// menuAddWorksheetNote
			// 
			this.menuAddWorksheetNote.Index = 3;
			this.menuAddWorksheetNote.Text = "Worksheet Note";
			this.menuAddWorksheetNote.Click += new System.EventHandler(this.menuAddWorksheetNote_Click);
			// 
			// menuAddHierarchyNote
			// 
			this.menuAddHierarchyNote.Index = 4;
			this.menuAddHierarchyNote.Text = "Hierarchy Note";
			this.menuAddHierarchyNote.Click += new System.EventHandler(this.menuAddHierarchyNote_Click);
			// 
			// menuRemoveNote
			// 
			this.menuRemoveNote.Index = 1;
			this.menuRemoveNote.Text = "&Remove Note";
			this.menuRemoveNote.Click += new System.EventHandler(this.menuRemoveNote_Click);
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 2;
			this.menuItem15.Text = "-";
			// 
			// menuMakeSecureNote
			// 
			this.menuMakeSecureNote.Index = 3;
			this.menuMakeSecureNote.Text = "Make &Secure";
			this.menuMakeSecureNote.Click += new System.EventHandler(this.menuMakeSecureNote_Click);
			// 
			// menuMakeReadOnlyNote
			// 
			this.menuMakeReadOnlyNote.Index = 4;
			this.menuMakeReadOnlyNote.Text = "Make Read Only";
			this.menuMakeReadOnlyNote.Click += new System.EventHandler(this.menuMakeReadOnlyNote_Click);
			// 
			// menuItem36
			// 
			this.menuItem36.Index = 5;
			this.menuItem36.Text = "-";
			// 
			// menuSetReminder
			// 
			this.menuSetReminder.Index = 6;
			this.menuSetReminder.Text = "Set &Reminder...";
			this.menuSetReminder.Visible = false;
			this.menuSetReminder.Click += new System.EventHandler(this.menuSetReminder_Click);
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 7;
			this.menuItem17.Text = "-";
			this.menuItem17.Visible = false;
			// 
			// menuNoteProperties
			// 
			this.menuNoteProperties.Index = 8;
			this.menuNoteProperties.Text = "&Note Properties";
			this.menuNoteProperties.Click += new System.EventHandler(this.menuNoteProperties_Click);
			// 
			// menuView
			// 
			this.menuView.Index = 2;
			this.menuView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuViewNoteProperties,
																					 this.menuViewToolBar,
																					 this.menuItem46,
																					 this.menuFullScreen});
			this.menuView.Text = "&View";
			this.menuView.Visible = false;
			// 
			// menuViewNoteProperties
			// 
			this.menuViewNoteProperties.Index = 0;
			this.menuViewNoteProperties.Text = "&Note Properties";
			this.menuViewNoteProperties.Click += new System.EventHandler(this.menuViewNoteProperties_Click);
			// 
			// menuViewToolBar
			// 
			this.menuViewToolBar.Index = 1;
			this.menuViewToolBar.Text = "Toolbar";
			this.menuViewToolBar.Visible = false;
			this.menuViewToolBar.Click += new System.EventHandler(this.menuViewToolBar_Click);
			// 
			// menuItem46
			// 
			this.menuItem46.Index = 2;
			this.menuItem46.Text = "-";
			this.menuItem46.Visible = false;
			// 
			// menuFullScreen
			// 
			this.menuFullScreen.Index = 3;
			this.menuFullScreen.Text = "&Full Screen";
			this.menuFullScreen.Visible = false;
			this.menuFullScreen.Click += new System.EventHandler(this.menuFullScreen_Click);
			// 
			// menuTools
			// 
			this.menuTools.Index = 3;
			this.menuTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuOptions,
																					  this.menuItem42,
																					  this.menuItem3});
			this.menuTools.Text = "&Tools";
			// 
			// menuOptions
			// 
			this.menuOptions.Index = 0;
			this.menuOptions.Text = "&Options...";
			this.menuOptions.Click += new System.EventHandler(this.menuOptions_Click);
			// 
			// menuItem42
			// 
			this.menuItem42.Index = 1;
			this.menuItem42.Text = "-";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuSavePreferences,
																					  this.menuRestorePreferences,
																					  this.menuItem4,
																					  this.menuDeletePreferences});
			this.menuItem3.Text = "&Manage Settings File";
			// 
			// menuSavePreferences
			// 
			this.menuSavePreferences.Index = 0;
			this.menuSavePreferences.Text = "Backup my preferences..";
			this.menuSavePreferences.Click += new System.EventHandler(this.menuSavePreferences_Click);
			// 
			// menuRestorePreferences
			// 
			this.menuRestorePreferences.Index = 1;
			this.menuRestorePreferences.Text = "&Restore my preferences...";
			this.menuRestorePreferences.Click += new System.EventHandler(this.menuRestorePreferences_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "-";
			// 
			// menuDeletePreferences
			// 
			this.menuDeletePreferences.Index = 3;
			this.menuDeletePreferences.Text = "Delete my preferences...";
			this.menuDeletePreferences.Click += new System.EventHandler(this.menuDeletePreferences_Click);
			// 
			// menuHelp
			// 
			this.menuHelp.Index = 4;
			this.menuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuShowHelpFile,
																					 this.menuTipsFromAuthor,
																					 this.menuItem48,
																					 this.menuSendComments,
																					 this.menuItem25,
																					 this.menuCheckUpdates,
																					 this.menuVisitHomePage,
																					 this.menuItem40,
																					 this.menuAbout});
			this.menuHelp.Text = "&Help";
			// 
			// menuShowHelpFile
			// 
			this.menuShowHelpFile.Index = 0;
			this.menuShowHelpFile.Shortcut = System.Windows.Forms.Shortcut.F1;
			this.menuShowHelpFile.Text = "&Help...";
			this.menuShowHelpFile.Click += new System.EventHandler(this.menuShowHelpFile_Click);
			// 
			// menuTipsFromAuthor
			// 
			this.menuTipsFromAuthor.Index = 1;
			this.menuTipsFromAuthor.Text = "&Tips from author...";
			this.menuTipsFromAuthor.Click += new System.EventHandler(this.menuTipsFromAuthor_Click);
			// 
			// menuItem48
			// 
			this.menuItem48.Index = 2;
			this.menuItem48.Text = "-";
			// 
			// menuSendComments
			// 
			this.menuSendComments.Index = 3;
			this.menuSendComments.Text = "Send your comments...";
			this.menuSendComments.Click += new System.EventHandler(this.menuSendComments_Click);
			// 
			// menuItem25
			// 
			this.menuItem25.Index = 4;
			this.menuItem25.Text = "-";
			// 
			// menuCheckUpdates
			// 
			this.menuCheckUpdates.Index = 5;
			this.menuCheckUpdates.Text = "Check for new updates...";
			this.menuCheckUpdates.Click += new System.EventHandler(this.menuCheckUpdates_Click);
			// 
			// menuVisitHomePage
			// 
			this.menuVisitHomePage.Index = 6;
			this.menuVisitHomePage.Text = "Visit Internet Homepage...";
			this.menuVisitHomePage.Click += new System.EventHandler(this.menuVisitHomePage_Click);
			// 
			// menuItem40
			// 
			this.menuItem40.Index = 7;
			this.menuItem40.Text = "-";
			// 
			// menuAbout
			// 
			this.menuAbout.Index = 8;
			this.menuAbout.Text = "&About...";
			this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
			// 
			// openSettingsFileDialog
			// 
			this.openSettingsFileDialog.DefaultExt = "config.npx";
			this.openSettingsFileDialog.Filter = "NotepadX Settings files (*.config.npx)|*.config.npx|All files (*.*)|*.*";
			// 
			// saveSettingsFileDialog
			// 
			this.saveSettingsFileDialog.DefaultExt = "config.npx";
			this.saveSettingsFileDialog.FileName = "notepadx_settings_backup";
			this.saveSettingsFileDialog.Filter = "NotepadX Settings files (*.config.npx)|*.config.npx|All files (*.*)|*.*";
			// 
			// openDocumentExternalChangeWatcher
			// 
			this.openDocumentExternalChangeWatcher.EnableRaisingEvents = true;
			this.openDocumentExternalChangeWatcher.NotifyFilter = System.IO.NotifyFilters.LastWrite;
			this.openDocumentExternalChangeWatcher.SynchronizingObject = this;
			this.openDocumentExternalChangeWatcher.Changed += new System.IO.FileSystemEventHandler(this.openDocumentExternalChangeWatcher_Changed);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(808, 537);
			this.Controls.Add(this.mainPanel);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.toolBar1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu1;
			this.Name = "MainForm";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Move += new System.EventHandler(this.Form1_Move);
			this.Closed += new System.EventHandler(this.Form1_Closed);
			((System.ComponentModel.ISupportInitialize)(this.editorFormatStatusPanel)).EndInit();
			this.mainPanel.ResumeLayout(false);
			this.rightPanel.ResumeLayout(false);
			this.childNotesViewerPanel.ResumeLayout(false);
			this.leftPanel.ResumeLayout(false);
			this.notePropertiesPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.openDocumentExternalChangeWatcher)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] commandLineRawArgs) 
		{
			MainForm mainFormInstance = new MainForm();
			mainFormInstance.CommandLineRawArgs = commandLineRawArgs;
			Application.Run(mainFormInstance);
		}

		public INoteEditor CurrentNoteEditor
		{
			get
			{
				return m_currentNoteEditor;
			}
			set
			{
				if (value != m_currentNoteEditor)
				{
					if (m_currentNoteEditor != null)
					{
						//hide current editor
						m_currentNoteEditor.IsVisible = false;
						m_currentNoteEditor.ResetAll();	//Remove content from memory
						m_currentNoteEditor = null;
					}
					
					m_currentNoteEditor = value;
				}	

				if (m_currentNoteEditor != null)
				{
					m_currentNoteEditor.ResetAll();	//Remove previous content from memory
					m_currentNoteEditor.IsVisible = true;
				}
			}
		}

		#region Menu and toolbar handlers
		private void ShowHelpFileHandler()
		{
			Help.ShowHelp(this,  (new AssemblyAttributeInfo()).HelpFileName);
		}
		private void ShowTipsHandler()
		{
			Help.ShowHelp(this,  (new AssemblyAttributeInfo()).HelpFileName, HelpNavigator.Topic, "quick_tips.htm");
		}
		private void AddNoteHandler()
		{
			m_notesTreeEditor.AddNewChildNoteForSelectedNode();
		}
		private void SendCommentsHandler()
		{
			Process.Start((new AssemblyAttributeInfo()).SendCommentsUrl);
		}
		private void VisitHomePageHandler()
		{
			Process.Start((new AssemblyAttributeInfo()).ProductHomepageUrl);
		}
		private void CheckProductUpdatesHandler()
		{
			Process.Start((new AssemblyAttributeInfo()).CheckProductUpdatesUrl + "?clientversion=" + (new AssemblyAttributeInfo()).BuildVersion);
			this.LastUpdateCheckDateTime = DateTime.Now;			
		}
		private void AboutFormHandler()
		{
			using(AboutForm newAboutForm = new AboutForm())
			{
				newAboutForm.ShowDialog();
			}
		}
		private void AddNoteHandler(string noteFormat)
		{
			m_notesTreeEditor.AddNewChildNoteForSelectedNode(noteFormat);
		}

		public string AuthorEmailAddress
		{
			get
			{
				return m_NotepadXApplicationSettings.GetSetting("Author Info", "Author Email Address", string.Empty);
			}
			set
			{
				m_NotepadXApplicationSettings.SetSetting("Author Info", "Author Email Address", value, true);
			}
		}
		public DateTime LastUpdateCheckDateTime
		{
			get
			{
				return DateTime.Parse(m_NotepadXApplicationSettings.GetSetting("Last Values", "Update Check Date Time", CommonFunctions.DateTimeToString(DateTime.MinValue)));
			}
			set
			{
				m_NotepadXApplicationSettings.SetSetting("Last Values", "Update Check Date Time",CommonFunctions.DateTimeToString(value), true);
			}
		}
		public string AuthorFullName
		{
			get
			{
				return m_NotepadXApplicationSettings.GetSetting("Author Info", "Author Full Name", string.Empty);
			}
			set
			{
				m_NotepadXApplicationSettings.SetSetting("Author Info", "Author Full Name", value, true);
			}
		}
		public string AuthorID
		{
			get
			{
				return m_NotepadXApplicationSettings.GetSetting("Author Info", "Author ID", CommonFunctions.GetLoggedInUserID());
			}
			set
			{
				m_NotepadXApplicationSettings.SetSetting("Author Info", "Author ID", value, true);
			}
		}

		private void ShowApplicationSettingsHandler()
		{
			AppOptionsForm optionsForm = new AppOptionsForm();
			optionsForm.NotepadXApplicationSettingsToUse = m_NotepadXApplicationSettings;
			PropertyBag bag = optionsForm.ApplicationPropertiesInfo;

			bag.Properties.Add(new PropertySpec("Run In Background When Closed", typeof(bool), "Preferences", "Minimize in system tray as icon when you click close button. To exit, click File > Exit in this setting.", 
				bool.Parse(m_NotepadXApplicationSettings.GetSetting("Preferences", "Run In Background When Closed", false.ToString()))));
			bag.Properties.Add(new PropertySpec("Auto Open Last Document", typeof(bool), "Preferences", "Automatically open the last document when starting the NotepadX", 
				bool.Parse(m_NotepadXApplicationSettings.GetSetting("Preferences", "Auto Open Last Document", true.ToString()))));
			bag.Properties.Add(new PropertySpec("Max Recent Document Count", typeof(System.UInt32), "Preferences", "How many last opened documents should be kept in Recent Documents list in File menu", 
				System.UInt32.Parse(m_NotepadXApplicationSettings.GetSetting("Preferences", "Max Recent Document Count", 10.ToString()))));
			bag.Properties.Add(new PropertySpec("Expire Password After (minutes)", typeof(System.UInt32), "Preferences", "For notes that you have secured with password, for how long NotepadX should remember the password you entered so you don't have to enter them again. Enter 0 to force ask password everytime.", 
				this.IntervalAfterPasswordExpires));
			bag.Properties.Add(new PropertySpec("Auto Save On Exit", typeof(bool), "Preferences", "Automatically save the document on exiting application", 
				bool.Parse(m_NotepadXApplicationSettings.GetSetting("Preferences", "Auto Save On Exit", false.ToString()))));
			bag.Properties.Add(new PropertySpec("Remember Window Size", typeof(bool), "Preferences", "Remembers the last size and position of application window", 
				bool.Parse(m_NotepadXApplicationSettings.GetSetting("Preferences", "Remember Window Size", true.ToString()))));
			bag.Properties.Add(new PropertySpec("File Name", typeof(string), "Last Values", "Last opened file", 
				m_NotepadXApplicationSettings.GetSetting("Last Values", "File Name", "")));
			bag.Properties.Add(new PropertySpec("Update Check Date Time", typeof(System.DateTime), "Last Values", "When was the last update check made? Set this to future date to stop this checks. Set it to date 30 days past now and restart program to check for updates.", 
				this.LastUpdateCheckDateTime));
			bag.Properties.Add(new PropertySpec("Author ID", typeof(string), "Author Info", "Unique name that will help identify author of NotepadX documents. By default this is your loggin name.", 
				this.AuthorID));
			bag.Properties.Add(new PropertySpec("Author Full Name", typeof(string), "Author Info", "Name of author who creates, modifies documents in NotepadX", 
				this.AuthorFullName));
			bag.Properties.Add(new PropertySpec("Author Email", typeof(string), "Author Info", "Email of author who creates, modifies documents in NotepadX", 
				this.AuthorEmailAddress));

			optionsForm.RefreshPropertyDisplay();
			m_NotepadXApplicationSettings.Save();
			if (optionsForm.ShowDialog() == DialogResult.OK)
			{
				m_NotepadXApplicationSettings.Save();
				UpdateFlagsFromNotepadXApplicationSettings();
			}
			else
				m_NotepadXApplicationSettings.ReloadFromFile(true);
		}
		private void ShowHelpHandler()
		{
			ShowHelpFileHandler();
		}
		private void CreateNewDocumentHandler()
		{
			CreateNewCateNotesDocument();
		}
		private void OpenDocumentHandler()
		{
			if (openDocumentDialog.ShowDialog() == DialogResult.OK)
			{
				OpenCateNotesDocument(openDocumentDialog.FileName, null);
			}
		}
		private void OpenSampleDocumentHandler()
		{
			OpenCateNotesDocument(GetSampleFileName(), null);
		}
		private void RemoveNoteHandler()
		{
			m_notesTreeEditor.RemoveNoteForSelectedNote();
		}
		private void SaveCatNoteDocumentHandler()
		{
			SaveCateNoteDocument();
		}
		private void ShowHideToolBarHandler()
		{
			toolBar1.Visible = !toolBar1.Visible;
		}
		private void ToggleFullScreenMode()
		{
			m_isFullScreenMode = !m_isFullScreenMode;
			toolBar1.Visible = !m_isFullScreenMode;
			foreach(MenuItem topMenu in mainMenu1.MenuItems) topMenu.Visible = !m_isFullScreenMode;
			statusBar1.Visible = !m_isFullScreenMode;
			this.WindowState = (m_isFullScreenMode?FormWindowState.Maximized:FormWindowState.Normal);
			this.ControlBox = !m_isFullScreenMode;
			this.MaximizeBox = !m_isFullScreenMode;
			this.MinimizeBox = !m_isFullScreenMode;
		}
		private void NotePropertiesHandler()
		{
			m_isNotePropertiesShown = !m_isNotePropertiesShown;
			notePropertiesPanel.Visible = m_isNotePropertiesShown;
			tbtnNodeProperties.Pushed = m_isNotePropertiesShown;

			if (notePropertiesPanel.Visible == false)
			{
				selectedNotePropertyEditor.NoteToDisplay = null;
			}
			else
			{
				selectedNotePropertyEditor.NoteToDisplay = m_notesTreeEditor.GetCatNoteDetailForSelectedNode();
			}
		}
		private void SetReminderHandler()
		{
			CommonFunctions.ShowNotImplementedMessage(tbtnSetReminder.Text);
		}
		private void OpenFolderHandler()
		{
			if (m_NotepadXDocument.FileName != "") 
			{
				string folderPathToOpen = Path.GetDirectoryName(m_NotepadXDocument.FileName);
				Process.Start(folderPathToOpen);
			}
			else
				MessageBox.Show("This document is not saved in file yet. Please save this document to file first");
		}
		private void RefreshDocumentHandler()
		{
			if (m_NotepadXDocument.FileName != string.Empty)
			{
				OpenCateNotesDocument(m_NotepadXDocument.FileName, m_notesTreeEditor.GetIdForSelectedNode());
			}
			else
			{
				MessageBox.Show ("This document can not be reloaded because it is not yet saved in file");
			}
		}
		private void MakeReadOnlyNoteHandler()
		{
			CatNoteDetail selectedCatNoteDetail = m_notesTreeEditor.GetCatNoteDetailForSelectedNode();
			if (selectedCatNoteDetail != null)
			{
				selectedCatNoteDetail.IsReadOnly = !selectedCatNoteDetail.IsReadOnly;
				UpdateNoteEditorForSelectedTreeNode(false);
			}
		}
		private void ExitWithoutSavingHandler()
		{
			m_isNoSaveWhileExit = true;
			this.Close();
		}
		private void ExitHandler()
		{
			m_isNoSaveWhileExit = false;
			this.Close();
		}
		private void MakeSecureHandler()
		{
			TreeNode selectedNode = m_notesTreeEditor.SelectedNode;
			if (selectedNode != null)
			{
				bool isChangeChilds;
				if (selectedNode.Nodes.Count > 0)
				{
					isChangeChilds = (MessageBox.Show("Do you wish to change this security setting for other notes under this note?", "Apply To Child Notes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,MessageBoxDefaultButton.Button1)==DialogResult.Yes);
				}
				else isChangeChilds = false;

				//Ask password
				string password = null;
				if (GetPasswordFromUser(ref password)==true)
				{
					try
					{
						ToggleSecuritySettingForTreeNode(selectedNode, isChangeChilds, password);
					}
					catch (System.Security.SecurityException noteSecurityException)
					{
						MessageBox.Show (noteSecurityException.Message);
					}
				}
					
				UpdateNoteEditorForSelectedTreeNode(false);
			}
		}
		private void UnimplementedFunctionalityHandler(string functionalityName)
		{
			CommonFunctions.ShowNotImplementedMessage(functionalityName);
		}
		#endregion
		
		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button == tbtnAddCategory)
			{
				AddNoteHandler();
			}
			else if (e.Button == tbtnHelp)
			{
				ShowHelpHandler();
			}
			else if (e.Button == tbtnNewDocument )
			{
				CreateNewDocumentHandler();
			}
			else if(e.Button == tbtnOpenDocument)
			{
				OpenDocumentHandler();
			}
			else if (e.Button == tbtnRemoveCategory )
			{
				RemoveNoteHandler();
			}
			else if (e.Button == tbtnSaveDocument )
			{
				SaveCatNoteDocumentHandler();
			}
			else if (e.Button == tbtnNodeProperties) 
			{
				NotePropertiesHandler();
			}
			else if (e.Button == tbtnSetReminder)
			{
				SetReminderHandler();
			}
			else if (e.Button == tbtnRefreshDocument)
			{
				RefreshDocumentHandler();
			}
			else if (e.Button == tbtnReadOnlyNote)
			{
				MakeReadOnlyNoteHandler();
			}
			else if (e.Button == tbtnExit)
			{
				ExitWithoutSavingHandler();
			}
			else if (e.Button == tbtnSecuredNote)
			{
				MakeSecureHandler();
			}
			else if (e.Button == tbtnHelp)
			{
				ShowHelpHandler();
			}
			else
			{
				UnimplementedFunctionalityHandler(e.Button.Text);
			}
		}
		
		
		private void ToggleSecuritySettingForTreeNode(TreeNode nodeToChange, bool isChangeChilds, string password)
		{
			CatNoteDetail selectedCatNoteDetail =m_notesTreeEditor.GetCatNoteDetailForNode(nodeToChange);
			if (selectedCatNoteDetail != null)
			{
				selectedCatNoteDetail.PasswordForEncryptedNote = password;
				selectedCatNoteDetail.IsEncrypted = !selectedCatNoteDetail.IsEncrypted;
					
				if (m_notesTreeEditor.SelectedNode.Nodes.Count > 0)
				{
					if (isChangeChilds==true)
					{
						foreach(TreeNode childNodeToChange in nodeToChange.Nodes)
						{
							ToggleSecuritySettingForTreeNode(childNodeToChange, isChangeChilds, password);
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

		private System.UInt32 IntervalAfterPasswordExpires
		{
			get
			{
				return System.UInt32.Parse(m_NotepadXApplicationSettings.GetSetting("Preferences", "Expire Password After (minutes)", 60.ToString()));
			}
			set
			{
				m_NotepadXApplicationSettings.SetSetting("Preferences", "Expire Password After (minutes)", value.ToString(), true);
				if (m_NotepadXDocument != null)
					m_NotepadXDocument.Configuration.SavedPasswordsForEncryptedNotes.IntervalAfterExpirePasswords = value;
			}
		}

		private bool GetAuthorInformationFromUser(DocumentAuthorInformation authorInfo)
		{
			AuthorInformationForm thisAuthorInformationForm = new AuthorInformationForm();
			thisAuthorInformationForm.SetAuthorInfo(authorInfo.AuthorID, authorInfo.AuthorFullName, authorInfo.AuthorEmailAddress);
			if (thisAuthorInformationForm.ShowDialog() == DialogResult.OK)
			{
				authorInfo.SetAuthorInfo(thisAuthorInformationForm.AuthorID, thisAuthorInformationForm.AuthorFullName, thisAuthorInformationForm.AuthorEmailAddress);
				return true;
			}
			else return false;
		}

		private void OpenCateNotesDocument(string fileName, string noteIdToSelect)
		{
			LastUsedFileNameInConfiguration = fileName;
			UpdateMRU(fileName);
			m_NotepadXDocument = new NotepadXDocument(fileName, new NotepadXConfiguration(new DocumentAuthorInformation(this.AuthorID, this.AuthorFullName, this.AuthorEmailAddress)));
			m_NotepadXDocument.Configuration.SavedPasswordsForEncryptedNotes.IntervalAfterExpirePasswords = this.IntervalAfterPasswordExpires;

			m_notesTreeEditor.CatNoteDocumentToUse = m_NotepadXDocument;
			if ((noteIdToSelect == null)||(noteIdToSelect == "")) noteIdToSelect = m_NotepadXDocument.NoteBookmark;
			m_notesTreeEditor.RefreshTreeFromCatNoteDocumentAndSelectNote(noteIdToSelect);
			HookupFileWatcherWithOpenedDocument();
		}

		private void HookupFileWatcherWithOpenedDocument()
		{
			if (m_NotepadXDocument.FileName != string.Empty)
			{
				openDocumentExternalChangeWatcher.EnableRaisingEvents = false;
				openDocumentExternalChangeWatcher.Path = Path.GetDirectoryName(m_NotepadXDocument.FileName);
				openDocumentExternalChangeWatcher.Filter = Path.GetFileName(m_NotepadXDocument.FileName);
				openDocumentExternalChangeWatcher.EnableRaisingEvents = true;
			}
			else
			{
				openDocumentExternalChangeWatcher.EnableRaisingEvents = false;
			}
		}

		private void EnableDisableUIForReadOnlyDocument()
		{
			m_notesTreeEditor.LabelEdit = !m_NotepadXDocument.IsReadonly;
			tbtnAddCategory.Enabled=!m_NotepadXDocument.IsReadonly;
			tbtnReadOnlyNote.Enabled =!m_NotepadXDocument.IsReadonly;
			tbtnRemoveCategory.Enabled =!m_NotepadXDocument.IsReadonly;
			tbtnSecuredNote.Enabled =!m_NotepadXDocument.IsReadonly;
			tbtnSetReminder.Enabled =!m_NotepadXDocument.IsReadonly;
		}

		private void CreateNewCateNotesDocument()
		{
			m_NotepadXDocument = new NotepadXDocument(new NotepadXConfiguration(new DocumentAuthorInformation(this.AuthorID, this.AuthorFullName, this.AuthorEmailAddress)));
			m_NotepadXDocument.Configuration.SavedPasswordsForEncryptedNotes.IntervalAfterExpirePasswords = this.IntervalAfterPasswordExpires;

			m_notesTreeEditor.CatNoteDocumentToUse = m_NotepadXDocument;
			m_notesTreeEditor.RefreshTreeFromCatNoteDocument(string.Empty);
			HookupFileWatcherWithOpenedDocument();
		}

		public void GenericApplicationExceptionHandler(object sender, System.Threading.ThreadExceptionEventArgs t) 
		{
			if ((t.Exception is System.UnauthorizedAccessException)
				|| (t.Exception is NotepadX.ReadOnlyDocumentException)
				|| (t.Exception is NotepadX.ReadOnlyNoteException))
			{
				MessageBox.Show("This operation is not allowed." + "\n\n" + t.Exception.Message);
			}
			else
			{
				MessageBox.Show (t.Exception.ToString() + "\n\n" + t.Exception.StackTrace, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private string GetSampleFileName()
		{
			const string DEFAULT_SAMPLE_FILE_NAME = "\\SAMPLE.npx";		
			return Path.GetDirectoryName(Application.ExecutablePath) + DEFAULT_SAMPLE_FILE_NAME;
		}
		
		private void UpdateFlagsFromNotepadXApplicationSettings()
		{
			m_isAutoSaveWhileExit = bool.Parse(m_NotepadXApplicationSettings.GetSetting("Preferences", "Auto Save On Exit", false.ToString()).ToLower());		
			m_rememberWindowLayout = bool.Parse(m_NotepadXApplicationSettings.GetSetting("Preferences", "Remember Window Size", true.ToString()));
			m_AutoOpenLastDocument = bool.Parse(m_NotepadXApplicationSettings.GetSetting("Preferences", "Auto Open Last Document", true.ToString()));
			m_MinimizeOnClose = bool.Parse(m_NotepadXApplicationSettings.GetSetting("Preferences", "Run In Background When Closed", false.ToString()));
			this.IntervalAfterPasswordExpires = this.IntervalAfterPasswordExpires; //force setting in document
			mnuRecentDocuments.MaxMRUCount = this.MaxMRUCount;
		}
				
		private void DoFirstTimeSetup()
		{
			//Register file type extentions
			CommonFunctions.AssociateFileTypeExtention("npx", "text/prs.sytelus.notepadx+xml", "NotepadX Document", Application.ExecutablePath + " -file \"%L\"");
			
			//Get author info
			DocumentAuthorInformation authorInfo = new DocumentAuthorInformation();
			authorInfo.SetAuthorInfo(this.AuthorID, this.AuthorFullName, this.AuthorEmailAddress);
			if (GetAuthorInformationFromUser(authorInfo)==true)
			{
				this.AuthorID = authorInfo.AuthorID;
				this.AuthorFullName = authorInfo.AuthorFullName;
				this.AuthorEmailAddress = authorInfo.AuthorEmailAddress;
			}
			else {};	//user presed cancel
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			StringDictionary validSwitchesAndDescription = new StringDictionary();
			validSwitchesAndDescription.Add("file", "Document file to open");
			validSwitchesAndDescription.Add("noteid", "Note ID to select after opening the document");
			validSwitchesAndDescription.Add("configprofile", "Application configuration profile to use");
			validSwitchesAndDescription.Add("autosave", "true if file to be saved when application is closed or false");
			StringDictionary commandLineOptions = CommonFunctions.CommandLineParameterArrayToOptions(CommandLineRawArgs, new string[] {"file", "noteid"}, validSwitchesAndDescription);

			m_NotepadXApplicationSettings = new NotepadXApplicationSettings();
			bool wasSettingsDocumentCreated = m_NotepadXApplicationSettings.OpenOrCreateSettingsDocument(true);
			
			m_NotepadXApplicationSettings._UsageStatistics_ApplicationLoadedCounter += 1;
			m_NotepadXApplicationSettings._UsageStatistics_ApplicationLastLoadedOn = DateTime.Now;

			//This should be the first option to process to
			//init CurrentConfigurationSet
			if (commandLineOptions["configprofile"] != null)
			{
				m_NotepadXApplicationSettings.CurrentConfigurationSet = commandLineOptions["configprofile"];
			} 
			else {} //leave CurrentConfigurationSet to default value
			UpdateFlagsFromNotepadXApplicationSettings();

			if (wasSettingsDocumentCreated)
			{
				//We are running for the first time?
				DoFirstTimeSetup();
			}

			string commandLineHelp = CommonFunctions.GetHelpMessageIfHelpSwitchInCommandLine (commandLineOptions, validSwitchesAndDescription);
			if (commandLineHelp != string.Empty)
			{
				MessageBox.Show(this, commandLineHelp, "Command Line Help", MessageBoxButtons.OK, MessageBoxIcon.Information);

				//Previous instance was activated, exit this instance
				ExitApplicationForced();
			}

			string fileNameToOpen = "";
			string noteIdToSelect = "";

			if (commandLineOptions["autosave"] != null)
			{
				m_isAutoSaveWhileExit = bool.Parse(commandLineOptions["configprofile"].ToLower());
			} 
			else
			{} //leave CurrentConfigurationSet to default value from app settings
			
			if (commandLineOptions["file"] != null)
			{
				fileNameToOpen = commandLineOptions["file"];
			}
			else
			{
				//Application.StartupPath is not used because it's not allowed when running app from n/w
				string lastusedFilename = LastUsedFileNameInConfiguration;
				if (lastusedFilename != null)
				{
					if (File.Exists(lastusedFilename)==false)
						lastusedFilename = GetSampleFileName();
				}
				else
					lastusedFilename = GetSampleFileName();
				
				fileNameToOpen = lastusedFilename;
			}
			
			if (commandLineOptions["noteid"] != null)
				noteIdToSelect = commandLineOptions["noteid"];

			
			//Create navigator
			m_notesTreeEditor = new TreeEditor();
			treeEditorContextMenu.MenuItems.AddRange((MenuItem[])( new ArrayList(menuEdit.CloneMenu().MenuItems).ToArray(typeof(MenuItem))));
			if (treeEditorContextMenu.MenuItems.Count>1)
			{
				treeEditorContextMenu.MenuItems.RemoveAt(0);
			}
			
			ctxMenuAddNote.MenuItems.AddRange((MenuItem[])( new ArrayList(menuAddNote.CloneMenu().MenuItems).ToArray(typeof(MenuItem))));
			
			sysTrayContextMenu.MenuItems.AddRange(new MenuItem[] {menuSave.CloneMenu(), menuOpenFolder.CloneMenu(), menuSeperator.CloneMenu(), menuOptions.CloneMenu(), menuHelp.CloneMenu(), menuSeperator.CloneMenu(), menuExit.CloneMenu()});

			m_notesTreeEditor.ContextMenu = treeEditorContextMenu;
			m_notesTreeEditor.TreeReload += new TreeReloadHandler(notesTreeEditor_TreeReload);
			m_notesTreeEditor.ChooseNewNoteFormat += new ChooseNewNoteFormatHandler(notesTreeEditor_ChooseNewNoteFormat);
			m_notesTreeEditor.AfterSelect += new TreeViewEventHandler(m_notesTreeEditor_AfterSelect);
			m_notesTreeEditor.DefaultNewNoteTitle = GetDefaultNewNoteTitle();
			navigationPanel.Controls.Add(m_notesTreeEditor);			
			m_notesTreeEditor.Visible = true;
			m_notesTreeEditor.Dock = DockStyle.Fill;

			
			CreateEditors();

			//If everything goes fine, hook up the generic exception handler
			Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(this.GenericApplicationExceptionHandler);
			//Application.ApplicationExit += new System.

			//Load MRU
			((MRUMenuItem)mnuRecentDocuments).Initialize(this.MRUDataInConfiguration, this.MaxMRUCount);

			if ((File.Exists(fileNameToOpen)==true)&& (m_AutoOpenLastDocument==true))
				OpenCateNotesDocument(fileNameToOpen, noteIdToSelect);
			else
				CreateNewCateNotesDocument();
			
			LoadWindowsLayoutSettings();

			//See if update warning is needed
			if (DateTime.Now.Subtract(this.LastUpdateCheckDateTime).Days > 30)
			{
				if (MessageBox.Show(this, "There might be new updates available for this software having more features. Do you wish to check for it?", "Check For Updates", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)==DialogResult.Yes)
				{
					this.CheckProductUpdatesHandler();
				}
			}
		}

		private void ExitApplicationForced()
		{
			Environment.Exit(0);
			Application.ExitThread();
			Application.Exit();
		}
		
		private void LoadWindowsLayoutSettings()
		{
			if (m_rememberWindowLayout == true)
			{
				try
				{
					this.WindowState = FormWindowState.Normal;
					this.Width = int.Parse (m_NotepadXApplicationSettings.GetSetting ("Last Values", "Window Width", this.Width.ToString()));
					this.Height = int.Parse (m_NotepadXApplicationSettings.GetSetting ("Last Values", "Window Hight", this.Height.ToString()));
					splitter1.SplitPosition =  int.Parse (m_NotepadXApplicationSettings.GetSetting ("Last Values", "Splitter Location", "125"));
					this.WindowState =(FormWindowState) Enum.Parse(this.WindowState.GetType(), m_NotepadXApplicationSettings.GetSetting ("Last Values", "Window State", "Normal"));
				}
				catch (Exception e1)
				{
				}
			}
		}
		private void SaveWindowsLayoutSettings()
		{
			if (m_rememberWindowLayout == true)
			{
				try
				{
					//Save window settings
					m_NotepadXApplicationSettings.SetSetting("Last Values", "Window State", this.WindowState.ToString(), false);
					if (this.WindowState == FormWindowState.Normal)
					{
						m_NotepadXApplicationSettings.SetSetting("Last Values", "Window Width", this.Width.ToString(), false);
						m_NotepadXApplicationSettings.SetSetting("Last Values", "Window Hight", this.Height.ToString(), false);
						m_NotepadXApplicationSettings.SetSetting("Last Values", "Splitter Location", splitter1.Location.X.ToString(), false);
					}
					else
					{//Do not save width/height of minimized windows
					}
					m_NotepadXApplicationSettings.Save();
				}
				catch (Exception e1)
				{
					Debug.Assert(false, "Error while saving preferences", e1.ToString());
				}
			}
		}
		
		private void CreateEditors()
		{
			//Create default editors
			m_richNoteEditor = new RichTextEditor();
			editorPanel.Controls.Add(m_richNoteEditor);
			m_richNoteEditor.CurrentFormat = NoteFormat.FORMAT_DEFAULT;
			m_richNoteEditor.Dock = DockStyle.Fill;
			m_richNoteEditor.Visible = false;
				
			m_textNoteEditor = new RichTextEditor();
			editorPanel.Controls.Add(m_textNoteEditor);
			m_textNoteEditor.CurrentFormat = NoteFormat.FORMAT_TEXT;
			m_textNoteEditor.Dock = DockStyle.Fill;
			m_textNoteEditor.Visible = false;

			m_worksheetNoteEditor = new WorksheetEditor();
			editorPanel.Controls.Add(m_worksheetNoteEditor);
			m_worksheetNoteEditor.Dock = DockStyle.Fill;
			m_worksheetNoteEditor.Visible = false;
			
			m_hierarchyEditor = new TreePropertyEditor();
			editorPanel.Controls.Add(m_hierarchyEditor);
			m_hierarchyEditor.Dock = DockStyle.Fill;
			m_hierarchyEditor.Visible = false;
		}

		private void UpdateFormCaption()
		{
			string productName = "NotepadX";
			try
			{
				productName = Application.ProductName;;
			}
			catch (Exception ex)
			{
				//Ignore exception - this occures when running exe from n/w because it doesn't have enough access rights
			}
			
			if (productName == null) productName = "";
			
			if (m_NotepadXDocument.FileName == string.Empty)
			{
				this.Text = productName + " - " + "<New Document>";
			}
			else
			{
				this.Text = productName + " - " + m_NotepadXDocument.FileName;
			}
			
			if (m_NotepadXDocument.IsReadonly == true)
			{
				this.Text += " (Read Only)";
			}
		}

		private void UpdateMRU(string fileName)
		{
			((MRUMenuItem)mnuRecentDocuments).FileOpened(fileName);
			this.MRUDataInConfiguration = ((MRUMenuItem)mnuRecentDocuments).MRUData;
		}

		private string LastUsedFileNameInConfiguration
		{
			get
			{
				return m_NotepadXApplicationSettings.GetSetting ("Last Values", "File Name");
			}
			set
			{
				m_NotepadXApplicationSettings.SetSetting ("Last Values", "File Name", value, true);
			}
		}

		private System.UInt32 MaxMRUCount
		{
			get
			{
				return System.UInt32.Parse(m_NotepadXApplicationSettings.GetSetting("Preferences", "Max Recent Document Count", 10.ToString()));
			}
			set
			{
				m_NotepadXApplicationSettings.SetSetting ("Preferences", "Max Recent Document Count", value.ToString(), true);
			}
		}

		private string MRUDataInConfiguration
		{
			get
			{
					return m_NotepadXApplicationSettings.GetSetting ("Last Values", "MRUData");
			}
			set
			{
					m_NotepadXApplicationSettings.SetSetting ("Last Values", "MRUData", value, true);
			}
		}
		
		private void Form1_Closed(object sender, System.EventArgs e)
		{
			SaveCurrentCatNoteDetailChanges();
			
			bool isSaveCatNoteDocument;
			
			if (m_isAutoSaveWhileExit == true)
				isSaveCatNoteDocument = true;
			else
			{
				if ((m_NotepadXDocument.Configuration.IsDirty == true) && (m_isNoSaveWhileExit == false))
					isSaveCatNoteDocument = (MessageBox.Show("Do you wish to save the changes?", "Save Document", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes);
				else
					isSaveCatNoteDocument = false;
			}
			
			if (isSaveCatNoteDocument == true)
				SaveCateNoteDocument();
			
			SaveWindowsLayoutSettings();
			
			m_NotepadXDocument = null;
		
			//sysTrayNotifyIcon.Visible = false;
			m_NotepadXApplicationSettings._UsageStatistics_ApplicationClosedCounter += 1;
			m_NotepadXApplicationSettings._UsageStatistics_ApplicationLastClosedOn = DateTime.Now;

			m_NotepadXApplicationSettings = null;		
		}

		private void SaveCateNoteDocument()
		{
			openDocumentExternalChangeWatcher.EnableRaisingEvents = false;
			m_NotepadXDocument.FileName	= SaveCateNoteDocumentInteractive(m_NotepadXDocument.FileName);	

			if (m_NotepadXDocument.FileName != string.Empty)
			{
				UpdateFormCaption();
			}
			HookupFileWatcherWithOpenedDocument();
		}

		private string SaveCateNoteDocumentInteractive(string fileNameToSaveTo)
		{
			SaveCurrentCatNoteDetailChanges();
			
			string fileNameSelected = CommonFunctions.SelectFileUsingSaveDialog(saveDocumentDialog, fileNameToSaveTo);

			//If file name has been selected
			if (fileNameSelected != string.Empty)
			{
				m_NotepadXDocument.Save(fileNameSelected);
			}

			return fileNameSelected;
		}

		private void SaveLastCatNoteDetailChanges()
		{
			//save previously set note's content
			if ((m_NotepadXDocument.NoteBookmark != "") && (CurrentNoteEditor != null))
			{
				if ((CurrentNoteEditor.IsModified == true) && (CurrentNoteEditor.IsReadOnly == false) && (CurrentNoteEditor.CurrentNoteID != ""))
				{
					CatNoteDetail modifiedCatNoteDetail = m_NotepadXDocument.GetNoteById(m_NotepadXDocument.NoteBookmark);
					SetNoteContentWithUserPasswordInteraction(modifiedCatNoteDetail, CurrentNoteEditor.GetNoteContent());
				}
			}
		}

		private string GetNoteContentWithUserPasswordInteraction(CatNoteDetail note)
		{
			string noteContent;
			if (note.IsEncrypted == true)
			{
				if (note.PasswordForEncryptedNote == null)
				{
					string password = null;
					if (GetPasswordFromUser(ref password) == true)
					{
						note.PasswordForEncryptedNote = password;
					}
					else throw new System.Security.SecurityException("Password required for secured notes");
				}
			}
			//Get the decrypted content
			noteContent = note.Content;

			return noteContent;
		}
		private void SetNoteContentWithUserPasswordInteraction(CatNoteDetail note, string contentToSet)
		{
			if (note.IsEncrypted == true)
			{
				bool askPasswordAgain = false;
				do
				{
					do
					{
						if (note.PasswordForEncryptedNote == null)
						{
							string password = null;
							if (GetPasswordFromUser(ref password) == true)
							{
								note.PasswordForEncryptedNote = password;
							}
							else
							{
								askPasswordAgain = (MessageBox.Show(this, "Password must be provided to save this content. If you do not provide the password, changes you made will be lost. Do you want to provide password?" , "Password Not Provided", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes);
							}
						}
					} while ((askPasswordAgain==true)&&(note.PasswordForEncryptedNote == null));

					askPasswordAgain = false;
					if (note.PasswordForEncryptedNote != null)
					{
						try
						{
							note.Content = contentToSet;	
						}
						catch (Exception decryptException)
						{
							askPasswordAgain = (MessageBox.Show(this, "Password you provided does not matches the previously set password. Do you want to provide password again?\n\n Tip: If you want to change previously set password, first enter your old password then make this note unsecured and then make secured again." , "Incorrect Password", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes);
						}
					}
					else {}; //changes are lost
				} while (askPasswordAgain==true);
			}
			else
				note.Content = contentToSet;
		}


		private void SaveCurrentCatNoteDetailChanges()
		{
			if (CurrentNoteEditor != null)
			{
				if ((CurrentNoteEditor.IsModified == true) && (CurrentNoteEditor.IsReadOnly == false) && (CurrentNoteEditor.CurrentNoteID != ""))
				{
					CatNoteDetail modifiedCatNoteDetail = m_NotepadXDocument.GetNoteById(CurrentNoteEditor.CurrentNoteID);
					modifiedCatNoteDetail.Content = CurrentNoteEditor.GetNoteContent();
				}
			}
		}

		private void m_notesTreeEditor_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			////System.Diagnostics.Debug.WriteLine ("AfterSelect fired");
			UpdateFormCaption();
			UpdateNoteEditorForSelectedTreeNode(true);
		}

		private void UpdateNoteEditorForSelectedTreeNode(bool saveLastBookMarkedNodeFromEditor)
		{
			if (saveLastBookMarkedNodeFromEditor == true)
				SaveLastCatNoteDetailChanges();
			
			if (m_notesTreeEditor.SelectedNode != null)
			{
				string nodeId = (string) m_notesTreeEditor.SelectedNode.Tag;
				CatNoteDetail selectedCatNoteDetail = m_NotepadXDocument.GetNoteById(nodeId);
				
				if (notePropertiesPanel.Visible == true)
					selectedNotePropertyEditor.NoteToDisplay = selectedCatNoteDetail;
				
				INoteEditor editorToChoose = null;
				//Choose editor for this node
				switch (selectedCatNoteDetail.Format)
				{
					case NoteFormat.FORMAT_TEXT:
						editorToChoose = m_textNoteEditor;
						break;
					case NoteFormat.FORMAT_RTF:
						editorToChoose = m_richNoteEditor;
						break;
					case NoteFormat.FORMAT_WORKSHEET:
						editorToChoose = m_worksheetNoteEditor;
						break;
					case NoteFormat.FORMAT_HIERARCHY:
						editorToChoose = m_hierarchyEditor;
						break;
					default:
						editorToChoose = null;
						break;
				}		
				
				CurrentNoteEditor = editorToChoose;

				string noteContent = "Failed to show note content. there's something wrong.";
				bool isForceContentReadOnly = false;

				try
				{
					//Get the decrypted content
					noteContent = GetNoteContentWithUserPasswordInteraction(selectedCatNoteDetail);
				}
				catch (Exception decryptException)
				{
					noteContent = @"This note was secured with a password. 
You must enter the correct password to see it's content.
					
Following error occured:
" + decryptException.Message;
					isForceContentReadOnly = true;
				}
				
				//If no editor is available
				if (CurrentNoteEditor == null)
				{
					//Choose text editor to show message
					CurrentNoteEditor = m_textNoteEditor;
					noteContent = "The note you are trieng to view is in '" + selectedCatNoteDetail.Format + "' format. There is no editor available which can display this format.";
					isForceContentReadOnly = true;
				}
				
				CurrentNoteEditor.SetNoteContent(selectedCatNoteDetail.Id, selectedCatNoteDetail.Title, noteContent);
				
				bool isNoteReadOnly = (selectedCatNoteDetail.IsReadOnly || isForceContentReadOnly);
				CurrentNoteEditor.IsReadOnly = isNoteReadOnly;
				
				//Update toobar buttons
				tbtnReadOnlyNote.Pushed = isNoteReadOnly;
				tbtnSecuredNote.Pushed = selectedCatNoteDetail.IsEncrypted;
				
				m_NotepadXDocument.NoteBookmark = nodeId;
				
				editorFormatStatusPanel.Text = selectedCatNoteDetail.Format;
			}
			else
			{
				InvalidateCurrentEditor();
			}
		}

		private void InvalidateCurrentEditor()
		{
			selectedNotePropertyEditor.NoteToDisplay = null;
			
			//Choose text editor to show message
			CurrentNoteEditor = m_textNoteEditor;
			CurrentNoteEditor.IsReadOnly = true;

			CurrentNoteEditor.SetNoteContent("", "No Note Selected", "Select a note to view");
			CurrentNoteEditor.IsReadOnly = true;
			m_NotepadXDocument.NoteBookmark = string.Empty;
			editorFormatStatusPanel.Text = "<none>";
		}
		
		private void notesTreeEditor_TreeReload(object sender, EventArgs e)
		{
			InvalidateCurrentEditor();
			UpdateFormCaption();
			EnableDisableUIForReadOnlyDocument();
		}

		private void notesTreeEditor_ChooseNewNoteFormat(object sender, ChooseNewNoteFormatEventArgs e)
		{
			if (e.KeyCode == Keys.Insert)
			{
				if (e.Shift == true)
					e.SelectedNewNoteFormat = NoteFormat.FORMAT_TEXT;
				else if (e.Alt == true)
					e.SelectedNewNoteFormat = NoteFormat.FORMAT_WORKSHEET;
				else if (e.Control == true)
					e.SelectedNewNoteFormat = NoteFormat.FORMAT_HIERARCHY;
				else //default note
					e.SelectedNewNoteFormat = NoteFormat.FORMAT_DEFAULT;
			}
		}
		

		private void Form1_Move(object sender, System.EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				this.ShowInTaskbar = false;
			}
			else this.ShowInTaskbar = true;
		}

		private void sysTrayNotifyIcon_DoubleClick(object sender, System.EventArgs e)
		{
			ActivateThisInstance();
		}

		private void ActivateThisInstance()
		{
			this.Visible = true;
			this.ShowInTaskbar = true;
			this.WindowState = FormWindowState.Normal;
			this.Activate();
		}
		
		private string GetDefaultNewNoteTitle()
		{
			return m_NotepadXApplicationSettings.GetSetting("Default Values", "New Note Title", "*New Note*");
		}

		private void selectedNotePropertyEditor_NotePropertiesChanged(object sender, NotepadX.NotePropertiesChangedEventArgs e)
		{
			m_notesTreeEditor.UpdateTreeNode(e.ChangedNote);
			UpdateNoteEditorForSelectedTreeNode(false);
		}


		#region Menu click handlers
		private void menuNew_Click(object sender, System.EventArgs e)
		{
			CreateNewDocumentHandler();		
		}

		private void menuOpen_Click(object sender, System.EventArgs e)
		{
			OpenDocumentHandler();
		}

		private void menuOpenSample_Click(object sender, System.EventArgs e)
		{
			OpenSampleDocumentHandler();
		}

		private void menuRefresh_Click(object sender, System.EventArgs e)
		{
			SaveCurrentCatNoteDetailChanges();
			RefreshDocumentHandler();
		}

		private void menuSave_Click(object sender, System.EventArgs e)
		{
			SaveCatNoteDocumentHandler();
		}

		private void menuSaveAs_Click(object sender, System.EventArgs e)
		{
			SaveCateNoteDocumentInteractive(string.Empty);
		}

		private void menuOpenFolder_Click(object sender, System.EventArgs e)
		{
			OpenFolderHandler();
		}

		private void menuExit_Click(object sender, System.EventArgs e)
		{
			ExitHandler();
		}

		private void menuExitWithouSave_Click(object sender, System.EventArgs e)
		{
			ExitWithoutSavingHandler();
		}

		private void menuAddPlainTextNote_Click(object sender, System.EventArgs e)
		{
			AddNoteHandler(NoteFormat.FORMAT_TEXT);
		}

		private void menuAddNormalNote_Click(object sender, System.EventArgs e)
		{
			AddNoteHandler();
		}

		private void menuAddWorksheetNote_Click(object sender, System.EventArgs e)
		{
			AddNoteHandler(NoteFormat.FORMAT_WORKSHEET);
		}

		private void menuAddHierarchyNote_Click(object sender, System.EventArgs e)
		{
			AddNoteHandler(NoteFormat.FORMAT_HIERARCHY);
		}

		private void menuRemoveNote_Click(object sender, System.EventArgs e)
		{
			RemoveNoteHandler();
		}

		private void menuMakeSecureNote_Click(object sender, System.EventArgs e)
		{
			MakeSecureHandler();
		}

		private void menuMakeReadOnlyNote_Click(object sender, System.EventArgs e)
		{
			MakeReadOnlyNoteHandler();
		}

		private void menuSetReminder_Click(object sender, System.EventArgs e)
		{
			UnimplementedFunctionalityHandler("Set reminder");		
		}

		private void menuNoteProperties_Click(object sender, System.EventArgs e)
		{
			NotePropertiesHandler();
		}

		private void menuViewNoteProperties_Click(object sender, System.EventArgs e)
		{
			NotePropertiesHandler();
		}

		private void menuViewToolBar_Click(object sender, System.EventArgs e)
		{
			ShowHideToolBarHandler();
		}

		private void menuFullScreen_Click(object sender, System.EventArgs e)
		{
			ToggleFullScreenMode();		
		}

		private void menuSavePreferences_Click(object sender, System.EventArgs e)
		{
			string selectedFile = CommonFunctions.SelectFileUsingSaveDialog(saveSettingsFileDialog, string.Empty );
			if (selectedFile != string.Empty)
				m_NotepadXApplicationSettings.SaveCopy(selectedFile);
		}

		private void menuRestorePreferences_Click(object sender, System.EventArgs e)
		{
			if (openSettingsFileDialog.ShowDialog() == DialogResult.OK)
			{
				m_NotepadXApplicationSettings.LoadFromFile(openSettingsFileDialog.FileName);
				m_NotepadXApplicationSettings.Save();
			}
		}

		private void menuOptions_Click(object sender, System.EventArgs e)
		{
			ShowApplicationSettingsHandler();
		}

		private void menuShowHelpFile_Click(object sender, System.EventArgs e)
		{
			ShowHelpFileHandler();
		}

		private void menuTipsFromAuthor_Click(object sender, System.EventArgs e)
		{
			ShowTipsHandler();
		}

		private void menuSendComments_Click(object sender, System.EventArgs e)
		{
			SendCommentsHandler();
		}
		
		private void menuCheckUpdates_Click(object sender, System.EventArgs e)
		{
			CheckProductUpdatesHandler();
		}

		private void menuVisitHomePage_Click(object sender, System.EventArgs e)
		{
			VisitHomePageHandler();
		}

		private void menuAbout_Click(object sender, System.EventArgs e)
		{
			AboutFormHandler();
		}
		#endregion

		private void sysTrayNotifyIcon_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
		
		}

		private void sysTrayContextMenu_Popup(object sender, System.EventArgs e)
		{
		
		}

		private void mnuRecentDocuments_MRUClicked(object sender, System.EventArgs e)
		{
			OpenCateNotesDocument(((MenuItem)sender).Text, string.Empty);
		}

		//Credit: Dmitry Krakhmalnik (http://www.dotnet247.com/247reference/msgs/14/74770.aspx)
		protected override void WndProc(ref Message m)
		{
			const int WM_SYSCOMMAND = 0x0112;
			const int SC_CLOSE = 0xF060;
			if ((m.Msg == WM_SYSCOMMAND) && ((int) m.WParam == SC_CLOSE) && (m_MinimizeOnClose==true))
			{
				// User clicked close button
				this.WindowState =
					FormWindowState.Minimized;
				return;
			}
			base.WndProc(ref m);
		}

		private void menuDeletePreferences_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show(this, "This will force you to shutdown this application and you will loose any unsaved work as well as your settings. Do you want to continue?", "Critical Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2)==DialogResult.Yes)
			{
				m_NotepadXApplicationSettings.Delete();		
				ExitApplicationForced();
			}
		}

		private void openDocumentExternalChangeWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
		{
			if (MessageBox.Show (this, "The document " + Path.GetFileNameWithoutExtension(m_NotepadXDocument.FileName) + " is modified by another application. Do you wish to reload this document?", "Document Was Modified", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)==DialogResult.Yes)
			{
				RefreshDocumentHandler();
			}
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
	9. Shortcut keys for add/remove/edit categories (TreeView editor)
	10. Multilanguage enabled
	1. Read only notes UI implementation
	11. Secured enchrypted notes
	12. System tray icon on minimize
	44. If parent note is secured then childs are also secured (40 mins)
	21. Drag & drop nodes
	x1. Drag and drop text as a node
	40. Persist last selected node in doc (11 mins)
	x2. Run from n/w and CD ROM (40 mins)
	x3. Ignore save of config if error (5 mins)
	x4. Support for non editable read-only files (4 hr)
	x5. Multi instance warning
	x6. Exit without save toolbutton (3 hr)
	x7. Richtext note (shift + ins)
	x8. Multi-editor support
*/

/*
Todo:
	2. Attachments
	3. Custom note properties
	4. Date time modified & windows user name for each note
	5. Save As
	6. Back up
	7. Save selected nodes as XML
	8. Save selected node as text
	9. HTML editing and formatting toolbar
	10. Edit count
	12. Symbol selection
	13. Export to Outlook Notes
	14. Set reminders in Outlook
	15. File type and icon registration
	16. Find utility
	17. Recently opened notes list
	18. Merge two documents
	19. Export to Word, HTML
	20. Import from NoteKeeper
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
	39. Open from command line: {doc, noteIdToOpen}
	41. Ctrl + S hotkey
	45. All the menus of notepad
	46. Rename app to NotepadX
	47. Allow to store attachments in seperate file
	48. Do not ask password for childs if already asked for parent
	50. Implement AutoActuals
	51. view source
	52. Usage stats
	53. Allow command line params to be optional
	54. System-wide hotkey
	55. Load XML on another thread for fast app start
	56. Save settings file using IsolatedStorage
	57. Convert whole UI in to UserControl
	58. Dock anywhere editor, properties windows
	59. Allow to store objects in App settings
	60. Make settings to allow to restrict add and deleteSelf, deleteChild, updateSelf
	61. Implement ListView based notes navigator
*/


/*
Immediate next things to do:
-Elimiate error while editing node caps in read only
-Form layout: include properties pan, child notes pan
-Move most code from MainFrom to other lclasses
-RichTextEdit editor control seperate
-Create grid edit control
-include formating in richedit control
-attachments functionality
-IsDirty property in NotepadXDocument
*/