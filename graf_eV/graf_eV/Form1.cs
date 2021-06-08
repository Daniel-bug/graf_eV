using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace graf_eV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //***********NĚJAKÁ UMĚLÁ DATA, JENOM PŘÍMKA OD 300 - 900nm, ALE OBECNĚ TO MŮŽE BÝT I JYNÝ ROZSAH VLNOVÝCH DÉLEK*****
            double[] dataX = new double[1024];
            int[] dataY = new int[1024];
            for(int i =0; i<1024; i++)
            {
                dataY[i] = i;
                dataX[i] = 300 + ((double)i / 1023 * 600);
               
            }
            chart1.ChartAreas[0].AxisX.Minimum = dataX.Min();
            chart1.ChartAreas[0].AxisX.Maximum = dataX.Max();
            chart1.Series[0].Points.DataBindXY(dataX, dataY);
            //***************************************************

            //*****PŘEPOČET NA eV************
            double[] data2_eV_X = new double[1024];
            int[] data2_Y = new int[1024];

            for(int i = 0; i<1024; i++)
            {
                data2_eV_X[i] = Math.Round((1240 / dataX[i]), 2);
                data2_Y[i] = 0;
            }

            chart1.Series.Add("eV");
            chart1.Series[1].XAxisType = AxisType.Secondary;
            chart1.ChartAreas[0].AxisX2.Enabled = AxisEnabled.True;
            chart1.ChartAreas[0].AxisX2.IsReversed = true;
            chart1.Series[1].Points.DataBindXY(data2_eV_X, data2_Y);

        }
    }
}
