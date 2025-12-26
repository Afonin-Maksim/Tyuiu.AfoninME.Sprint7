using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tyuiu.AfoninME.Sprint7.V10.Lib;

namespace Tyuiu.AfoninME.Sprint7.V10
{
    public partial class FormFilterDate : Form
    {
        private readonly DataService ds = new();
        private readonly List<Order> orders;
        public List<Order> Result { get; private set; } = new();

        public FormFilterDate(List<Order> ordersList)
        {
            InitializeComponent();
            this.orders = ordersList ?? new List<Order>();
        }

        private void buttonApply_AME_Click(object sender, EventArgs e)
        {
            DateTime from = dateTimePickerFrom_AME.Value.Date;
            DateTime to = dateTimePickerTo_AME.Value.Date;
            Result = ds.FilterByDatePeriod(orders, from, to);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_AME_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}