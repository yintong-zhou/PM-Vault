namespace PM_Vault_Form
{
    partial class PMVault
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelNavBar = new System.Windows.Forms.Panel();
            this.btn_generate = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_vault = new System.Windows.Forms.Button();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.btn_logo = new System.Windows.Forms.Button();
            this.panelTopBar = new System.Windows.Forms.Panel();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.lbl_message = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.panelNavBar.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.panelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelNavBar
            // 
            this.panelNavBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(52)))), ((int)(((byte)(69)))));
            this.panelNavBar.Controls.Add(this.btn_generate);
            this.panelNavBar.Controls.Add(this.btn_close);
            this.panelNavBar.Controls.Add(this.btn_vault);
            this.panelNavBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelNavBar.Location = new System.Drawing.Point(0, 0);
            this.panelNavBar.Name = "panelNavBar";
            this.panelNavBar.Size = new System.Drawing.Size(200, 558);
            this.panelNavBar.TabIndex = 0;
            // 
            // btn_generate
            // 
            this.btn_generate.FlatAppearance.BorderSize = 0;
            this.btn_generate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_generate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_generate.Location = new System.Drawing.Point(0, 129);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(200, 47);
            this.btn_generate.TabIndex = 4;
            this.btn_generate.Text = "Generate Password";
            this.btn_generate.UseVisualStyleBackColor = true;
            this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
            // 
            // btn_close
            // 
            this.btn_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_close.FlatAppearance.BorderSize = 0;
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_close.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_close.Image = global::PM_Vault_Form.Properties.Resources.close;
            this.btn_close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_close.Location = new System.Drawing.Point(0, 504);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(200, 54);
            this.btn_close.TabIndex = 3;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // btn_vault
            // 
            this.btn_vault.FlatAppearance.BorderSize = 0;
            this.btn_vault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_vault.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_vault.Location = new System.Drawing.Point(0, 76);
            this.btn_vault.Name = "btn_vault";
            this.btn_vault.Size = new System.Drawing.Size(200, 47);
            this.btn_vault.TabIndex = 2;
            this.btn_vault.Text = "My Vault";
            this.btn_vault.UseVisualStyleBackColor = true;
            this.btn_vault.Click += new System.EventHandler(this.btn_vault_Click);
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.panelTitle.Controls.Add(this.btn_logo);
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(200, 70);
            this.panelTitle.TabIndex = 1;
            // 
            // btn_logo
            // 
            this.btn_logo.FlatAppearance.BorderSize = 0;
            this.btn_logo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_logo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_logo.Image = global::PM_Vault_Form.Properties.Resources._lock;
            this.btn_logo.Location = new System.Drawing.Point(0, 0);
            this.btn_logo.Name = "btn_logo";
            this.btn_logo.Size = new System.Drawing.Size(200, 70);
            this.btn_logo.TabIndex = 0;
            this.btn_logo.UseVisualStyleBackColor = true;
            // 
            // panelTopBar
            // 
            this.panelTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(144)))), ((int)(((byte)(191)))));
            this.panelTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopBar.Location = new System.Drawing.Point(200, 0);
            this.panelTopBar.Name = "panelTopBar";
            this.panelTopBar.Size = new System.Drawing.Size(732, 70);
            this.panelTopBar.TabIndex = 2;
            this.panelTopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTopBar_MouseDown);
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.White;
            this.panelLogin.Controls.Add(this.lbl_message);
            this.panelLogin.Controls.Add(this.label3);
            this.panelLogin.Controls.Add(this.label2);
            this.panelLogin.Controls.Add(this.txt_password);
            this.panelLogin.Controls.Add(this.label1);
            this.panelLogin.Controls.Add(this.txt_username);
            this.panelLogin.Controls.Add(this.btn_Login);
            this.panelLogin.Location = new System.Drawing.Point(200, 103);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(732, 422);
            this.panelLogin.TabIndex = 3;
            // 
            // lbl_message
            // 
            this.lbl_message.AutoSize = true;
            this.lbl_message.ForeColor = System.Drawing.Color.Red;
            this.lbl_message.Location = new System.Drawing.Point(232, 358);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(0, 21);
            this.lbl_message.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(315, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(317, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "Password";
            // 
            // txt_password
            // 
            this.txt_password.AllowDrop = true;
            this.txt_password.Location = new System.Drawing.Point(236, 185);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(260, 27);
            this.txt_password.TabIndex = 5;
            this.txt_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_password.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(232, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Password Manager Vault";
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(236, 125);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(260, 27);
            this.txt_username.TabIndex = 3;
            this.txt_username.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Login
            // 
            this.btn_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(52)))), ((int)(((byte)(69)))));
            this.btn_Login.FlatAppearance.BorderSize = 0;
            this.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Login.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btn_Login.Location = new System.Drawing.Point(301, 266);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(130, 47);
            this.btn_Login.TabIndex = 2;
            this.btn_Login.Text = "Log In";
            this.btn_Login.UseVisualStyleBackColor = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // PMVault
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(932, 558);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.panelTopBar);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.panelNavBar);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PMVault";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.PMVault_Load);
            this.panelNavBar.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelNavBar;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Button btn_logo;
        private System.Windows.Forms.Button btn_vault;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Panel panelTopBar;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_message;
        private System.Windows.Forms.Button btn_generate;
    }
}

