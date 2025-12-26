#nullable disable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Tyuiu.AfoninME.Sprint7.V10.Lib;

namespace Tyuiu.AfoninME.Sprint7.V10
{
    public partial class FormMain : Form
    {
        private readonly DataService ds = new();
        private List<Order> allOrders = new();   // полный набор заказов из файла
        private List<Order> orders = new();      // текущий набор заказов после фильтраций/сортировок
        private string currentFile = "";
        private bool sortDescending = false;

        public FormMain()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
            Text = "Учёт заказов | Афонин М.Е. | Sprint 7 | Вариант 10";

            dataGridOrders_AME.AutoGenerateColumns = true;
            dataGridOrders_AME.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridOrders_AME.CellValueChanged += dataGridOrders_AME_CellValueChanged;
            dataGridOrders_AME.CurrentCellDirtyStateChanged += dataGridOrders_AME_CurrentCellDirtyStateChanged;
        }

        // === для немедленного пересчёта ===
        private void dataGridOrders_AME_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridOrders_AME.IsCurrentCellDirty)
                dataGridOrders_AME.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        // === пересчёт суммы при изменении цены/количества ===
        private void dataGridOrders_AME_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            string col = dataGridOrders_AME.Columns[e.ColumnIndex].HeaderText;
            if (col != "Цена" && col != "Кол-во") return;

            try
            {
                var row = dataGridOrders_AME.Rows[e.RowIndex];
                if (row.IsNewRow) return;

                decimal price = 0;
                int qty = 0;
                decimal.TryParse(Convert.ToString(row.Cells["Цена"].Value), out price);
                int.TryParse(Convert.ToString(row.Cells["Кол-во"].Value), out qty);
                decimal total = price * qty;
                row.Cells["Сумма"].Value = total.ToString("0");

                // обновим коллекцию при изменениях
                if (e.RowIndex < orders.Count)
                {
                    orders[e.RowIndex].ProductPrice = price;
                    orders[e.RowIndex].Quantity = qty;
                }
            }
            catch { }
        }

        // === Открытие файла ===
        private void buttonOpen_AME_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new())
            {
                dlg.Filter = "CSV файлы|*.csv|Все файлы|*.*";
                if (dlg.ShowDialog() != DialogResult.OK) return;

                currentFile = dlg.FileName;
                allOrders = ds.LoadOrders(currentFile);
                orders = new List<Order>(allOrders);
                ShowOrders(orders);
            }
        }

        // === Сохранение файла ===
        private void buttonSave_AME_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new())
            {
                dlg.Filter = "CSV файлы|*.csv|Все файлы|*.*";
                if (dlg.ShowDialog() != DialogResult.OK) return;

                SyncGridToOrders();
                ds.SaveOrders(dlg.FileName, orders);
                MessageBox.Show("Файл успешно сохранён!", "Сохранение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // === Синхронизация таблицы и списка заказов ===
        private void SyncGridToOrders()
        {
            orders.Clear();
            foreach (DataGridViewRow row in dataGridOrders_AME.Rows)
            {
                if (row.IsNewRow) continue;

                decimal price = 0;
                int qty = 0;
                DateTime.TryParse(Convert.ToString(row.Cells["Дата"].Value), out DateTime date);
                decimal.TryParse(Convert.ToString(row.Cells["Цена"].Value), out price);
                int.TryParse(Convert.ToString(row.Cells["Кол-во"].Value), out qty);

                orders.Add(new Order
                {
                    LastName = Convert.ToString(row.Cells["Фамилия"].Value ?? ""),
                    FirstName = Convert.ToString(row.Cells["Имя"].Value ?? ""),
                    Patronymic = Convert.ToString(row.Cells["Отчество"].Value ?? ""),
                    AccountNumber = Convert.ToString(row.Cells["№ счёта"].Value ?? ""),
                    Address = Convert.ToString(row.Cells["Адрес"].Value ?? ""),
                    Phone = Convert.ToString(row.Cells["Телефон"].Value ?? ""),
                    OrderNumber = Convert.ToString(row.Cells["№ заказа"].Value ?? ""),
                    OrderDate = date == DateTime.MinValue ? DateTime.Now : date,
                    ProductName = Convert.ToString(row.Cells["Товар"].Value ?? ""),
                    ProductPrice = price,
                    Quantity = qty
                });
            }
        }

        // === Поиск ===
        private void textBoxSearch_AME_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSearch_AME.Text))
                ShowOrders(orders);
            else
                ShowOrders(ds.SearchByAnyField(orders, textBoxSearch_AME.Text));
        }

        // === Сортировка ===
        private void buttonSort_AME_Click(object sender, EventArgs e)
        {
            if (orders == null || orders.Count == 0)
            {
                MessageBox.Show("Нет данных для сортировки.");
                return;
            }

            sortDescending = !sortDescending;
            orders = ds.Sort(orders, "сумма", sortDescending);
            ShowOrders(orders);
            toolStripButtonSort_AME.Text = sortDescending ? "Сортировка ↓" : "Сортировка ↑";

            ShowStatsAndChart(); // ← сразу показать статистику и график
        }

        // === Фильтр по дате ===
        private void buttonFilterDate_AME_Click(object sender, EventArgs e)
        {
            if (allOrders == null || allOrders.Count == 0)
            {
                MessageBox.Show("Нет исходных данных для фильтрации.");
                return;
            }

            using (var form = new FormFilterDate(allOrders))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    orders = form.Result.ToList();
                    ShowOrders(orders);
                    ShowStatsAndChart(); // ← сразу показать статистику и график
                }
            }
        }

        // === Сброс фильтра ===
        private void buttonReset_AME_Click(object sender, EventArgs e)
        {
            if (allOrders == null || allOrders.Count == 0) return;
            orders = new List<Order>(allOrders);
            ShowOrders(orders);
        }

        // === Статистика и график (вынесено вместе) ===
        private void ShowStatsAndChart()
        {
            if (orders == null || orders.Count == 0)
            {
                MessageBox.Show("Нет данных для анализа.");
                return;
            }

            var s = ds.GetStatistics(orders);
            MessageBox.Show(
                $"Количество заказов: {s.Count}\n" +
                $"Общая сумма: {s.Sum}\n" +
                $"Средняя: {Math.Round(s.Avg, 0)}\n" +
                $"Минимум: {Math.Round(s.Min, 0)}\n" +
                $"Максимум: {Math.Round(s.Max, 0)}",
                "Статистика");
            new FormChart(orders).ShowDialog();
        }

        // === Просто кнопки ===
        private void buttonStats_AME_Click(object sender, EventArgs e) => ShowStatsAndChart();
        private void buttonChart_AME_Click(object sender, EventArgs e) => new FormChart(orders).ShowDialog();
        private void buttonHelp_AME_Click(object sender, EventArgs e) => new FormHelp().ShowDialog();
        private void buttonAbout_AME_Click(object sender, EventArgs e) => new FormAbout().ShowDialog();
        private void menuExit_AME_Click(object sender, EventArgs e) => this.Close();

        // === Формирование таблицы ===
        private void ShowOrders(IEnumerable<Order> list)
        {
            dataGridOrders_AME.Columns.Clear();
            dataGridOrders_AME.Rows.Clear();

            string[] headers = {
                "Фамилия","Имя","Отчество","№ счёта","Адрес","Телефон",
                "№ заказа","Дата","Товар","Цена","Кол-во","Сумма"
            };
            foreach (string h in headers)
                dataGridOrders_AME.Columns.Add(h, h);

            foreach (var o in list)
            {
                dataGridOrders_AME.Rows.Add(
                    o.LastName,
                    o.FirstName,
                    o.Patronymic,
                    o.AccountNumber,
                    o.Address,
                    o.Phone,
                    o.OrderNumber,
                    o.OrderDate.ToShortDateString(),
                    o.ProductName,
                    o.ProductPrice.ToString("0"),
                    o.Quantity,
                    (o.ProductPrice * o.Quantity).ToString("0"));
            }
        }
    }
}