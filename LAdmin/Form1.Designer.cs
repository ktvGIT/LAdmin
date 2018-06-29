namespace LAdmin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.listViewIncidents = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonNewIncident = new System.Windows.Forms.Button();
            this.textBoxExtraSolution = new System.Windows.Forms.TextBox();
            this.textBoxSolution = new System.Windows.Forms.TextBox();
            this.textBoxProblem = new System.Windows.Forms.TextBox();
            this.textBoxInitiator = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageInc = new System.Windows.Forms.TabPage();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonSendTo = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonMoveToArch = new System.Windows.Forms.Button();
            this.buttonUbdForm = new System.Windows.Forms.Button();
            this.tabPageArc = new System.Windows.Forms.TabPage();
            this.textBoxsearch = new System.Windows.Forms.TextBox();
            this.buttonSrchArc = new System.Windows.Forms.Button();
            this.labelDateArc = new System.Windows.Forms.Label();
            this.dateTimePickerEndArc = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerBeginArc = new System.Windows.Forms.DateTimePicker();
            this.listViewIncidentsArc = new System.Windows.Forms.ListView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.textBoxHost = new System.Windows.Forms.TextBox();
            this.listBoxResources = new System.Windows.Forms.ListBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageInc.SuspendLayout();
            this.tabPageArc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Resursers";
            // 
            // listViewIncidents
            // 
            this.listViewIncidents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewIncidents.HideSelection = false;
            this.listViewIncidents.Location = new System.Drawing.Point(6, 32);
            this.listViewIncidents.Name = "listViewIncidents";
            this.listViewIncidents.Size = new System.Drawing.Size(983, 199);
            this.listViewIncidents.TabIndex = 1;
            this.listViewIncidents.UseCompatibleStateImageBehavior = false;
            this.listViewIncidents.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewIncidents_ColumnClick);
            this.listViewIncidents.SelectedIndexChanged += new System.EventHandler(this.listViewIncidents_SelectedIndexChanged);
            this.listViewIncidents.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewIncidents_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "List of Incindents";
            // 
            // buttonNewIncident
            // 
            this.buttonNewIncident.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonNewIncident.Location = new System.Drawing.Point(224, 252);
            this.buttonNewIncident.Name = "buttonNewIncident";
            this.buttonNewIncident.Size = new System.Drawing.Size(175, 23);
            this.buttonNewIncident.TabIndex = 9;
            this.buttonNewIncident.Text = "Save as new";
            this.buttonNewIncident.UseVisualStyleBackColor = true;
            this.buttonNewIncident.Visible = false;
            this.buttonNewIncident.Click += new System.EventHandler(this.buttonNewIncident_Click);
            // 
            // textBoxExtraSolution
            // 
            this.textBoxExtraSolution.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxExtraSolution.Location = new System.Drawing.Point(6, 262);
            this.textBoxExtraSolution.Multiline = true;
            this.textBoxExtraSolution.Name = "textBoxExtraSolution";
            this.textBoxExtraSolution.Size = new System.Drawing.Size(535, 82);
            this.textBoxExtraSolution.TabIndex = 8;
            this.textBoxExtraSolution.TextChanged += new System.EventHandler(this.textBoxExtraSolution_TextChanged);
            // 
            // textBoxSolution
            // 
            this.textBoxSolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSolution.Location = new System.Drawing.Point(6, 196);
            this.textBoxSolution.Name = "textBoxSolution";
            this.textBoxSolution.Size = new System.Drawing.Size(517, 20);
            this.textBoxSolution.TabIndex = 7;
            this.textBoxSolution.Tag = "3";
            this.textBoxSolution.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // textBoxProblem
            // 
            this.textBoxProblem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProblem.Location = new System.Drawing.Point(6, 141);
            this.textBoxProblem.Name = "textBoxProblem";
            this.textBoxProblem.Size = new System.Drawing.Size(517, 20);
            this.textBoxProblem.TabIndex = 6;
            this.textBoxProblem.Tag = "2";
            this.textBoxProblem.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // textBoxInitiator
            // 
            this.textBoxInitiator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInitiator.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxInitiator.Location = new System.Drawing.Point(6, 71);
            this.textBoxInitiator.Name = "textBoxInitiator";
            this.textBoxInitiator.Size = new System.Drawing.Size(281, 20);
            this.textBoxInitiator.TabIndex = 5;
            this.textBoxInitiator.Tag = "1";
            this.textBoxInitiator.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBoxInitiator.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInitiator_KeyPress);
            this.textBoxInitiator.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBoxInitiator_MouseDoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Details of the result";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "result";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "What did he want ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "who is";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Details of the incident";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1017, 697);
            this.splitContainer1.SplitterDistance = 315;
            this.splitContainer1.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageInc);
            this.tabControl1.Controls.Add(this.tabPageArc);
            this.tabControl1.Location = new System.Drawing.Point(-1, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1003, 307);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageInc
            // 
            this.tabPageInc.Controls.Add(this.buttonSave);
            this.tabPageInc.Controls.Add(this.buttonSendTo);
            this.tabPageInc.Controls.Add(this.listViewIncidents);
            this.tabPageInc.Controls.Add(this.buttonClear);
            this.tabPageInc.Controls.Add(this.buttonMoveToArch);
            this.tabPageInc.Controls.Add(this.buttonUbdForm);
            this.tabPageInc.Controls.Add(this.buttonNewIncident);
            this.tabPageInc.Controls.Add(this.label2);
            this.tabPageInc.Location = new System.Drawing.Point(4, 22);
            this.tabPageInc.Name = "tabPageInc";
            this.tabPageInc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInc.Size = new System.Drawing.Size(995, 281);
            this.tabPageInc.TabIndex = 0;
            this.tabPageInc.Text = "Incindents";
            this.tabPageInc.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.Location = new System.Drawing.Point(383, 252);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonSendTo
            // 
            this.buttonSendTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSendTo.Location = new System.Drawing.Point(175, 252);
            this.buttonSendTo.Name = "buttonSendTo";
            this.buttonSendTo.Size = new System.Drawing.Size(175, 23);
            this.buttonSendTo.TabIndex = 13;
            this.buttonSendTo.Text = "Mail to";
            this.buttonSendTo.UseVisualStyleBackColor = true;
            this.buttonSendTo.Click += new System.EventHandler(this.buttonSendTo_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClear.Location = new System.Drawing.Point(17, 252);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(152, 23);
            this.buttonClear.TabIndex = 12;
            this.buttonClear.Text = "New";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonMoveToArch
            // 
            this.buttonMoveToArch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMoveToArch.Location = new System.Drawing.Point(828, 252);
            this.buttonMoveToArch.Name = "buttonMoveToArch";
            this.buttonMoveToArch.Size = new System.Drawing.Size(147, 23);
            this.buttonMoveToArch.TabIndex = 2;
            this.buttonMoveToArch.Text = "Move to archive";
            this.buttonMoveToArch.UseVisualStyleBackColor = true;
            this.buttonMoveToArch.Click += new System.EventHandler(this.buttonMoveToArch_Click);
            // 
            // buttonUbdForm
            // 
            this.buttonUbdForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUbdForm.Location = new System.Drawing.Point(747, 252);
            this.buttonUbdForm.Name = "buttonUbdForm";
            this.buttonUbdForm.Size = new System.Drawing.Size(75, 23);
            this.buttonUbdForm.TabIndex = 3;
            this.buttonUbdForm.Text = "Update form";
            this.buttonUbdForm.UseVisualStyleBackColor = true;
            this.buttonUbdForm.Click += new System.EventHandler(this.buttonUbdForm_Click);
            // 
            // tabPageArc
            // 
            this.tabPageArc.Controls.Add(this.textBoxsearch);
            this.tabPageArc.Controls.Add(this.buttonSrchArc);
            this.tabPageArc.Controls.Add(this.labelDateArc);
            this.tabPageArc.Controls.Add(this.dateTimePickerEndArc);
            this.tabPageArc.Controls.Add(this.dateTimePickerBeginArc);
            this.tabPageArc.Controls.Add(this.listViewIncidentsArc);
            this.tabPageArc.Location = new System.Drawing.Point(4, 22);
            this.tabPageArc.Name = "tabPageArc";
            this.tabPageArc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageArc.Size = new System.Drawing.Size(995, 281);
            this.tabPageArc.TabIndex = 1;
            this.tabPageArc.Text = "Archives";
            this.tabPageArc.UseVisualStyleBackColor = true;
            // 
            // textBoxsearch
            // 
            this.textBoxsearch.Location = new System.Drawing.Point(238, 42);
            this.textBoxsearch.Name = "textBoxsearch";
            this.textBoxsearch.Size = new System.Drawing.Size(275, 20);
            this.textBoxsearch.TabIndex = 5;
            this.textBoxsearch.TextChanged += new System.EventHandler(this.textBoxsearch_TextChanged);
            // 
            // buttonSrchArc
            // 
            this.buttonSrchArc.Location = new System.Drawing.Point(519, 39);
            this.buttonSrchArc.Name = "buttonSrchArc";
            this.buttonSrchArc.Size = new System.Drawing.Size(75, 23);
            this.buttonSrchArc.TabIndex = 4;
            this.buttonSrchArc.Text = "search";
            this.buttonSrchArc.UseVisualStyleBackColor = true;
            this.buttonSrchArc.Click += new System.EventHandler(this.buttonSrchArc_Click);
            // 
            // labelDateArc
            // 
            this.labelDateArc.AutoSize = true;
            this.labelDateArc.Location = new System.Drawing.Point(34, 27);
            this.labelDateArc.Name = "labelDateArc";
            this.labelDateArc.Size = new System.Drawing.Size(171, 13);
            this.labelDateArc.TabIndex = 3;
            this.labelDateArc.Text = "to                                             from";
            // 
            // dateTimePickerEndArc
            // 
            this.dateTimePickerEndArc.CustomFormat = "yyyyMMdd";
            this.dateTimePickerEndArc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEndArc.Location = new System.Drawing.Point(127, 43);
            this.dateTimePickerEndArc.Name = "dateTimePickerEndArc";
            this.dateTimePickerEndArc.Size = new System.Drawing.Size(105, 20);
            this.dateTimePickerEndArc.TabIndex = 2;
            // 
            // dateTimePickerBeginArc
            // 
            this.dateTimePickerBeginArc.CustomFormat = "yyyyMMdd";
            this.dateTimePickerBeginArc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerBeginArc.Location = new System.Drawing.Point(6, 43);
            this.dateTimePickerBeginArc.Name = "dateTimePickerBeginArc";
            this.dateTimePickerBeginArc.Size = new System.Drawing.Size(105, 20);
            this.dateTimePickerBeginArc.TabIndex = 1;
            // 
            // listViewIncidentsArc
            // 
            this.listViewIncidentsArc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewIncidentsArc.HideSelection = false;
            this.listViewIncidentsArc.Location = new System.Drawing.Point(6, 69);
            this.listViewIncidentsArc.Name = "listViewIncidentsArc";
            this.listViewIncidentsArc.Size = new System.Drawing.Size(983, 206);
            this.listViewIncidentsArc.TabIndex = 0;
            this.listViewIncidentsArc.UseCompatibleStateImageBehavior = false;
            this.listViewIncidentsArc.SelectedIndexChanged += new System.EventHandler(this.listViewIncidentsArc_SelectedIndexChanged);
            this.listViewIncidentsArc.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewIncidentsArc_MouseDoubleClick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.textBoxHost);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxExtraSolution);
            this.splitContainer2.Panel1.Controls.Add(this.label7);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxSolution);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxProblem);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxInitiator);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.listBoxResources);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Size = new System.Drawing.Size(1017, 378);
            this.splitContainer2.SplitterDistance = 556;
            this.splitContainer2.TabIndex = 0;
            // 
            // textBoxHost
            // 
            this.textBoxHost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHost.Location = new System.Drawing.Point(313, 71);
            this.textBoxHost.Name = "textBoxHost";
            this.textBoxHost.Size = new System.Drawing.Size(210, 20);
            this.textBoxHost.TabIndex = 10;
            this.textBoxHost.DoubleClick += new System.EventHandler(this.textBoxHost_DoubleClick);
            // 
            // listBoxResources
            // 
            this.listBoxResources.AllowDrop = true;
            this.listBoxResources.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxResources.FormattingEnabled = true;
            this.listBoxResources.Location = new System.Drawing.Point(3, 43);
            this.listBoxResources.Name = "listBoxResources";
            this.listBoxResources.Size = new System.Drawing.Size(439, 316);
            this.listBoxResources.TabIndex = 1;
            this.listBoxResources.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBoxResources_DragDrop);
            this.listBoxResources.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBoxResources_DragEnter);
            this.listBoxResources.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxResources_MouseDoubleClick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Обращения";
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 721);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Incindents";
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageInc.ResumeLayout(false);
            this.tabPageInc.PerformLayout();
            this.tabPageArc.ResumeLayout(false);
            this.tabPageArc.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listViewIncidents;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxExtraSolution;
        private System.Windows.Forms.TextBox textBoxSolution;
        private System.Windows.Forms.TextBox textBoxProblem;
        private System.Windows.Forms.TextBox textBoxInitiator;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonNewIncident;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListBox listBoxResources;
        private System.Windows.Forms.TextBox textBoxHost;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button buttonMoveToArch;
        private System.Windows.Forms.Button buttonUbdForm;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonSendTo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageInc;
        private System.Windows.Forms.TabPage tabPageArc;
        private System.Windows.Forms.Button buttonSrchArc;
        private System.Windows.Forms.Label labelDateArc;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndArc;
        private System.Windows.Forms.DateTimePicker dateTimePickerBeginArc;
        private System.Windows.Forms.ListView listViewIncidentsArc;
        private System.Windows.Forms.TextBox textBoxsearch;
    }
}

