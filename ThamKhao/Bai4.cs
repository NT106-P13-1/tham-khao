using System.Text.Json;

namespace ThamKhao
{
    public partial class Bai4 : Form
    {
        class Phim
        {
            public string TenPhim { get; set; }
            public int GiaVeChuan { get; set; }
            public int[] PhongChieu { get; set; }
        }
        public Bai4()
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
                cbPhim.DataSource = phims;
                cbPhim.DisplayMember = "TenPhim";
            }
        }
    }
}