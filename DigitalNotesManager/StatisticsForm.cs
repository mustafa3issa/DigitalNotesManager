using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DigitalNotesManager.Data;
using DigitalNotesManager.Helpers;

namespace DigitalNotesManager
{
    public partial class StatisticsForm : Form
    {
        private readonly NotesDbContext _context = new NotesDbContext();

        public StatisticsForm()
        {
            InitializeComponent();
            LoadCategoryChart();
            LoadMonthlyChart();
        }

        private void LoadCategoryChart()
        {
            var notesByCategory = _context.Notes
                .Where(n => n.UserID == UserSession.UserID)
                .GroupBy(n => n.Category)
                .Select(g => new { Category = g.Key ?? "Uncategorized", Count = g.Count() })
                .OrderByDescending(g => g.Count)
                .ToList();

            categoryChart.Series.Clear();
            categoryChart.Legends.Clear();
            categoryChart.Titles.Clear();

            var series = new Series("Notes by Category");
            series.ChartType = SeriesChartType.Pie;
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "{0}";
            series["PieLabelStyle"] = "Inside"; // Show values inside the pie slices
            series.BorderColor = Color.White;
            series.BorderWidth = 2;

            foreach (var item in notesByCategory)
                series.Points.AddXY(item.Category, item.Count);

            categoryChart.Series.Add(series);

            var legend = new Legend("Categories");
            legend.Docking = Docking.Right;
            legend.Alignment = StringAlignment.Center;
            legend.LegendStyle = LegendStyle.Table;
            legend.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            categoryChart.Legends.Add(legend);

            categoryChart.Titles.Add("Notes per Category");
        }

        private void LoadMonthlyChart()
        {
            var notesByMonth = _context.Notes
                .Where(n => n.UserID == UserSession.UserID)
                .GroupBy(n => new { n.CreatedDate.Year, n.CreatedDate.Month })
                .Select(g => new
                {
                    g.Key.Year,
                    g.Key.Month,
                    Count = g.Count()
                })
                .OrderBy(g => g.Year)
                .ThenBy(g => g.Month)
                .ToList()
                .Select(g => new
                {
                    Month = $"{g.Month}/{g.Year}",
                    g.Count
                })
                .ToList();

            monthlyChart.Series.Clear();

            var series = new Series("Notes per Month")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                LabelForeColor = Color.White, // Label color inside the column
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            // Show label inside the column instead of above it
            series["LabelStyle"] = "Bottom";  // Puts label inside the column
            series["PointWidth"] = "0.6";     // Adjusts column width

            foreach (var item in notesByMonth)
                series.Points.AddXY(item.Month, item.Count);

            monthlyChart.Series.Add(series);

            // Improve chart appearance
            var chartArea = monthlyChart.ChartAreas[0];
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.BackColor = Color.White;

            monthlyChart.Titles.Clear();
            monthlyChart.Titles.Add("Notes Created per Month");
        }
    }
}
