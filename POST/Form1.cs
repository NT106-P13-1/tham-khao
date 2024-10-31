using Microsoft.VisualBasic.ApplicationServices;
using System.Net.Http;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace POST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri(@"https://nt106.uitiot.vn")
        };

        private void button1_Click(object sender, EventArgs e)
        {
            DoLogin();
        }

        private async void DoLogin()
        {
            string username = tbUsername.Text;
            string password = tbPassword.Text;

            var formData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password)
            });
            using HttpResponseMessage response = await httpClient.PostAsync(
                "auth/token",
                formData
            );

            var res = await response.Content.ReadAsStringAsync();
            JObject keyValuePairs = JObject.Parse(res);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show(keyValuePairs["detail"].ToString());
            }
            else
            {
                if (keyValuePairs["access_token"] != null)
                {
                    string jwt = $"{keyValuePairs["token_type"]} {keyValuePairs["access_token"]}";
                    rtbShow.Text = jwt;
                }
                MessageBox.Show($"Login success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}