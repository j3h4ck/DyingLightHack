using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;
using System.Threading;
using System.Runtime.InteropServices;

namespace dyinglight
{
    public partial class Form1 : Form
    {
        Mem m = new Mem();
        int PID;
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);
        string x_address = "engine_x64_rwdi.dll+00A8E2E8,280,0,700,BC";
        string y_address = "engine_x64_rwdi.dll+00A8E2E8,280,0,700,C4";
        string z_address = "engine_x64_rwdi.dll+00A8E2E8,280,0,700,C0";
        float z;
        float x;
        float y;
        float z2;
        bool fly1 = false;

        public Form1()
        {

            InitializeComponent();
            this.TopMost = true;
            
            button1.ForeColor = Color.Red;
            button2.ForeColor = Color.Red;


        }
        public void Cheat()
        {
            
            z = m.ReadFloat(z_address);
            //MessageBox.Show("z is : " + z);
            //backgroundWorker1.RunWorkerAsync();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PID = m.GetProcIdFromName("DyingLightGame.exe");
            if (PID == 0)
            {
                richTextBox1.AppendText("[-] Process isnt running\n");
            }
            else
            {
                button1.ForeColor = Color.LimeGreen;
                richTextBox1.AppendText("[+] Game is running\n");
                richTextBox1.AppendText("[+] PID : " + PID + "\n");
                m.OpenProcess(PID);
                Cheat();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(10);
            if (GetAsyncKeyState(Keys.Space) < 0)
            {
                z = m.ReadFloat(z_address);
                z2 = z + 8;
                
                //richTextBox1.AppendText("old z : " + z + "\n");
                //label1.Text += "old z : " + z + "\n";
                //label1.Text += "new z : " + z2 + "\n";
                //richTextBox1.AppendText("new z : " + z2 + "\n");
                m.WriteMemory(z_address,"float", z2.ToString());
                Thread.Sleep(10);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fly1 = !fly1;
            if (fly1 == false)
            {
                button2.ForeColor = Color.Red;
                button2.Text = "deactivated";
                flyhack.Stop();
                richTextBox1.AppendText("[-] Fly Hack Deactivated\n");
            }
            else if (fly1 == true)
            {
                button2.ForeColor = Color.LimeGreen;
                button2.Text = "activated";
                flyhack.Start();
                richTextBox1.AppendText("[+] Fly Hack Activated\n");
            }

            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void zcalc_Tick(object sender, EventArgs e)
        {
            x = m.ReadFloat(x_address);
            y = m.ReadFloat(y_address);
            z = m.ReadFloat(z_address);
            label2.Text = "x : " + x.ToString();
            label3.Text = "z : " + z.ToString();
            label4.Text = "y : " + y.ToString();
            if (GetAsyncKeyState(Keys.F10) < 0)
            {
                fly1 = !fly1;
                if (fly1 == false)
                {
                    button2.ForeColor = Color.Red;
                    button2.Text = "deactivated";
                    flyhack.Stop();
                    richTextBox1.AppendText("[-] Fly Hack Deactivated\n");
                }
                else if (fly1 == true)
                {
                    button2.ForeColor = Color.LimeGreen;
                    button2.Text = "activated";
                    flyhack.Start();
                    richTextBox1.AppendText("[+] Fly Hack Activated\n");
                }
            }


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            float xbase = 272.5458984f;
            float ybase = 88.02549744f;
            float zbase = 134.3164368f;
            m.WriteMemory(x_address, "float", xbase.ToString());
            m.WriteMemory(y_address, "float", ybase.ToString());
            m.WriteMemory(z_address, "float", zbase.ToString());
            richTextBox1.AppendText("[*] Teleporting to base\n");
            richTextBox1.AppendText("[+] Teleported successfully\n");


        }

        private void button4_Click(object sender, EventArgs e)
        {
            float xlake = 0.2735294104f;
            float ylake = 73.82168579f;
            float zlake = 98.27256775f;
            m.WriteMemory(x_address, "float", xlake.ToString());
            m.WriteMemory(y_address, "float", ylake.ToString());
            m.WriteMemory(z_address, "float", zlake.ToString());
            richTextBox1.AppendText("[*] Teleporting to lake\n");
            richTextBox1.AppendText("[+] Teleported successfully\n");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            float xbridge = -132.0366669f;
            float ybridge = 278.3412781f;
            float zbridge = 237.6899109f;
            m.WriteMemory(x_address, "float", xbridge.ToString());
            m.WriteMemory(y_address, "float", ybridge.ToString());
            m.WriteMemory(z_address, "float", zbridge.ToString());
            richTextBox1.AppendText("[*] Teleporting to bridge\n");
            richTextBox1.AppendText("[+] Teleported successfully\n");
        }
    }
}
