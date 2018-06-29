using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;

namespace LAdmin
{
    class CIncidents 
    {
        public int ColumnIndex { get; set; }

        public List<CIncident> Incidents ;
        public CIncidents()
        {
            Incidents = new List<CIncident>();
        }


 

        public void GetSearchList(String srchStr)
        {
           List<CIncident> AftersearchList = new List<CIncident>();
            foreach (CIncident Incident in Incidents)
            {
                if (Incident.Getsearch(srchStr))
                {
                    AftersearchList.Add(Incident);
                }
            }
            this.Incidents = AftersearchList;
        }

        public void GetListFromDir(string dirName)
        {
            String curDir = "";
            
   
            string incidentDate = string.Empty;
            DirectoryInfo dirDate = new DirectoryInfo(dirName);
            foreach (var itemDate in dirDate.GetDirectories())
            {
                  curDir = dirName+@"\" + itemDate.Name;
                  incidentDate = itemDate.Name;
                  DirectoryInfo dirExecutorAndProblem = new DirectoryInfo(curDir);               
                
                  foreach (var itemExecutorAndProblem in dirExecutorAndProblem.GetDirectories())
                  {

                      //////////Date........................
                      curDir =dirName+@"\" + itemDate.Name+ @"\" + itemExecutorAndProblem;
                      CIncident incident = new CIncident();                   
                      incident.DateExec = incidentDate;                    
                      incident.DateWithTime = (DateTime.Now-File.GetCreationTime(curDir)).ToString("ddhhmmss");
                      //////////FIO and problem......................      
                      incident.GetFioAndProblem(itemExecutorAndProblem.Name);

                    //////// solution..............................
                    incident.GetSolution(curDir);     
                                       
                              incident.SetIncID(dirName);
                              incident.GetExecutorFromDir();                            
                
                         // }
                      

                      Incidents.Add(incident);
                  }

            }
        }


        public void SortIncidents(int IncidentFild)
        {          
            Incidents = Incidents.OrderByDescending(x => x[IncidentFild]).ToList();
        }


    }
}
