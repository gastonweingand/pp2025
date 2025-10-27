using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIHilos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Quitar la restricción de que los controles solo pueden ser modificados por el hilo que los creó
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnAvanzar_Click(object sender, EventArgs e)
        {
            int nro = int.Parse(Interaction.InputBox("Por favor selecciona la barra que quiere utilizar (1-2-3)"));

            Thread hilo = new Thread(Hilo);
            hilo.Start();
        }

        static readonly object lockObject = new object();

        private void Hilo()
        {
            lock (lockObject)
            {
                for (int i = 1; i <= 100; i++)
                {
                    progressBar.PerformStep();
                    Thread.Sleep(50);
                }

                progressBar.Step = -1;

                for (int i = 100; i > 0; i--)
                {
                    progressBar.PerformStep();
                    Thread.Sleep(50);
                }
                progressBar.Step = 1;
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            int nro = int.Parse(Interaction.InputBox("Por favor selecciona la barra que quiere pintar (1-2-3)"));


        }
    }
}
