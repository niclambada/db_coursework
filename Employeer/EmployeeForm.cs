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
    public partial class EmployeeForm : Form
    {
        public List<Components> componentsList = new List<Components>();
        public EmployeeForm()
        {
            InitializeComponent();
            insertComponentToCombobox();

            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = componentsList;

            comboBox1.DataSource = componentsList;
            comboBox1.DisplayMember = "comName";
            comboBox1.ValueMember = "id";
        }

        public void insertComponentToCombobox()
        {
            OracleConnection conn = DBUtils.GetDBConnection();

            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "cwpack1.getComponentsNameAndId";
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                // Выполнить процедуру.
                OracleDataReader objReader = cmd.ExecuteReader();
                // prvPrintReader(objReader);

                while (objReader.Read())
                {
                    Components emp = new Components()
                    {
                        id = objReader.GetValue(0).ToString(),
                        comName = objReader.GetValue(1).ToString()
                    };
                    componentsList.Add(emp);

                }
                objReader.Close();
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

        private void EmployeeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void signin_Click(object sender, EventArgs e)
        {

        }

        private void buyDetail_Click(object sender, EventArgs e)
        {

        }
    }
}
