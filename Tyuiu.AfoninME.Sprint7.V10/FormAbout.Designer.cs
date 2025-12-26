namespace Tyuiu.AfoninME.Sprint7.V10
{
    partial class FormAbout
    {
        private System.Windows.Forms.PictureBox pictureBoxLogo_AME;
        private System.Windows.Forms.Label labelInfo_AME;
        private System.Windows.Forms.Button buttonOk_AME;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            pictureBoxLogo_AME = new PictureBox();
            labelInfo_AME = new Label();
            buttonOk_AME = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo_AME).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxLogo_AME
            // 
            pictureBoxLogo_AME.Image = (Image)resources.GetObject("pictureBoxLogo_AME.Image");
            pictureBoxLogo_AME.Location = new Point(12, 12);
            pictureBoxLogo_AME.Name = "pictureBoxLogo_AME";
            pictureBoxLogo_AME.Size = new Size(160, 160);
            pictureBoxLogo_AME.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLogo_AME.TabIndex = 0;
            pictureBoxLogo_AME.TabStop = false;
            // 
            // labelInfo_AME
            // 
            labelInfo_AME.AutoSize = true;
            labelInfo_AME.Font = new Font("Microsoft Sans Serif", 10F);
            labelInfo_AME.Location = new Point(190, 20);
            labelInfo_AME.Name = "labelInfo_AME";
            labelInfo_AME.Size = new Size(323, 119);
            labelInfo_AME.TabIndex = 1;
            labelInfo_AME.Text = "Разработчик: Афонин М.Е.\nГруппа: ИСТНб-25-1\n\nТюменский индустриальный университет, 2025\nПредметная область: Заказы\n\nВнутреннее имя: Tyuiu.AfoninME.Sprint7.V10";
            // 
            // buttonOk_AME
            // 
            buttonOk_AME.Image = (Image)resources.GetObject("buttonOk_AME.Image");
            buttonOk_AME.Location = new Point(380, 150);
            buttonOk_AME.Name = "buttonOk_AME";
            buttonOk_AME.Size = new Size(75, 45);
            buttonOk_AME.TabIndex = 2;
            buttonOk_AME.Click += buttonOk_AME_Click;
            // 
            // FormAbout
            // 
            ClientSize = new Size(520, 200);
            Controls.Add(pictureBoxLogo_AME);
            Controls.Add(labelInfo_AME);
            Controls.Add(buttonOk_AME);
            Name = "FormAbout";
            StartPosition = FormStartPosition.CenterParent;
            Text = "О программе";
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo_AME).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}