using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBCW
{
    public partial class ClientForm : Form
    {
        public List<Employee> employeesList = new List<Employee>(); 
        public string Login { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        ArrayList arr;
        public ClientForm(string login, string pass)
        {
            InitializeComponent();
            Login = login;
            Password = pass;

            getClienIdAndName(Login, Password);
            insertEmployeeToCombobox();

            foreach(var i in employeesList)
            {
                
                //MessageBox.Show(i.fio + i.id.ToString());
                this.comboBox1.Items.Add(i.fio);
            }
           
        }

        public void insertEmployeeToCombobox()
        {
            OracleConnection conn = DBUtils.GetDBConnection();


            try
            {

                conn.Open();
                // MessageBox.Show("Open1");
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "cwpack1.getNameAndIdEmp";
                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                // Выполнить процедуру.
                OracleDataReader objReader = cmd.ExecuteReader();
                prvPrintReader(objReader);
                //string name = cmd.Parameters["idd"].Value.ToString();
                //string id = cmd.Parameters["fio"].Value.ToString();
                //Name = id.ToString();
                //UserLabel.Text = id.ToString();
                //Id = int.Parse(name);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private  void prvPrintReader(OracleDataReader objReader)
        {
            string temp;
            for (int i = 0; i < objReader.FieldCount; i++)
            {
               // MessageBox.Show(objReader.GetName(i));
            }
            //System.Console.Write("\n");
            while (objReader.Read())
            {
                for (int i = 0; i < objReader.FieldCount; i++)
                {


                    arr.Add(objReader[i].ToString());
                    //MessageBox.Show(objReader[i].ToString());
                }
                //System.Console.Write("\n");
            }

            Employee emp = new Employee()
            {
                Tempid = "",
                fio = ""
            };
            employeesList.Add(emp);
        }
        public void getClienIdAndName(string login, string pass)
        {
            OracleConnection conn = DBUtils.GetDBConnection();


            try
            {
               
                conn.Open();
                // MessageBox.Show("Open1");
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "cwpack1.getClienIdAndName";
                cmd.CommandType = CommandType.StoredProcedure;
            
                cmd.Parameters.Add("Login", OracleDbType.NVarchar2).Value = Login;
                cmd.Parameters.Add("Passw", OracleDbType.NVarchar2).Value = Password;
                cmd.Parameters.Add("idd", OracleDbType.Int64).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("fio", OracleDbType.NVarchar2, 50).Direction = ParameterDirection.Output;
                // Выполнить процедуру.
                cmd.ExecuteNonQuery();
                string name = cmd.Parameters["idd"].Value.ToString();
                string id = cmd.Parameters["fio"].Value.ToString();
                Name = id.ToString();
                UserLabel.Text = id.ToString();
                Id = int.Parse(name);
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
                MessageBox.Show(ex.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        private void makeOrder_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
