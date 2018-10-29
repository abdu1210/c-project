using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace database
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\cse904\database\database\Database1.mdf;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet1.register' table. You can move, or remove it, as needed.
            this.registerTableAdapter.Fill(this.database1DataSet1.register);
            // TODO: This line of code loads data into the 'database1DataSet.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter.Fill(this.database1DataSet.Table);

        }

        private void save_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into register values('" + idtext.Text + "', '" + nametext.Text + "','" + semtext.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("saved");
          
            reload();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE from register WHERE name= '"+nametext.Text+"'";   
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("deleted");
            reload();
        }

        private void update_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE register SET name= '" +name.Text+ "'WHERE sem='"+semtext.Text+"'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("updated");
            reload();
        }
        public void reload()
        {
            String strupdate = "select * FROM register ";
            SqlDataAdapter myAdapter = new SqlDataAdapter(strupdate, con);
            DataTable mytable = new DataTable();
            myAdapter.Fill(mytable);
            BindingSource bs1 = new BindingSource();
            bs1.DataSource = mytable;
            dataGridView1.DataSource = bs1;
        }
    }
}
