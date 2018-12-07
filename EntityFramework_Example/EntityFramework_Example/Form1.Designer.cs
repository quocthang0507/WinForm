namespace EntityFramework_Example
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.label1 = new System.Windows.Forms.Label();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.dgvData = new System.Windows.Forms.DataGridView();
			this.btn_ViewByClass = new System.Windows.Forms.Button();
			this.btn_Delete = new System.Windows.Forms.Button();
			this.btn_Modify = new System.Windows.Forms.Button();
			this.btn_Add = new System.Windows.Forms.Button();
			this.btn_View = new System.Windows.Forms.Button();
			this.tbx_Class = new System.Windows.Forms.TextBox();
			this.tbx_Name = new System.Windows.Forms.TextBox();
			this.tbx_ID = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Green;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(657, 41);
			this.label1.TabIndex = 1;
			this.label1.Text = "CHƯƠNG TRÌNH QUẢN LÝ SINH VIÊN TRƯỜNG ĐẠI HỌC ĐÀ LẠT";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 41);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.dgvData);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.btn_ViewByClass);
			this.splitContainer1.Panel2.Controls.Add(this.btn_Delete);
			this.splitContainer1.Panel2.Controls.Add(this.btn_Modify);
			this.splitContainer1.Panel2.Controls.Add(this.btn_Add);
			this.splitContainer1.Panel2.Controls.Add(this.btn_View);
			this.splitContainer1.Panel2.Controls.Add(this.tbx_Class);
			this.splitContainer1.Panel2.Controls.Add(this.tbx_Name);
			this.splitContainer1.Panel2.Controls.Add(this.tbx_ID);
			this.splitContainer1.Panel2.Controls.Add(this.label4);
			this.splitContainer1.Panel2.Controls.Add(this.label3);
			this.splitContainer1.Panel2.Controls.Add(this.label2);
			this.splitContainer1.Size = new System.Drawing.Size(657, 431);
			this.splitContainer1.SplitterDistance = 367;
			this.splitContainer1.TabIndex = 2;
			// 
			// dgvData
			// 
			this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvData.Location = new System.Drawing.Point(0, 0);
			this.dgvData.Name = "dgvData";
			this.dgvData.Size = new System.Drawing.Size(367, 431);
			this.dgvData.TabIndex = 0;
			// 
			// btn_ViewByClass
			// 
			this.btn_ViewByClass.Location = new System.Drawing.Point(150, 150);
			this.btn_ViewByClass.Name = "btn_ViewByClass";
			this.btn_ViewByClass.Size = new System.Drawing.Size(103, 23);
			this.btn_ViewByClass.TabIndex = 10;
			this.btn_ViewByClass.Text = "View by Class";
			this.btn_ViewByClass.UseVisualStyleBackColor = true;
			this.btn_ViewByClass.Click += new System.EventHandler(this.btn_ViewByClass_Click);
			// 
			// btn_Delete
			// 
			this.btn_Delete.Location = new System.Drawing.Point(110, 282);
			this.btn_Delete.Name = "btn_Delete";
			this.btn_Delete.Size = new System.Drawing.Size(75, 23);
			this.btn_Delete.TabIndex = 9;
			this.btn_Delete.Text = "Delete";
			this.btn_Delete.UseVisualStyleBackColor = true;
			this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
			// 
			// btn_Modify
			// 
			this.btn_Modify.Location = new System.Drawing.Point(110, 238);
			this.btn_Modify.Name = "btn_Modify";
			this.btn_Modify.Size = new System.Drawing.Size(75, 23);
			this.btn_Modify.TabIndex = 8;
			this.btn_Modify.Text = "Modify";
			this.btn_Modify.UseVisualStyleBackColor = true;
			this.btn_Modify.Click += new System.EventHandler(this.btn_Modify_Click);
			// 
			// btn_Add
			// 
			this.btn_Add.Location = new System.Drawing.Point(110, 197);
			this.btn_Add.Name = "btn_Add";
			this.btn_Add.Size = new System.Drawing.Size(75, 23);
			this.btn_Add.TabIndex = 7;
			this.btn_Add.Text = "Add";
			this.btn_Add.UseVisualStyleBackColor = true;
			this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
			// 
			// btn_View
			// 
			this.btn_View.Location = new System.Drawing.Point(69, 150);
			this.btn_View.Name = "btn_View";
			this.btn_View.Size = new System.Drawing.Size(75, 23);
			this.btn_View.TabIndex = 6;
			this.btn_View.Text = "View all";
			this.btn_View.UseVisualStyleBackColor = true;
			this.btn_View.Click += new System.EventHandler(this.btn_View_Click);
			// 
			// tbx_Class
			// 
			this.tbx_Class.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
			this.tbx_Class.Location = new System.Drawing.Point(110, 101);
			this.tbx_Class.MaxLength = 5;
			this.tbx_Class.Name = "tbx_Class";
			this.tbx_Class.Size = new System.Drawing.Size(100, 23);
			this.tbx_Class.TabIndex = 5;
			// 
			// tbx_Name
			// 
			this.tbx_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
			this.tbx_Name.Location = new System.Drawing.Point(110, 60);
			this.tbx_Name.MaxLength = 100;
			this.tbx_Name.Name = "tbx_Name";
			this.tbx_Name.Size = new System.Drawing.Size(164, 23);
			this.tbx_Name.TabIndex = 4;
			// 
			// tbx_ID
			// 
			this.tbx_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
			this.tbx_ID.Location = new System.Drawing.Point(110, 21);
			this.tbx_ID.MaxLength = 7;
			this.tbx_ID.Name = "tbx_ID";
			this.tbx_ID.Size = new System.Drawing.Size(100, 23);
			this.tbx_ID.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
			this.label4.Location = new System.Drawing.Point(20, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 17);
			this.label4.TabIndex = 2;
			this.label4.Text = "Class";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
			this.label3.Location = new System.Drawing.Point(20, 63);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 17);
			this.label3.TabIndex = 1;
			this.label3.Text = "Full name";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
			this.label2.Location = new System.Drawing.Point(20, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(21, 17);
			this.label2.TabIndex = 0;
			this.label2.Text = "ID";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(657, 472);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Quản lý sinh viên - Example";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.DataGridView dgvData;
		private System.Windows.Forms.TextBox tbx_Class;
		private System.Windows.Forms.TextBox tbx_Name;
		private System.Windows.Forms.TextBox tbx_ID;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btn_Delete;
		private System.Windows.Forms.Button btn_Modify;
		private System.Windows.Forms.Button btn_Add;
		private System.Windows.Forms.Button btn_View;
        private System.Windows.Forms.Button btn_ViewByClass;
    }
}

