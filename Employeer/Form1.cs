using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employeer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            err.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            err.Visible = false;
            if (String.IsNullOrEmpty(loginBox7.Text))
            {
                errorProvider1.SetError(loginBox7, "Не указан логин!");
            }
            else if (String.IsNullOrEmpty(passwBox6.Text))
            {
                errorProvider1.SetError(passwBox6, "Не указан пароль!");
            }           
            else if (getEmployeeInfo(loginBox7.Text, passwBox6.Text) == "consists")
            {
                List<Employee> newEmp = new List<Employee>();
                newEmp.Add(getAllEmpInfo());

                EmployeeForm employee = new EmployeeForm(loginBox7.Text, passwBox6.Text);
                employee.Show();
                
                this.Hide();
            }
            else
            {
                err.Visible = true;
            }
        }

        string getEmployeeInfo(string login, string password)
        {
            OracleConnection conn = DBUtils.GetDBConnection();

            try
            {
                conn.Open();
                
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "cwpack1.checkEmpAccount";
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add("login", OracleDbType.NVarchar2).Value = login;
                cmd.Parameters.Add("pass", OracleDbType.NVarchar2).Value = password;
                
                cmd.Parameters.Add("results", OracleDbType.Int64).Direction = ParameterDirection.Output;

                // Выполнить процедуру.
                cmd.ExecuteNonQuery();

                string ct = cmd.Parameters["results"].Value.ToString();
                if (int.Parse(ct) > 0)
                {
                    return "consists";
                }
                else
                {
                    return "not consists";
                }

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

            return "not consists";
        }
        
        Employee getAllEmpInfo()
        {
            Employee emp = new Employee();

            return emp;
        }
    }
}
