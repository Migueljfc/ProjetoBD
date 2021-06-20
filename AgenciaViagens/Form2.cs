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
        private int currentDestino;
        private bool adding;
        private int lastClientID;
        private int currentAdmin = Form1.currentAdmin;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            loadClientsList();
            textBox1.Text = currentAdmin.ToString();
            listBox2.SelectedIndex = listBox2.Items.Count-1;
            lastClientID = Convert.ToInt32(textBox13.Text);

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
        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBox3.SelectedIndex >= 0)
            {
                currentDestino = listBox3.SelectedIndex;
                ShowDestino();
            }
        }
        
        private void loadClientsList()
        { 
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Cliente WHERE FK_IdAdmin = @currentAdmin ", cn);
            cmd.Parameters.AddWithValue("@currentAdmin", currentAdmin);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox2.Items.Clear();

            while (reader.Read())
            {
                Cliente client = new Cliente();
                client.ID = Convert.ToInt32(reader["ID"]);
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


        private void CreateClient(Cliente client)
        {
           
            if (!verifySGBDConnection())
            {
                return;
            }
            
            string nome = client.Nome;
            string apelido = client.Apelido;
            string email = client.Email;
            int clientCC = client.ClientCC;
            int telefone = client.Telefone;
            lastClientID = lastClientID + 1;
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddClient"

            };
      
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@CC", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@apelido", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@telefone", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@FK_idAdmin", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@message", SqlDbType.NVarChar, 250));
            cmd.Parameters["@ID"].Value = lastClientID;
            cmd.Parameters["@CC"].Value = clientCC;
            cmd.Parameters["@nome"].Value = nome;
            cmd.Parameters["@apelido"].Value = apelido;
            cmd.Parameters["@email"].Value = email;
            cmd.Parameters["@telefone"].Value = telefone;
            cmd.Parameters["@FK_idAdmin"].Value = Int32.Parse(textBox1.Text);
            cmd.Parameters["@message"].Direction = ParameterDirection.Output;
            cmd.Connection = cn;
            
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro falha ao Criar Cliente \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                
                MessageBox.Show("Criado com sucesso");
                cn.Close();
                ClearFields();
                loadClientsList();
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
                
            }
            else
            {
                UpdateClient(cliente);
                listBox2.Items[currentClient] = cliente;
               
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
            textBox13.Text = client.ID.ToString();
            textBox4.Text = client.Nome;
            textBox2.Text = client.Apelido;
            textBox6.Text = client.Email;
            textBox5.Text = client.ClientCC.ToString();
            textBox3.Text = client.Telefone.ToString();

        }
        private void ShowDestino()
        {
            if (listBox3.Items.Count == 0 | currentDestino < 0)
            {
                return;
            }

            Destino client = new Cliente();
            client = (Cliente)listBox2.Items[currentClient];
            textBox13.Text = client.ID.ToString();
            textBox4.Text = client.Nome;
            textBox2.Text = client.Apelido;
            textBox6.Text = client.Email;
            textBox5.Text = client.ClientCC.ToString();
            textBox3.Text = client.Telefone.ToString();

        }

        private void RemoveClient()
        {
            int clientid = Int32.Parse(textBox13.Text);

            if (!verifySGBDConnection())
            {
                return;
            }


            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "DeleteCliente"
            };

            cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@message", SqlDbType.NVarChar, 250));
            cmd.Parameters["@ID"].Value = clientid;
            cmd.Parameters["@message"].Direction = ParameterDirection.Output;

            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro falha ao Remover Cliente \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                loadClientsList();
                MessageBox.Show("Apagado com sucesso");
                if(clientid == lastClientID)
                {
                    lastClientID = lastClientID - 1;
                }
                cn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentClient = listBox2.SelectedIndex;
            if (currentClient < 0)
            {
                MessageBox.Show("Seleciona um Cliente para remover");
                return;
            }
            RemoveClient();
        }

        private void UpdateClient(Cliente client)
        {
            if (!verifySGBDConnection())
                return;

            string nome = client.Nome;
            string apelido = client.Apelido;
            string email = client.Email;
            int clientCC = client.ClientCC;
            int telefone = client.Telefone;

            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "UpdateCliente"
                
            };

            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@CC", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@apelido", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@telefone", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@message", SqlDbType.NVarChar, 250));
            cmd.Parameters["@ID"].Value = Int32.Parse(textBox13.Text);
            cmd.Parameters["@CC"].Value = clientCC;
            cmd.Parameters["@nome"].Value = nome;
            cmd.Parameters["@apelido"].Value = apelido;
            cmd.Parameters["@email"].Value = email;
            cmd.Parameters["@telefone"].Value = telefone;
            cmd.Parameters["@message"].Direction = ParameterDirection.Output;
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro falha ao Editar Cliente \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                MessageBox.Show("Editado com sucesso");
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
                    client.ID = Convert.ToInt32(reader["ID"]);
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
            label16.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox13.Visible = false;
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
            label16.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox13.Visible = true; 
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

        private void button10_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

    }
}
