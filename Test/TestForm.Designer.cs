namespace BookStore.Test
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
            updateProduct1 = new Views.UserControls.UpdateProduct(3);
            SuspendLayout();
            // 
            // updateProduct1
            // 
            updateProduct1.AutoScroll = true;
            updateProduct1.BackColor = Color.White;
            updateProduct1.Dock = DockStyle.Fill;
            updateProduct1.Location = new Point(0, 0);
            updateProduct1.Name = "updateProduct1";
            updateProduct1.Size = new Size(889, 574);
            updateProduct1.TabIndex = 1;
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(889, 574);
            Controls.Add(updateProduct1);
            Name = "TestForm";
            Text = "TestForm";
            Load += TestForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Views.UserControls.UpdateProduct updateProduct1;
    }
}