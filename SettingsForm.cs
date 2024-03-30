using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1;

namespace HistoryBrowser
{
    public partial class SettingsForm : Form
    {
        Form1 mainForm;
        public string SolutionName { get; set; }

        public SettingsForm(Form1 f)
        {
            InitializeComponent();
            mainForm = f;
            IsAutoStartChecked();

        }

        private void Cbox_night_treme_CheckedChanged(object sender, EventArgs e)
        {
        }


        private void Cbox_autoStart_CheckedChanged(object sender, EventArgs e)
        {

        }

        //Встановлюе значення Cbox_autoStart.Checked = true,
        //якщо воно було встановленно в попередньому сеансі 
        private void IsAutoStartChecked()
        {
            SolutionName = Environment.GetCommandLineArgs()[0]
                    .Split("\\")
                    .Last()
                    .Split('.')
                    .First();

            using (RegistryKey registry = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
            {
                // шукае назву проекту в регістрі
                if (registry.GetValueNames().Any(x => x.Equals(SolutionName)))
                {
                    Cbox_autoStart.Checked = true;
                    //BeginInvoke(()=>Cbox_autoStart.Checked = true);
                }
            }
        }
        private void Cbox_openWindowInFullScreen_CheckedChanged(object sender, EventArgs e)
        {
        }

        //зберігае налаштування в регістр
        private async void Btn_save_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                string nameApp = $"{SolutionName}Settings";
                string pathRegistry = $"Software\\{nameApp}";

                using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(pathRegistry, true))
                {
                    if (registryKey != null)
                    {
                        registryKey.SetValue(Cbox_autoStart.Name, Cbox_autoStart.Checked);
                        registryKey.SetValue(Cbox_night_treme.Name, Cbox_night_treme.Checked);
                        registryKey.SetValue(Cbox_openWindowInFullScreen.Name, Cbox_openWindowInFullScreen.Checked);
                    }
                    else
                    {
                        using (RegistryKey newKey = Registry.CurrentUser.CreateSubKey($"Software\\{nameApp}", true))
                        {
                            newKey.SetValue(Cbox_autoStart.Name, Cbox_autoStart.Checked);
                            newKey.SetValue(Cbox_night_treme.Name, Cbox_night_treme.Checked);
                            newKey.SetValue(Cbox_openWindowInFullScreen.Name, Cbox_openWindowInFullScreen.Checked);
                        }
                    }
                }

                DarkTreme(Cbox_night_treme.Checked);
                AutoStart();
                Invoke(() => OpenWindowInFullScreen(Cbox_openWindowInFullScreen.Checked));  
                Invoke(() => this.Close());
            });

        }

        public void OpenWindowInFullScreen(bool res)
        {
            if (!res)
            {
                mainForm.WindowState = FormWindowState.Normal;
                
                Cbox_openWindowInFullScreen.Checked = false;
                StartPosition = FormStartPosition.CenterScreen;

            }
            else
            {
                mainForm.WindowState = FormWindowState.Maximized;
                Cbox_openWindowInFullScreen.Checked = true;
                StartPosition = FormStartPosition.CenterScreen;

            }
        }

        public bool IsOpenWindowInFullScreen()
        {
            string pathRegistry = $"Software\\{SolutionName}Settings";

            using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(pathRegistry, true))
            {
                foreach (var item in registryKey.GetValueNames())
                {
                    if (item.Equals(Cbox_openWindowInFullScreen.Name))
                    {
                        try
                        {
                            return Cbox_openWindowInFullScreen.Checked = bool.Parse(registryKey.GetValue(Cbox_openWindowInFullScreen.Name).ToString());
                        }
                        catch (Exception)
                        {
                            return Cbox_openWindowInFullScreen.Checked = false;
                        }
                    }
                }
            }
            //OpenWindowInFullScreen();
            return false;
        }

        //змінює колір теми true - dark treme, false- light treme
        public void DarkTreme(bool b)
        {
            if (b)
            {
                mainForm.BackColor = Color.Black;
                mainForm.ForeColor = Color.White;

                mainForm.Dgv_history.EnableHeadersVisualStyles = false;
                mainForm.Dgv_history.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
                mainForm.Dgv_history.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                mainForm.Dgv_history.RowsDefaultCellStyle.BackColor = Color.Black;
                mainForm.Dgv_history.GridColor = Color.Pink;

                mainForm.menuStrip1.BackColor = Color.Black;
                mainForm.menuStrip1.ForeColor = Color.White;

                ////////////////// SettingsForm
                ///
                this.BackColor = mainForm.BackColor;
                this.ForeColor = mainForm.ForeColor;
                Btn_save.ForeColor = Color.Black;

            }
            else
            {
                mainForm.BackColor = Color.Gray;
                mainForm.ForeColor = Color.Black;

                mainForm.Dgv_history.EnableHeadersVisualStyles = false;
                mainForm.Dgv_history.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
                mainForm.Dgv_history.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

                mainForm.Dgv_history.RowsDefaultCellStyle.BackColor = Color.Gray;
                mainForm.Dgv_history.GridColor = Color.Black;

                mainForm.menuStrip1.BackColor = Color.Gray;
                mainForm.menuStrip1.ForeColor = Color.Black;

                ////////////////// SettingsForm
                ///
                this.BackColor = mainForm.BackColor;
                this.ForeColor = mainForm.ForeColor;
            }
        }


        public bool IsDarkTremeChecked()
        {
            string nameApp = SolutionName + "Settings";
            string pathRegistry = $"Software\\{nameApp}";

            using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(pathRegistry, true))
            {
                foreach (var item in registryKey.GetValueNames())
                {
                    if (item.Equals(Cbox_night_treme.Name))
                    {
                        try
                        {
                            return Cbox_night_treme.Checked = bool.Parse(registryKey.GetValue(Cbox_night_treme.Name).ToString());
                        }
                        catch (Exception)
                        {
                            return Cbox_night_treme.Checked = false;
                        }
                    }
                }
                return false;
            }
        }

        //встановлює авто запуск програми в реестр
        void AutoStart()
        {
            if (Cbox_autoStart.Checked)
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
                {
                    if (key != null && !key.GetValueNames().Any(x => x.Equals(SolutionName)))
                    {
                        //key.SetValue("WinFormsApp1", Application.ExecutablePath);
                        key.SetValue(SolutionName, Application.ExecutablePath);
                    }
                }
            }
            else if (!Cbox_autoStart.Checked)
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
                {
                    if (key != null)
                    {
                        //key.DeleteValue("WinFormsApp1");
                        if(key.GetValueNames().Any(x=>x.Equals(SolutionName)))
                        {
                            key.DeleteValue(SolutionName);
                        }
                    }
                }
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            IsAutoStartChecked();
            IsDarkTremeChecked();
            IsOpenWindowInFullScreen();
        }
    }
}
