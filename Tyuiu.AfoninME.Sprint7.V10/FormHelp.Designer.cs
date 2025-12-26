namespace Tyuiu.AfoninME.Sprint7.V10
{
    partial class FormHelp
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelHelpText_AME;
        private System.Windows.Forms.Button buttonClose_AME;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHelp));
            labelHelpText_AME = new Label();
            buttonClose_AME = new Button();
            SuspendLayout();
            // 
            // labelHelpText_AME
            // 
            labelHelpText_AME.AutoSize = true;
            labelHelpText_AME.Font = new Font("Segoe UI", 10F);
            labelHelpText_AME.Location = new Point(20, 20);
            labelHelpText_AME.MaximumSize = new Size(550, 0);
            labelHelpText_AME.Name = "labelHelpText_AME";
            labelHelpText_AME.Size = new Size(518, 209);
            labelHelpText_AME.TabIndex = 0;
            labelHelpText_AME.Text = resources.GetString("labelHelpText_AME.Text");
            // 
            // buttonClose_AME
            // 
            buttonClose_AME.Font = new Font("Segoe UI", 10F);
            buttonClose_AME.Image = (Image)resources.GetObject("buttonClose_AME.Image");
            buttonClose_AME.Location = new Point(234, 287);
            buttonClose_AME.Name = "buttonClose_AME";
            buttonClose_AME.Size = new Size(120, 61);
            buttonClose_AME.TabIndex = 1;
            buttonClose_AME.Click += buttonClose_AME_Click;
            // 
            // FormHelp
            // 
            ClientSize = new Size(600, 360);
            Controls.Add(labelHelpText_AME);
            Controls.Add(buttonClose_AME);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FormHelp";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Руководство пользователя";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}