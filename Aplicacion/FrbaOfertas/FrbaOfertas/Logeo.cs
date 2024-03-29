﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaOfertas.ConexionBD;
using FrbaOfertas.Utils;

namespace FrbaOfertas
{
    public partial class Logeo : Form
    {
        int contIntentosFallidos;
        int tiempoBloqueo;
        Util utils = new Util();
        public static List<string> usuariosEliminadosLogicamente = new List<string>();
        public static string username = "";

        public string UserName{
        
            get {return textBoxUser.Text; }
        }

  

        public Logeo(int tiempoBloqueo, int contIntentosFallidos)
        {
            InitializeComponent();
            this.contIntentosFallidos = contIntentosFallidos;
            this.tiempoBloqueo = tiempoBloqueo;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ingresar_btn_Click(object sender, EventArgs e)
        {
            List<String> values = new List<String>() { "@userName", "@bloqueado", "@fechaBloqueo" };
            if (textBoxUser.Text == "" || textBoxPassword.Text == "")
            {
                error_message.Text = "Complete los campos";
                error_message.Visible = true;
            }
            else
            {
                Object usr = new Conexion().executeScalarFunction("existeUsuario", this.textBoxUser.Text);
                Object loginValido = new Conexion().executeScalarFunction("loginValido", textBoxUser.Text, textBoxPassword.Text);
                Object bloqueado = new Conexion().executeScalarFunction("usuarioEstaBloqueado", textBoxUser.Text);
                DateTime datetime = DateTime.Now;
                long unixDateTime = Util.ConvertToUnixTime(datetime);
                Object auxTime = new Conexion().executeScalarFunction("obtenerFecha", this.textBoxUser.Text, this.tiempoBloqueo);
                Int32 unixDateUser = Convert.ToInt32(auxTime);
                if (Convert.ToInt32(bloqueado) == 1 && unixDateTime < unixDateUser)
                {
                    utils.getInstance().ClearTextBoxes(this.Controls);
                    error_message.Text = "Usuario bloqueado, vuelva a intentar más tarde";
                    error_message.Visible = true;
                }
                else if ((Convert.ToInt32(loginValido) == 1) && (Convert.ToInt32(bloqueado) == 0))
                {
                    if(usuariosEliminadosLogicamente.Contains(textBoxUser.Text))
                    {
                        MessageBox.Show("Usuario ha sido dado de baja por administrador");
                    }
                    else
                    {
                        username = textBoxUser.Text;
                        limpiarIntentosFallidos();
                        redireccionar(this.textBoxUser.Text);
                    }
                    
                }
                else if ((Convert.ToInt32(bloqueado) == 1) && (unixDateTime >= unixDateUser) && Convert.ToInt32(usr) == 1)
                {
                    new Conexion().executeProcedure(Properties.Settings.Default.Schema + ".updateBloqueadoUser", new List<string>() { "@nombreUsuario", "@bloqueado" }, textBoxUser.Text, "0");
                    if (Convert.ToInt32(loginValido) == 1)
                    {
                        if (usuariosEliminadosLogicamente.Contains(textBoxUser.Text))
                        {
                            MessageBox.Show("Usuario ha sido dado de baja por administrador");
                        }
                        else
                        {
                            username = textBoxUser.Text;
                            limpiarIntentosFallidos();
                            redireccionar(this.textBoxUser.Text);
                        }
                    }
                }
                else
                {
                    Object cantFallidos = -1;
                    if (Convert.ToInt32(usr) == 1)
                    {
                        new Conexion().executeProcedure(Properties.Settings.Default.Schema + ".sumarIntentoFallido",
                                                        new List<string>() { "@nombreUsuario" }, textBoxUser.Text);
                        cantFallidos = new Conexion().executeScalarFunction("obtenerCantIntentosFallidos", textBoxUser.Text);
                    }
                    if (Convert.ToInt32(cantFallidos) == 3)
                    {
                        MessageBox.Show("Ha agotado el maximo de intentos permitidos, se le bloqueara el usuario por " + this.tiempoBloqueo + " minutos");
                        String localDate = Convert.ToString(DateTime.Now);
                        new Conexion().executeProcedure(Properties.Settings.Default.Schema + ".updateBloqueadoUser", new List<string>() { "@nombreUsuario", "@bloqueado" }, textBoxUser.Text, "1");
                        new Util().ClearTextBoxes(this.Controls);
                        error_message.Text = "";
                    }
                    else if (Convert.ToInt32(cantFallidos) == -1)
                    {
                        error_message.Text = "Ingreso incorrecto";
                        error_message.Visible = true;
                    }
                    else
                    {
                        error_message.Text = "Ingreso incorrecto, le quedan: " + (3-Convert.ToInt32(cantFallidos)) + " intentos";
                        error_message.Visible = true;
                    }
                }
            }
        }

        private void redireccionar(string username)
        {
            this.Hide();
            new MenuPrincipal(username).Show();
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            utils.getInstance().ClearTextBoxes(this.Controls);
        }

        private void user_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void error_message_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new Login.LoginABM().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void limpiarIntentosFallidos()
        {
            new Conexion().executeProcedure(
                Properties.Settings.Default.Schema + ".reiniciarIntentosFallidos",
                new List<string>() { "@nombreUsuario" },
                textBoxUser.Text);
        }
    }
}
