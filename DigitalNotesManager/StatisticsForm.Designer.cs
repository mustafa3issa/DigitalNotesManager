using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DigitalNotesManager
{
    partial class StatisticsForm
    {
        private Chart categoryChart;
        private Chart monthlyChart;

        private void InitializeComponent()
        {
            categoryChart = new Chart();
            monthlyChart = new Chart();
            ChartArea chartArea1 = new ChartArea();
            ChartArea chartArea2 = new ChartArea();

            // Category Chart
            chartArea1.Name = "ChartArea1";
            categoryChart.ChartAreas.Add(chartArea1);
            categoryChart.Location = new System.Drawing.Point(20, 20);
            categoryChart.Size = new System.Drawing.Size(400, 350);
            categoryChart.BackColor = System.Drawing.Color.WhiteSmoke;
            categoryChart.BorderlineColor = System.Drawing.Color.Gray;
            categoryChart.BorderlineDashStyle = ChartDashStyle.Solid;

            // Monthly Chart
            chartArea2.Name = "ChartArea2";
            monthlyChart.ChartAreas.Add(chartArea2);
            monthlyChart.Location = new System.Drawing.Point(440, 20);
            monthlyChart.Size = new System.Drawing.Size(400, 350);
            monthlyChart.BackColor = System.Drawing.Color.WhiteSmoke;
            monthlyChart.BorderlineColor = System.Drawing.Color.Gray;
            monthlyChart.BorderlineDashStyle = ChartDashStyle.Solid;

            // Form
            AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(860, 400);
            Controls.Add(categoryChart);
            Controls.Add(monthlyChart);
            Font = new System.Drawing.Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "StatisticsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Notes Statistics";
        }
    }
}
