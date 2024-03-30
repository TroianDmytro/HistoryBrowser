using HistoryBrowser;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Diagnostics;
using WinFormsApp1.View;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        DatabaseHelper databaseHelper;
        List<MyData> listHistory;

        public Form1()
        {
            InitializeComponent();

            listHistory = new List<MyData>();
            SettingsForm settingsForm = new SettingsForm(this);
            settingsForm.DarkTreme(settingsForm.IsDarkTremeChecked());
            settingsForm.OpenWindowInFullScreen(settingsForm.IsOpenWindowInFullScreen());
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            LicenseManager licenseManager = new LicenseManager();
            var b = licenseManager.ValidateLicense();
            this.Text = $"HistoryBrowser {"trial version " + licenseManager.numberOfDaysTrialVersion}";

            //Task.Run(ReadHistory);
            //Thread thread = new Thread(ReadHistory);
            //thread.Start();
            ReadHistory();

        }

        void CreateDgv_history()
        {
            DataGridView dataGridView = new DataGridView();
            panel1.Controls.Add(dataGridView);
        }

        //считування історії Chrom
        private async void ReadHistory()
        {
            await Task.Run(() =>
            {
                databaseHelper = new DatabaseHelper(@"C:\Users\troya\AppData\Local\Google\Chrome\User Data\Default\History");
                listHistory = databaseHelper.GetMyData();

                //Dgv_history.DataSource = listHistory.ToArray();
                Dgv_history.Invoke(()=> Dgv_history.Columns.Add("CountVisit", "Count visit"));
                Dgv_history.Invoke(()=> Dgv_history.Columns.Add("url", "url"));

                for (int i = 0; i < listHistory.Count; i++)
                {
                    if (listHistory == null)
                        continue;

                    string[] row = [listHistory[i].visit_count.ToString(), listHistory[i].top_level_url];

                    //Dgv_history.Rows[i].Cells[0].Value = listHistory[i].visit_count;
                    //Dgv_history.Rows[i].Cells[1].Value = listHistory[i].top_level_url;
                    Dgv_history.Invoke(() => Dgv_history.Rows.Add(row));

                    //if (i % 20 == 0)
                    //{
                    //    Dgv_history.Refresh();
                    //}
                }
            });
            //databaseHelper = new DatabaseHelper(@"C:\Users\troya\AppData\Local\Google\Chrome\User Data\Default\History");
            //listHistory = databaseHelper.GetMyData();

            //Action action = () =>
            //{
            //    //Dgv_history.DataSource = listHistory.ToArray();
            //    Dgv_history.Columns.Add("CountVisit", "Count visit");
            //    Dgv_history.Columns.Add("url", "url");

            //    for (int i = 0; i < listHistory.Count; i++)
            //    {
            //        if (listHistory == null)
            //            continue;

            //        Dgv_history.Rows.Add();
            //        Dgv_history.Rows[i].Cells[0].Value = listHistory[i].visit_count;
            //        Dgv_history.Rows[i].Cells[1].Value = listHistory[i].top_level_url;

            //        if (i % 20 == 0)
            //        {
            //            Dgv_history.Refresh();
            //        }
            //    }
            //};
            //Invoke(action);
            
            
        }

        // відкривае посилання в Chrom
        private void Dgv_history_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Thread thread = new Thread(() => Process.Start(new ProcessStartInfo("C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe", $"{Dgv_history.Rows[e.RowIndex].Cells[e.ColumnIndex].Value}")));
            thread.Start();
        }


        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm st = new SettingsForm(this);
            st.Show();

        }

        //Оновлюе значення Dgv_history
        private async void Btn_refresh_Click(object sender, EventArgs e)
        {
            Dgv_history.Refresh();
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
