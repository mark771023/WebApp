using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace WinFormAPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57042/api/Students");

            HttpResponseMessage resp = client.GetAsync("http://localhost:57042/api/Students").Result;
            IEnumerable<Student> data = null;

            if (resp.IsSuccessStatusCode)
            {
                data = resp.Content.ReadAsAsync<IEnumerable<Student>>().Result;

                foreach (var item in data)
                {

                    listBox1.Items.Add("學號：" + item.學號 + "，姓名：" + item.姓名 + "，性別：" + item.性別 + "，電話：" + item.電話 + "，生日：" + item.生日);
                }

            }

        }


        public class Student
        {
            public string 學號 { get; set; }
            public string 姓名 { get; set; }
            public string 性別 { get; set; }
            public string 電話 { get; set; }
            public string 生日 { get; set; }
        }

    }
}
