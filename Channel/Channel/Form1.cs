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

namespace Channel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=USER\LOCAL;Initial Catalog=ChannelDatabase;Integrated Security=True");

        private void btn_save_Click(object sender, EventArgs e)
        {
            connection.Open();

            SqlCommand cmd = new SqlCommand("insert into tbl_channel (name,category,link) values(@p1,@p2,@p3)", connection);

            cmd.Parameters.AddWithValue("@p1", txt_name.Text);

            cmd.Parameters.AddWithValue("@p2", txt_category.Text);

            cmd.Parameters.AddWithValue("@p3", txt_link.Text);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Save Succed","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);

            connection.Close();

        }
        public void videos()
        {

            SqlDataAdapter data = new SqlDataAdapter("select * from tbl_channel",connection);
            DataTable DataTable = new DataTable();
            data.Fill(DataTable);
            dataGridView1.DataSource = DataTable;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            videos();
        }



        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int chosenIndex = dataGridView1.SelectedCells[0].RowIndex;

            string link = dataGridView1.Rows[chosenIndex].Cells[3].Value.ToString();

           webBrowser1.Navigate(link);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
