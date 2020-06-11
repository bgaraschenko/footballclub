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

namespace record_of_soccer_stock
{
    public partial class Form1 : Form
    {
        SqlConnection sql = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\steam\source\repos\record_of_soccer_stock\record_of_soccer_stock\Database1.mdf;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (sql.State == ConnectionState.Closed)
                    sql.Open();
                SqlCommand cmd = new SqlCommand("Procedure", sql);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@mode", "Add");
                cmd.Parameters.AddWithValue("@Id", 0);
                cmd.Parameters.AddWithValue("@balls", int.Parse(numericUpDown1.Text));
                cmd.Parameters.AddWithValue("@football_player_uniforms", int.Parse(numericUpDown2.Text));
                cmd.Parameters.AddWithValue("@goalkeeper_uniform", int.Parse(numericUpDown3.Text));
                cmd.Parameters.AddWithValue("@referee_uniforms_and_equipment", int.Parse(numericUpDown4.Text));
                cmd.Parameters.AddWithValue("@goal", int.Parse(numericUpDown5.Text));
                cmd.Parameters.AddWithValue("@nets_for_goals", int.Parse(numericUpDown6.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Сохранение прошло успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
            finally
            {
                sql.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            void FillDataGridView()
            {
                if (sql.State == ConnectionState.Closed)
                    sql.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("Search", sql);
                sqlData.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlData.SelectCommand.Parameters.AddWithValue("@Id", textBox1.Text);
                DataTable dataTable = new DataTable();
                sqlData.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns[0].Visible = false;
                sql.Close();

            }
            try
            {
                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Message");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
