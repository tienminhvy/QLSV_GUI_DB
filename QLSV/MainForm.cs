using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "ThongTinSinhVien")
                {
                    f.Activate();
                    return;
                }                    
            }
            // ko co tao moi
            ThongTinSinhVien ttsv = new ThongTinSinhVien();
            ttsv.MdiParent = this;
            ttsv.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "DanhMucKhoa")
                {
                    f.Activate();
                    return;
                }
            }
            // ko co tao moi
            DanhMucKhoa dmkh = new DanhMucKhoa();
            dmkh.MdiParent = this;
            dmkh.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.Name == "DanhMucMonHoc")
                {
                    f.Activate();
                    return;
                }
            }
            // ko co tao moi
            DanhMucMonHoc dmmh = new DanhMucMonHoc();
            dmmh.MdiParent = this;
            dmmh.Show();
        }
    }
}
