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

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form1.currentAdmin.ToString();
            cn = getSGBDConnection();
        }

        private SqlConnection getSGBDConnection()
        {
            // return new SqlConnection("data source= DESKTOP-TB868K4\\SQLEXPRESS;integrated security=true;initial catalog=AgenciaViagens");
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
                throw new Exception("Failed to update contact in database. \n ERROR MESSAGE: \n" + ex.Message);
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
                cliente.ClientCC = textBox5.;
                cliente.Telefone = textBox3;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            CreateClient(cliente);
            return true;
        }


        private void ShowCliente()
        {
    
            label2.Visible = true; 
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            button4.Visible = true;

        }
        private void HideCliente()
        {

            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            button4.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
           
           
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            HideCliente();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            HideCliente();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            HideCliente();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Criada com sucesso");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
