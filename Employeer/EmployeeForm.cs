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
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name1 { get; set; }
        public int Id { get; set; }
        int amount = 0;
        public EmployeeForm(string login, string passw)
        {
            InitializeComponent();
            Login = login;
            Password = passw;
            getCurrentEmpIdAndName(Login, Password);
            insertComponentToCombobox();

            var bindingSource1 = new BindingSource();
            bindingSource1.DataSource = componentsList;

            comboBox1.DataSource = componentsList;
            comboBox1.DisplayMember = "comName";
            comboBox1.ValueMember = "id";
            getClientOrdersForEmployee();
            getClientOrdersForEmployeeToDo();
            dataGridView1.MultiSelect = false;
        }
        public void getCurrentEmpIdAndName(string login, string pass)
        {
            OracleConnection conn = DBUtils.GetDBConnection();


            try
            {

                conn.Open();
                // MessageBox.Show("Open1");
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "cwpack1.getCurrentEmplIdAndName";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("lgine", OracleDbType.NVarchar2).Value = Login;
                cmd.Parameters.Add("psde", OracleDbType.NVarchar2).Value = Password;
                cmd.Parameters.Add("id_rete", OracleDbType.Int64).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("fioe", OracleDbType.NVarchar2, 50).Direction = ParameterDirection.Output;
                // Выполнить процедуру.
                cmd.ExecuteNonQuery();
                string name = cmd.Parameters["id_rete"].Value.ToString();
                string id = cmd.Parameters["fioe"].Value.ToString();
                Name1 = id.ToString();
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

        public void getClientOrdersForEmployeeToDo()
        {
            OracleConnection conn = DBUtils.GetDBConnection();
            try
            {

                conn.Open();
                OracleDataAdapter objAdapter = new OracleDataAdapter();

                OracleCommand cmd = new Oracle.ManagedDataAccess.Client.OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "cwpack1.getClientOrdersForEmployeeToDo";
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("eplid", OracleDbType.Int32).Value = int.Parse(Id.ToString());
                cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                objAdapter.SelectCommand = cmd;

                DataTable dtEmp = new DataTable();
                objAdapter.Fill(dtEmp);
                dataGridView3.DataSource = dtEmp;

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

        public void getClientOrdersForEmployee()
        {
            OracleConnection conn = DBUtils.GetDBConnection();
            try
            {

                conn.Open();
                OracleDataAdapter objAdapter = new OracleDataAdapter();

                OracleCommand cmd = new Oracle.ManagedDataAccess.Client.OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "cwpack1.getClientOrdersForEmployee";
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("eplid", OracleDbType.Int32).Value = int.Parse(Id.ToString());
                cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                objAdapter.SelectCommand = cmd;

                DataTable dtEmp = new DataTable();
                objAdapter.Fill(dtEmp);
                dataGridView1.DataSource = dtEmp;

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
        
        private void buyDetail_Click(object sender, EventArgs e)
        {

           

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
            
            }
        }

        private void makeOrder_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(amount.ToString());
            
            //MessageBox.Show(p.ToString());
            int costs = 0;
            
            if (dataGridView1.Rows.Count >1)
            {
                int id_order = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());

                if (String.IsNullOrEmpty(repairBox1.Text))
                {
                    errorProvider1.SetError(repairBox1, "Не указано описание ремонта!");
                }
                else if (!int.TryParse(priceBox2.Text.ToString(), out costs))
                {
                    errorProvider1.SetError(priceBox2, "Не числовой тип!");
                }
                else if (String.IsNullOrEmpty(priceBox2.Text))
                {
                    errorProvider1.SetError(priceBox2, "Не указана стоимость!");
                }
                else if (dataGridView1.Rows.Count == 0)
                {
                    errorProvider1.SetError(dataGridView1, "Не выбран заказ или список заказов пуст!");

                }
                else
                {
                    
                    errorProvider1.Clear();
                    //MessageBox.Show(id_order.ToString());
                    addMakers(repairBox1.Text, int.Parse(priceBox2.Text.ToString()), DateTime.Now);

                    int idmk = getLastMakers();

                    foreach (var i in addcomponentIdsList)
                    {
                        addComponents(i, idmk);
                    }

                    changeStatusAndMakers(id_order, idmk);

                    getClientOrdersForEmployeeToDo();
                    getClientOrdersForEmployee();
                    amount = 0;
                    listBox1.Items.Clear();
                    repairBox1.Clear();
                    priceBox2.Clear();

                }
                
            }
            else
            {
                errorProvider1.SetError(priceBox2, "Список заказов пуст!");
            }
            
        }

        public void changeStatusAndMakers(int id_order, int idmk)
        {
            OracleConnection conn = DBUtils.GetDBConnection();
            try
            {

                conn.Open();
                // MessageBox.Show("Open1");
                OracleCommand cmd = new Oracle.ManagedDataAccess.Client.OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "cwpack1.changeStatusAndMakers";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("ior", OracleDbType.Int32).Value = id_order;
                cmd.Parameters.Add("idmk", OracleDbType.Int32).Value = idmk;
            


                // Выполнить процедуру.
                cmd.ExecuteNonQuery();

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
        public int getLastMakers()
        {
            int result = 0;

            OracleConnection conn = DBUtils.GetDBConnection();


            try
            {

                conn.Open();
                // MessageBox.Show("Open1");
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "cwpack1.getLastMakers";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("idmk", OracleDbType.Int64).Direction = ParameterDirection.Output;

                // Выполнить процедуру.
                cmd.ExecuteNonQuery();
                string ct = cmd.Parameters["idmk"].Value.ToString();
                result = int.Parse(ct.ToString());
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


            return result;
        }
        public void addMakers(string TypeOfRepair, int Costs, DateTime repairdate)
        {
            OracleConnection conn = DBUtils.GetDBConnection();
            try
            {

                conn.Open();
                // MessageBox.Show("Open1");
                OracleCommand cmd = new Oracle.ManagedDataAccess.Client.OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "cwpack1.addMakers";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("repairtype", OracleDbType.NVarchar2).Value = TypeOfRepair;
                cmd.Parameters.Add("price", OracleDbType.Int32).Value = Costs+amount;
                cmd.Parameters.Add("repairdate", OracleDbType.Date).Value = repairdate;
            

                // Выполнить процедуру.
                cmd.ExecuteNonQuery();

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
        public void addComponents(int idcomp, int idmaker)
        {
            OracleConnection conn = DBUtils.GetDBConnection();
            try
            {

                conn.Open();
                // MessageBox.Show("Open1");
                OracleCommand cmd = new Oracle.ManagedDataAccess.Client.OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "cwpack1.addComponentsOrder";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("idcomp", OracleDbType.Int32).Value = idcomp;
                cmd.Parameters.Add("idmaker", OracleDbType.Int32).Value = idmaker;
               

                // Выполнить процедуру.
                cmd.ExecuteNonQuery();

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

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        public void ChangeStatus(int idor)
        {
            OracleConnection conn = DBUtils.GetDBConnection();
            try
            {

                conn.Open();
                // MessageBox.Show("Open1");
                OracleCommand cmd = new Oracle.ManagedDataAccess.Client.OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "cwpack1.changeOrderStatus";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("idor", OracleDbType.Int32).Value = idor;
                

                // Выполнить процедуру.
                cmd.ExecuteNonQuery();

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

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (dataGridView3.Rows.Count > 1)
            {
                if (dataGridView3.Rows.Count == 0)
                {
                    errorProvider1.SetError(label3, "Не выбран заказ или список заказов пуст!");

                }
                else
                {
                    MessageBox.Show("Hello");
                    int id_order = Convert.ToInt32(dataGridView3[0, dataGridView3.CurrentRow.Index].Value.ToString());
                    MessageBox.Show(id_order.ToString());
                    ChangeStatus(id_order);

                    getClientOrdersForEmployeeToDo();
                    getClientOrdersForEmployee();
                }
            }
            else
            {
                errorProvider1.SetError(label3, "Не выбран заказ или список заказов пуст!");
            }
            
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            getClientOrdersForEmployeeToDo();
            getClientOrdersForEmployee();
            showHistoryEmpOrders();
        }
        public void showHistoryEmpOrders()
        {
            OracleConnection conn = DBUtils.GetDBConnection();
            try
            {

                conn.Open();
                OracleDataAdapter objAdapter = new OracleDataAdapter();

                OracleCommand cmd = new Oracle.ManagedDataAccess.Client.OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "cwpack1.getOrdersHistoryForEmployee";
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("eplid", OracleDbType.Int32).Value = int.Parse(Id.ToString());
                cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                objAdapter.SelectCommand = cmd;

                DataTable dtEmp = new DataTable();
                objAdapter.Fill(dtEmp);
                dataGridView2.DataSource = dtEmp;

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
    }
}
