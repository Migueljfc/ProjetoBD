using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AgenciaViagens
{
    public partial class Form2 : Form
    {

        private SqlConnection cn;
        private int currentClient;
        private bool adding;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            loadClientsList();
            textBox1.Text = Form1.currentAdmin.ToString();
            cn = getSGBDConnection();
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("data source= DESKTOP-TB868K4\\SQLEXPRESS;integrated security=true;initial catalog=AgenciaViagens");
            //return new SqlConnection("data source= LAPTOP-V53SE24E\\SQLEXPRESS;integrated security=true;initial catalog=AgenciaViagens");
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex >= 0)
            {
                currentClient = listBox2.SelectedIndex;
                ShowClient();
            }

        }
        private void loadClientsList()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Cliente", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox2.Items.Clear();

            while (reader.Read())
            {
                Cliente client = new Cliente();
                client.ClientCC = Convert.ToInt32(reader["CC"]);
                client.Nome = reader["nome"].ToString();
                client.Apelido = reader["apelido"].ToString();
                client.Telefone = Convert.ToInt32(reader["telefone"]);
                client.Email = reader["email"].ToString();
                listBox2.Items.Add(client);
            }
            cn.Close();

            currentClient = 0;
            ShowClient();
        }


        private void CreateClient(Cliente C)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT Cliente (CC, Nome, Apelido, Email, Telefone) " + "VALUES (@CC, @nome, @apelido, @email, @telefone) ";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@CC", C.ClientCC);
            cmd.Parameters.AddWithValue("@nome", C.Nome);
            cmd.Parameters.AddWithValue("@apelido", C.Apelido);
            cmd.Parameters.AddWithValue("@email", C.Email);
            cmd.Parameters.AddWithValue("@telefone", C.Telefone);
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update client in database. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private bool SaveClient()
        {
            Cliente cliente = new Cliente();
            try
            {
                cliente.Nome = textBox4.Text;
                cliente.Apelido = textBox2.Text;
                cliente.Email = textBox6.Text;
                cliente.ClientCC = Int32.Parse(textBox5.Text);
                cliente.Telefone = Int32.Parse(textBox3.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            if (adding)
            {
                CreateClient(cliente);
                listBox2.Items.Add(cliente);
                Console.WriteLine("Create");
            }
            else
            {
                UpdateClient(cliente);
                listBox2.Items[currentClient] = cliente;
                Console.WriteLine("Create");
            }
            return true;
        }

        private void ShowClient()
        {
            if(listBox2.Items.Count == 0 | currentClient < 0)
            {
                return;
            }

            Cliente client = new Cliente();
            client = (Cliente)listBox2.Items[currentClient];
            textBox4.Text = client.Nome;
            textBox2.Text = client.Apelido;
            textBox6.Text = client.Email;
            textBox5.Text = client.ClientCC.ToString();
            textBox3.Text = client.Telefone.ToString();

        }

        private void RemoveClient()
        {

        }

        private void UpdateClient(Cliente client)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE Cliente " + "SET CC = @CC, " + "    nome = @nome, " + "    apelido = @apelido, " + "    telefone = @telefone, " + "    email = @email";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@CC", client.ClientCC);
            cmd.Parameters.AddWithValue("@nome",client.Nome);
            cmd.Parameters.AddWithValue("@apelido", client.Apelido);
            cmd.Parameters.AddWithValue("@telefone", client.Telefone);
            cmd.Parameters.AddWithValue("@email", client.Email);
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
                MessageBox.Show("Update OK");
                cn.Close();
            }
        }


    
        private void button4_Click(object sender, EventArgs e)
        {
            adding = true;
            ClearFields();
            HideButtons();
            listBox2.Enabled = false;
        }

     
        

        private void button5_Click(object sender, EventArgs e)
        {
            listBox2.Enabled = false;
            ClearFields();
            ShowButtonSearch();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentClient = listBox2.SelectedIndex;
            if (currentClient < 0)
            {
                MessageBox.Show("Seleciona um Cliente para editar");
                return;
            }
            adding = false;
            HideButtons();
            listBox2.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            loadClientsList();
            ClearFields();
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox2.Enabled = true;
            loadClientsList();
            HideButtonSearch();
            ShowButtons();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Cliente WHERE nome=@nome", cn);
            cmd.Parameters.AddWithValue("@nome", textBox4.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            listBox2.Items.Clear();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Cliente client = new Cliente();
                    client.Nome = reader["nome"].ToString();
                    client.Apelido = reader["apelido"].ToString();
                    client.Telefone = Convert.ToInt32(reader["telefone"]);
                    client.Email = reader["email"].ToString();
                    client.ClientCC = Convert.ToInt32(reader["CC"]);
                    listBox2.Items.Add(client);
                }



                currentClient = 0;
                ShowClient();
                HideButtonSearch();
                listBox2.Enabled = true;

            }
            else
            {
                MessageBox.Show("Conta não encontrada");
            }
            cn.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                SaveClient();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            listBox2.Enabled = true;
            //int idx = listBox2.FindString(textBox6.Text);
            //listBox2.SelectedIndex = idx;
            ShowButtons();
        }
        private void ClearFields()
        {
            textBox4.Text = "";
            textBox2.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox3.Text = "";
        }

        private void ShowButtonSearch()
        {
            label2.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            button2.Visible = false;
            button4.Visible = false;
            button3.Visible = false;
            button5.Visible = false;

            button6.Visible = true;
            button7.Visible = true;



        }
        private void HideButtonSearch()
        {

            label2.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            button2.Visible = true;
            button4.Visible = true;
            button3.Visible = true;
            button5.Visible = true;

            button6.Visible = false;
            button7.Visible = false;
        }
        private void HideButtons()
        {
            button2.Visible = false;
            button4.Visible = false;
            button3.Visible = false;
            button5.Visible = false;
            
            
            button7.Visible = true;
            button9.Visible = true;
        }
        private void ShowButtons()
        {
            button2.Visible = true;
            button4.Visible = true;
            button3.Visible = true;
            button5.Visible = true;
            

            button7.Visible = false;
            button9.Visible = false;
        }
    }
}
