using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
//using Microsoft.Office.Interop.Outlook;
using System.Reflection;

namespace LAdmin
{
    class CIncident
    {
        public const string resource = @"\Resources\";
        private const String BeginExecutor ="__";
        private const String EndExecutor = "__";
        private const String delimiter = "@";
        public Boolean IsExecution { get; set; }
        public String Initiator { get; set; }
        public String Executor { get; set; }        
        public String DateExec { get; set; }
        public String Problem { get; set; }
        public String Solution { get; set; }
        public String DateWithTime { get; set; }
        public String ExtraSolution { get; set; }
        public List<String> Resources { get; set; }
        private String IncID { get; set; }
        public CIncident()
        {
            IsExecution = false;
            Initiator="";
            Executor="";
            DateExec="";
            Problem ="";
            Solution= "";
            Resources = new List<string>();        
            ExtraSolution = "";

        }


        public CIncident(string id, string dateExec, string initiator, string problem, string solution)
        {
            DateExec = dateExec.Trim();
            Initiator = initiator;
            Problem = problem;
            Solution=solution.Trim();            
            SetIncID(id);
            ExtraSolution = "";
            Executor = "";
            GetExtrasolution(id);
            
        }

        public int Count()
        {
            return 5;
        }

        public string this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0: return this.DateExec;
                    case 1: return this.Initiator;
                    case 2: return this.Problem;
                    case 3: return this.Solution;
                    case 4: return this.Executor;
                    case 5: return this.DateWithTime;
              

