﻿namespace BookStore.Test
{
    partial class Form2
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
            productReport1 = new Views.UserControls.ProductReport();
            SuspendLayout();
            // 
            // productReport1
            // 
            productReport1.Dock = DockStyle.Fill;
            productReport1.Location = new Point(0, 0);
            productReport1.Margin = new Padding(3, 4, 3, 4);
            productReport1.Name = "productReport1";
            productReport1.Size = new Size(914, 600);
            productReport1.TabIndex = 0;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(productReport1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
        }

        #endregion

        private Views.UserControls.ProductReport productReport1;
    }
}