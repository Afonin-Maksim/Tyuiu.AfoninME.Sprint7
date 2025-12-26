using System;
using System.Windows.Forms;

namespace Tyuiu.AfoninME.Sprint7.V10
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;
        private MenuStrip menuMain_AME;
        private ToolStripMenuItem menuFile_AME;
        private ToolStripMenuItem menuOpen_AME;
        private ToolStripMenuItem menuSave_AME;
        private ToolStripMenuItem menuExit_AME;
        private ToolStripMenuItem menuHelp_AME;
        private ToolStripMenuItem menuGuide_AME;
        private ToolStripMenuItem menuAbout_AME;

        private DataGridView dataGridOrders_AME;
        private Label labelSearch_AME;
        private TextBox textBoxSearch_AME;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            menuMain_AME = new MenuStrip();
            menuFile_AME = new ToolStripMenuItem();
            menuOpen_AME = new ToolStripMenuItem();
            menuSave_AME = new ToolStripMenuItem();
            menuExit_AME = new ToolStripMenuItem();
            menuHelp_AME = new ToolStripMenuItem();
            menuGuide_AME = new ToolStripMenuItem();
            menuAbout_AME = new ToolStripMenuItem();
            dataGridOrders_AME = new DataGridView();
            labelSearch_AME = new Label();
            textBoxSearch_AME = new TextBox();
            toolStripButtonSort_AME = new ToolStripButton();
            toolStripButtonFilterDate_AME = new ToolStripButton();
            toolStripButtonStats_AME = new ToolStripButton();
            toolStripButtonChart_AME = new ToolStripButton();
            toolStripMain_AME = new ToolStrip();
            menuMain_AME.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridOrders_AME).BeginInit();
            toolStripMain_AME.SuspendLayout();
            SuspendLayout();
            // 
            // menuMain_AME
            // 
            menuMain_AME.Items.AddRange(new ToolStripItem[] { menuFile_AME, menuHelp_AME });
            menuMain_AME.Location = new Point(0, 0);
            menuMain_AME.Name = "menuMain_AME";
            menuMain_AME.Size = new Size(984, 24);
            menuMain_AME.TabIndex = 4;
            // 
            // menuFile_AME
            // 
            menuFile_AME.DropDownItems.AddRange(new ToolStripItem[] { menuOpen_AME, menuSave_AME, menuExit_AME });
            menuFile_AME.Name = "menuFile_AME";
            menuFile_AME.Size = new Size(48, 20);
            menuFile_AME.Text = "Файл";
            // 
            // menuOpen_AME
            // 
            menuOpen_AME.Name = "menuOpen_AME";
            menuOpen_AME.Size = new Size(132, 22);
            menuOpen_AME.Text = "Открыть";
            menuOpen_AME.Click += buttonOpen_AME_Click;
            // 
            // menuSave_AME
            // 
            menuSave_AME.Name = "menuSave_AME";
            menuSave_AME.Size = new Size(132, 22);
            menuSave_AME.Text = "Сохранить";
            menuSave_AME.Click += buttonSave_AME_Click;
            // 
            // menuExit_AME
            // 
            menuExit_AME.Name = "menuExit_AME";
            menuExit_AME.Size = new Size(132, 22);
            menuExit_AME.Text = "Выход";
            menuExit_AME.Click += menuExit_AME_Click;
            // 
            // menuHelp_AME
            // 
            menuHelp_AME.DropDownItems.AddRange(new ToolStripItem[] { menuGuide_AME, menuAbout_AME });
            menuHelp_AME.Name = "menuHelp_AME";
            menuHelp_AME.Size = new Size(65, 20);
            menuHelp_AME.Text = "Справка";
            // 
            // menuGuide_AME
            // 
            menuGuide_AME.Name = "menuGuide_AME";
            menuGuide_AME.Size = new Size(221, 22);
            menuGuide_AME.Text = "Руководство пользователя";
            menuGuide_AME.Click += buttonHelp_AME_Click;
            // 
            // menuAbout_AME
            // 
            menuAbout_AME.Name = "menuAbout_AME";
            menuAbout_AME.Size = new Size(221, 22);
            menuAbout_AME.Text = "О разработчике";
            menuAbout_AME.Click += buttonAbout_AME_Click;
            // 
            // dataGridOrders_AME
            // 
            dataGridOrders_AME.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridOrders_AME.BackgroundColor = Color.White;
            dataGridOrders_AME.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridOrders_AME.Location = new Point(12, 90);
            dataGridOrders_AME.Name = "dataGridOrders_AME";
            dataGridOrders_AME.RowHeadersVisible = false;
            dataGridOrders_AME.Size = new Size(960, 440);
            dataGridOrders_AME.TabIndex = 0;
            // 
            // labelSearch_AME
            // 
            labelSearch_AME.Location = new Point(12, 60);
            labelSearch_AME.Name = "labelSearch_AME";
            labelSearch_AME.Size = new Size(100, 23);
            labelSearch_AME.TabIndex = 2;
            labelSearch_AME.Text = "Поиск:";
            // 
            // textBoxSearch_AME
            // 
            textBoxSearch_AME.Location = new Point(70, 57);
            textBoxSearch_AME.Name = "textBoxSearch_AME";
            textBoxSearch_AME.Size = new Size(250, 23);
            textBoxSearch_AME.TabIndex = 1;
            textBoxSearch_AME.TextChanged += textBoxSearch_AME_TextChanged;
            // 
            // toolStripButtonSort_AME
            // 
            toolStripButtonSort_AME.Image = (Image)resources.GetObject("toolStripButtonSort_AME.Image");
            toolStripButtonSort_AME.Name = "toolStripButtonSort_AME";
            toolStripButtonSort_AME.Size = new Size(93, 22);
            toolStripButtonSort_AME.Text = "Сортировка";
            toolStripButtonSort_AME.Click += buttonSort_AME_Click;
            // 
            // toolStripButtonFilterDate_AME
            // 
            toolStripButtonFilterDate_AME.Image = (Image)resources.GetObject("toolStripButtonFilterDate_AME.Image");
            toolStripButtonFilterDate_AME.Name = "toolStripButtonFilterDate_AME";
            toolStripButtonFilterDate_AME.Size = new Size(111, 22);
            toolStripButtonFilterDate_AME.Text = "Фильтр по дате";
            toolStripButtonFilterDate_AME.Click += buttonFilterDate_AME_Click;
            // 
            // toolStripButtonStats_AME
            // 
            toolStripButtonStats_AME.Image = (Image)resources.GetObject("toolStripButtonStats_AME.Image");
            toolStripButtonStats_AME.Name = "toolStripButtonStats_AME";
            toolStripButtonStats_AME.Size = new Size(88, 22);
            toolStripButtonStats_AME.Text = "Статистика";
            toolStripButtonStats_AME.Click += buttonStats_AME_Click;
            // 
            // toolStripButtonChart_AME
            // 
            toolStripButtonChart_AME.Image = (Image)resources.GetObject("toolStripButtonChart_AME.Image");
            toolStripButtonChart_AME.Name = "toolStripButtonChart_AME";
            toolStripButtonChart_AME.Size = new Size(68, 22);
            toolStripButtonChart_AME.Text = "График";
            toolStripButtonChart_AME.Click += buttonChart_AME_Click;
            // 
            // toolStripMain_AME
            // 
            toolStripMain_AME.Items.AddRange(new ToolStripItem[] { toolStripButtonSort_AME, toolStripButtonFilterDate_AME, toolStripButtonStats_AME, toolStripButtonChart_AME });
            toolStripMain_AME.Location = new Point(0, 24);
            toolStripMain_AME.Name = "toolStripMain_AME";
            toolStripMain_AME.Size = new Size(984, 25);
            toolStripMain_AME.TabIndex = 3;
            // 
            // FormMain
            // 
            ClientSize = new Size(984, 561);
            Controls.Add(dataGridOrders_AME);
            Controls.Add(textBoxSearch_AME);
            Controls.Add(labelSearch_AME);
            Controls.Add(toolStripMain_AME);
            Controls.Add(menuMain_AME);
            MainMenuStrip = menuMain_AME;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Учёт заказов | Афонин М.Е. | Sprint 7 | Вариант 10";
            menuMain_AME.ResumeLayout(false);
            menuMain_AME.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridOrders_AME).EndInit();
            toolStripMain_AME.ResumeLayout(false);
            toolStripMain_AME.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
        private ToolStripButton toolStripButtonSort_AME;
        private ToolStripButton toolStripButtonFilterDate_AME;
        private ToolStripButton toolStripButtonStats_AME;
        private ToolStripButton toolStripButtonChart_AME;
        private ToolStrip toolStripMain_AME;
    }
}