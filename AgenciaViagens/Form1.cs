using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace AgenciaViagens
{
    public partial class Form1 : Form
    {
        private SqlConnection cn;
        public static int currentAdmin;


        public Form1()
        {
            InitializeComponent();
            
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            HideSignUp();
            cn = getSGBDConnection();

        }

        private SqlConnection getSGBDConnection()
        {
            //return new SqlConnection("data source= DESKTOP-TB868K4\\SQLEXPRESS;integrated security=true;initial catalog=AgenciaViagens");
            return new SqlConnection("data source= LAPTOP-V53SE24E\\SQLEXPRESS;integrated security=true;initial catalog=AgenciaViagens");
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void CreateAdmin(Admin A)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT Administrador (ID, Nome, Apelido, Pass) " + "VALUES (@ID, @nome, @apelido, @pass) ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@ID", A.AdminID);
            cmd.Parameters.AddWithValue("@nome", A.Name);
            cmd.Parameters.AddWithValue("@apelido", A.Apelido);
            cmd.Parameters.AddWithValue("@pass", A.Password);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private bool SaveAdmin()
        {
            Admin admin = new Admin();
            try
            {
                admin.AdminID = textBox6.Text;
                admin.Name = textBox4.Text;
                admin.Apelido = textBox3.Text;
                admin.Password = textBox5.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            CreateAdmin(admin);
            return true;
        }


        private void HideSignUp()
        {
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label6.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox6.Visible = false;
            button2.Visible = true;
            button3.Visible = true;
        }

        private void ShowSignUp()
        {
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label1.Visible = false;
            label2.Visible = false;
            label6.Visible = true;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox6.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowSignUp();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HideSignUp();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Administrador WHERE ID=@ID and pass = @pass", cn);
            cmd.Parameters.AddWithValue("@ID", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", textBox2.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                currentAdmin = Int32.Parse(textBox1.Text);
                var newform = new Form2();
                newform.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Conta não encontrada");
            }
            cn.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (SaveAdmin())
            {
                System.Windows.Forms.MessageBox.Show("Criada com sucesso");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Erro");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
