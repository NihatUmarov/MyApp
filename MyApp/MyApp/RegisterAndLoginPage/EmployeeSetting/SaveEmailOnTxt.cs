using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyApp.RegisterAndLoginPage.EmployeeSetting
{
    public class SaveEmailOnTxt
    {
        public string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TxtEmail");

        public SaveEmailOnTxt()
        {
            if (!File.Exists(fileName))
            {
                File.WriteAllText(fileName, "");
            }
        }
        public void SaveEmail(string value)
        {
            File.WriteAllText(fileName, value);
        }
        public string GetEmail()
        {
            return File.ReadAllText(fileName);
        }
        public void DeleteEmail()
        {
            File.WriteAllText(fileName, "");
        }
    }
}
