﻿namespace BookStore.Test
{
    partial class TestForm
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
            listOrder1 = new Views.Forms.ListOrder();
            SuspendLayout();
            // 
            // listOrder1
            // 
            listOrder1.Dock = DockStyle.Fill;
            listOrder1.Location = new Point(0, 0);
            listOrder1.Name = "listOrder1";
            listOrder1.Size = new Size(871, 574);
            listOrder1.TabIndex = 0;
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(871, 574);
            Controls.Add(listOrder1);
            Name = "TestForm";
            Text = "TestForm";
            Load += TestForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Views.Forms.ListOrder listOrder1;
    }
}