﻿using System;
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
    public partial class Editar : Form
    {
        private Dictionary<string, string> datos;

        public Editar(Dictionary<string, string> row)
        {
            InitializeComponent();
            datos = row;
            string[] dir = row["direccion"].Split(' ');

            this.dir_calle.Text = "";
            for (int i = 0; i < dir.Length - 1; i++)
            {
                this.dir_calle.Text += dir[i] + " ";
            }
            this.dir_calle.Text = this.dir_calle.Text.TrimEnd(' ');
            this.dir_numero.Text = dir.Last();

            this.dir_piso.Text = row["direccion_piso"];
            this.dir_depto.Text = row["direccion_depto"];
            this.dir_localidad.Text = row["direccion_localidad"];
            this.nombre.Text = row["nombre"];
            this.apellido.Text = row["apellido"];
            this.mail.Text = row["mail"];
            this.dni.Text = row["dni"];
            this.telefono.Text = row["telefono"];
            this.codigoPostal.Text = row["codigoPostal"];
            this.fechaNacimiento.Text = row["fechaNacimiento"];

            Object estaHabilitado = new ConexionBD.Conexion().executeScalarFunction("clienteEstaHabilitado",
                        dni.Text, this.nombre.Text, this.apellido.Text);
            if (estaHabilitado.ToString() == "1") //Si está inhabilitado
            {
                habilitarBtn.Visible = true;
            }
            else
            {
                inhabilitarBtn.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new AbmCliente().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (passwordNueva1.Text != passwordNueva2.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden");
                return;
            }
            float rAux;
            if (!float.TryParse(dni.Text, out rAux) || !float.TryParse(telefono.Text, out rAux) ||
                !float.TryParse(codigoPostal.Text, out rAux) || !float.TryParse(dir_numero.Text, out rAux) ||
                !float.TryParse(dir_piso.Text, out rAux))
            {
                MessageBox.Show("Campos numéricos deben tener sólo números");
                return;
            }

            try
            {
                new ConexionBD.Conexion().executeQuery(String.Format(
                "update {0}.Cliente set cliente_nombre='{1}', cliente_apellido='{2}', cliente_email='{3}', " +
                "cliente_numero_dni={4}, cliente_telefono={5}, cliente_codigo_postal={6}, cliente_fecha_nacimiento='{7}', " +
                "cliente_direccion='{8}', cliente_direccion_piso={9}, cliente_direccion_depto='{10}', " +
                "cliente_direccion_localidad='{11}' where cliente_id={12}",
                Properties.Settings.Default.Schema, nombre.Text, apellido.Text, mail.Text,
                dni.Text, telefono.Text, codigoPostal.Text, fechaNacimiento.Value.ToShortDateString(),
                dir_calle.Text + " " + dir_numero.Text, dir_piso.Text, dir_depto.Text, dir_localidad.Text,
                datos["id"]));

                if (passwordNueva1.Text != "" && passwordNueva2.Text != "")
                {
                    new ConexionBD.Conexion().executeProcedure(Properties.Settings.Default.Schema + ".cambiarContraseniaCliente",
                        new List<string>() { "@id_cliente", "@password" },
                        new string[] { datos["id"], passwordNueva1.Text });
                }
                MessageBox.Show("Cliente actualizado correctamente");
                this.Hide();
                new AbmCliente().Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al actualizar los datos del cliente");
            }
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void dir_depto_TextChanged(object sender, EventArgs e)
        {

        }

        private void dir_localidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void Editar_Load(object sender, EventArgs e)
        {

        }

        private void habilitarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                new ConexionBD.Conexion().executeProcedure(Properties.Settings.Default.Schema + ".habilitarCliente",
                    new List<string>() { "@dni", "@nombre", "@apellido" },
                    new string[] { datos["dni"], datos["nombre"], datos["apellido"] });
                MessageBox.Show("Cliente habilitado correctamente");
                this.Hide();
                new Editar(datos).Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al habilitar al cliente");
            } 
        }

        private void inhabilitarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                new ConexionBD.Conexion().executeProcedure(Properties.Settings.Default.Schema + ".inhabilitarCliente",
                    new List<string>() { "@dni", "@nombre", "@apellido" },
                    new string[] { datos["dni"], datos["nombre"], datos["apellido"] });
                MessageBox.Show("Cliente inhabilitado correctamente");
                this.Hide();
                new Editar(datos).Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al inhabilitar al cliente");
            } 
        }
    }
}
