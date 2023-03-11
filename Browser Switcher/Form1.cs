using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Browser_Switcher 
{ 
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
          int nLeftRect,     // x-coordinate of upper-left corner
          int nTopRect,      // y-coordinate of upper-left corner
          int nRightRect,    // x-coordinate of lower-right corner
          int nBottomRect,   // y-coordinate of lower-right corner
          int nWidthEllipse, // width of ellipse
          int nHeightEllipse // height of ellipse
        );
        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle; //removes ability to resize
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; //removes the top bar
            this.MaximizeBox = false; //prevents maximizing
            this.MinimizeBox = false; //prevents minimizing

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, get_Length() * 90 + 16, 104, 20, 20));

            int length = get_Length();
            Button B1 = create_Button(1, 0);
            B1.Click += B1_Click;
            B1.MouseEnter += B1_MouseEnter;
            B1.MouseLeave += B1_MouseLeave;

            this.Controls.Add(B1);
            if (length > 1)
            {
                Button B2 = create_Button(2, 0);
                B2.Click += B2_Click;
                B2.MouseEnter += B2_MouseEnter;
                B2.MouseLeave += B2_MouseLeave;
                this.Controls.Add(B2);
            }
            if (length > 2)
            {
                Button B3 = create_Button(3, 0);
                B3.Click += B3_Click;
                B3.MouseEnter += B3_MouseEnter;
                B3.MouseLeave += B3_MouseLeave;
                this.Controls.Add(B3);
            }
            if (length > 3)
            {
                Button B4 = create_Button(4, 0);
                B4.Click += B4_Click;
                B4.MouseEnter += B4_MouseEnter;
                B4.MouseLeave += B4_MouseLeave;
                this.Controls.Add(B4);
            }
            if (length > 4)
            {
                Button B5 = create_Button(5, 0);
                B5.Click += B5_Click;
                B5.MouseEnter += B5_MouseEnter;
                B5.MouseLeave += B5_MouseLeave;
                this.Controls.Add(B5);
            }

        }
        public Button create_Button(int length, int c)
        {
            Button B1 = new Button();
            B1.Location = new Point(8 + (length-1) * 90-c, 7-c);
            B1.Height = 90+2*c;
            B1.Width = 90+2*c;
            B1.TabStop = false;
            B1.FlatStyle = FlatStyle.Flat;
            B1.FlatAppearance.BorderSize = 0;
            B1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            return B1;
        }
        public string[ , ] get_Data()
        {
            string Raw_Data = Properties.Settings.Default.Browsers;
            string[] Split_Data = Raw_Data.Split('|');
            string[,] Browsers = { { "", "" }, { "", "" }, { "", "" }, { "", "" }, { "", "" } };
            for (int i = 0; i < Split_Data.Length; i++)
            {
                String Line = Split_Data[i];
                String[] Data = Line.Split(',');
                for (int a = 0; a < 2; a++)
                {
                    Browsers[i, a] = Data[a];

                }
            }
            return Browsers;
        }
        public int get_Length()
        {
            string[,] Browsers = get_Data();
            int length = 1;
            if (Browsers[1, 0] != "")
            {
                length = 2;
            }
            if (Browsers[2, 0] != "")
            {
                length = 3;
            }
            if (Browsers[3, 0] != "")
            {
                length = 4;
            }
            if (Browsers[4, 0] != "")
            {
                length = 5;
            }
            return length;
        }

        private void B1_Click(object sender, EventArgs e)
        {
            string[,] Browsers = get_Data();
            Process.Start(Browsers[0, 0], "https://stackoverflow.com/questions/72353745/how-do-i-make-my-c-sharp-net-application-run-when-a-https-link-is-clicked"); // opens link
            System.Windows.Forms.Application.Exit(); //closes the application
        }

        private void B2_Click(object sender, EventArgs e)
        {
            string[,] Browsers = get_Data();
            Process.Start(Browsers[1, 0], "https://stackoverflow.com/questions/72353745/how-do-i-make-my-c-sharp-net-application-run-when-a-https-link-is-clicked"); // opens link
            System.Windows.Forms.Application.Exit(); //closes the application
        }
        private void B3_Click(object sender, EventArgs e)
        {
            string[,] Browsers = get_Data();
            Process.Start(Browsers[2, 0], "URL"); // opens link
            System.Windows.Forms.Application.Exit(); //closes the application
        }
        private void B4_Click(object sender, EventArgs e)
        {
            string[,] Browsers = get_Data();
            Process.Start(Browsers[3, 0], "URL"); // opens link
            System.Windows.Forms.Application.Exit(); //closes the application
        }
        private void B5_Click(object sender, EventArgs e)
        {
            string[,] Browsers = get_Data();
            Process.Start(Browsers[4, 0], "URL"); // opens link
            System.Windows.Forms.Application.Exit(); //closes the application
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[,] Browsers = get_Data();
            this.Size = new Size(get_Length() * 90+16, 104);
            this.CenterToScreen();
        }

        private void Form1_Deactivate(object sender, EventArgs e) //runs when page is minimised
        {
            System.Windows.Forms.Application.Exit();
        }

        private void B1_MouseEnter(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int a = Enlarge(clickedButton,0);
        }
        private void B2_MouseEnter(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int a = Enlarge(clickedButton,1);
        }
        private void B3_MouseEnter(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int a = Enlarge(clickedButton, 2);
        }
        private void B4_MouseEnter(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int a = Enlarge(clickedButton, 3);
        }
        private void B5_MouseEnter(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int a = Enlarge(clickedButton, 4);
        }
        private void B1_MouseLeave(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int a = Shrink(clickedButton,0);
        }
        private void B2_MouseLeave(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int a = Shrink(clickedButton,1);
        }
        private void B3_MouseLeave(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int a = Shrink(clickedButton, 2);
        }
        private void B4_MouseLeave(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int a = Shrink(clickedButton, 3);
        }
        private void B5_MouseLeave(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int a = Shrink(clickedButton, 4);
        }
        public int Enlarge(Button clickedButton, int index)
        {
            clickedButton.Enabled = true;
            clickedButton.Width = 104;
            clickedButton.Height = 104;
            clickedButton.Location = new Point(1+90*index, 0);
            return 0;
        }
        public int Shrink(Button clickedButton, int index)
        {
            clickedButton.Enabled = true;
            clickedButton.Width = 90;
            clickedButton.Height = 90;
            clickedButton.Location = new Point(8 + index*90, 7);
            return 0;
        }
    }
}
