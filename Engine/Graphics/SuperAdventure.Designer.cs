namespace Graphics
{
    partial class SuperAdventure
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
            this.SuspendLayout();
            // 
            // SuperAdventure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 545);
            this.Name = "SuperAdventure";
            this.Text = "SuperAdventure";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SuperAdventure_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SuperAdventure_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SuperAdventure_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.SuperAdventure_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}