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
            builder.IntegratedSecurity = true;// Windows�F�؂̂���true.�T�[�o�[�F�؂ɂ��Ă���ꍇ��false�Ń��[�U�[���ƃp�X���[�h������
            builder.TrustServerCertificate = true;

            string sql = "select getdate()";// SQL������

            DataTable dt = new DataTable();
            using (var connection = new SqlConnection(builder.ConnectionString))
            using (var adapter = new SqlDataAdapter(sql,connection))
            {
                connection.Open();
                adapter.Fill(dt);//Fill�����sql�����s�����B�f�[�^�e�[�u��(dt)�Ɍ��ʂ�����
            }

            dataGridView1.DataSource = dt;
        }
    }
}
