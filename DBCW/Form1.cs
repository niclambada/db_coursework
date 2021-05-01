using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DBCW
{
    public partial class Form1 : Form
    {
        public string fio { get; set; }
        public string adress { get; set; }
        public string phoneNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public List<Client> client = new List<Client>();
        public Form1()
        {
            InitializeComponent();
            registered.Visible = false;
            err.Visible = false;
        }
        #region test Button
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string fio = "Цветкво Николай Сергеевич",
        //           adress = "Ул Леонида Беды",
        //           phoneNumber = "+375336803813",
        //           Login = "Login",
        //           Password = "Passw";


        //    OracleConnection conn = DBUtils.GetDBConnection();

        //    MessageBox.Show("Open");
        //    try
        //    {
        //        conn.Open();
        //        MessageBox.Show("Open1");
        //        // Создать объект Command для вызова процедуры Get_Employee_Info.
        //        OracleCommand cmd = new OracleCommand();
        //        cmd.Connection = conn;
        //        cmd.CommandText = "cwpack1.addclient";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        // Добавить параметр @p_Emp_Id и настроить его значение = 100.
        //        cmd.Parameters.Add("fullName", OracleDbType.NVarchar2).Value = fio;
        //        cmd.Parameters.Add("Adress", OracleDbType.NVarchar2).Value = adress;
        //        cmd.Parameters.Add("PhoneNumber", OracleDbType.NVarchar2).Value = phoneNumber;
        //        cmd.Parameters.Add("Login", OracleDbType.NVarchar2).Value = Login;
        //        cmd.Parameters.Add("Passw", OracleDbType.NVarchar2).Value = Password;

        //        // Выполнить процедуру.
        //        cmd.ExecuteNonQuery();
        //        MessageBox.Show("OK");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex);
        //        MessageBox.Show(ex.StackTrace);
        //    }
        //    finally
        //    {
        //        conn.Close();
        //        conn.Dispose();
        //    }
        //}
        #endregion
        private void button1_Click_1(object sender, EventArgs e)
        {
            string patern = @"^(\375|80)(29|25|44|33)(\d{3})(\d{2})(\d{2})$";
            registered.Visible = false;
            if (String.IsNullOrEmpty(fioBox1.Text))
            {
                errorProvider1.SetError(fioBox1, "Не указано ФИО!");
            }
            else if (fioBox1.Text.Length < 15)
            {
                errorProvider1.SetError(fioBox1, "Слишком короткое ФИО!");
            }
            else if (String.IsNullOrEmpty(adressBox2.Text))
            {
                errorProvider1.SetError(adressBox2, "Не указан Адрес");
            }
            else if (String.IsNullOrEmpty(phNumBox3.Text))
            {
                errorProvider1.SetError(phNumBox3, "Не указан номер телефона");
            }
            else if (!Regex.IsMatch(phNumBox3.Text, patern, RegexOptions.IgnoreCase))
            {
                errorProvider1.SetError(phNumBox3, "Неверный формат номера телефона 80(375)ххххххххх");
            }
            else if (String.IsNullOrEmpty(loginBox4.Text))
            {
                errorProvider1.SetError(loginBox4, "Не указан логин");
            }
            else if (String.IsNullOrEmpty(passwBox5.Text))
            {
                errorProvider1.SetError(passwBox5, "Не указан пароль");
            }
            else if(checkLogin(loginBox4.Text) == "consists")
            {
                errorProvider1.SetError(loginBox4, "Пользователь с таким логином уже есть!");
            }
            else
            {
                Client user = new Client()
                {
                    fio = fioBox1.Text,
                    adress = adressBox2.Text,
                    phoneNumber = phNumBox3.Text,
                    Login = loginBox4.Text,
                    Password = passwBox5.Text
                };

                client.Add(user);
                errorProvider1.Clear();
                //MessageBox.Show("OK");
                createNewClient(client);
                registered.Visible = true;
            }
        }

        string checkLogin(string login)
        {
            OracleConnection conn = DBUtils.GetDBConnection();

            try
            {
                conn.Open();
               // MessageBox.Show("Open1");
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "cwpack1.getCountOfClientWithSameLogin";
                cmd.CommandType = CommandType.StoredProcedure;
                // Добавить параметр @p_Emp_Id и настроить его значение = 100.
                cmd.Parameters.Add("checklogin", OracleDbType.NVarchar2).Value = login;
                // Зарегистрировать параметр @v_Emp_No как OUTPUT.
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
               // MessageBox.Show("Проверка завершена");
                fioBox1.Clear();
                adressBox2.Clear();
                phNumBox3.Clear();
                loginBox4.Clear();
                passwBox5.Clear();
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

            return "not constists";
        }

        public void createNewClient(List<Client> user)
        {
            string fio = "",
                    adress = "",
                    phoneNumber = "",
                    Login = "",
                    Password = "";

            OracleConnection conn = DBUtils.GetDBConnection();

            
            try
            {
                foreach (var i in user)
                {
                    fio = i.fio;
                    adress = i.adress;
                    phoneNumber = i.phoneNumber;
                    Login = i.Login;
                    Password = i.Password;

                }
                conn.Open();
               // MessageBox.Show("Open1");
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "cwpack1.addclient";
                cmd.CommandType = CommandType.StoredProcedure;
                // Добавить параметр @p_Emp_Id и настроить его значение = 100.
                cmd.Parameters.Add("fullName", OracleDbType.NVarchar2).Value = fio;
                cmd.Parameters.Add("Adress", OracleDbType.NVarchar2).Value = adress;
                cmd.Parameters.Add("PhoneNumber", OracleDbType.NVarchar2).Value = phoneNumber;
                cmd.Parameters.Add("Login", OracleDbType.NVarchar2).Value = Login;
                cmd.Parameters.Add("Passw", OracleDbType.NVarchar2).Value = Password;

                // Выполнить процедуру.
                cmd.ExecuteNonQuery();
                MessageBox.Show("Регистрация завершена!");
                fioBox1.Clear();
                adressBox2.Clear();
                phNumBox3.Clear();
                loginBox4.Clear();
                passwBox5.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            err.Visible = false;
            if (String.IsNullOrEmpty(loginBox7.Text))
            {
                errorProvider2.SetError(loginBox7, "Не указан логин!");
            }           
            else if (String.IsNullOrEmpty(passwBox6.Text))
            {
                errorProvider2.SetError(passwBox6, "Не указан пароль!");
            }
            else if(getClietnInfo(loginBox7.Text, passwBox6.Text) == "consists")
            {
                //retu clint
                List<Client> newCl = new List<Client>();
                newCl.Add(getAllClientInfo());

                ClientForm clientForm = new ClientForm(loginBox7.Text, passwBox6.Text);
                clientForm.Show();
               
                this.Hide();
            }
            else
            {
                err.Visible = true;
            }
           
        }

       
        string getClietnInfo(string login, string password)
        {
            OracleConnection conn = DBUtils.GetDBConnection();

            try
            {
                conn.Open();
                // MessageBox.Show("Open1");
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "cwpack1.checkClientAccount";
                cmd.CommandType = CommandType.StoredProcedure;
                // Добавить параметр @p_Emp_Id и настроить его значение = 100.
                cmd.Parameters.Add("login", OracleDbType.NVarchar2).Value = login;
                cmd.Parameters.Add("pass", OracleDbType.NVarchar2).Value = password;
                // Зарегистрировать параметр @v_Emp_No как OUTPUT.
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
        
        Client getAllClientInfo()
        {
            Client user = new Client();

            return user;
        }
    }
}
