﻿using FrbaOfertas.ConexionBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas.AbmCliente
{
    public partial class Nuevo : Form
    {
        private string username;

        public Nuevo()
        {
            InitializeComponent();
            fechaNacimiento.Format = DateTimePickerFormat.Custom;
            fechaNacimiento.CustomFormat = "yyyy-MM-dd";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AbmCliente().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (apellido.Text == "" || nombre.Text == "")
            {
                MessageBox.Show("Campos 'Nombre' y 'Apellido' son obligatorios");
                return;
            }

            if (dni.Text == "")
            {
                MessageBox.Show("Campo 'DNI' es obligatorio");
                return;
            }

            this.username= nombre.Text.ToLower() + '_' + apellido.Text.ToLower();
            DateTime fechaVenc = Properties.Settings.Default.fecha;
            string schema = Properties.Settings.Default.Schema;

            Tuple<string, List<string>, Object[]>[] procs = new Tuple<string,List<string>,object[]>[3];
            procs[1] = altaCliente();
            procs[0] = altaUsuario();
            procs[2] = tarjetaNueva();

                try
                {
                    
                    ConexionBD.Conexion conection = new ConexionBD.Conexion().getInstance();
                    conection.executeStoredTransaction(procs);

                    MessageBox.Show("Cliente creado correctamente.\nUsuario:'" + this.username + "'\nContraseña:'" + dni.Text + "'");
                    this.Hide();
                    new AbmCliente().Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
        }


        private Tuple<string, List<string>, Object[]> altaCliente() {
            return new Tuple<string, List<string>, Object[]>(
                   Properties.Settings.Default.Schema + ".altaCliente",
                   new List<String>()
                    {
                         "@fecha_nac","@nombreCliente","@apellidoCliente","@dniCliente",
		                 "@mailCliente","@telefonoCliente","@direccionCliente", "@pisoCliente",
                         "@deptoCliente", "@localidadCliente",
		                 "@codigoPostalCliente" ,"@ciudadCliente","@usuario"
                    },
                   new Object[]{
                        fechaNacimiento.Value.ToShortDateString(),nombre.Text,apellido.Text,dni.Value.ToString() == ""? DBNull.Value.ToString() : dni.Value.ToString(),
                        mail.Text,telefono.Value.ToString() == ""? DBNull.Value.ToString() : telefono.Value.ToString(), calle.Text + " " + (numero.Value.ToString() == ""? DBNull.Value.ToString() : numero.Value.ToString()), piso.Value.ToString() == ""? DBNull.Value.ToString() : piso.Value.ToString(), depto.Text,
                        localidaad.Text,codigoPostal.Value.ToString() == ""? DBNull.Value.ToString() : codigoPostal.Value.ToString(), city.Text, username
                    }
           );
        
        }

        private Tuple<string, List<string>, Object[]> altaUsuario()
        {
            return new Tuple<string, List<string>, Object[]>(
                    Properties.Settings.Default.Schema + ".altaUsuario",
                    new List<String>()
                    {
                        "@nombreUsuario", "@password"
                    },
                    new String[]{
                       username,dni.Text
                    }
                );
        }

        private Tuple<string, List<string>, Object[]> tarjetaNueva()
        {
            return new Tuple<string, List<string>, Object[]>(
                 Properties.Settings.Default.Schema + ".tarjetaRegaloParaUsuario",
           new List<String>() {
               "@userName", "@fechaVencimiento"
           },
           new Object[]{
               username, new DateTime(2100, 12, 31).ToShortDateString()
           }
           );
        }


        private void Nuevo_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void fechaNacimiento_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
