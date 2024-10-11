using System.Text.Json;

namespace Lab02
{
    public partial class Form1 : Form
    {
        class Phim
        {
            public string TenPhim { get; set; }
            public int GiaVeChuan { get; set; }
            public int[] PhongChieu { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open);
                List<Phim>? phims = JsonSerializer.Deserialize<List<Phim>>(fileStream);
                comboBox1.DataSource = phims;
                comboBox1.DisplayMember = "TenPhim";
            }
        }
    }
}