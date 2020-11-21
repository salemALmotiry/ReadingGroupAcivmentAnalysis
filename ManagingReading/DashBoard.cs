using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.Office.Interop.Excel;
using Axis = LiveCharts.Wpf.Axis;
using SeriesCollection = LiveCharts.SeriesCollection;


//using static ManagingReading.FillterFile;


namespace ManagingReading

{
    public partial class DashBoard : Form
    {
        int mov;
        int movX;
        int movY;
        int hd;
        bool hide;
        bool TimerNeeded1 = true;
        bool TimerNeeded2 = true;
        bool TimerNeeded3 = true;
        bool TimerNeeded4 = true;

        int countTimerNeeded1 = 0;
        int countTimerNeeded2 = 0;
        int countTimerNeeded3 = 0;
        int countTimerNeeded4 = 0;
        bool DialogCheck = false;
        string text;

        bool bk = true;


        FilterFile fil = new FilterFile();

        double[,] temp12 = new double[4, 1];


        public DashBoard()
        {

            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

          
            this.StartPosition = FormStartPosition.Manual;
            this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
            this.Left = (Screen.PrimaryScreen.Bounds.Width - this.Width) / 2;

            guna2ShadowPanel1.Hide();
            hd = spanel.Height;
            hide = true;
            spanel.Height = 0;
            panel3.Hide();
            panel66.Hide();
            panel6.Show();

        }




        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hide)
            {

                spanel.Height = spanel.Height + 20;
                if (spanel.Height >= hd)
                {
                    timer1.Stop();
                    hide = false;
                    this.Refresh();
                }
            }
            else
            {
                spanel.Height = spanel.Height - 20;
                if (spanel.Height <= 0)
                {
                    timer1.Stop();
                    hide = true;
                    this.Refresh();

                }
            }
        }

        private void InfoStart_Click(object sender, EventArgs e)
        {

            timer1.Start();
        }



        private void timer2_Tick(object sender, EventArgs e)
        {



            {

                if (countTimerNeeded1 >= fil.totalpage)
                {
                    //     timer2.Stop();
                    TimerNeeded1 = false;

                    countTimerNeeded1 = fil.totalpage;
                    textBox1.Text = countTimerNeeded1.ToString();
                }
                if (TimerNeeded1 == true)
                {
                    textBox1.Text = countTimerNeeded1.ToString();

                    countTimerNeeded1 += (int)temp12[0, 0];
                }
            }

            {
                if (countTimerNeeded2 >= fil.totalmembers)
                {
                    //     timer2.Stop();

                    TimerNeeded2 = false;
                    countTimerNeeded2 = fil.totalmembers;
                    TotalMemberLabel.Text= countTimerNeeded2.ToString();
                }


                if (TimerNeeded2 == true)
                {
                    TotalMemberLabel.Text = countTimerNeeded2.ToString();

                    countTimerNeeded2 += (int)temp12[2, 0];
                }
            }


            if (countTimerNeeded3 >= fil.totalbooks)
            {
                //     timer2.Stop();
                TimerNeeded3 = false;

                countTimerNeeded3 = fil.totalbooks;
                totalbooksCounterlabel.Text = countTimerNeeded3.ToString();
            }
            if (TimerNeeded3 == true)
            {
                totalbooksCounterlabel.Text = countTimerNeeded3.ToString();

                countTimerNeeded3 += (int)temp12[1,0];
            }

          
            if (countTimerNeeded4 >= fil.totalBookRead)
            {
                //     timer2.Stop();
                TimerNeeded4 = false;

                countTimerNeeded4 = fil.totalBookRead;
                TotalBookReadCounterlabel.Text = countTimerNeeded4.ToString();
            }
            if (TimerNeeded4 == true)
            {
                TotalBookReadCounterlabel.Text = countTimerNeeded4.ToString();

                countTimerNeeded4 += 1;
            }




        }




        private void MainRe_Click(object sender, EventArgs e)
        {
            if (DialogCheck == true)
            {
                panel3.Show();
                panel66.Hide();
                cartesianChart1.AxisX.Clear();
                cartesianChart1.AxisY.Clear();
                cartesianChart2.AxisX.Clear();
                cartesianChart2.AxisY.Clear();

              
                TimerNeeded1 = true;
                TimerNeeded2 = true;
                TimerNeeded3 = true;
                TimerNeeded4 = true;
                countTimerNeeded1 = 0;
                countTimerNeeded2 = 0;
                countTimerNeeded3 = 0;
                countTimerNeeded4 = 0;
                timer2.Start();


                if (fil.MemberNameNoDuplicates.Count >= 8)
                {
                    chartt(fil.Most8MemberReadPage.ToList(), fil.Most8MemberRead.ToList());
                }
                else
                {
                    chartt(fil.TotalPageReadForEachMember, fil.MemberNameNoDuplicates);
                }


                if (fil.BookInfoForName.Count >= 5)
                {
                    chart1(fil.Most5BookReadTimes.ToList(), fil.Most5BookRead.ToList()); ;

                  //  MessageBox.Show(fil.Most5BookReadTimes[4].ToString());
                }
                else
                {
                    chart1(fil.MostBookReadCount, fil.BookInfoForName); ;

                }

                guna2ShadowPanel1.Show();
            }
        }



        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {


            this.Close();
            Start s = new Start();
            s.Close();
           
        }

        public void chartt(List<int> number, List<string> memberN)


        {


            cartesianChart1.Series = new LiveCharts.SeriesCollection
            {
                new ColumnSeries
                { 
                 
                    ColumnPadding =5,
                    Title = "page",
                    Values = new ChartValues<int>(number)
                }
            };
            cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            {
                Title = "",
                LabelsRotation = 16,
                Separator = new Separator { Step = 1 },
                Labels = memberN


            });
      
            cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            {
                Title = " ",
                    MinValue =1,
                   Separator = new Separator { Step = (number.Max()/10)+1 },
                LabelFormatter = value => value.ToString("N"),


            });


        }
        public void chart1(List<int> number, List<string> memberN)


        {

            cartesianChart2.Series = new LiveCharts.SeriesCollection
            {
                new ColumnSeries
                {
                       ColumnPadding =5,
                    Title = "Book",
                   
                    Values = new ChartValues<int>(number),

                }

            };


            cartesianChart2.AxisX.Add(new Axis
            {
                Title = "",
                Separator = new Separator  {  Step = 1  },
                LabelsRotation = 16,
           
                Labels = memberN,


            });

            cartesianChart2.AxisY.Add(new LiveCharts.Wpf.Axis
            {
               
                Title = " ",
             
                Separator = new Separator { Step = (number.Max()/10)+1},
                LabelFormatter = value => value.ToString("N")


            });


        }


        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x00020000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void DialogFile_Click(object sender, EventArgs e)
        {


            openFileDialog1.Filter = "Text|*.txt|All|*.*";
            openFileDialog1.FileName = ".txt";
        
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                DialogCheck = true;
                text = System.IO.File.ReadAllText(openFileDialog1.FileName);

                fil.filterFile('1', "readinginfo", "endfile", text, '_');

                fil.filterFile('2', "booksinfo", "readinginfo", text, '_');

                fil.filterFile('3', "memberinfo", "booksinfo", text, '_');

                //     fil.totalconut();
                fil.setup();

                if (fil.totalpage >= 100)
                {
                    temp12[0, 0] = fil.totalpage / 30;

                }
                else
                {
                    temp12[0, 0] = 3;
                }
                if (fil.totalbooks >= 100)
                {
                    temp12[1, 0] = fil.totalbooks / 30;

                }
                else
                {
                    temp12[1, 0] = 3;
                }

                if (fil.totalmembers >= 100)
                {
                    temp12[2, 0] = fil.totalmembers / 30;

                }
                else
                {
                    temp12[2, 0] = 3;
                }

                if (fil.totalBookRead >= 100)
                {
                    temp12[3, 0] = fil.totalBookRead / 30;


                }
                else
                {
                    temp12[3, 0] = 3;
                }






                MainRe_Click(sender, e);

            }else
            {
                DialogCheck = false;
            }
        }



        private void SecondReport_Click(object sender, EventArgs e)
        {
            if (DialogCheck == true)
            {
                panel66.Show();
                //     panel3.Hide();

                //fil.MostBookRead();
                //   int j = 1;

                listViewForBookRead.Items.Clear();

                listViewForCategoies.Items.Clear();
                listViewMemberRead.Items.Clear();
                listViewFormemberReadBook.Items.Clear();
                for (int i = 0; i < fil.BookInfoForName.Count; i++)
                {

                    string[] d = { (i + 1).ToString(), fil.BookInfoForName[i], fil.MostBookReadCount[i].ToString() };


                    ListViewItem item = new ListViewItem(d);

                    listViewForBookRead.Items.Add(item);


                }


                for (int i = 0; i < fil.BookInfoForCategories.Count; i++)
                {
                    string[] d = { (i + 1).ToString(), fil.BookInfoForCategories[i], fil.Categoriescount[i].ToString() };


                    ListViewItem item = new ListViewItem(d);

                    listViewForCategoies.Items.Add(item);


                }


                for (int i = 0; i < fil.MemberNameNoDuplicates.Count; i++)
                {

                    string[] d = { (i + 1).ToString(), fil.MemberNameNoDuplicates[i], fil.TotalPageReadForEachMember[i].ToString() };


                    ListViewItem item = new ListViewItem(d);

                    listViewMemberRead.Items.Add(item);


                }


                for (int i = 0; i < fil.MemberNameRankForBookRead.Count; i++)
                {
                    string[] d = { (i + 1).ToString(), fil.MemberNameRankForBookRead[i], fil.NumberOfbookreadFoeEachMember[i].ToString() };


                    ListViewItem item = new ListViewItem(d);

                    listViewFormemberReadBook.Items.Add(item);

                }

            }

        }

        private void panel66_Paint(object sender, PaintEventArgs e)
        {

        }

   
     
        private void statisticalReportsforBook_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3(fil.MostBookReadCount, fil.BookInfoForName,MostBookReadlabel.Text);

            f.Show();
        }

        private void statisticalReportsforCategories_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3(fil.Categoriescount, fil.BookInfoForCategories,MostCateReadlabel.Text);

            f.Show();
        }

        private void statisticalReportsforMemRead_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3(fil.TotalPageReadForEachMember, fil.MemberNameNoDuplicates, MostMemReadlabel.Text);

            f.Show();

        }

        private void statisticalReportsforMemReadBook_Click(object sender, EventArgs e)
        {
            
            Form3 f = new Form3(fil.NumberOfbookreadFoeEachMember, fil.MemberNameRankForBookRead, MostMemReadBooklabel.Text);

            f.Show();

        }


        private void DashDoard_Load(object sender, EventArgs e)
        {


            this.StartPosition = FormStartPosition.CenterScreen;
          
        }

        private void MovePanel_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void MovePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void MovePanel_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

      
    }
    }