                    default: throw new ArgumentOutOfRangeException("Out of Index");
                }
            }
        }

        public void SetIncID(string ID)
        {
            
            IncID = ID + @"\" + DateExec + @"\" + Initiator + delimiter + Problem;
            IncID=IncID;
        }

        public string GetResourcesPath()
        {
            return IncID + resource;
        }

        public List <string> GetResourcesFileName()
        {
           List<string> resFileName= new List<string>();

             if (this.Resources != null)
                    foreach (string res in this.Resources)
                    {
                        resFileName.Add(System.IO.Path.GetFileName(res));
                    }

             return resFileName;
           
        }


        public string GetIncID()
        {
          return IncID;
        }

        public void GetResurses()
        {
            GetExecutorFromDir();
            string dirRes = IncID + resource;
            if (Directory.Exists(dirRes))
            {
                string[] filesRes = Directory.GetFiles(dirRes, "*.*", SearchOption.TopDirectoryOnly);
                Resources = new List<string>();
                foreach (string f in filesRes)
                {
                   if (!f.Contains(BeginExecutor+Executor+EndExecutor))            
                    {
                        Resources.Add(f);
                    }
                  
                }
            }
        }


        public void GetExecutorFromDir()
        {
            string dirRes = IncID + resource;
            if (Directory.Exists(dirRes))
            {
                string[] fileExecutor = Directory.GetFiles(dirRes, BeginExecutor+"*"+EndExecutor, SearchOption.TopDirectoryOnly);
                if (fileExecutor.Count() == 1)
                {
                    Executor = System.IO.Path.GetFileName(fileExecutor[0]);
                    Executor = Executor.Substring(2, Executor.Length - 4);
                }
            }
        }

        public void GetExtrasolution(string id)
        {     
            string SolutionFile = id + @"\" + DateExec + @"\" + Initiator + delimiter + Problem + @"\" + Solution + ".txt";
           if (System.IO.File.Exists(SolutionFile))
           {
               ExtraSolution = File.ReadAllText(SolutionFile);
           }         
            
        }


        private void SetDateString()
        {
            string pattern = @"([^А-ЯЁа-яёA-Za-z()0-9\s\-])";
            Initiator = Regex.Replace(Initiator, pattern, "");
            //pattern = @"([А-ЯЁ][а-яё]+[\-\s]?){3,}";
            //pattern = @"([^а-яёa-z()0-9\s\-])";
            Problem = Regex.Replace(Problem, pattern, "");
            Problem=Problem.ToLower();
            Solution = Regex.Replace(Solution, pattern, "");

        }


        public void newIncident()
        {
           SetDateString();
            string CurDir = new CConfig().WorkDirName+@"\";
           Directory.CreateDirectory(CurDir + DateExec);
           if (Directory.Exists(CurDir + DateExec))
           {             
               Directory.CreateDirectory(CurDir + DateExec + @"\" + Initiator + delimiter+ Problem);             
               string res = CurDir + DateExec + @"\" + Initiator + delimiter + Problem + resource;
               Directory.CreateDirectory(res);


               System.IO.File.WriteAllText(res + @"\" +BeginExecutor+ Executor+EndExecutor, ExtraSolution);

               SetSolution(CurDir);
           
               }
           
           

        }

        public void ChangeIncident(CIncident Incident)
        {
            try
            {
                SetDateString();
                
                string CurDir = new CConfig().WorkDirName + @"\" + DateExec + @"\" + Incident.Initiator + delimiter + Incident.Problem;
                string NewCurDir = new CConfig().WorkDirName + @"\" + DateExec + @"\" + Initiator + delimiter + Problem;
                if (CurDir!=NewCurDir)
                {
                    System.IO.Directory.Move(CurDir, NewCurDir);
                }
                SetSolution(new CConfig().WorkDirName + @"\");
            }
            catch 
            {
                throw new System.Exception("could not make changes, maybe the directory is locked or not found");
            }
        }

        private void SetSolution(string CurDir)
        {
          
            string SolutionFile = CurDir + DateExec + @"\" + Initiator + delimiter + Problem + @"\" + Solution + ".txt";
            if (Solution.Trim() != "")
            {
                if (System.IO.File.Exists(SolutionFile))
                {
                    System.IO.File.WriteAllText(SolutionFile, ExtraSolution);
                }
                else
                {
                 
                    string[] files = Directory.GetFiles(CurDir + DateExec + @"\" + Initiator + delimiter + Problem, "*.txt", SearchOption.TopDirectoryOnly);
                        foreach (string f in files)
                        {
                            System.IO.File.Delete(f);

                        }
                        System.IO.File.WriteAllText(SolutionFile, ExtraSolution);

                }

            }
        }

        public void MoveIncidentToArch()
        {
            string CurDir = new CConfig().WorkDirName + @"\";
            string ArchDir = new CConfig().ArchivesDirName + @"\";
           
            CurDir = CurDir + DateExec + @"\" + Initiator + delimiter+ Problem;
            Directory.CreateDirectory(ArchDir + DateExec);
          try
            {
              
                new DirectoryInfo(CurDir).MoveTo(ArchDir + DateExec + @"\" + Initiator + delimiter + Problem);
            }
            catch
            {
                throw new System.Exception("this dir in the archive already exists. Check the archive.");
            }

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(new CConfig().WorkDirName + @"\" + DateExec);
            if (di.GetFiles().Length == 0 && di.GetDirectories().Length == 0)
            {
                Directory.Delete(new CConfig().WorkDirName + @"\" + DateExec, true);
            }

        }

        public void GetSolution(String curDir)
        {
            string[] files = Directory.GetFiles(curDir + @"\", "*.txt", SearchOption.TopDirectoryOnly);

            if (files.Count() != 1)
            {
               
                Solution = "";
                ExtraSolution = "";
            }
            else
            {
                Solution = System.IO.Path.GetFileName(files[0]).Substring(0, System.IO.Path.GetFileName(files[0]).Length - 4);
               
                ExtraSolution = File.ReadAllText(files[0]);
            }

            
        }

        public void GetFioAndProblem(string itemExecutorAndProblem)
        {
            int depPosition=itemExecutorAndProblem.IndexOf(delimiter);
            if (depPosition != -1)
            {

                Initiator = itemExecutorAndProblem.Substring(0, depPosition);
                Problem = itemExecutorAndProblem.Substring(depPosition+delimiter.Length);
            }
            else
            {
                Problem = itemExecutorAndProblem;
            }

           
        }


        public bool Getsearch(string srchStr)
        {
           
            //Type t = this.GetType();
            //FieldInfo[] fieldNames = t.GetFields();
            //PropertyInfo[] properties = t.GetProperties();

            //foreach (PropertyInfo fil in properties)
            //{
            //    if (fil.PropertyType == typeof(String) )
            //    if ((fil.GetValue(this, null) as string).Contains(srchStr)  )
            //    {
            //         return true;

            //    }
            //    //string i ="";
            //    //if (fil.GetValue(this, null) as string == "0")            
            //    //    i += "111";

            //}
            
            for(int i=0;i<this.Count();i++)
            {
                if (this[i].ToLower().Contains(srchStr.ToLower()))
                    return true;

            }
            return false;


        }

        public void SentIncindentFromMail()
        {
            ////using Outlook = Microsoft.Office.Interop.Outlook;
            //Application oApp = new Application(); // Create the Outlook application.
            //MailItem oMsg = (MailItem)oApp.CreateItem(OlItemType.olMailItem); // Create a new mail item.
            //oMsg.Body = Initiator + "\n\r" + Problem +"\n\r"+ ExtraSolution; //add the body of the email
            ////Attachment oAttach = oMsg.Attachments.Add(@"D:\\мой*файл.txt");  //attached the file
            //oMsg.Subject =  Problem + "  ( для рабочей группы: ФИЛИАЛ СПБ ОПЕРУ (СЗРЦ))"; //Subject line
            //Recipients oRecips = (Recipients)oMsg.Recipients; // Add a recipient.
            //Recipient oRecip = (Recipient)oRecips.Add("OPP@msk.vtb.ru"); // Change the recipient in the next line if necessary.
            //oRecip.Resolve();
            //oMsg.Display(); // Send.
            //// Clean up:
            //oRecip = null;
            //oRecips = null;
            //oMsg = null;
            //oApp = null;

        }

    }


}
