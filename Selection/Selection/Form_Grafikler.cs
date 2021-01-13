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

namespace Selection
{
    public partial class Form_Grafikler : Form
    {
        public Form_Grafikler()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=USER\LOCAL;Initial Catalog=Selection2020;Integrated Security=True");
        private void Form_Grafikler_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("select Ilce_Ad from tbl_ilce ",connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0]);
            }

            connection.Close();


            connection.Open();

            SqlCommand cmd = new SqlCommand("  select sum(A_Parti),SUM(B_parti),sum(C_Parti),SUM(D_Parti),sum(E_Parti) from tbl_ilce",connection);
            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                grafik.Series["Partiler"].Points.AddXY("A Parti", rdr[0]);
                grafik.Series["Partiler"].Points.AddXY("B Parti", rdr[1]);
                grafik.Series["Partiler"].Points.AddXY("C Parti", rdr[2]);
                grafik.Series["Partiler"].Points.AddXY("D Parti", rdr[3]);
                grafik.Series["Partiler"].Points.AddXY("E Parti", rdr[4]);
            }

            connection.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand c = new SqlCommand("select * from tbl_ilce where Ilce_Ad=@p1",connection);
            c.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader r = c.ExecuteReader();

            while (r.Read())
            {
                progressBar1.Value = int.Parse(r[2].ToString());
                progressBar2.Value = int.Parse(r[3].ToString());
                progressBar3.Value = int.Parse(r[4].ToString());
                progressBar4.Value = int.Parse(r[5].ToString());
                progressBar5.Value = int.Parse(r[6].ToString());
                lbl_a.Text = "%" + r[2].ToString();
                lbl_b.Text = "%" + r[3].ToString();
                lbl_c.Text = "%" + r[4].ToString();
                lbl_d.Text = "%" + r[5].ToString();
                lbl_e.Text = "%" + r[6].ToString();
            }
            connection.Close();
        }
    }
}
