﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.ListadoEstadistico
{
    public partial class listFacturacion : Form
    {
        public listFacturacion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ListadoEstadistico.Form1().Show();
        }

        private void listFacturacion_Load(object sender, EventArgs e)
        {
            year.Value = Properties.Settings.Default.fecha.Year;
            semestre.SelectedItem = "Primero";
        }
    }
}
