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
            createOrder1 = new Views.UserControls.CreateOrder();
            SuspendLayout();
            // 
            // createOrder1
            // 
            createOrder1.Dock = DockStyle.Fill;
            createOrder1.Location = new Point(0, 0);
            createOrder1.Name = "createOrder1";
            createOrder1.Size = new Size(842, 450);
            createOrder1.TabIndex = 0;
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(842, 450);
            Controls.Add(createOrder1);
            Name = "TestForm";
            Text = "TestForm";
            Load += TestForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Views.UserControls.CreateOrder createOrder1;
    }
}