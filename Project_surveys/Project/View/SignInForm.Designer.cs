namespace Project
{
    partial class SignUpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUpForm));
            this.buttonLogin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.panelRegister = new System.Windows.Forms.Panel();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonConfirmReg = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPasswordReg = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPasswordConfirm = new System.Windows.Forms.TextBox();
            this.textBoxUsernameReg = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.buttonGoToRegisterPanel = new System.Windows.Forms.Button();
            this.timerSlider = new System.Windows.Forms.Timer(this.components);
            this.panelRegister.SuspendLayout();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.buttonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLogin.FlatAppearance.BorderSize = 0;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Font = new System.Drawing.Font("Century", 18F);
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(29, 373);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(460, 44);
            this.buttonLogin.TabIndex = 11;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.label2.Location = new System.Drawing.Point(23, 250);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 35);
            this.label2.TabIndex = 10;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.label1.Location = new System.Drawing.Point(20, 153);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 35);
            this.label1.TabIndex = 9;
            this.label1.Text = "Username:";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Century", 13F);
            this.textBoxPassword.Location = new System.Drawing.Point(29, 288);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(459, 34);
            this.textBoxPassword.TabIndex = 8;
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Font = new System.Drawing.Font("Century", 13F);
            this.textBoxUsername.Location = new System.Drawing.Point(29, 191);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(459, 34);
            this.textBoxUsername.TabIndex = 7;
            // 
            // panelRegister
            // 
            this.panelRegister.Controls.Add(this.buttonBack);
            this.panelRegister.Controls.Add(this.buttonConfirmReg);
            this.panelRegister.Controls.Add(this.label7);
            this.panelRegister.Controls.Add(this.textBoxPasswordReg);
            this.panelRegister.Controls.Add(this.label4);
            this.panelRegister.Controls.Add(this.textBoxPasswordConfirm);
            this.panelRegister.Controls.Add(this.textBoxUsernameReg);
            this.panelRegister.Controls.Add(this.label6);
            this.panelRegister.Controls.Add(this.label5);
            this.panelRegister.Location = new System.Drawing.Point(533, 0);
            this.panelRegister.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelRegister.Name = "panelRegister";
            this.panelRegister.Size = new System.Drawing.Size(533, 539);
            this.panelRegister.TabIndex = 14;
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.buttonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Century", 18F);
            this.buttonBack.ForeColor = System.Drawing.Color.White;
            this.buttonBack.Image = ((System.Drawing.Image)(resources.GetObject("buttonBack.Image")));
            this.buttonBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBack.Location = new System.Drawing.Point(56, 441);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(460, 44);
            this.buttonBack.TabIndex = 21;
            this.buttonBack.Text = "Go Back";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonConfirmReg
            // 
            this.buttonConfirmReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.buttonConfirmReg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonConfirmReg.FlatAppearance.BorderSize = 0;
            this.buttonConfirmReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfirmReg.Font = new System.Drawing.Font("Century", 18F);
            this.buttonConfirmReg.ForeColor = System.Drawing.Color.White;
            this.buttonConfirmReg.Location = new System.Drawing.Point(56, 372);
            this.buttonConfirmReg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonConfirmReg.Name = "buttonConfirmReg";
            this.buttonConfirmReg.Size = new System.Drawing.Size(460, 44);
            this.buttonConfirmReg.TabIndex = 18;
            this.buttonConfirmReg.Text = "Confirm";
            this.buttonConfirmReg.UseVisualStyleBackColor = false;
            this.buttonConfirmReg.Click += new System.EventHandler(this.buttonConfirmReg_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.label7.Location = new System.Drawing.Point(49, 43);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(184, 47);
            this.label7.TabIndex = 18;
            this.label7.Text = "Register";
            // 
            // textBoxPasswordReg
            // 
            this.textBoxPasswordReg.Font = new System.Drawing.Font("Century", 13F);
            this.textBoxPasswordReg.Location = new System.Drawing.Point(56, 229);
            this.textBoxPasswordReg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPasswordReg.MaxLength = 10;
            this.textBoxPasswordReg.Name = "textBoxPasswordReg";
            this.textBoxPasswordReg.Size = new System.Drawing.Size(456, 34);
            this.textBoxPasswordReg.TabIndex = 20;
            this.textBoxPasswordReg.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.label4.Location = new System.Drawing.Point(52, 276);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(278, 35);
            this.label4.TabIndex = 19;
            this.label4.Text = "Confirm Password:";
            // 
            // textBoxPasswordConfirm
            // 
            this.textBoxPasswordConfirm.Font = new System.Drawing.Font("Century", 13F);
            this.textBoxPasswordConfirm.Location = new System.Drawing.Point(56, 314);
            this.textBoxPasswordConfirm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPasswordConfirm.MaxLength = 10;
            this.textBoxPasswordConfirm.Name = "textBoxPasswordConfirm";
            this.textBoxPasswordConfirm.Size = new System.Drawing.Size(456, 34);
            this.textBoxPasswordConfirm.TabIndex = 15;
            this.textBoxPasswordConfirm.UseSystemPasswordChar = true;
            // 
            // textBoxUsernameReg
            // 
            this.textBoxUsernameReg.Font = new System.Drawing.Font("Century", 13F);
            this.textBoxUsernameReg.Location = new System.Drawing.Point(56, 153);
            this.textBoxUsernameReg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxUsernameReg.MaxLength = 30;
            this.textBoxUsernameReg.Name = "textBoxUsernameReg";
            this.textBoxUsernameReg.Size = new System.Drawing.Size(456, 34);
            this.textBoxUsernameReg.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.label6.Location = new System.Drawing.Point(52, 191);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 35);
            this.label6.TabIndex = 18;
            this.label6.Text = "Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.label5.Location = new System.Drawing.Point(52, 118);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 35);
            this.label5.TabIndex = 17;
            this.label5.Text = "Username:";
            // 
            // panelInfo
            // 
            this.panelInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.panelInfo.Controls.Add(this.label9);
            this.panelInfo.Controls.Add(this.label8);
            this.panelInfo.Controls.Add(this.pictureBox1);
            this.panelInfo.Location = new System.Drawing.Point(533, 0);
            this.panelInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(533, 539);
            this.panelInfo.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century", 24F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(69, 340);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(375, 47);
            this.label9.TabIndex = 2;
            this.label9.Text = "Project April 2019";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century", 24F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(143, 274);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(228, 47);
            this.label8.TabIndex = 1;
            this.label8.Text = "IT Kariera";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(172, 106);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 146);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.label3.Location = new System.Drawing.Point(17, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 47);
            this.label3.TabIndex = 16;
            this.label3.Text = "Sign In";
            // 
            // panelLogin
            // 
            this.panelLogin.Controls.Add(this.buttonGoToRegisterPanel);
            this.panelLogin.Controls.Add(this.label3);
            this.panelLogin.Controls.Add(this.textBoxPassword);
            this.panelLogin.Controls.Add(this.textBoxUsername);
            this.panelLogin.Controls.Add(this.buttonLogin);
            this.panelLogin.Controls.Add(this.label1);
            this.panelLogin.Controls.Add(this.label2);
            this.panelLogin.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLogin.Location = new System.Drawing.Point(0, 0);
            this.panelLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(533, 539);
            this.panelLogin.TabIndex = 17;
            // 
            // buttonGoToRegisterPanel
            // 
            this.buttonGoToRegisterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.buttonGoToRegisterPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGoToRegisterPanel.FlatAppearance.BorderSize = 0;
            this.buttonGoToRegisterPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGoToRegisterPanel.Font = new System.Drawing.Font("Century", 18F);
            this.buttonGoToRegisterPanel.ForeColor = System.Drawing.Color.White;
            this.buttonGoToRegisterPanel.Location = new System.Drawing.Point(27, 441);
            this.buttonGoToRegisterPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonGoToRegisterPanel.Name = "buttonGoToRegisterPanel";
            this.buttonGoToRegisterPanel.Size = new System.Drawing.Size(460, 44);
            this.buttonGoToRegisterPanel.TabIndex = 17;
            this.buttonGoToRegisterPanel.Text = "Register";
            this.buttonGoToRegisterPanel.UseVisualStyleBackColor = false;
            this.buttonGoToRegisterPanel.Click += new System.EventHandler(this.buttonGoToRegisterPanel_Click);
            // 
            // timerSlider
            // 
            this.timerSlider.Interval = 10;
            this.timerSlider.Tick += new System.EventHandler(this.timerSlider_Tick);
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 539);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.panelRegister);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SignUpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SurveyProject";
            this.panelRegister.ResumeLayout(false);
            this.panelRegister.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Panel panelRegister;
        private System.Windows.Forms.TextBox textBoxPasswordReg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPasswordConfirm;
        private System.Windows.Forms.TextBox textBoxUsernameReg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Button buttonGoToRegisterPanel;
        private System.Windows.Forms.Timer timerSlider;
        private System.Windows.Forms.Button buttonConfirmReg;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

