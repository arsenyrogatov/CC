namespace CC
{
    partial class LoginForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.login_button = new System.Windows.Forms.Button();
            this.login_maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.pwd_maskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // login_button
            // 
            this.login_button.Location = new System.Drawing.Point(332, 101);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(132, 25);
            this.login_button.TabIndex = 0;
            this.login_button.Text = "Войти";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // login_maskedTextBox
            // 
            this.login_maskedTextBox.Location = new System.Drawing.Point(332, 28);
            this.login_maskedTextBox.Mask = "+0 (999) 000-00-00";
            this.login_maskedTextBox.Name = "login_maskedTextBox";
            this.login_maskedTextBox.Size = new System.Drawing.Size(132, 25);
            this.login_maskedTextBox.TabIndex = 3;
            // 
            // pwd_maskedTextBox
            // 
            this.pwd_maskedTextBox.Location = new System.Drawing.Point(332, 73);
            this.pwd_maskedTextBox.Mask = "000000";
            this.pwd_maskedTextBox.Name = "pwd_maskedTextBox";
            this.pwd_maskedTextBox.PasswordChar = '*';
            this.pwd_maskedTextBox.Size = new System.Drawing.Size(132, 25);
            this.pwd_maskedTextBox.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.login_maskedTextBox);
            this.panel1.Controls.Add(this.pwd_maskedTextBox);
            this.panel1.Controls.Add(this.login_button);
            this.panel1.Location = new System.Drawing.Point(3, 217);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 142);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Пароль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Номер телефона";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CC.Properties.Resources.home;
            this.pictureBox1.Location = new System.Drawing.Point(178, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(701, 199);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(251)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(800, 460);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "to build a home";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.MaskedTextBox login_maskedTextBox;
        private System.Windows.Forms.MaskedTextBox pwd_maskedTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

