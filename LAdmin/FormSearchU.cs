using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace LAdmin
{
    public partial class FormSearchU : Form
    {
        public FormSearchU()
        {
            InitializeComponent();
        }



        private DataTable GetTabele(string SearcStr)
        {
            try
            {

                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = ConfigurationManager.ConnectionStrings["Constr"].ConnectionString; ;
                cn.Open();



                string strSQL = @"select FioOk, HostName,JobName,DeptName,LocalPhone 
                                    from ( select *,ISNULL(sStr,'')+MS+ExchADDR+LN+FN+Sn+REPLACE(LocalPhone,'-','') as sStr from
                                    [basename]) AS AllInfo
                                    WHERE (sStr LIKE REPLACE('%'+@sstr+'%',' ','%') )
                                ";

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@sstr";
                param.Value = SearcStr;

                SqlCommand myCommand = new SqlCommand(strSQL, cn);
                myCommand.Parameters.Add(param);
                DataTable UserDetails = new DataTable();
                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {
                    UserDetails.Load(myDataReader);                                        
                }
                cn.Close();
                return UserDetails;
            }
            catch (Exception ex)
            {
                throw new Exception("Error read from base "+ex);               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {           
            dataGridViewUserDetails.DataSource = GetTabele(textBoxSearch.Text);
        }

        private void dataGridViewUserDetails_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
  
            Form1 main = this.Owner as Form1;
            if (main != null)
            {              
                main.TxtBoxInitiator = dataGridViewUserDetails.CurrentRow.Cells[0].Value.ToString();
                main.TxtBoxHost = dataGridViewUserDetails.CurrentRow.Cells[1].Value.ToString();
            }
            this.Close();

        }

        private void FormSearchU_Load(object sender, EventArgs e)
        {
            dataGridViewUserDetails.AutoGenerateColumns = true;
            dataGridViewUserDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                textBoxSearch.Text = main.TxtBoxInitiator;
               
            }

            if (textBoxSearch.Text != "")
            {
                dataGridViewUserDetails.DataSource = GetTabele(textBoxSearch.Text);
            }
            textBoxSearch.SelectionStart = textBoxSearch.TextLength ;
        }

        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                dataGridViewUserDetails.DataSource = GetTabele(textBoxSearch.Text);
            }
            
            


            if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }

        
    }
}
