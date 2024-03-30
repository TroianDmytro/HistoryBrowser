
using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace HistoryBrowser
{
    public class LicenseManager
    {
        private string? CurrentOCKey { get; set; }
        private string? ExistingOCKey { get; set; }

        readonly private string nameKeyRegistry = "ExistingOCKey";
        readonly private string dataFirstLaunch = "DateOfFirstLaunch";
        public DateTime? DateOfFirstLaunch { get; set; }

        public int numberDays;
        public int numberOfDaysTrialVersion;

        public LicenseManager()
        {
            GetCurrentKey();
            numberDays = GetNumberDays();
            numberOfDaysTrialVersion = GetNumberDaysTrialVersion();
            SaveOCKey();
        }

        private void GetCurrentKey()
        {
            string userName = Environment.UserName.ToString();
            string osVershion = Environment.OSVersion.ToString();

            CurrentOCKey = userName + osVershion;
        }

        // перевіряє відповідність ключа з реєстру до поточного повертає true якщо збігаєтся
        public bool ValidateLicense()
        {
            ExistingOCKey = ReadExistingOCKey();

            if (!string.IsNullOrEmpty(ExistingOCKey) && CurrentOCKey.Equals(ExistingOCKey))
            {
                
                if (numberDays <= 30)
                {
                    return true;
                }
                
            }

            return false;
        }

        //шукае ключ в реестрі якщо ключ не знайдено повертае null
        private string? ReadExistingOCKey()
        {
            using(RegistryKey key = Registry.CurrentUser.OpenSubKey(GetPathRegistry(), true))
            {
                foreach (var item in key.GetValueNames())
                {
                    if (item.Equals(nameKeyRegistry))
                    {
                        return key.GetValue(nameKeyRegistry)?.ToString() ;
                    }
                }
            }
            return null;
        }

        private DateTime? ReadExistingDate()
        {
            if (!string.IsNullOrEmpty(ReadExistingOCKey()))
            {
                using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(GetPathRegistry(), true))
                {
                    if (registryKey != null)
                    {
                        foreach (var item in registryKey.GetValueNames())
                        {
                            if (item.Equals(dataFirstLaunch))
                            {
                                try
                                {
                                    return DateTime.Parse(registryKey.GetValue(dataFirstLaunch).ToString());
                                }
                                catch (Exception)
                                {
                                    return null;
                                }
                            }
                        }
                    }
                }
            }

            return null;
        }


        //зберігае ключ в реєстрі
        public bool SaveOCKey()
        {
            string pathReg = GetPathRegistry();
            using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(pathReg, true))
            {
                if (registryKey != null)
                {
                    string[] strings = registryKey.GetValueNames();
                    foreach (var item in strings)
                    {
                        if (item.Equals(this.nameKeyRegistry)) 
                        {
                            return false;
                        }
                    }
                  
                    registryKey.SetValue(nameKeyRegistry, CurrentOCKey);
                    registryKey.SetValue(dataFirstLaunch, DateAndTime.Now.ToShortDateString());
                    return true;
                }
            }
            return false;
        }

        //повертае шлях до папки з налаштуваннями в регістрі
        private string GetPathRegistry()
        {
            string solutionName = Environment.GetCommandLineArgs()[0]
                    .Split("\\")
                    .Last()
                    .Split('.')
                    .First();

            string nameApp = solutionName + "Settings";
            return $"Software\\{nameApp}";
        }

        private int GetNumberDays()
        {
            DateOfFirstLaunch = ReadExistingDate();
            return (DateTime.Now - DateOfFirstLaunch).Value.Days;
        }

        private int GetNumberDaysTrialVersion()
        {
            if ((30 - GetNumberDays()) < 0)
            {
                return 0;
            }
            else
            {
                return 30 - GetNumberDays();
            }
        }

    }

}
