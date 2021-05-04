
namespace DBCW
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.registered = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.passwBox5 = new System.Windows.Forms.TextBox();
            this.loginBox4 = new System.Windows.Forms.TextBox();
            this.phNumBox3 = new System.Windows.Forms.TextBox();
            this.adressBox2 = new System.Windows.Forms.TextBox();
            this.fioBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.err = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.passwBox6 = new System.Windows.Forms.TextBox();
            this.loginBox7 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(786, 434);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.registered);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.passwBox5);
            this.tabPage1.Controls.Add(this.loginBox4);
            this.tabPage1.Controls.Add(this.phNumBox3);
            this.tabPage1.Controls.Add(this.adressBox2);
            this.tabPage1.Controls.Add(this.fioBox1);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(778, 401);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Регистрация";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // registered
            // 
            this.registered.AutoSize = true;
            this.registered.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.registered.ForeColor = System.Drawing.Color.Lime;
            this.registered.Location = new System.Drawing.Point(198, 316);
            this.registered.MaximumSize = new System.Drawing.Size(600, 400);
            this.registered.Name = "registered";
            this.registered.Size = new System.Drawing.Size(406, 32);
            this.registered.TabIndex = 23;
            this.registered.Text = "Регистрация прошла успешно!";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(295, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(285, 29);
            this.button1.TabIndex = 21;
            this.button1.Text = "Зарегистрироваться";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // passwBox5
            // 
            this.passwBox5.Location = new System.Drawing.Point(295, 197);
            this.passwBox5.MaxLength = 150;
            this.passwBox5.Name = "passwBox5";
            this.passwBox5.PasswordChar = '*';
            this.passwBox5.Size = new System.Drawing.Size(285, 27);
            this.passwBox5.TabIndex = 20;
            // 
            // loginBox4
            // 
            this.loginBox4.Location = new System.Drawing.Point(295, 161);
            this.loginBox4.MaxLength = 150;
            this.loginBox4.Name = "loginBox4";
            this.loginBox4.Size = new System.Drawing.Size(285, 27);
            this.loginBox4.TabIndex = 19;
            // 
            // phNumBox3
            // 
            this.phNumBox3.Location = new System.Drawing.Point(295, 127);
            this.phNumBox3.MaxLength = 40;
            this.phNumBox3.Name = "phNumBox3";
            this.phNumBox3.Size = new System.Drawing.Size(285, 27);
            this.phNumBox3.TabIndex = 18;
            // 
            // adressBox2
            // 
            this.adressBox2.Location = new System.Drawing.Point(295, 91);
            this.adressBox2.MaxLength = 200;
            this.adressBox2.Name = "adressBox2";
            this.adressBox2.Size = new System.Drawing.Size(285, 27);
            this.adressBox2.TabIndex = 17;
            // 
            // fioBox1
            // 
            this.fioBox1.Location = new System.Drawing.Point(295, 53);
            this.fioBox1.MaxLength = 50;
            this.fioBox1.Name = "fioBox1";
            this.fioBox1.Size = new System.Drawing.Size(285, 27);
            this.fioBox1.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Пароль";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(198, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Логин";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Тел номер";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Адрес";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(198, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "ФИО";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.err);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.passwBox6);
            this.tabPage2.Controls.Add(this.loginBox7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(778, 401);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Авторизация";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // err
            // 
            this.err.AutoSize = true;
            this.err.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.err.ForeColor = System.Drawing.Color.Red;
            this.err.Location = new System.Drawing.Point(295, 292);
            this.err.Name = "err";
            this.err.Size = new System.Drawing.Size(314, 25);
            this.err.TabIndex = 20;
            this.err.Text = "Неверный логин или пароль";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(295, 234);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(285, 29);
            this.button2.TabIndex = 19;
            this.button2.Text = "Войти";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // passwBox6
            // 
            this.passwBox6.Location = new System.Drawing.Point(295, 174);
            this.passwBox6.Name = "passwBox6";
            this.passwBox6.PasswordChar = '*';
            this.passwBox6.Size = new System.Drawing.Size(285, 27);
            this.passwBox6.TabIndex = 18;
            // 
            // loginBox7
            // 
            this.loginBox7.Location = new System.Drawing.Point(295, 138);
            this.loginBox7.Name = "loginBox7";
            this.loginBox7.Size = new System.Drawing.Size(285, 27);
            this.loginBox7.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "Пароль";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(198, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Логин";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(818, 497);
            this.MinimumSize = new System.Drawing.Size(818, 497);
            this.Name = "Form1";
            this.Text = "MainMenu";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox passwBox5;
        private System.Windows.Forms.TextBox loginBox4;
        private System.Windows.Forms.TextBox phNumBox3;
        private System.Windows.Forms.TextBox adressBox2;
        private System.Windows.Forms.TextBox fioBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox loginBox7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.TextBox passwBox6;
        private System.Windows.Forms.Label registered;
        private System.Windows.Forms.Label err;
    }
}

