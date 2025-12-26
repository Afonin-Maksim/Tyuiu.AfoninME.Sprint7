using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tyuiu.AfoninME.Sprint7.V10.Lib;

namespace Tyuiu.AfoninME.Sprint7.V10
{
    public partial class FormChart : Form
    {
        private readonly List<Order> orders;
        public FormChart(List<Order> orders)
        {
            InitializeComponent();
            this.orders = orders ?? new();
            DrawChart();
        }

        private void DrawChart()
        {
            if (orders.Count == 0) return;

            var grouped = orders
                .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
                .Select(g => new { M = $"{g.Key.Month:D2}.{g.Key.Year}", S = g.Sum(x => x.Total) })
                .OrderBy(x => x.M)
                .ToList();

            int w = pictureBoxChart_AME.Width;
            int h = pictureBoxChart_AME.Height;

            Bitmap bmp = new(w, h);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                var font = new Font("Segoe UI", 9);
                Pen axis = new(Color.Black, 2);
                g.DrawLine(axis, 50, h - 50, w - 50, h - 50);
                g.DrawLine(axis, 50, 50, 50, h - 50);

                decimal max = grouped.Max(x => x.S);
                if (max == 0) max = 1;
                int barW = (w - 100) / (grouped.Count * 2);
                for (int i = 0; i < grouped.Count; i++)
                {
                    float x = 50 + barW * (i * 2 + 1);
                    float barH = (float)(grouped[i].S / max * (h - 100));
                    float y = h - 50 - barH;
                    g.FillRectangle(Brushes.SteelBlue, x, y, barW, barH);
                    g.DrawRectangle(Pens.Black, x, y, barW, barH);
                    g.DrawString(grouped[i].M, font, Brushes.Black, x - 5, h - 45);
                    g.DrawString(grouped[i].S.ToString("F0"), font, Brushes.Black, x, y - 20);
                }
                g.DrawString("Месяц", font, Brushes.Black, w / 2 - 20, h - 25);
                g.DrawString("Сумма (руб.)", font, Brushes.Black, 5, 10);
            }
            pictureBoxChart_AME.Image = bmp;
        }
    }
}