using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace LAdmin
{
    class CConfig
    {
        public String HotkeyPrSc { get; set; }
        public String WorkDirName { get; set; }
        public String ArchivesDirName { get; set; }
        public String DWRCC { get; set; }
        public String Screen { get; set; }

        public CConfig()
        {
            try
            {
                
                
                WorkDirName = ConfigurationManager.AppSettings["WorkDirName"];
                ArchivesDirName = ConfigurationManager.AppSettings["Archives"];
                Screen = ConfigurationManager.AppSettings["Screen"];

                if (WorkDirName == "")
                {
                    WorkDirName = GetAppPath() + @"work";
                }

                if (ArchivesDirName == "")
                {
                    ArchivesDirName = GetAppPath() + @"Archives";
                }
                

                HotkeyPrSc = ConfigurationManager.AppSettings["HotkeyPrSc"];
                DWRCC = ConfigurationManager.AppSettings["DWRCC"];
               
            }
            catch (Exception ex)
            {
                throw new Exception("read config error " + "(" + ex + ")");
            }
        }


        private string GetAppPath()
        {

            System.Reflection.Module[] modules = System.Reflection.Assembly.GetExecutingAssembly().GetModules();
            string location = System.IO.Path.GetDirectoryName(modules[0].FullyQualifiedName);
            if ((location != "") && (location[location.Length - 1] != '\\'))
                location += '\\';
            return location;
        }
    }

    
}
