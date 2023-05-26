using System.ComponentModel;

namespace client
{
    partial class LoginWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.usernameText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernameText
            // 
            this.usernameText.Location = new System.Drawing.Point(49, 62);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(135, 22);
            this.usernameText.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(49, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(49, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(49, 151);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(135, 22);
            this.passwordText.TabIndex = 3;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(109, 201);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 39);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Log in";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // LoginWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usernameText);
            this.Name = "LoginWindow";
            this.Text = "LoginWindow";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button loginButton;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordText;

        private System.Windows.Forms.TextBox usernameText;
        private System.Windows.Forms.Label label1;

        #endregion
    }
}