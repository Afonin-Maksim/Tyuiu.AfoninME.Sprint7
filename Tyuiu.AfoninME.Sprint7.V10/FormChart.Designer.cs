namespace Tyuiu.AfoninME.Sprint7.V10
{
    partial class FormChart
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox pictureBoxChart_AME;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pictureBoxChart_AME = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChart_AME)).BeginInit();
            this.SuspendLayout();
            this.pictureBoxChart_AME.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxChart_AME.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxChart_AME.Name = "pictureBoxChart_AME";
            this.pictureBoxChart_AME.Size = new System.Drawing.Size(800, 450);
            this.pictureBoxChart_AME.TabIndex = 0;
            this.pictureBoxChart_AME.TabStop = false;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBoxChart_AME);
            this.Text = "График заказов по месяцам";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxChart_AME)).EndInit();
            this.ResumeLayout(false);
        }
    }
}