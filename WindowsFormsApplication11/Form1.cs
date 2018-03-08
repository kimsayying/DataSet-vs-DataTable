using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication11
{
    public partial class Form1 : Form
    {
        string connString = @"Data Source=IST-KIM\SQLEXPRESS;Initial Catalog=AddressBook;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
               
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //SqldataAdapter act as a bridge between database and dataset/datatable
                DataTable tb1 = new DataTable();
                SqlDataAdapter sd = new SqlDataAdapter("select *from table_1", connString);
                sd.Fill(tb1); //fill the data table
                SqlDataAdapter sd1 = new SqlDataAdapter("select *from table_2", connString);
                sd1.Fill(tb1);
                SqlDataAdapter sd2 = new SqlDataAdapter("select *from table_3", connString);
                sd2.Fill(tb1); 
                dataGridView4.DataSource = tb1; //set the data source on the dataGridView4 to the table

                DataSet set = new DataSet();
                SqlDataAdapter sd3 = new SqlDataAdapter("select *from table_1", connString);
                sd3.Fill(set, "table1"); //fill the data set
                SqlDataAdapter sd4 = new SqlDataAdapter("select *from table_2", connString);
                sd4.Fill(set, "table2");
                SqlDataAdapter sd5 = new SqlDataAdapter("select *from table_3", connString);
                sd5.Fill(set, "table3");
                dataGridView1.DataSource = set.Tables[0]; //set the data source on the dataGridView4 which set to display
                dataGridView2.DataSource = set.Tables[1];
                dataGridView3.DataSource = set.Tables[2];
            }
           catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}
