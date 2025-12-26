using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Tyuiu.AfoninME.Sprint7.V10.Lib
{
    public class Order
    {
        public string LastName { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string Patronymic { get; set; } = "";
        public string AccountNumber { get; set; } = "";
        public string Address { get; set; } = "";
        public string Phone { get; set; } = "";
        public string OrderNumber { get; set; } = "";
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string ProductName { get; set; } = "";
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }

        public decimal Total => ProductPrice * Quantity;
    }

    public class DataService
    {
        private static readonly char[] Delimiters = { ';', ',', '\t', '|', ' ' };

        // ==== Загрузка CSV ====
        public List<Order> LoadOrders(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Файл не найден.", path);

            var orders = new List<Order>();

            foreach (var raw in File.ReadAllLines(path))
            {
                if (string.IsNullOrWhiteSpace(raw)) continue;

                char delimiter = raw.Contains(';') ? ';' :
                                 raw.Contains('\t') ? '\t' :
                                 raw.Contains('|') ? '|' :
                                 raw.Contains(',') ? ',' : ' ';

                string[] p = raw.Split(delimiter);
                if (p.Length < 11) continue;

                DateTime.TryParse(p[7].Trim(), new CultureInfo("ru-RU"),
                    DateTimeStyles.None, out DateTime date);
                decimal.TryParse(p[9].Trim().Replace(',', '.'),
                    NumberStyles.Float, CultureInfo.InvariantCulture, out decimal price);
                int.TryParse(p[10].Trim(), out int qty);

                orders.Add(new Order
                {
                    LastName = p[0].Trim(),
                    FirstName = p[1].Trim(),
                    Patronymic = p[2].Trim(),
                    AccountNumber = p[3].Trim(),
                    Address = p[4].Trim(),
                    Phone = p[5].Trim(),
                    OrderNumber = p[6].Trim(),
                    OrderDate = date,
                    ProductName = p[8].Trim(),
                    ProductPrice = price,
                    Quantity = qty
                });
            }
            return orders;
        }

        // ==== Сохранение CSV ====
        public void SaveOrders(string path, IEnumerable<Order> orders)
        {
            var lines = orders.Select(o =>
                $"{o.LastName};{o.FirstName};{o.Patronymic};{o.AccountNumber};{o.Address};{o.Phone};" +
                $"{o.OrderNumber};{o.OrderDate:dd.MM.yyyy};{o.ProductName};" +
                $"{Math.Round(o.ProductPrice, 0)};{o.Quantity}");

            // ✅ Excel понимает UTF‑8 только с подписью BOM.
            var utf8bom = new System.Text.UTF8Encoding(encoderShouldEmitUTF8Identifier: true);

            File.WriteAllLines(path, lines, utf8bom);
        }

        // ==== Поиск ====
        public List<Order> SearchByAnyField(List<Order> orders, string query)
        {
            if (orders == null || orders.Count == 0) return new List<Order>();
            if (string.IsNullOrWhiteSpace(query)) return orders;

            string q = query.ToLower().Trim();

            return orders
                .Where(o =>
                    ($"{o.LastName} {o.FirstName} {o.Patronymic} {o.AccountNumber} {o.Address} {o.Phone} " +
                     $"{o.OrderNumber} {o.OrderDate:dd.MM.yyyy} {o.ProductName} {o.ProductPrice} {o.Quantity} {o.Total}")
                    .ToLower()
                    .Contains(q))
                .ToList();
        }

        // ==== Сортировка (исправленная) ====
        public List<Order> Sort(List<Order> src, string field, bool desc = false)
        {
            if (src == null || src.Count == 0) return new List<Order>();

            string f = field.Trim().ToLowerInvariant();
            IEnumerable<Order> res = src;

            if (f == "сумма" || f == "итог")
            {
                res = desc ? src.OrderByDescending(o => o.ProductPrice * o.Quantity)
                           : src.OrderBy(o => o.ProductPrice * o.Quantity);
            }
            else if (f == "цена" || f == "стоимость")
            {
                res = desc ? src.OrderByDescending(o => o.ProductPrice)
                           : src.OrderBy(o => o.ProductPrice);
            }
            else if (f == "кол-во" || f == "количество")
            {
                res = desc ? src.OrderByDescending(o => o.Quantity)
                           : src.OrderBy(o => o.Quantity);
            }
            else if (f == "дата")
            {
                res = desc ? src.OrderByDescending(o => o.OrderDate)
                           : src.OrderBy(o => o.OrderDate);
            }
            else
            {
                res = desc ? src.OrderByDescending(o => o.LastName)
                           : src.OrderBy(o => o.LastName);
            }

            return res.ToList();
        }

        // ==== Статистика ====
        public (int Count, decimal Sum, decimal Avg, decimal Min, decimal Max) GetStatistics(List<Order> orders)
        {
            if (orders == null || orders.Count == 0)
                return (0, 0, 0, 0, 0);

            var totals = orders.Select(o => o.Total);
            return (orders.Count, totals.Sum(), totals.Average(), totals.Min(), totals.Max());
        }

        // ==== Данные для графика ====
        public Dictionary<string, decimal> GetChartData(List<Order> orders)
        {
            var dict = new Dictionary<string, decimal>();
            if (orders == null || orders.Count == 0) return dict;

            foreach (var group in orders.GroupBy(o => $"{o.OrderDate.Month:D2}.{o.OrderDate.Year}"))
            {
                dict[group.Key] = group.Sum(o => o.Total);
            }

            return dict;
        }
        public List<Order> FilterByDatePeriod(List<Order> orders, DateTime from, DateTime to)
        {
            if (orders == null || orders.Count == 0)
                return new List<Order>();

            // Чтобы корректно отфильтровать — сравниваем только дату без времени
            DateTime start = from.Date;
            DateTime end = to.Date;

            return orders
                .Where(o => o.OrderDate.Date >= start && o.OrderDate.Date <= end)
                .OrderBy(o => o.OrderDate)
                .ToList();
        }
    }
}