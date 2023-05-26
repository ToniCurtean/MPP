using System.ComponentModel;

namespace WindowsFormsApp2
{
    partial class MainForm
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
            this.listViewConcerts = new System.Windows.Forms.ListView();
            this.listViewConcertsDate = new System.Windows.Forms.ListView();
            this.dataBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.ticketsBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buyButton = new System.Windows.Forms.Button();
            this.labelErr = new System.Windows.Forms.Label();
            this.logOutButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewConcerts
            // 
            this.listViewConcerts.Location = new System.Drawing.Point(26, 36);
            this.listViewConcerts.Name = "listViewConcerts";
            this.listViewConcerts.Size = new System.Drawing.Size(417, 397);
            this.listViewConcerts.TabIndex = 0;
            this.listViewConcerts.UseCompatibleStateImageBehavior = false;
            // 
            // listViewConcertsDate
            // 
            this.listViewConcertsDate.Location = new System.Drawing.Point(485, 36);
            this.listViewConcertsDate.Name = "listViewConcertsDate";
            this.listViewConcertsDate.Size = new System.Drawing.Size(402, 397);
            this.listViewConcertsDate.TabIndex = 1;
            this.listViewConcertsDate.UseCompatibleStateImageBehavior = false;
            // 
            // dataBox
            // 
            this.dataBox.Location = new System.Drawing.Point(919, 94);
            this.dataBox.Name = "dataBox";
            this.dataBox.Size = new System.Drawing.Size(147, 22);
            this.dataBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(919, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cauta dupa data";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(991, 143);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 4;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.OnSearchButtonClick);
            this.searchButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnSearchButtonClick);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(64, 480);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(137, 22);
            this.nameBox.TabIndex = 5;
            // 
            // ticketsBox
            // 
            this.ticketsBox.Location = new System.Drawing.Point(306, 480);
            this.ticketsBox.Name = "ticketsBox";
            this.ticketsBox.Size = new System.Drawing.Size(144, 22);
            this.ticketsBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(64, 455);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nume:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(306, 454);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Numar bilete";
            // 
            // buyButton
            // 
            this.buyButton.Location = new System.Drawing.Point(375, 526);
            this.buyButton.Name = "buyButton";
            this.buyButton.Size = new System.Drawing.Size(75, 34);
            this.buyButton.TabIndex = 9;
            this.buyButton.Text = "Buy";
            this.buyButton.UseVisualStyleBackColor = true;
            this.buyButton.Click += new System.EventHandler(this.OnBuyButtonClick);
            // 
            // labelErr
            // 
            this.labelErr.Location = new System.Drawing.Point(485, 436);
            this.labelErr.Name = "labelErr";
            this.labelErr.Size = new System.Drawing.Size(402, 66);
            this.labelErr.TabIndex = 10;
            // 
            // logOutButton
            // 
            this.logOutButton.Location = new System.Drawing.Point(969, 537);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(97, 33);
            this.logOutButton.TabIndex = 11;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.OnLogOutButtonClick);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.label7.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 582);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.labelErr);
            this.Controls.Add(this.buyButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ticketsBox);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataBox);
            this.Controls.Add(this.listViewConcertsDate);
            this.Controls.Add(this.listViewConcerts);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.mainLoad);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.Button logOutButton;

        private System.Windows.Forms.Label labelErr;

        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox ticketsBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buyButton;

        private System.Windows.Forms.Button searchButton;

        private System.Windows.Forms.ListView listViewConcertsDate;
        private System.Windows.Forms.TextBox dataBox;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.ListView listViewConcerts;

        #endregion
    }
}