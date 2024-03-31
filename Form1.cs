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
        public DataGridView Dgv_historys;
        string domain;

        public Form1()
        {
            InitializeComponent();

            listHistory = new List<MyData>();

            CreateDgv_history();

            SettingsForm settingsForm = new SettingsForm(this);
            settingsForm.DarkTreme(settingsForm.IsDarkTremeChecked());
            settingsForm.OpenWindowInFullScreen(settingsForm.IsOpenWindowInFullScreen());

            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            LicenseManager licenseManager = new LicenseManager();
            var b = licenseManager.ValidateLicense();
            this.Text = $"HistoryBrowser {"trial version " + licenseManager.numberOfDaysTrialVersion}";

            ReadHistory();
        }

        // сворює datagridview
        void CreateDgv_history()
        {
            Dgv_historys = new DataGridView();
            Dgv_historys.Name = "Dgv_historys";
            Dgv_historys.AllowUserToAddRows = false;
            Dgv_historys.RowHeadersVisible = false;
            panel1.Controls.Add(Dgv_historys);
            Dgv_historys.Dock = DockStyle.Fill;
            Dgv_historys.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Dgv_historys.Click += Dgv_historys_Click;
        }

        //при кліку переходе по посиланню
        private void Dgv_historys_Click(object? sender, EventArgs e)
        {
            int ind = Dgv_historys.CurrentCell.RowIndex;
            Thread thread = new Thread(() => Process.Start(new ProcessStartInfo("C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe", $"{Dgv_historys.Rows[ind].Cells[1].Value}")));
            thread.Start();
        }

        //считування історії Chrom
        private async void ReadHistory()
        {
            await Task.Run((Action)(() =>
            {
                Invoke(() => Btn_enterSearsnDomain.Enabled = false);
                databaseHelper = new DatabaseHelper(@"C:\Users\troya\AppData\Local\Google\Chrome\User Data\Default\History");
                listHistory = databaseHelper.GetMyData();

                FillingDgv_historys(listHistory);
                //this.Dgv_historys.Invoke<int>((Func<int>)(() => (int)this.Dgv_historys.Columns.Add("CountVisit", "Count visit")));
                //this.Dgv_historys.Invoke<int>((Func<int>)(() => (int)this.Dgv_historys.Columns.Add("url", "url")));

                //for (int i = 0; i < listHistory.Count; i++)
                //{
                //    if (listHistory == null)
                //        continue;

                //    string[] row = [listHistory[i].visit_count.ToString(), listHistory[i].top_level_url];

                //    this.Dgv_historys.Invoke<int>((Func<int>)(() => (int)this.Dgv_historys.Rows.Add(row)));

                //}
                Task.Delay(2000);

                Invoke(() =>
                {
                    Lb_loading.Visible = false;
                    Lb_loading.Enabled = false;
                    Btn_enterSearsnDomain.Enabled = true;
                });
            }));
        }

        // відкривае посилання в Chrom
        private void Dgv_history_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm st = new SettingsForm(this);
            st.Show();

        }

        //Оновлюе значення Dgv_historys
        private async void Btn_refresh_Click(object sender, EventArgs e)
        {
            Dgv_historys.Rows.Clear();
            Dgv_historys.Columns.Clear();

            Lb_loading.Visible = true;
            Lb_loading.ForeColor = Color.White;

            ReadHistory();
            Dgv_historys.Refresh();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        //обробляє натисканя на кнопку Enter
        private void Btn_enterSearsnDomain_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Tb_searchDomain.Text))
            {
                return;
            }

            domain = Tb_searchDomain.Text;

            List<MyData> searchDomainList = new List<MyData>();
            searchDomainList = listHistory
                .Where(x => EqualsDomain(domain, x.top_level_url))
                .Select(x => x)
                .ToList();

            FillingDgv_historys(searchDomainList);

            Tb_searchDomain.Text = string.Empty;

        }

        //Заповнює Dgv_historys значеннями зі списку переданого як параметр
        async void FillingDgv_historys(List<MyData> list)
        {
            await Task.Run(() =>
            {
                Invoke(() =>
                {
                    Dgv_historys.Rows.Clear();
                    Dgv_historys.Columns.Clear();
                });

                this.Dgv_historys
                .Invoke<int>((Func<int>)(() => (int)this.Dgv_historys.Columns.Add("CountVisit", "Count visit")));
                this.Dgv_historys
                .Invoke<int>((Func<int>)(() => (int)this.Dgv_historys.Columns.Add("url", "url")));

                for (int i = 0; i < list.Count; i++)
                {
                    if (list == null)
                        continue;

                    string[] row = [list[i].visit_count.ToString(), list[i].top_level_url];

                    this.Dgv_historys.Invoke<int>((Func<int>)(() => (int)this.Dgv_historys.Rows.Add(row)));
                }
            });
        }


        // порівнює параметр dom з параметром url.
        // Якщо в url домен співпадає з dom повертае true
        bool EqualsDomain(string dom, string url)
        {
            string str = url
                .Replace("https://", "")
                .Split('/')
                .First()
                .Replace("www.", "")
                .Split('.')
                .First();

            if (dom.Equals(str))
            {
                return true;
            }

            return false;
        }

        // обробник натискання клавиши Enter в полі Tb_searchDomain
        private void Tb_searchDomain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar ==(char)Keys.Enter)
            {
                Btn_enterSearsnDomain_Click(sender, e);
            }
        }
    }
}
