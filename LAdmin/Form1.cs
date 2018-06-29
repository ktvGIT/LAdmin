using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using gma.System.Windows;
using System.Reflection;
using System.Drawing.Imaging;
using System.Threading;


namespace LAdmin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        UserActivityHook actHook;
        String KressedKey;
        int SortInlistViewIncidents=5;
        private void Form1_Load(object sender, EventArgs e)
        {
            actHook = new UserActivityHook(); // crate an instance with global hooks
            actHook.KeyUp += new KeyEventHandler(MyKeyUp);
            actHook.KeyDown += new KeyEventHandler(MyKeyDown);
            String  Username = GetUserName();
            this.Text = "v. 27.06.2018-1 " + Username + " screenshot Shift + " + new CConfig().HotkeyPrSc;
            CIncident incident = new CIncident();

            dateTimePickerBeginArc.Text = Convert.ToString(DateTime.Now.AddDays(-1));
            dateTimePickerEndArc.Text = Convert.ToString(DateTime.Now);


            UpdateForm(0, SortInlistViewIncidents, listViewIncidents);                                                            
        }

        private string GetUserName()
        {
            string Login = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            int pos = Login.IndexOf("\\");
            return Login.Substring(pos + 1);
        }



        public void MyKeyUp(object sender, KeyEventArgs e)
        {
       

            if (e.KeyData.ToString() == new CConfig().HotkeyPrSc  &&  KressedKey == "LShiftKey")
            {
                CIncident incident = new CIncident();
                incident = GetIncFromListView(listViewIncidents, new CConfig().WorkDirName);
                
               
                if (this.WindowState == FormWindowState.Minimized)
                {
                    notifyIcon1.Visible = false;
                  
                }
                else
                {
                    this.Visible = false;
                    this.ShowInTaskbar = false;                                                    
                }
               
                GetScreenShot(incident.GetResourcesPath());                
                
                if (this.WindowState == FormWindowState.Minimized)
                {
                    notifyIcon1.Visible = true;
                }
                else
                {
                    this.Visible = true;
                    this.ShowInTaskbar = true;                   
                }

                UpdateForm(listViewIncidents.SelectedItems[0].Index, SortInlistViewIncidents, listViewIncidents);  
            }

            if (e.KeyData.ToString() == "LShiftKey")
            {

                KressedKey = "";
            }
        }


        public void MyKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.ToString() == "LShiftKey"  )
            {
                KressedKey = "LShiftKey";
            }
          
        }


        private void UpdateForm(int popositionInlistView, int SortColumnId, ListView lVIncidents)
        {
            try
            {
                CIncidents Incidents = new CIncidents();
                Incidents.GetListFromDir(new CConfig().WorkDirName);
                Incidents.SortIncidents(SortColumnId);

                UdeteeveryForm(popositionInlistView, SortColumnId, lVIncidents, Incidents);
                SetInterfaceElements(lVIncidents, new CConfig().WorkDirName);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void UpdateFormSearchInArc(int popositionInlistView, int SortColumnId)
        {
            try
            {
                 
                    CIncidents Incidents = new CIncidents();
                    Incidents.GetListFromDir(new CConfig().ArchivesDirName);
                    Incidents.GetSearchList(textBoxsearch.Text);
                    UdeteeveryForm(popositionInlistView, SortColumnId, listViewIncidentsArc, Incidents);
               
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void UpdateFormArc(int popositionInlistView, int SortColumnId)
        {
            try
            {
                CIncidents Incidents = new CIncidents();
                Incidents.GetListFromDir(new CConfig().ArchivesDirName);
                Incidents.SortIncidents(SortColumnId);
                var Re = Incidents.Incidents.Where(
                    p => DateTime.ParseExact(p.DateExec, "yyyyMMdd",
                        System.Globalization.CultureInfo.GetCultureInfo("ru-RU")) >= DateTime.ParseExact(dateTimePickerBeginArc.Text, "yyyyMMdd",
                        System.Globalization.CultureInfo.GetCultureInfo("ru-RU"))).Where(
                        p => DateTime.ParseExact(p.DateExec, "yyyyMMdd",
                        System.Globalization.CultureInfo.GetCultureInfo("ru-RU")) <= DateTime.ParseExact(dateTimePickerEndArc.Text, "yyyyMMdd",
                        System.Globalization.CultureInfo.GetCultureInfo("ru-RU")) );

                CIncidents Inc2 = new CIncidents();


                foreach (CIncident R1 in Re)
                {

                    CIncident ii = new CIncident();
                    ii = R1;
                    Inc2.Incidents.Add(ii);
                }
               
                UdeteeveryForm(popositionInlistView, SortColumnId, listViewIncidentsArc, Inc2);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void UdeteeveryForm(int popositionInlistView, int SortColumnId, ListView lVIncidents, CIncidents Incidents)
   {
       try
       {
           

           lVIncidents.Clear();
           lVIncidents.View = View.Details;
           lVIncidents.Columns.Add("Date", 150);
           lVIncidents.Columns.Add("user", 250);
           lVIncidents.Columns.Add("problem", 250);
           lVIncidents.Columns.Add("solution", 450);
           lVIncidents.Columns.Add("executor", 150);
           lVIncidents.Columns.Add("storage time", 150);
           lVIncidents.FullRowSelect = true;
           lVIncidents.GridLines = true;
           lVIncidents.MultiSelect = false;

           foreach (CIncident incident in Incidents.Incidents)
           {
               lVIncidents.Items.Add(new ListViewItem(new[] { 
                                                                                        
                             incident.DateExec, incident.Initiator,incident.Problem,incident.Solution,incident.Executor,incident.DateWithTime
                            }));
           }




           if (lVIncidents.Items.Count != 0)
           {
               if (lVIncidents.Items.Count <= popositionInlistView)
               {
                   popositionInlistView--;
               }
               lVIncidents.Select();
               lVIncidents.Items[popositionInlistView].Focused = true;
               lVIncidents.Items[popositionInlistView].Selected = true;
               lVIncidents.FocusedItem = lVIncidents.Items[popositionInlistView];
               lVIncidents.EnsureVisible(popositionInlistView);
           }
       }
       catch (Exception ex)
       {
           MessageBox.Show(ex.ToString());
       }
   }

        private void textBoxInitiator_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowSForm();
        }

        private void ShowSForm()
        {
            FormSearchU formSearchU = new FormSearchU();
            formSearchU.Owner = this;
            formSearchU.ShowDialog();
        }

        public string TxtBoxInitiator
        {
            get { return textBoxInitiator.Text; }
            set { textBoxInitiator.Text = value; }
        }

        public string TxtBoxHost
        {
            get { return textBoxHost.Text; }
            set { textBoxHost.Text = value; }
        }

        private void textBoxHost_DoubleClick(object sender, EventArgs e)
        {         
                    
            if (textBoxHost.Text != "")
            {              
                Process.Start(new CConfig().DWRCC, " -c -h -m:" + textBoxHost.Text + " -a:1");
            }
        }

        private void textBoxInitiator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ShowSForm();
            }
        }

        private void SetInterfaceElements(ListView lv,string dirName)
        {
            if (lv.SelectedItems.Count != 0)
            {

                CIncident incident = new CIncident();
                incident = GetIncFromListView(lv, dirName);
                incident.GetResurses();                
                listBoxResources.Items.Clear();
                if (incident.Resources != null)
                    foreach (string res in incident.GetResourcesFileName())
                    {
                        listBoxResources.Items.Add(res);
                    }


                textBoxInitiator.Text = incident.Initiator;
                textBoxProblem.Text = incident.Problem;
                textBoxSolution.Text = incident.Solution;
                textBoxExtraSolution.Text = incident.ExtraSolution;
                textBoxHost.Text = "";

                textBoxInitiator.ForeColor = System.Drawing.Color.Black;
                textBoxSolution.ForeColor = System.Drawing.Color.Black;
                textBoxProblem.ForeColor = System.Drawing.Color.Black;

            }
            else
            {
                textBoxInitiator.Text = "";
                textBoxProblem.Text = "";
                textBoxSolution.Text = "";
                textBoxExtraSolution.Text = "";
                textBoxHost.Text = "";
            }
        }

        private void listBoxResources_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageInc)
            {
                OpenResurs(listViewIncidents, new CConfig().WorkDirName);
            }
            if (tabControl1.SelectedTab == tabPageArc)
            {
                OpenResurs(listViewIncidentsArc,new CConfig().ArchivesDirName);
            }
           
        }

        private void OpenResurs(ListView lV,String dirName)
        {
            CIncident incident = new CIncident();
            incident = GetIncFromListView(lV,dirName);
            string a = incident.GetIncID();
            if (listBoxResources.SelectedItem != null)
            {
                if (System.IO.File.Exists(a + CIncident.resource + listBoxResources.SelectedItem.ToString()))
                {
                    Process.Start(a + CIncident.resource + listBoxResources.SelectedItem.ToString());
                }
            }
        }

        private void buttonNewIncident_Click(object sender, EventArgs e)
        {
            CIncident incident = new CIncident();
            incident = GetIncFromListView(listViewIncidents, new CConfig().WorkDirName);
            if (incident.Initiator != textBoxInitiator.Text ||
                incident.Problem != textBoxProblem.Text ||
                incident.Solution != textBoxSolution.Text ||
                incident.ExtraSolution != textBoxExtraSolution.Text)
            {
                CIncident newIcincident = new CIncident(new CConfig().WorkDirName, DateTime.Now.ToString("yyyyMMdd"),
                    textBoxInitiator.Text, textBoxProblem.Text, textBoxSolution.Text);
                newIcincident.ExtraSolution = textBoxExtraSolution.Text;
                newIcincident.Executor = GetUserName(); 
                newIcincident.newIncident();


                UpdateForm(listViewIncidents.SelectedItems[0].Index, SortInlistViewIncidents, listViewIncidents);
            }
            else
            {
                MessageBox.Show("you have not made any changes");
            }

            
        }

        private CIncident GetIncFromListView(ListView lv,String DirName)
        {
            if (lv.SelectedItems.Count != 0)
            {
            return    new CIncident(DirName,
                  lv.SelectedItems[0].SubItems[0].Text,
                  lv.SelectedItems[0].SubItems[1].Text,
                  lv.SelectedItems[0].SubItems[2].Text,
                  lv.SelectedItems[0].SubItems[3].Text);
           }
           else
           {
             return   new CIncident();
           }
        }



        private void SetTextBoxText(TextBox tb)
        {
            int limit = 100;
            if (tb.Text.Count() > limit)
            {
                MessageBox.Show(limit.ToString()+ " characters limit");
                tb.Text = tb.Text.Substring(0, limit);
            }


            if (listViewIncidents.SelectedItems.Count != 0)
            {
                if (tb.Text != listViewIncidents.SelectedItems[0].SubItems[Convert.ToInt32(tb.Tag)].Text)
                {
                    tb.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    tb.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

       

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            SetTextBoxText(sender as TextBox);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            CIncident incident = new CIncident();
            incident = GetIncFromListView(listViewIncidents, new CConfig().WorkDirName);
            if (incident.Initiator != textBoxInitiator.Text ||
                incident.Problem != textBoxProblem.Text ||
                incident.Solution != textBoxSolution.Text ||
                incident.ExtraSolution != textBoxExtraSolution.Text)
            {
                try
                {
                    CIncident newIcincident = new CIncident(new CConfig().WorkDirName, incident.DateExec,
                    textBoxInitiator.Text, textBoxProblem.Text, textBoxSolution.Text);
                    newIcincident.ExtraSolution = textBoxExtraSolution.Text;
                    newIcincident.ChangeIncident(incident);

                    UpdateForm(listViewIncidents.SelectedItems[0].Index, SortInlistViewIncidents, listViewIncidents);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

       

        private void GetScreenShot(string path)
        {
            String[] argParts = new CConfig().Screen.Split(',');

            int screenLeft = Convert.ToBoolean(argParts[0]!="") ? Convert.ToInt32(argParts[0]) : SystemInformation.VirtualScreen.Left;
            int screenTop = Convert.ToBoolean(argParts[1]!="") ? Convert.ToInt32(argParts[1]): SystemInformation.VirtualScreen.Top;
            int screenWidth = Convert.ToBoolean(argParts[2]!="") ? Convert.ToInt32(argParts[2]) : SystemInformation.VirtualScreen.Width;
            int screenHeight =Convert.ToBoolean(argParts[3]!="") ? Convert.ToInt32(argParts[3]) : SystemInformation.VirtualScreen.Height;

           
            string format = "yyyy.MM.dd HH.mm.ss";
            string ext = "png";

            string filepath = Path.Combine(path, DateTime.Now.ToString(format)) + "." + ext;
            List<PropertyInfo> props = typeof(ImageFormat).GetProperties(BindingFlags.Static | BindingFlags.Public).ToList();
            var imgformat = (ImageFormat)props.Find(prop => prop.Name.ToLower() == ext).GetValue(null, null);

            if (Directory.Exists(path))
            {
                Size screenSz = Screen.AllScreens[0].Bounds.Size;
                screenSz.Width = screenSz.Width * 2;
                Bitmap screenshot = new Bitmap(screenWidth, screenHeight);
                Graphics gr = Graphics.FromImage(screenshot);
                gr.CopyFromScreen(screenLeft, screenTop, 0, 0, screenSz);

                screenshot.Save(filepath, imgformat);
            }
        }

        private void listViewIncidents_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenDir(listViewIncidents, new CConfig().WorkDirName);
        }

        private void OpenDir(ListView lV,string DirName)
        {
            CIncident incident = new CIncident();
            incident = GetIncFromListView(lV,DirName);
            if (System.IO.Directory.Exists(incident.GetIncID()))
            {
                Process.Start(incident.GetIncID());
            }
            else
            {
                MessageBox.Show("Err in name of directory");

            }
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            } 
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Maximized;
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
                tabControl1.SelectedTab = tabPageInc;
                SetInterfaceElements(listViewIncidents, new CConfig().WorkDirName);

            } 
        }

        private void listViewIncidents_SelectedIndexChanged(object sender, EventArgs e)
        {

            SetInterfaceElements(listViewIncidents, new CConfig().WorkDirName);
            
        }

        private void buttonMoveToArch_Click(object sender, EventArgs e)
        {
            try
            {
                CIncident incident = new CIncident();
                incident = GetIncFromListView(listViewIncidents, new CConfig().WorkDirName);
                incident.MoveIncidentToArch();
                UpdateForm(listViewIncidents.SelectedItems[0].Index, SortInlistViewIncidents, listViewIncidents);
            }
                             
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonUbdForm_Click(object sender, EventArgs e)
        {
            UpdateForm(listViewIncidents.SelectedItems[0].Index, SortInlistViewIncidents, listViewIncidents);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {         
           
            {
                CIncident newIcincident = new CIncident(new CConfig().WorkDirName, DateTime.Now.ToString("yyyyMMdd"),
                    GetUserName(), "", "");              
                newIcincident.Executor = GetUserName();
                newIcincident.newIncident();
                UpdateForm(listViewIncidents.Items.Count, SortInlistViewIncidents, listViewIncidents);
            }
            

        }

        private void textBoxExtraSolution_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSolution.Text == "" && textBoxExtraSolution.Text!="")
            {
                textBoxExtraSolution.Text = "";
                MessageBox.Show("there is no solution");
            }

        }

        private void listViewIncidents_ColumnClick(object sender, ColumnClickEventArgs e)
        {

            SortInlistViewIncidents = e.Column;
            UpdateForm(0, SortInlistViewIncidents, listViewIncidents);

        }

        private void buttonSendTo_Click(object sender, EventArgs e)
        {
            CIncident newIcincident = new CIncident(new CConfig().WorkDirName, DateTime.Now.ToString("yyyyMMdd"),
                   textBoxInitiator.Text, textBoxProblem.Text, textBoxSolution.Text);
            newIcincident.ExtraSolution = textBoxExtraSolution.Text;


            newIcincident.SentIncindentFromMail();

        }

        private void buttonSrchArc_Click(object sender, EventArgs e)
        {
            if (textBoxsearch.Text != "")
            {
                UpdateFormSearchInArc(0, SortInlistViewIncidents);
            }
            else
            {
                UpdateFormArc(0, SortInlistViewIncidents);
            }
        }

      
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab == tabPageInc)
            {
                SetInterfaceElements(listViewIncidents, new CConfig().WorkDirName);
            }
            if (tabControl1.SelectedTab == tabPageArc)
            {
                SetInterfaceElements(listViewIncidentsArc, new CConfig().ArchivesDirName);
            }
        }

        private void listViewIncidentsArc_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetInterfaceElements(listViewIncidentsArc, new CConfig().ArchivesDirName);
        }

        private void listViewIncidentsArc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenDir(listViewIncidentsArc, new CConfig().ArchivesDirName);
        }

        private void textBoxsearch_TextChanged(object sender, EventArgs e)
        {
            if (textBoxsearch.Text != "")
            {
                dateTimePickerBeginArc.Enabled = false;
                dateTimePickerEndArc.Enabled = false;
            }
            else
            {
                dateTimePickerBeginArc.Enabled = true;
                dateTimePickerEndArc.Enabled = true;
            }
        }



        private void listBoxResources_DragDrop(object sender, DragEventArgs e)
        {
            //string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            //foreach (string fileName in files)
            //{
            //    listBoxResources.Items.Add(fileName);
            //}

        }

        private void listBoxResources_DragEnter(object sender, DragEventArgs e)
        {

            //if (e.Data.GetDataPresent(DataFormats.Text))
            //{
            //    var link = (string)e.Data.GetData(DataFormats.Text);
            //    MessageBox.Show(link.ToString());
            //    //e.Effect = link.StartsWith("http") ? e.AllowedEffect : DragDropEffects.None;
            //}

            //if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            //    e.Effect = DragDropEffects.All;
            //else
            //    e.Effect = DragDropEffects.None;

        
           
        }

     
    
      

    }
}
