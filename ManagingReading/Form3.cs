﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.Office.Interop.Excel;
using Axis = LiveCharts.Wpf.Axis;
using SeriesCollection = LiveCharts.SeriesCollection;

namespace ManagingReading
{
    public partial class Form3 : Form
    {

        public string[] Most8MemberRead = new string[8];

        public int[] Most8MemberReadPage = new int[8];
       
        public Form3(List<int> number, List<string> memberN, string text)
        {
            
            InitializeComponent();

            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisY.Clear();
            label4.Text = text;
            
          
            if (memberN.Count >= 8)
            {

                for (int i = 0; i < 8; i++)
                {
                    Most8MemberRead[i] = memberN[i].Trim(); ;
                    Most8MemberReadPage[i] = number[i];
                }
            }



            if (memberN.Count >= 8)
            {
                cartesianChart1.Series = new LiveCharts.SeriesCollection
            {
                new ColumnSeries
                {
                        ColumnPadding =5,
                    Title = "",
                    Values = new ChartValues<int>(Most8MemberReadPage.ToList())
                }
            };
                cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
                {
                    Title = "",
                    LabelsRotation = 16,
                    Separator = new Separator { Step = 1 },
                    Labels = Most8MemberRead.ToList()


                });
              
                cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
                {

                    Title = " ",
                    //     MinValue =1,
                    Separator = new Separator { Step = (number.Max() / 10) + 1 },
                    LabelFormatter = value => value.ToString("N"),


                });

            }



            if (memberN.Count <8)
            {
                cartesianChart1.Series = new LiveCharts.SeriesCollection
            {
                new ColumnSeries
                {
                        ColumnPadding =5,
                    Title = "",
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
                    
                    Separator = new Separator { Step = (number.Max() / 10)+1 },
                    LabelFormatter = value => value.ToString("N"),


                });

            }

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








        private void guna2ImageButton4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

    
    }
}
