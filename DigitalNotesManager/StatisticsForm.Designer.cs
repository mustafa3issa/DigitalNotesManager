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
            ChartArea chartArea1 = new ChartArea();
            ChartArea chartArea2 = new ChartArea();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsForm));
            categoryChart = new Chart();
            monthlyChart = new Chart();
            ((System.ComponentModel.ISupportInitialize)categoryChart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)monthlyChart).BeginInit();
            SuspendLayout();
            // 
            // categoryChart
            // 
            categoryChart.BackColor = Color.WhiteSmoke;
            categoryChart.BorderlineColor = Color.Gray;
            categoryChart.BorderlineDashStyle = ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            categoryChart.ChartAreas.Add(chartArea1);
            categoryChart.Location = new Point(20, 20);
            categoryChart.Name = "categoryChart";
            categoryChart.Size = new Size(400, 350);
            categoryChart.TabIndex = 0;
            // 
            // monthlyChart
            // 
            monthlyChart.BackColor = Color.WhiteSmoke;
            monthlyChart.BorderlineColor = Color.Gray;
            monthlyChart.BorderlineDashStyle = ChartDashStyle.Solid;
            chartArea2.Name = "ChartArea2";
            monthlyChart.ChartAreas.Add(chartArea2);
            monthlyChart.Location = new Point(440, 20);
            monthlyChart.Name = "monthlyChart";
            monthlyChart.Size = new Size(400, 350);
            monthlyChart.TabIndex = 1;
            // 
            // StatisticsForm
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(860, 400);
            Controls.Add(categoryChart);
            Controls.Add(monthlyChart);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "StatisticsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Notes Statistics";
            ((System.ComponentModel.ISupportInitialize)categoryChart).EndInit();
            ((System.ComponentModel.ISupportInitialize)monthlyChart).EndInit();
            ResumeLayout(false);
        }
    }
}
