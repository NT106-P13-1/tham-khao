using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        [Serializable]
        public class SinhVien
        {
            public string HoTen;
            public string MSSV;
            public string Lop;

            public SinhVien(string hoten, string mssv, string lop)
            {
                HoTen = hoten;
                MSSV = mssv;
                Lop = lop;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SinhVien sinhvienGhi = new SinhVien(textBox1.Text, textBox2.Text, textBox3.Text);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fs = new FileStream(sfd.FileName, FileMode.CreateNew);
            binaryFormatter.Serialize(fs, sinhvienGhi);
            MessageBox.Show("Ghi dữ liệu thành công!");
            fs.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            var result = binaryFormatter.Deserialize(fs);
            SinhVien sinhvienDoc = (SinhVien)result;
            textBox4.Text = sinhvienDoc.HoTen + Environment.NewLine + sinhvienDoc.MSSV + Environment.NewLine + sinhvienDoc.Lop + Environment.NewLine;
        }
    }
}
