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


namespace FrbaOfertas.Login
{
    public partial class LoginABM : Form
    {
        int contIntentosFallidos;
        int tiempoBloqueo;
        Util utils = new Util();

        public LoginABM(int tiempoBloqueo, int contIntentosFallidos)
        {
            InitializeComponent();
            this.contIntentosFallidos = contIntentosFallidos;
            this.tiempoBloqueo = tiempoBloqueo;
        
        }

        private void LoginABM_Load(object sender, EventArgs e)
        {

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
           utils.getInstance().ClearTextBoxes(this.Controls);
        }


        private void buttonIngesar_Click(object sender, EventArgs e)
        {

            List<String> values = new List<String>() { "@userName", "@bloqueado", "@fechaBloqueo" };
            if (new Util().getInstance().isAnyEmpty(this.Controls))
            {
                MessageBox.Show("No pueden haber campos sin completar");
            }
            else
            {

                Object usr = new Conexion().executeScalarFunction("existeUsuario", this.textBoxUser.Text);
                Object loginValido = new Conexion().executeScalarFunction("validateLogin",textBoxUser.Text,textBoxPassword.Text);
                Object bloqueado = new Conexion().executeScalarFunction("userIsBlocked",textBoxUser.Text);
                DateTime datetime = DateTime.Now;
                long unixDateTime = Util.ConvertToUnixTime(datetime);
                Object auxTime = new Conexion().executeScalarFunction("obtenerFecha",this.textBoxUser.Text,this.tiempoBloqueo);
                Int32 unixDateUser = Convert.ToInt32(auxTime);
                if (Convert.ToInt32(bloqueado) == 1 && unixDateTime < unixDateUser)
                    {
                     
                        new Util().ClearTextBoxes(this.Controls);
                        MessageBox.Show("Usuario bloqueado,vuelva a intentar mas tarde");
                       
                    }
                    else if ((Convert.ToInt32(loginValido) == 0) && (Convert.ToInt32(bloqueado) == 0))
                {
                 
                        MessageBox.Show("Login satisfactiorio");
                        
                   
                    
                }

                else if ((Convert.ToInt32(bloqueado) == 1) && (unixDateTime >= unixDateUser))
                {
                
                 new Conexion().executeProcedure("updateBloqueadoUser", values, this.textBoxUser.Text, "0","NULL");
                 MessageBox.Show("Usuario: " + textBoxUser.Text + " desbloqueado");
                    if (Convert.ToInt32(loginValido) == 0 && Convert.ToInt32(bloqueado) == 0)
                {
                 
                        MessageBox.Show("Login satisfactiorio");
                        
                   
                    
                }
                }
                else
                {
                    contIntentosFallidos = contIntentosFallidos - 1;
                    MessageBox.Show("Login incorrecto, le quedan: " + contIntentosFallidos + " intentos");

                    if (contIntentosFallidos == 0)
                    {
                        MessageBox.Show("Ha agotado el maximo de intentos permitidos, se le bloqueara el usuario por " + this.tiempoBloqueo + " minutos");
                        String localDate = Convert.ToString(DateTime.Now);
                        new Conexion().executeProcedure("updateBloqueadoUser", values, textBoxUser.Text, "1", localDate);
                        new Util().ClearTextBoxes(this.Controls);
                        contIntentosFallidos = 3;
                    }
                }
            }
        }

             private void buttonSalir_Click(object sender, EventArgs e)
             {
                 this.Close();
             }

            
            
        
    }

 }

