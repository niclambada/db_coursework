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
        public List<int> addcomponentIdsList = new List<int>();
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
                        comName = objReader.GetValue(1).ToString(),
                        price = objReader.GetValue(2).ToString()
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
        int amount = 0;
        private void buyDetail_Click(object sender, EventArgs e)
        {
            int cost = 0;

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //listBox1.Items.Add(comboBox1.SelectedValue.ToString());
            listBox1.Items.Add(comboBox1.Text.ToString());
            addcomponentIdsList.Add(int.Parse(comboBox1.SelectedValue.ToString()));

            var ts = from tc in componentsList
                     where tc.id == comboBox1.SelectedValue.ToString()
                     select int.Parse(tc.price);
           

            foreach(var i in ts)
            {
                amount += i;
            }
            MessageBox.Show(amount.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem!= null) { 
            listBox1.Items.Remove(listBox1.SelectedItem);
            addcomponentIdsList.Remove(int.Parse(comboBox1.SelectedValue.ToString()));
            var ts = from tc in componentsList
                     where tc.id == comboBox1.SelectedValue.ToString()
                     select int.Parse(tc.price);


            foreach (var i in ts)
            {
               
                amount -= i;
            }
            MessageBox.Show(amount.ToString());
            }
        }
    }
}
