using System.ComponentModel;

namespace client
{
    partial class FestivalWindow
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
            this.concertsView = new System.Windows.Forms.ListView();
            this.concertsDateView = new System.Windows.Forms.ListView();
            this.dateText = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buyerText = new System.Windows.Forms.TextBox();
            this.ticketsText = new System.Windows.Forms.TextBox();
            this.buyButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.logoutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // concertsView
            // 
            this.concertsView.Location = new System.Drawing.Point(27, 36);
            this.concertsView.Name = "concertsView";
            this.concertsView.Size = new System.Drawing.Size(332, 239);
            this.concertsView.TabIndex = 0;
            this.concertsView.UseCompatibleStateImageBehavior = false;
            // 
            // concertsDateView
            // 
            this.concertsDateView.Location = new System.Drawing.Point(420, 36);
            this.concertsDateView.Name = "concertsDateView";
            this.concertsDateView.Size = new System.Drawing.Size(327, 239);
            this.concertsDateView.TabIndex = 1;
            this.concertsDateView.UseCompatibleStateImageBehavior = false;
            // 
            // dateText
            // 
            this.dateText.Location = new System.Drawing.Point(601, 294);
            this.dateText.Name = "dateText";
            this.dateText.Size = new System.Drawing.Size(146, 22);
            this.dateText.TabIndex = 2;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(601, 322);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(146, 36);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Cauta dupa data";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(390, 364);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // buyerText
            // 
            this.buyerText.Location = new System.Drawing.Point(40, 311);
            this.buyerText.Name = "buyerText";
            this.buyerText.Size = new System.Drawing.Size(122, 22);
            this.buyerText.TabIndex = 5;
            // 
            // ticketsText
            // 
            this.ticketsText.Location = new System.Drawing.Point(40, 361);
            this.ticketsText.Name = "ticketsText";
            this.ticketsText.Size = new System.Drawing.Size(122, 22);
            this.ticketsText.TabIndex = 6;
            // 
            // buyButton
            // 
            this.buyButton.Location = new System.Drawing.Point(40, 403);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(122, 23);
            this.buyButton.TabIndex = 7;
            this.buyButton.Text = "Cumpara bilete!";
            this.buyButton.UseVisualStyleBackColor = true;
            this.buyButton.Click += new System.EventHandler(this.buyButton_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(40, 285);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nume";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(40, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Numar de bilete";
            // 
            // logoutButton
            // 
            this.logoutButton.Location = new System.Drawing.Point(713, 415);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(75, 23);
            this.logoutButton.TabIndex = 10;
            this.logoutButton.Text = "Log Out";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // FestivalWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buyButton);
            this.Controls.Add(this.ticketsText);
            this.Controls.Add(this.buyerText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.dateText);
            this.Controls.Add(this.concertsDateView);
            this.Controls.Add(this.concertsView);
            this.Name = "FestivalWindow";
            this.Text = "FestivalWindow";
            this.Load += new System.EventHandler(this.mainLoad);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button logoutButton;

        private System.Windows.Forms.TextBox buyerText;
        private System.Windows.Forms.TextBox ticketsText;
        private System.Windows.Forms.Button buyButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.ListView concertsView;
        private System.Windows.Forms.ListView concertsDateView;
        private System.Windows.Forms.TextBox dateText;
        private System.Windows.Forms.Button searchButton;

        #endregion
    }
}