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
    public partial class Form_Selection : Form
    {
        public Form_Selection()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=USER\LOCAL;Initial Catalog=Selection2020;Integrated Security=True");

        private void btn_oy_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into tbl_ilce (Ilce_Ad,A_Parti,B_Parti,C_Parti,D_Parti,E_Parti) values (@p1,@p2,@p3,@p4,@p5,@p6)",connection);

            command.Parameters.AddWithValue("@p1", txt_ilce.Text);
            command.Parameters.AddWithValue("@p2", txt_a.Text);
            command.Parameters.AddWithValue("@p3", txt_b.Text);
            command.Parameters.AddWithValue("@p4", txt_c.Text);
            command.Parameters.AddWithValue("@p5", txt_d.Text);
            command.Parameters.AddWithValue("@p6", txt_e.Text);

            command.ExecuteNonQuery();

            MessageBox.Show("İşlem Başarılı");

            connection.Close();
        }

        private void btn_grafik_Click(object sender, EventArgs e)
        {
            Form_Grafikler G = new Form_Grafikler();

            G.Show();
        }
    }
}
