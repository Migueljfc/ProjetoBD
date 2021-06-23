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
        private int currentAlojamento;
        private int currentTransporte;
        private int currentViagem;
        private bool adding;
        private int  selectedDestino;
        private int selectedAlojamento;
        private int precoTrans;
        private int precoAloj;
        private int selectedTransporte;
        private int lastClientID;
        private int currentAdmin = Form1.currentAdmin;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            loadClientsList();
            loadDestList();
            loadAlojList();
            loadTransList();
            textBox1.Text = currentAdmin.ToString();
            listBox2.SelectedIndex = listBox2.Items.Count-1;
            if(listBox2.SelectedIndex >= 0)
            {

                lastClientID = Convert.ToInt32(textBox13.Text);
            }

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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                currentViagem = listBox2.SelectedIndex;
                ShowViagem();
            }
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

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBox4.SelectedIndex >= 0)
            {
                currentAlojamento = listBox4.SelectedIndex;
                ShowAlojamento();
            }
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBox5.SelectedIndex >= 0)
            {
                currentTransporte = listBox5.SelectedIndex;
                ShowTransporte();
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
        private void loadDestList()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Destino", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox3.Items.Clear();

            while (reader.Read())
            {
                Destino d = new Destino();
                d.ID = Convert.ToInt32(reader["ID"]);
                d.Pais= reader["pais"].ToString();
                d.Cidade = reader["cidade"].ToString();
                d.CodPostal = reader["codPostal"].ToString();
                listBox3.Items.Add(d);
            }
            cn.Close();

            currentDestino = 0;
            ShowDestino();
        }
        private void loadAlojList()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Alojamento", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox4.Items.Clear();

            while (reader.Read())
            {
                Alojamento aloj = new Alojamento();
                aloj.AlojID = Convert.ToInt32(reader["ID"]);
                aloj.Tipo = reader["tipo"].ToString();
                aloj.Nome = reader["nome"].ToString();
                aloj.Preco = Convert.ToInt32(reader["preco"]);
                listBox4.Items.Add(aloj);
            }
            cn.Close();

            currentAlojamento = 0;
            ShowAlojamento();
        }

        private void loadTransList()
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Transporte", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox5.Items.Clear();

            while (reader.Read())
            {
                Transporte t = new Transporte();
                t.TransID = Convert.ToInt32(reader["ID"]);
                t.Tipo = reader["tipo"].ToString();
                t.Companhia = reader["companhia"].ToString();
                t.Preco = Convert.ToInt32(reader["preco"]);
                t.NumPassageiros  = Convert.ToInt32(reader["numPassageiros"]);
                t.DataPartida = reader["dataPartida"].ToString();
                t.DataChegada = reader["dataChegada"].ToString();
                listBox5.Items.Add(t);
            }
            cn.Close();

            currentTransporte = 0;
            ShowTransporte();
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

        private void SaveDestino(Destino d)
        {
            
            if (!verifySGBDConnection())
            {
                return ;
            }
            int id = d.ID;
            string pais = d.Pais;
            string cidade = d.Cidade;
            string codpostal = d.CodPostal;
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddDestino"

            };

            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@codPostal", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@pais", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@cidade", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@message", SqlDbType.NVarChar, 250));
            cmd.Parameters["@ID"].Value = id;
            cmd.Parameters["@pais"].Value = pais;
            cmd.Parameters["@cidade"].Value = cidade;
            cmd.Parameters["@codPostal"].Value = codpostal;
            cmd.Parameters["@message"].Direction = ParameterDirection.Output;
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro falha ao Criar Destino \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {

                MessageBox.Show("Criado com sucesso");
                cn.Close();
                ClearFields();
                listBox3.Items.Add(d);
                loadDestList();
            }

        }

        private void SaveViagem(Destino d)
        {

            if (!verifySGBDConnection())
            {
                return;
            }
            int id = d.ID;
            string pais = d.Pais;
            string cidade = d.Cidade;
            string codpostal = d.CodPostal;
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddDestino"

            };

            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@codPostal", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@pais", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@cidade", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@message", SqlDbType.NVarChar, 250));
            cmd.Parameters["@ID"].Value = id;
            cmd.Parameters["@pais"].Value = pais;
            cmd.Parameters["@cidade"].Value = cidade;
            cmd.Parameters["@codPostal"].Value = codpostal;
            cmd.Parameters["@message"].Direction = ParameterDirection.Output;
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro falha ao Criar Destino \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {

                MessageBox.Show("Criado com sucesso");
                cn.Close();
                ClearFields();
                listBox3.Items.Add(d);
                loadDestList();
            }

        }

        private void SaveAlojamento(Alojamento aloj)
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            int id = aloj.AlojID;
            string nome = aloj.Nome;
            string tipo = aloj.Tipo;
            int preco = aloj.Preco;
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddAlojamento"

            };

            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@nome", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@preco", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@FK_Dest", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@FK_Tem2", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@message", SqlDbType.NVarChar, 250));
            cmd.Parameters["@ID"].Value = id;
            cmd.Parameters["@nome"].Value = nome;
            cmd.Parameters["@tipo"].Value = tipo;
            cmd.Parameters["@FK_Dest"].Value = selectedDestino;
            cmd.Parameters["@FK_Tem2"].Value = selectedDestino;
            cmd.Parameters["@preco"].Value = preco;
            cmd.Parameters["@message"].Direction = ParameterDirection.Output;
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro falha ao Criar Alojamento \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {

                MessageBox.Show("Criado com sucesso");
                cn.Close();
                ClearFields();
                listBox4.Items.Add(aloj);
                loadAlojList();
            }
        }

        private void SaveTransporte(Transporte t)
        {
            if (!verifySGBDConnection())
            {
                return;
            }
            int id = t.TransID;
            string companhia = t.Companhia;
            string dataPartida = t.DataPartida;
            string dataChegada = t.DataChegada;
            int numPassageiros = t.NumPassageiros;
            string tipo = t.Tipo;
            int preco = t.Preco;
            System.Diagnostics.Debug.WriteLine(dataPartida);
            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "AddTransporte"

            };

            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@numPassageiros", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@companhia", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@dataPartida", SqlDbType.Date));
            cmd.Parameters.Add(new SqlParameter("@dataChegada", SqlDbType.Date));
            cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@preco", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@FK_Dest", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@FK_Tem", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@message", SqlDbType.NVarChar, 250));
            cmd.Parameters["@ID"].Value = id;
            cmd.Parameters["@numPassageiros"].Value = numPassageiros;
            cmd.Parameters["@companhia"].Value = companhia;
            cmd.Parameters["@tipo"].Value = tipo;
            cmd.Parameters["@dataPartida"].Value = dataPartida;
            cmd.Parameters["@dataChegada"].Value = dataChegada;
            cmd.Parameters["@FK_Dest"].Value = selectedAlojamento;
            cmd.Parameters["@FK_Tem"].Value = selectedAlojamento;
            cmd.Parameters["@preco"].Value = preco;
            cmd.Parameters["@message"].Direction = ParameterDirection.Output;
            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro falha ao Criar Alojamento \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {

                MessageBox.Show("Criado com sucesso");
                cn.Close();
                ClearFields();
                listBox5.Items.Add(t);
                loadTransList();
            }
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

            Destino d = new Destino();
            d = (Destino)listBox3.Items[currentDestino];
            textBox21.Text = d.ID.ToString();
            textBox14.Text = d.Pais;
            textBox15.Text = d.Cidade;
            textBox16.Text = d.CodPostal;
        }

        private void ShowAlojamento()
        {

            if (listBox4.Items.Count == 0 | currentAlojamento < 0)
            {
                return;
            }
            Alojamento aloj = new Alojamento();
            aloj = (Alojamento)listBox4.Items[currentAlojamento];
            textBox17.Text = aloj.AlojID.ToString();
            textBox11.Text = aloj.Preco.ToString();
            textBox10.Text = aloj.Nome;
            comboBox1.Text = aloj.Tipo;
        }

        private void ShowTransporte()
        {

            if (listBox5.Items.Count == 0 | currentTransporte < 0)
            {
                return;
            }
            Transporte t = new Transporte();
            t = (Transporte)listBox5.Items[currentTransporte];
            textBox18.Text = t.TransID.ToString();
            textBox20.Text = t.NumPassageiros.ToString();
            dateTimePicker4.Text = t.DataPartida.ToString();
            dateTimePicker3.Text = t.DataChegada.ToString();
            textBox19.Text = t.NumPassageiros.ToString();
            comboBox2.Text = t.Tipo.ToString();
            textBox9.Text = t.Preco.ToString();
        }

        private void ShowViagem()
        {

            if (listBox1.Items.Count == 0 | currentViagem < 0)
            {
                return;
            }
            Viagem v = new Viagem();
            v = (Viagem)listBox1.Items[currentViagem];
            textBox7.Text = v.ViagemID.ToString();
            textBox8.Text = v.PrecoTotal.ToString();
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
        private void button12_Click(object sender, EventArgs e)
        {
            currentDestino= listBox3.SelectedIndex;
            if (currentDestino < 0)
            {
                MessageBox.Show("Seleciona um Destino para remover");
                return;
            }
            RemoveDestino();
        }

        private void RemoveDestino()
        {
            

            if (!verifySGBDConnection())
            {
                return;
            }


            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "DeleteDestino"
            };

            cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@message", SqlDbType.NVarChar, 250));
            cmd.Parameters["@ID"].Value = Convert.ToInt32(textBox21.Text);
            cmd.Parameters["@message"].Direction = ParameterDirection.Output;

            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro falha ao Remover Destino \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                loadDestList();
                MessageBox.Show("Apagado com sucesso");
                cn.Close();
            }
        }

        private void RemoveAlojamento()
        {
            
            if (!verifySGBDConnection())
            {
                return;
            }


            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandText = "DeleteAlojamento"
            };

            cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
            cmd.Parameters.Add(new SqlParameter("@message", SqlDbType.NVarChar, 250));
            cmd.Parameters["@ID"].Value = Convert.ToInt32(textBox17.Text); ;
            cmd.Parameters["@message"].Direction = ParameterDirection.Output;

            cmd.Connection = cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro falha ao Remover Alojamento \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                loadAlojList();
                MessageBox.Show("Apagado com sucesso");
                cn.Close();
            }
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
            textBox14.Text = " ";
            textBox15.Text = " ";
            textBox16.Text = " ";
            textBox21.Text = " ";
            textBox10.Text = " ";
            textBox11.Text = " ";
            textBox17.Text = " ";
            comboBox1.Text = " ";

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

        private void ShowCriarDestino()
        {
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button26.Visible = false;

            button14.Visible = true;
            button15.Visible = true;
            
        }
        private void HideCriarDestino()
        {
            button11.Visible = true;
            button12.Visible = true;
            button13.Visible = true;
            button26.Visible = true;

            button14.Visible = false;
            button15.Visible = false;
        }

        private void ShowCriarAlojamento()
        {
            button18.Visible = false;
            button19.Visible = false;
            button20.Visible = false;
            button27.Visible = false;

            button16.Visible = true;
            button17.Visible = true;
        }
        private void HideCriarAlojamento()
        {
            button18.Visible = true;
            button19.Visible = true;
            button20.Visible = true;
            button27.Visible = true;

            button16.Visible = false;
            button17.Visible = false;
        }

        private void ShowCriarTransporte()
        {
            button24.Visible = false;
            button25.Visible = false;
            button28.Visible = false;
            button23.Visible = false;

            button21.Visible = true;
            button22.Visible = true;
        }
        private void HideCriarTransporte()
        {
            button24.Visible = true;
            button25.Visible = true;
            button28.Visible = true;
            button23.Visible = true;

            button21.Visible = false;
            button22.Visible = false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Destino d = new Destino();

            d.ID = Convert.ToInt32(textBox21.Text);
            d.Pais = textBox14.Text;
            d.Cidade = textBox15.Text;
            d.CodPostal = textBox16.Text;
            //System.Diagnostics.Debug.WriteLine(d);
            SaveDestino(d);
            ShowDestino();
            loadDestList();
            HideCriarDestino();
            listBox3.Enabled = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ClearFields();
            ShowCriarDestino();
            listBox3.Enabled = false;

        }

        private void button15_Click(object sender, EventArgs e)
        {
            HideCriarDestino();
            ClearFields();
            listBox3.Enabled = true;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if(listBox3.SelectedIndex >= 0)
            {
                MessageBox.Show("Adicionado à viagem");
                selectedDestino = Convert.ToInt32(textBox21.Text);
                textBox22.Text = selectedDestino.ToString();
            }
            else
            {
                MessageBox.Show("Tem de selecionar um destino na lista");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            
            Alojamento aloj = new Alojamento();

            aloj.AlojID = Convert.ToInt32(textBox17.Text);
            aloj.Nome= textBox10.Text;
            aloj.Preco = Convert.ToInt32(textBox11.Text);
            aloj.Tipo = comboBox1.Text;
            //System.Diagnostics.Debug.WriteLine(d);
            SaveAlojamento(aloj);
            ShowAlojamento();
            loadAlojList();
            HideCriarAlojamento();
            listBox4.Enabled = true;
            
        }

        private void button20_Click(object sender, EventArgs e)
        {

            ClearFields();
            ShowCriarAlojamento();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            HideCriarAlojamento();
            
        }

        private void button19_Click(object sender, EventArgs e)
        {
            currentAlojamento = listBox4.SelectedIndex;
            if (currentAlojamento < 0)
            {
                MessageBox.Show("Seleciona um Destino para remover");
                return;
            }
            RemoveAlojamento();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (listBox4.SelectedIndex >= 0)
            {
                MessageBox.Show("Adicionado à viagem");
                selectedAlojamento = Convert.ToInt32(textBox17.Text);
                textBox12.Text = selectedDestino.ToString();
                precoAloj = Convert.ToInt32(textBox11.Text);
                textBox8.Text = precoAloj.ToString();
            }
            else
            {
                MessageBox.Show("Tem de selecionar um Alojamento na lista");
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            ShowCriarTransporte();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Transporte t = new Transporte();

            t.TransID = Convert.ToInt32(textBox18.Text);
            t.DataPartida = dateTimePicker4.Text;
            t.DataChegada = dateTimePicker3.Text;
            t.Preco = Convert.ToInt32(textBox9.Text);
            t.Tipo = comboBox2.Text;
            t.Companhia = textBox19.Text;
            t.NumPassageiros = Convert.ToInt32(textBox20.Text);

            //System.Diagnostics.Debug.WriteLine(d);
            SaveTransporte(t);
            ShowTransporte();
            loadTransList();
            HideCriarTransporte();
            listBox4.Enabled = true;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            HideCriarTransporte();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (listBox5.SelectedIndex >= 0)
            {
                MessageBox.Show("Adicionado à viagem");
                selectedTransporte = Convert.ToInt32(textBox18.Text);
                textBox23.Text = selectedDestino.ToString();
                precoTrans = Convert.ToInt32(textBox9.Text);
                precoTrans = precoAloj + precoTrans;
                textBox8.Text = precoTrans.ToString();
            }
            else
            {
                MessageBox.Show("Tem de selecionar um Transporte na lista");
            }
        }
    }
    
}
