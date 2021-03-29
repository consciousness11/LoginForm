using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void validation()
        {
           if(!(textBoxUser.Text== string.Empty))
            {
                if (!(textBoxPass.Text == string.Empty))
                {
                    using (SqlConnection connection = new SqlConnection(@"Data Source=.\sqlexpress01;Initial Catalog=studentinfo;Integrated Security=True;"))
                    {
                        const string query = "select * from UserDb where username = @username and password = @password";
                        using (SqlCommand sqlCmd= new SqlCommand(query,connection))
                        {
                            sqlCmd.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar));
                            sqlCmd.Parameters["@username"].Value = textBoxUser.Text;
                            sqlCmd.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar));
                            sqlCmd.Parameters["@password"].Value = textBoxPass.Text;
                            try
                            {
                                connection.Open();
                                using (SqlDataReader dataReader = sqlCmd.ExecuteReader()) 
                                {
                                    int count = 0;
                                    while (dataReader.Read())
                                    {
                                        count = count + 1;
                                    }
                                    if(count == 1)
                                    {
                                        MessageBox.Show("Login Successful !");
                                        Form2 frm = new Form2();
                                        frm.Show();
                                        this.Hide();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Username or Password Incorrect !");
                                    }
                                    dataReader.Close();
                                }
                            }
                            catch (Exception ex)
                            {

                                MessageBox.Show(ex.Message);
                            }
                            finally
                            {
                                connection.Close();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Password Empty !");
                }
            }
            else
            {
                MessageBox.Show("Username Empty");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            validation();
        }
    }
    
   
}
