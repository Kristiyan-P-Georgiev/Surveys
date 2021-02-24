namespace Project
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonShowCreateSurveyPanel = new System.Windows.Forms.Button();
            this.buttonMySurveys = new System.Windows.Forms.Button();
            this.buttonTakeSurvey = new System.Windows.Forms.Button();
            this.panelCreateSurvey = new System.Windows.Forms.Panel();
            this.buttonCreateSurvey = new System.Windows.Forms.Button();
            this.buttonOptionChoice = new System.Windows.Forms.Button();
            this.buttonText = new System.Windows.Forms.Button();
            this.labelSurveyTitle = new System.Windows.Forms.Label();
            this.textBoxSurveyTitle = new System.Windows.Forms.TextBox();
            this.panelFillSurvey = new System.Windows.Forms.Panel();
            this.buttonConfirmSurveyCode = new System.Windows.Forms.Button();
            this.textBoxSurveyCode = new System.Windows.Forms.TextBox();
            this.labelSurveyCode = new System.Windows.Forms.Label();
            this.panelMySurveys = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonHome = new System.Windows.Forms.Button();
            this.buttonUser = new System.Windows.Forms.Button();
            this.panelUser = new System.Windows.Forms.Panel();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.timerUserPanel = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelCheckAnswers = new System.Windows.Forms.Panel();
            this.panelFillSurveyDropdown = new System.Windows.Forms.Panel();
            this.buttonFillSurveyByCode = new System.Windows.Forms.Button();
            this.buttonCheckEverySurvey = new System.Windows.Forms.Button();
            this.timerFillSurveyPanel = new System.Windows.Forms.Timer(this.components);
            this.panelEverySurvey = new System.Windows.Forms.Panel();
            this.panelEditSurvey = new System.Windows.Forms.Panel();
            this.panelCreateSurvey.SuspendLayout();
            this.panelFillSurvey.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelFillSurveyDropdown.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonShowCreateSurveyPanel
            // 
            this.buttonShowCreateSurveyPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonShowCreateSurveyPanel.FlatAppearance.BorderSize = 0;
            this.buttonShowCreateSurveyPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowCreateSurveyPanel.Font = new System.Drawing.Font("Century", 9F);
            this.buttonShowCreateSurveyPanel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonShowCreateSurveyPanel.Location = new System.Drawing.Point(0, 0);
            this.buttonShowCreateSurveyPanel.Name = "buttonShowCreateSurveyPanel";
            this.buttonShowCreateSurveyPanel.Size = new System.Drawing.Size(107, 40);
            this.buttonShowCreateSurveyPanel.TabIndex = 0;
            this.buttonShowCreateSurveyPanel.Text = "Create a new survey";
            this.buttonShowCreateSurveyPanel.UseVisualStyleBackColor = true;
            this.buttonShowCreateSurveyPanel.Click += new System.EventHandler(this.buttonShowCreateSurveyPanel_Click);
            // 
            // buttonMySurveys
            // 
            this.buttonMySurveys.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMySurveys.FlatAppearance.BorderSize = 0;
            this.buttonMySurveys.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMySurveys.Font = new System.Drawing.Font("Century", 12F);
            this.buttonMySurveys.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonMySurveys.Location = new System.Drawing.Point(0, 40);
            this.buttonMySurveys.Name = "buttonMySurveys";
            this.buttonMySurveys.Size = new System.Drawing.Size(107, 40);
            this.buttonMySurveys.TabIndex = 1;
            this.buttonMySurveys.Text = "My surveys";
            this.buttonMySurveys.UseVisualStyleBackColor = true;
            this.buttonMySurveys.Click += new System.EventHandler(this.buttonMySurveys_Click);
            // 
            // buttonTakeSurvey
            // 
            this.buttonTakeSurvey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTakeSurvey.FlatAppearance.BorderSize = 0;
            this.buttonTakeSurvey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTakeSurvey.Font = new System.Drawing.Font("Century", 12F);
            this.buttonTakeSurvey.ForeColor = System.Drawing.Color.White;
            this.buttonTakeSurvey.Location = new System.Drawing.Point(585, 0);
            this.buttonTakeSurvey.Name = "buttonTakeSurvey";
            this.buttonTakeSurvey.Size = new System.Drawing.Size(107, 43);
            this.buttonTakeSurvey.TabIndex = 2;
            this.buttonTakeSurvey.Text = "Fill survey";
            this.buttonTakeSurvey.UseVisualStyleBackColor = true;
            this.buttonTakeSurvey.Click += new System.EventHandler(this.buttonTakeSurvey_Click);
            // 
            // panelCreateSurvey
            // 
            this.panelCreateSurvey.Controls.Add(this.buttonCreateSurvey);
            this.panelCreateSurvey.Controls.Add(this.buttonOptionChoice);
            this.panelCreateSurvey.Controls.Add(this.buttonText);
            this.panelCreateSurvey.Controls.Add(this.labelSurveyTitle);
            this.panelCreateSurvey.Controls.Add(this.textBoxSurveyTitle);
            this.panelCreateSurvey.Location = new System.Drawing.Point(37, 43);
            this.panelCreateSurvey.Name = "panelCreateSurvey";
            this.panelCreateSurvey.Size = new System.Drawing.Size(740, 396);
            this.panelCreateSurvey.TabIndex = 3;
            this.panelCreateSurvey.Visible = false;
            // 
            // buttonCreateSurvey
            // 
            this.buttonCreateSurvey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.buttonCreateSurvey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCreateSurvey.FlatAppearance.BorderSize = 0;
            this.buttonCreateSurvey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCreateSurvey.Font = new System.Drawing.Font("Century", 14F);
            this.buttonCreateSurvey.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonCreateSurvey.Location = new System.Drawing.Point(70, 139);
            this.buttonCreateSurvey.Name = "buttonCreateSurvey";
            this.buttonCreateSurvey.Size = new System.Drawing.Size(607, 38);
            this.buttonCreateSurvey.TabIndex = 6;
            this.buttonCreateSurvey.Text = "CreateSurvey";
            this.buttonCreateSurvey.UseVisualStyleBackColor = false;
            this.buttonCreateSurvey.Click += new System.EventHandler(this.buttonCreateSurvey_Click);
            // 
            // buttonOptionChoice
            // 
            this.buttonOptionChoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.buttonOptionChoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOptionChoice.FlatAppearance.BorderSize = 0;
            this.buttonOptionChoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOptionChoice.Font = new System.Drawing.Font("Century", 14F);
            this.buttonOptionChoice.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonOptionChoice.Location = new System.Drawing.Point(407, 68);
            this.buttonOptionChoice.Name = "buttonOptionChoice";
            this.buttonOptionChoice.Size = new System.Drawing.Size(171, 48);
            this.buttonOptionChoice.TabIndex = 5;
            this.buttonOptionChoice.Text = "OptionChoice";
            this.buttonOptionChoice.UseVisualStyleBackColor = false;
            this.buttonOptionChoice.Click += new System.EventHandler(this.buttonOptionChoice_Click);
            // 
            // buttonText
            // 
            this.buttonText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.buttonText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonText.FlatAppearance.BorderSize = 0;
            this.buttonText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonText.Font = new System.Drawing.Font("Century", 14F);
            this.buttonText.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonText.Location = new System.Drawing.Point(170, 68);
            this.buttonText.Name = "buttonText";
            this.buttonText.Size = new System.Drawing.Size(119, 48);
            this.buttonText.TabIndex = 4;
            this.buttonText.Text = "Text";
            this.buttonText.UseVisualStyleBackColor = false;
            this.buttonText.Click += new System.EventHandler(this.buttonText_Click);
            // 
            // labelSurveyTitle
            // 
            this.labelSurveyTitle.AutoSize = true;
            this.labelSurveyTitle.Font = new System.Drawing.Font("Century", 14F);
            this.labelSurveyTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.labelSurveyTitle.Location = new System.Drawing.Point(70, 8);
            this.labelSurveyTitle.Name = "labelSurveyTitle";
            this.labelSurveyTitle.Size = new System.Drawing.Size(119, 23);
            this.labelSurveyTitle.TabIndex = 1;
            this.labelSurveyTitle.Text = "Survey Title";
            // 
            // textBoxSurveyTitle
            // 
            this.textBoxSurveyTitle.Font = new System.Drawing.Font("Century", 12F);
            this.textBoxSurveyTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.textBoxSurveyTitle.Location = new System.Drawing.Point(70, 34);
            this.textBoxSurveyTitle.MaxLength = 80;
            this.textBoxSurveyTitle.Name = "textBoxSurveyTitle";
            this.textBoxSurveyTitle.Size = new System.Drawing.Size(607, 27);
            this.textBoxSurveyTitle.TabIndex = 0;
            // 
            // panelFillSurvey
            // 
            this.panelFillSurvey.Controls.Add(this.buttonConfirmSurveyCode);
            this.panelFillSurvey.Controls.Add(this.textBoxSurveyCode);
            this.panelFillSurvey.Controls.Add(this.labelSurveyCode);
            this.panelFillSurvey.Location = new System.Drawing.Point(60, 43);
            this.panelFillSurvey.Name = "panelFillSurvey";
            this.panelFillSurvey.Size = new System.Drawing.Size(740, 396);
            this.panelFillSurvey.TabIndex = 4;
            this.panelFillSurvey.Visible = false;
            // 
            // buttonConfirmSurveyCode
            // 
            this.buttonConfirmSurveyCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.buttonConfirmSurveyCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonConfirmSurveyCode.FlatAppearance.BorderSize = 0;
            this.buttonConfirmSurveyCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfirmSurveyCode.Font = new System.Drawing.Font("Century", 14F);
            this.buttonConfirmSurveyCode.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonConfirmSurveyCode.Location = new System.Drawing.Point(4, 41);
            this.buttonConfirmSurveyCode.Name = "buttonConfirmSurveyCode";
            this.buttonConfirmSurveyCode.Size = new System.Drawing.Size(171, 48);
            this.buttonConfirmSurveyCode.TabIndex = 7;
            this.buttonConfirmSurveyCode.Text = "Confirm";
            this.buttonConfirmSurveyCode.UseVisualStyleBackColor = false;
            this.buttonConfirmSurveyCode.Click += new System.EventHandler(this.buttonConfirmSurveyCode_Click);
            // 
            // textBoxSurveyCode
            // 
            this.textBoxSurveyCode.Font = new System.Drawing.Font("Century", 12F);
            this.textBoxSurveyCode.Location = new System.Drawing.Point(173, 8);
            this.textBoxSurveyCode.Name = "textBoxSurveyCode";
            this.textBoxSurveyCode.Size = new System.Drawing.Size(153, 27);
            this.textBoxSurveyCode.TabIndex = 5;
            // 
            // labelSurveyCode
            // 
            this.labelSurveyCode.AutoSize = true;
            this.labelSurveyCode.Font = new System.Drawing.Font("Century", 14F);
            this.labelSurveyCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.labelSurveyCode.Location = new System.Drawing.Point(0, 8);
            this.labelSurveyCode.Name = "labelSurveyCode";
            this.labelSurveyCode.Size = new System.Drawing.Size(167, 23);
            this.labelSurveyCode.TabIndex = 6;
            this.labelSurveyCode.Text = "Type survey code:";
            // 
            // panelMySurveys
            // 
            this.panelMySurveys.Location = new System.Drawing.Point(60, 43);
            this.panelMySurveys.Name = "panelMySurveys";
            this.panelMySurveys.Size = new System.Drawing.Size(740, 396);
            this.panelMySurveys.TabIndex = 5;
            this.panelMySurveys.Visible = false;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.panelHeader.Controls.Add(this.label8);
            this.panelHeader.Controls.Add(this.buttonHome);
            this.panelHeader.Controls.Add(this.buttonUser);
            this.panelHeader.Controls.Add(this.buttonTakeSurvey);
            this.panelHeader.Location = new System.Drawing.Point(1, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(799, 43);
            this.panelHeader.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century", 18F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(3, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(299, 28);
            this.label8.TabIndex = 8;
            this.label8.Text = "IT Kariera Project 2019";
            // 
            // buttonHome
            // 
            this.buttonHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHome.FlatAppearance.BorderSize = 0;
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHome.Font = new System.Drawing.Font("Century", 14F);
            this.buttonHome.ForeColor = System.Drawing.Color.White;
            this.buttonHome.Location = new System.Drawing.Point(479, 0);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(107, 43);
            this.buttonHome.TabIndex = 8;
            this.buttonHome.Text = "Home";
            this.buttonHome.UseVisualStyleBackColor = true;
            this.buttonHome.Click += new System.EventHandler(this.buttonHome_Click);
            // 
            // buttonUser
            // 
            this.buttonUser.AutoSize = true;
            this.buttonUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonUser.FlatAppearance.BorderSize = 0;
            this.buttonUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUser.Font = new System.Drawing.Font("Century", 12F);
            this.buttonUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonUser.Location = new System.Drawing.Point(693, 0);
            this.buttonUser.MaximumSize = new System.Drawing.Size(107, 43);
            this.buttonUser.Name = "buttonUser";
            this.buttonUser.Size = new System.Drawing.Size(106, 43);
            this.buttonUser.TabIndex = 7;
            this.buttonUser.Text = "User";
            this.buttonUser.UseVisualStyleBackColor = true;
            this.buttonUser.SizeChanged += new System.EventHandler(this.buttonUser_SizeChanged);
            this.buttonUser.Click += new System.EventHandler(this.buttonUser_Click);
            // 
            // panelUser
            // 
            this.panelUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.panelUser.Controls.Add(this.buttonLogOut);
            this.panelUser.Controls.Add(this.buttonShowCreateSurveyPanel);
            this.panelUser.Controls.Add(this.buttonMySurveys);
            this.panelUser.Location = new System.Drawing.Point(693, 43);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(107, 0);
            this.panelUser.TabIndex = 7;
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLogOut.FlatAppearance.BorderSize = 0;
            this.buttonLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogOut.Font = new System.Drawing.Font("Century", 12F);
            this.buttonLogOut.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonLogOut.Location = new System.Drawing.Point(0, 80);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(107, 40);
            this.buttonLogOut.TabIndex = 2;
            this.buttonLogOut.Text = "Log out";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // timerUserPanel
            // 
            this.timerUserPanel.Interval = 20;
            this.timerUserPanel.Tick += new System.EventHandler(this.timerUserPanel_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(328, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.label1.Location = new System.Drawing.Point(304, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 28);
            this.label1.TabIndex = 9;
            this.label1.Text = "Create a survey";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 18F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.label2.Location = new System.Drawing.Point(313, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 28);
            this.label2.TabIndex = 10;
            this.label2.Text = "Fill in a survey";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century", 18F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.label3.Location = new System.Drawing.Point(257, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(301, 28);
            this.label3.TabIndex = 11;
            this.label3.Text = "Check how other people";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century", 18F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.label4.Location = new System.Drawing.Point(267, 352);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(286, 28);
            this.label4.TabIndex = 12;
            this.label4.Text = "completed your survey";
            // 
            // panelCheckAnswers
            // 
            this.panelCheckAnswers.Location = new System.Drawing.Point(60, 43);
            this.panelCheckAnswers.Name = "panelCheckAnswers";
            this.panelCheckAnswers.Size = new System.Drawing.Size(740, 396);
            this.panelCheckAnswers.TabIndex = 6;
            this.panelCheckAnswers.Visible = false;
            // 
            // panelFillSurveyDropdown
            // 
            this.panelFillSurveyDropdown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.panelFillSurveyDropdown.Controls.Add(this.buttonFillSurveyByCode);
            this.panelFillSurveyDropdown.Controls.Add(this.buttonCheckEverySurvey);
            this.panelFillSurveyDropdown.Location = new System.Drawing.Point(586, 43);
            this.panelFillSurveyDropdown.Name = "panelFillSurveyDropdown";
            this.panelFillSurveyDropdown.Size = new System.Drawing.Size(107, 0);
            this.panelFillSurveyDropdown.TabIndex = 8;
            // 
            // buttonFillSurveyByCode
            // 
            this.buttonFillSurveyByCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFillSurveyByCode.FlatAppearance.BorderSize = 0;
            this.buttonFillSurveyByCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFillSurveyByCode.Font = new System.Drawing.Font("Century", 9F);
            this.buttonFillSurveyByCode.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonFillSurveyByCode.Location = new System.Drawing.Point(0, 0);
            this.buttonFillSurveyByCode.Name = "buttonFillSurveyByCode";
            this.buttonFillSurveyByCode.Size = new System.Drawing.Size(107, 40);
            this.buttonFillSurveyByCode.TabIndex = 0;
            this.buttonFillSurveyByCode.Text = "By Code";
            this.buttonFillSurveyByCode.UseVisualStyleBackColor = true;
            this.buttonFillSurveyByCode.Click += new System.EventHandler(this.buttonFillSurveyByCode_Click);
            // 
            // buttonCheckEverySurvey
            // 
            this.buttonCheckEverySurvey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCheckEverySurvey.FlatAppearance.BorderSize = 0;
            this.buttonCheckEverySurvey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCheckEverySurvey.Font = new System.Drawing.Font("Century", 9F);
            this.buttonCheckEverySurvey.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonCheckEverySurvey.Location = new System.Drawing.Point(0, 40);
            this.buttonCheckEverySurvey.Name = "buttonCheckEverySurvey";
            this.buttonCheckEverySurvey.Size = new System.Drawing.Size(107, 40);
            this.buttonCheckEverySurvey.TabIndex = 1;
            this.buttonCheckEverySurvey.Text = "Check Every Survey";
            this.buttonCheckEverySurvey.UseVisualStyleBackColor = true;
            this.buttonCheckEverySurvey.Click += new System.EventHandler(this.buttonCheckEverySurvey_Click);
            // 
            // timerFillSurveyPanel
            // 
            this.timerFillSurveyPanel.Interval = 20;
            this.timerFillSurveyPanel.Tick += new System.EventHandler(this.timerFillSurveyPanel_Tick);
            // 
            // panelEverySurvey
            // 
            this.panelEverySurvey.Location = new System.Drawing.Point(60, 43);
            this.panelEverySurvey.Name = "panelEverySurvey";
            this.panelEverySurvey.Size = new System.Drawing.Size(740, 396);
            this.panelEverySurvey.TabIndex = 7;
            this.panelEverySurvey.Visible = false;
            // 
            // panelEditSurvey
            // 
            this.panelEditSurvey.Location = new System.Drawing.Point(60, 43);
            this.panelEditSurvey.Name = "panelEditSurvey";
            this.panelEditSurvey.Size = new System.Drawing.Size(740, 396);
            this.panelEditSurvey.TabIndex = 7;
            this.panelEditSurvey.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 438);
            this.Controls.Add(this.panelFillSurveyDropdown);
            this.Controls.Add(this.panelUser);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelEditSurvey);
            this.Controls.Add(this.panelEverySurvey);
            this.Controls.Add(this.panelCheckAnswers);
            this.Controls.Add(this.panelMySurveys);
            this.Controls.Add(this.panelFillSurvey);
            this.Controls.Add(this.panelCreateSurvey);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "SurveyProject";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panelCreateSurvey.ResumeLayout(false);
            this.panelCreateSurvey.PerformLayout();
            this.panelFillSurvey.ResumeLayout(false);
            this.panelFillSurvey.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelUser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelFillSurveyDropdown.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonShowCreateSurveyPanel;
        private System.Windows.Forms.Button buttonMySurveys;
        private System.Windows.Forms.Button buttonTakeSurvey;
        private System.Windows.Forms.Panel panelCreateSurvey;
        private System.Windows.Forms.Label labelSurveyTitle;
        private System.Windows.Forms.TextBox textBoxSurveyTitle;
        private System.Windows.Forms.Button buttonOptionChoice;
        private System.Windows.Forms.Button buttonText;
        private System.Windows.Forms.Button buttonCreateSurvey;
        private System.Windows.Forms.Panel panelFillSurvey;
        private System.Windows.Forms.TextBox textBoxSurveyCode;
        private System.Windows.Forms.Label labelSurveyCode;
        private System.Windows.Forms.Panel panelMySurveys;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button buttonUser;
        private System.Windows.Forms.Panel panelUser;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.Timer timerUserPanel;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.Button buttonConfirmSurveyCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelCheckAnswers;
        private System.Windows.Forms.Panel panelFillSurveyDropdown;
        private System.Windows.Forms.Button buttonFillSurveyByCode;
        private System.Windows.Forms.Button buttonCheckEverySurvey;
        private System.Windows.Forms.Timer timerFillSurveyPanel;
        private System.Windows.Forms.Panel panelEverySurvey;
        private System.Windows.Forms.Panel panelEditSurvey;
    }
}