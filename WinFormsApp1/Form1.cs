using Microsoft.Data.SqlClient;
using System.Data;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = @"DESKTOP-O4DS0L0";
            builder.InitialCatalog = "AndersonA";
            builder.IntegratedSecurity = true;// Windows認証のためtrue.サーバー認証にしている場合はfalseでユーザー名とパスワードを入れる
            builder.TrustServerCertificate = true;

            string sql = "select getdate()";// SQL文字列

            DataTable dt = new DataTable();
            using (var connection = new SqlConnection(builder.ConnectionString))
            using (var adapter = new SqlDataAdapter(sql,connection))
            {
                connection.Open();
                adapter.Fill(dt);//Fillするとsqlが実行される。データテーブル(dt)に結果が入る
            }

            dataGridView1.DataSource = dt;
        }
    }
}
