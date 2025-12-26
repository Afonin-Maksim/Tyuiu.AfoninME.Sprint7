namespace Tyuiu.AfoninME.Sprint7.V10
{
    partial class FormFilterDate
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelFrom_AME;
        private System.Windows.Forms.Label labelTo_AME;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom_AME;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo_AME;
        private System.Windows.Forms.Button buttonApply_AME;
        private System.Windows.Forms.Button buttonCancel_AME;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFilterDate));
            labelFrom_AME = new Label();
            labelTo_AME = new Label();
            dateTimePickerFrom_AME = new DateTimePicker();
            dateTimePickerTo_AME = new DateTimePicker();
            buttonApply_AME = new Button();
            buttonCancel_AME = new Button();
            SuspendLayout();
            // 
            // labelFrom_AME
            // 
            labelFrom_AME.AutoSize = true;
            labelFrom_AME.Location = new Point(25, 30);
            labelFrom_AME.Name = "labelFrom_AME";
            labelFrom_AME.Size = new Size(18, 15);
            labelFrom_AME.TabIndex = 0;
            labelFrom_AME.Text = "С:";
            // 
            // labelTo_AME
            // 
            labelTo_AME.AutoSize = true;
            labelTo_AME.Location = new Point(210, 30);
            labelTo_AME.Name = "labelTo_AME";
            labelTo_AME.Size = new Size(26, 15);
            labelTo_AME.TabIndex = 2;
            labelTo_AME.Text = "По:";
            // 
            // dateTimePickerFrom_AME
            // 
            dateTimePickerFrom_AME.Format = DateTimePickerFormat.Short;
            dateTimePickerFrom_AME.Location = new Point(60, 25);
            dateTimePickerFrom_AME.Name = "dateTimePickerFrom_AME";
            dateTimePickerFrom_AME.Size = new Size(120, 23);
            dateTimePickerFrom_AME.TabIndex = 1;
            // 
            // dateTimePickerTo_AME
            // 
            dateTimePickerTo_AME.Format = DateTimePickerFormat.Short;
            dateTimePickerTo_AME.Location = new Point(245, 25);
            dateTimePickerTo_AME.Name = "dateTimePickerTo_AME";
            dateTimePickerTo_AME.Size = new Size(120, 23);
            dateTimePickerTo_AME.TabIndex = 3;
            // 
            // buttonApply_AME
            // 
            buttonApply_AME.Image = (Image)resources.GetObject("buttonApply_AME.Image");
            buttonApply_AME.Location = new Point(60, 75);
            buttonApply_AME.Name = "buttonApply_AME";
            buttonApply_AME.Size = new Size(79, 43);
            buttonApply_AME.TabIndex = 4;
            buttonApply_AME.Click += buttonApply_AME_Click;
            // 
            // buttonCancel_AME
            // 
            buttonCancel_AME.Image = (Image)resources.GetObject("buttonCancel_AME.Image");
            buttonCancel_AME.Location = new Point(245, 75);
            buttonCancel_AME.Name = "buttonCancel_AME";
            buttonCancel_AME.Size = new Size(75, 43);
            buttonCancel_AME.TabIndex = 5;
            buttonCancel_AME.Click += buttonCancel_AME_Click;
            // 
            // FormFilterDate
            // 
            ClientSize = new Size(400, 130);
            Controls.Add(labelFrom_AME);
            Controls.Add(dateTimePickerFrom_AME);
            Controls.Add(labelTo_AME);
            Controls.Add(dateTimePickerTo_AME);
            Controls.Add(buttonApply_AME);
            Controls.Add(buttonCancel_AME);
            Name = "FormFilterDate";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Фильтр по дате";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}