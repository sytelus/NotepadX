using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Sytel.NotepadX
{
	/// <summary>
	/// Summary description for AuthorInformationForm.
	/// </summary>
	public class AuthorInformationForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxAuthorID;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBoxAuthorFullName;
		private System.Windows.Forms.TextBox textBoxAuthorEmail;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AuthorInformationForm()
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
				if(components != null)
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
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxAuthorID = new System.Windows.Forms.TextBox();
			this.textBoxAuthorFullName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxAuthorEmail = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(2, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(55, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Author ID:";
			// 
			// textBoxAuthorID
			// 
			this.textBoxAuthorID.Location = new System.Drawing.Point(64, 58);
			this.textBoxAuthorID.Name = "textBoxAuthorID";
			this.textBoxAuthorID.Size = new System.Drawing.Size(304, 20);
			this.textBoxAuthorID.TabIndex = 5;
			this.textBoxAuthorID.Text = "";
			// 
			// textBoxAuthorFullName
			// 
			this.textBoxAuthorFullName.Location = new System.Drawing.Point(64, 82);
			this.textBoxAuthorFullName.Name = "textBoxAuthorFullName";
			this.textBoxAuthorFullName.Size = new System.Drawing.Size(304, 20);
			this.textBoxAuthorFullName.TabIndex = 1;
			this.textBoxAuthorFullName.Text = "";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(2, 82);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(59, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Full Name:";
			// 
			// textBoxAuthorEmail
			// 
			this.textBoxAuthorEmail.Location = new System.Drawing.Point(64, 106);
			this.textBoxAuthorEmail.Name = "textBoxAuthorEmail";
			this.textBoxAuthorEmail.Size = new System.Drawing.Size(304, 20);
			this.textBoxAuthorEmail.TabIndex = 2;
			this.textBoxAuthorEmail.Text = "";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(2, 106);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(36, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Email:";
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(-24, 130);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(416, 8);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(296, 145);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(216, 145);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "Ok";
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.label4.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.label4.Location = new System.Drawing.Point(0, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(376, 41);
			this.label4.TabIndex = 9;
			this.label4.Text = "This author information will be included in the documents you create or modify to" +
				" tracke changes. This is an optional information you need to provide and can be " +
				"changed any time later from Options menu.";
			// 
			// groupBox2
			// 
			this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox2.Location = new System.Drawing.Point(-20, 37);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(416, 8);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			// 
			// AuthorInformationForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(376, 174);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.textBoxAuthorEmail);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBoxAuthorFullName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBoxAuthorID);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.Name = "AuthorInformationForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Enter Author Information";
			this.ResumeLayout(false);

		}
		#endregion

		public string AuthorID
		{
			get
			{
				return textBoxAuthorID.Text;
			}
			set
			{
				textBoxAuthorID.Text = value;
			}
		}

		public void SetAuthorInfo(string authorID, string authorName, string authorEmailAddress)
		{
			this.AuthorID = authorID;
			this.AuthorFullName = authorName;
			this.AuthorEmailAddress = authorEmailAddress;
		}

		public string AuthorFullName
		{
			get
			{
				return textBoxAuthorFullName.Text;
			}
			set
			{
				textBoxAuthorFullName.Text = value;
			}
		}

		public string AuthorEmailAddress
		{
			get
			{
				return textBoxAuthorEmail.Text;
			}
			set
			{
				textBoxAuthorEmail.Text = value;
			}
		}
	}
}
