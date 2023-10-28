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

namespace QLSV
{
    public partial class XemDiem : Form
    {
        public XemDiem()
        {
            InitializeComponent();
        }

        private void sinhVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.sinhVienBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qLSVDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLSVDataSet.Khoa' table. You can move, or remove it, as needed.
            this.khoaTableAdapter.Fill(this.qLSVDataSet.Khoa);
            // TODO: This line of code loads data into the 'qLSVDataSet.SinhVien' table. You can move, or remove it, as needed.
            this.sinhVienTableAdapter.Fill(this.qLSVDataSet.SinhVien);

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            // lấy chuỗi connectionstring từ app.config
            string conn = global::QLSV.Properties.Settings.Default.QLSVConnectionString;
            string str;
            // truy vấn lấy điểm các môn học của SV có mã số được chọn
            str = string.Format("Select TenMH, Diem From KetQua,Mon where KetQua.MaMH = Mon.MaMH AND MaSo = {0}", comboBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(str, conn); 
            DataSet ds = new DataSet();
            // đổ vào dataset
            da.Fill(ds);
            // hiển thị ra DataGridView dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.DataSource = ds.Tables[0];
            fillTxtKhoa();
        }

        public void fillTxtKhoa()
        {
            // lấy chuỗi connectionstring từ app.config
            string conn = global::QLSV.Properties.Settings.Default.QLSVConnectionString;
            string str;
            // truy vấn lấy điểm các môn học của SV có mã số được chọn
            str = string.Format("Select MaKhoa From SinhVien WHERE MaSo = {0}", comboBox1.Text);
            SqlDataAdapter da = new SqlDataAdapter(str, conn);
            DataSet ds = new DataSet();
            // đổ vào dataset
            da.Fill(ds);
            // hiển thị ra DataGridView dataGridView1.DataSource = ds.Tables[0];
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.Rows[0];
            txtKhoa.Text = Convert.ToString(dr["MaKhoa"]);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fillTxtKhoa();
            } catch (Exception ex)
            {
                // lỗi lỏ
            }
        }
    }
}
