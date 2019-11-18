﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaOfertas
{
    public partial class Perfil : Form
    {
        private static string usuario;

        public Perfil(string user)
        {
            InitializeComponent();
            usuario = user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().Show();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (rol.Text)
            {
                case "Cliente":
                    guardarDatosCliente();
                    break;
                case "Proveedor":
                    guardarDatosProveedor();
                    break;
                case "Administrador":
                    guardarDatosAdmin();
                    break;
                default: break;
            }
        }

        private void Perfil_Load(object sender, EventArgs e)
        {
            username.Text = usuario;
            rol.Text = new ConexionBD.Conexion().executeScalarFunction("obtenerRolUsuario", usuario).ToString();
            if (rol.Text == "Cliente")
                actualizarDatosCliente();
            if (rol.Text == "Proveedor")
                actualizarDatosProveedor();
            if (rol.Text == "Administrador")
                actualizarDatosAdministrador();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void actualizarDatosCliente()
        {
            panelCliente.Visible = true;
            string Dir_Aux = new ConexionBD.Conexion().selectReturnOnlyObject(
                "select cliente_direccion from " + Properties.Settings.Default.Schema + ".Cliente c inner join " +
                Properties.Settings.Default.Schema + ".Usuario u on c.usuario_id = u.usuario_id where u.usuario_nombre = '" + usuario + "'"
                ).ToString();
            Tuple<string, string> calleNumTuple = obtenerDireccion(Dir_Aux);
            dir_calle.Text = calleNumTuple.Item1;
            dir_numero.Text = calleNumTuple.Item2;
            dir_depto.Text = new ConexionBD.Conexion().selectReturnOnlyObject(
                "select cliente_direccion_depto from " + Properties.Settings.Default.Schema + ".Cliente c inner join " +
                Properties.Settings.Default.Schema + ".Usuario u on c.usuario_id = u.usuario_id where u.usuario_nombre = '" + usuario + "'"
                ).ToString();
            dir_localidad.Text = new ConexionBD.Conexion().selectReturnOnlyObject(
                "select cliente_direccion_localidad from " + Properties.Settings.Default.Schema + ".Cliente c inner join " +
                Properties.Settings.Default.Schema + ".Usuario u on c.usuario_id = u.usuario_id where u.usuario_nombre = '" + usuario + "'"
                ).ToString();
            dir_piso.Text = new ConexionBD.Conexion().selectReturnOnlyObject(
                "select cliente_direccion_piso from " + Properties.Settings.Default.Schema + ".Cliente c inner join " +
                Properties.Settings.Default.Schema + ".Usuario u on c.usuario_id = u.usuario_id where u.usuario_nombre = '" + usuario + "'"
                ).ToString();
            cli_nombre.Text = new ConexionBD.Conexion().selectReturnOnlyObject(
                "select cliente_nombre from " + Properties.Settings.Default.Schema + ".Cliente c inner join " +
                Properties.Settings.Default.Schema + ".Usuario u on c.usuario_id = u.usuario_id where u.usuario_nombre = '" + usuario + "'"
                ).ToString();
            cli_apellido.Text = new ConexionBD.Conexion().selectReturnOnlyObject(
                "select cliente_apellido from " + Properties.Settings.Default.Schema + ".Cliente c inner join " +
                Properties.Settings.Default.Schema + ".Usuario u on c.usuario_id = u.usuario_id where u.usuario_nombre = '" + usuario + "'"
                ).ToString();
            cli_mail.Text = new ConexionBD.Conexion().selectReturnOnlyObject(
                "select cliente_email from " + Properties.Settings.Default.Schema + ".Cliente c inner join " +
                Properties.Settings.Default.Schema + ".Usuario u on c.usuario_id = u.usuario_id where u.usuario_nombre = '" + usuario + "'"
                ).ToString();
            cli_dni.Text = new ConexionBD.Conexion().selectReturnOnlyObject(
                "select cliente_numero_dni from " + Properties.Settings.Default.Schema + ".Cliente c inner join " +
                Properties.Settings.Default.Schema + ".Usuario u on c.usuario_id = u.usuario_id where u.usuario_nombre = '" + usuario + "'"
                ).ToString();
            cli_telefono.Text = new ConexionBD.Conexion().selectReturnOnlyObject(
                "select cliente_telefono from " + Properties.Settings.Default.Schema + ".Cliente c inner join " +
                Properties.Settings.Default.Schema + ".Usuario u on c.usuario_id = u.usuario_id where u.usuario_nombre = '" + usuario + "'"
                ).ToString();
            cli_cp.Text = new ConexionBD.Conexion().selectReturnOnlyObject(
                "select cliente_codigo_postal from " + Properties.Settings.Default.Schema + ".Cliente c inner join " +
                Properties.Settings.Default.Schema + ".Usuario u on c.usuario_id = u.usuario_id where u.usuario_nombre = '" + usuario + "'"
                ).ToString();
            cli_fechaNacimiento.Value = (DateTime)new ConexionBD.Conexion().selectReturnOnlyObject(
                "select cliente_fecha_nacimiento from " + Properties.Settings.Default.Schema + ".Cliente c inner join " +
                Properties.Settings.Default.Schema + ".Usuario u on c.usuario_id = u.usuario_id where u.usuario_nombre = '" + usuario + "'"
                );
            cli_ciudad.Text = new ConexionBD.Conexion().selectReturnOnlyObject(
                "select cliente_ciudad from " + Properties.Settings.Default.Schema + ".Cliente c inner join " +
                Properties.Settings.Default.Schema + ".Usuario u on c.usuario_id = u.usuario_id where u.usuario_nombre = '" + usuario + "'"
                ).ToString();
        }

        private void actualizarDatosProveedor()
        {
            panelProveedor.Visible = true;
            string Dir_Aux = new ConexionBD.Conexion().selectReturnOnlyObject(
                "select proveedor_direccion from " + Properties.Settings.Default.Schema + ".Proveedor c inner join " +
                Properties.Settings.Default.Schema + ".Usuario u on c.usuario_id = u.usuario_id where u.usuario_nombre = '" + usuario + "'"
                ).ToString();
            Tuple<string, string> calleNumTuple = obtenerDireccion(Dir_Aux);
            dir_calle.Text = calleNumTuple.Item1;
            dir_numero.Text = calleNumTuple.Item2;
            dir_depto.Text = new ConexionBD.Conexion().selectReturnOnlyObject(
                "select proveedor_direccion_depto from " + Properties.Settings.Default.Schema + ".Proveedor c inner join " +
                Properties.Settings.Default.Schema + ".Usuario u on c.usuario_id = u.usuario_id where u.usuario_nombre = '" + usuario + "'"
                ).ToString();
            dir_localidad.Text = new ConexionBD.Conexion().selectReturnOnlyObject(
                "select proveedor_direccion_localidad from " + Properties.Settings.Default.Schema + ".Proveedor c inner join " +
                Properties.Settings.Default.Schema + ".Usuario u on c.usuario_id = u.usuario_id where u.usuario_nombre = '" + usuario + "'"
                ).ToString();
            dir_piso.Text = new ConexionBD.Conexion().selectReturnOnlyObject(
                "select proveedor_direccion_piso from " + Properties.Settings.Default.Schema + ".Proveedor c inner join " +
                Properties.Settings.Default.Schema + ".Usuario u on c.usuario_id = u.usuario_id where u.usuario_nombre = '" + usuario + "'"
                ).ToString();
            prov_razonSocial.Text = new ConexionBD.Conexion().selectReturnOnlyObject(
                "select proveedor_razon_social from " + Properties.Settings.Default.Schema + ".Proveedor c inner join " +
                Properties.Settings.Default.Schema + ".Usuario u on c.usuario_id = u.usuario_id where u.usuario_nombre = '" + usuario + "'"
                ).ToString();
            prov_mail.Text = new ConexionBD.Conexion().selectReturnOnlyObject(
                "select proveedor_email from " + Properties.Settings.Default.Schema + ".Proveedor c inner join " +
                Properties.Settings.Default.Schema + ".Usuario u on c.usuario_id = u.usuario_id where u.usuario_nombre = '" + usuario + "'"
                ).ToString();
            prov_telefono.Text = new ConexionBD.Conexion().selectReturnOnlyObject(
                "select proveedor_telefono from " + Properties.Settings.Default.Schema + ".Proveedor c inner join " +
                Properties.Settings.Default.Schema + ".Usuario u on c.usuario_id = u.usuario_id where u.usuario_nombre = '" + usuario + "'"
                ).ToString();
            prov_cp.Text = new ConexionBD.Conexion().selectReturnOnlyObject(
                "select proveedor_codigo_postal from " + Properties.Settings.Default.Schema + ".Proveedor c inner join " +
                Properties.Settings.Default.Schema + ".Usuario u on c.usuario_id = u.usuario_id where u.usuario_nombre = '" + usuario + "'"
                ).ToString();
            prov_cuit.Text = new ConexionBD.Conexion().selectReturnOnlyObject(
                "select proveedor_cuit from " + Properties.Settings.Default.Schema + ".Proveedor c inner join " +
                Properties.Settings.Default.Schema + ".Usuario u on c.usuario_id = u.usuario_id where u.usuario_nombre = '" + usuario + "'"
                ).ToString();
            prov_rubro.Text = new ConexionBD.Conexion().selectReturnOnlyObject(
                "select proveedor_rubro from " + Properties.Settings.Default.Schema + ".Proveedor c inner join " +
                Properties.Settings.Default.Schema + ".Usuario u on c.usuario_id = u.usuario_id where u.usuario_nombre = '" + usuario + "'"
                ).ToString();
            prov_contacto.Text = new ConexionBD.Conexion().selectReturnOnlyObject(
                "select proveedor_contacto from " + Properties.Settings.Default.Schema + ".Proveedor c inner join " +
                Properties.Settings.Default.Schema + ".Usuario u on c.usuario_id = u.usuario_id where u.usuario_nombre = '" + usuario + "'"
                ).ToString();
            prov_ciudad.Text = new ConexionBD.Conexion().selectReturnOnlyObject(
                "select proveedor_ciudad from " + Properties.Settings.Default.Schema + ".Proveedor c inner join " +
                Properties.Settings.Default.Schema + ".Usuario u on c.usuario_id = u.usuario_id where u.usuario_nombre = '" + usuario + "'"
                ).ToString();
        }

        private void actualizarDatosAdministrador()
        {
            panelDireccion.Visible = false;
        }

        private Tuple<string, string> obtenerDireccion(string calleMasNumero)
        {
            string[] dir = calleMasNumero.Split(' ');
            string calle = "";
            string numero = "";

            for (int i = 0; i < dir.Length - 1; i++)
            {
                calle += dir[i] + " ";
            }
            calle = calle.TrimEnd(' ');
            numero = dir.Last();

            return Tuple.Create<string, string>(calle, numero);
        }

        private void guardarDatosCliente()
        {
            if (passwordNueva1.Text != passwordNueva2.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden");
                return;
            }
            float rAux;
            if ((cli_dni.Text != "" && !float.TryParse(cli_dni.Text, out rAux)) || (cli_telefono.Text != "" && !float.TryParse(cli_telefono.Text, out rAux)) ||
                (cli_cp.Text != "" && !float.TryParse(cli_cp.Text, out rAux)) || (dir_numero.Text != "" && !float.TryParse(dir_numero.Text, out rAux)) ||
                (dir_piso.Text != "" && !float.TryParse(dir_piso.Text, out rAux)))
            {
                MessageBox.Show("Campos numéricos deben tener sólo números");
                return;
            }

            int cantVector = 2;
            if (passwordNueva1.Text != "" && passwordNueva2.Text != "")
                cantVector = 3;
            Tuple<string, List<string>, Object[]>[] procs = new Tuple<string, List<string>, object[]>[cantVector];
            Object id_cliente = new ConexionBD.Conexion().executeScalarFunction("obtenerIdCliente", usuario);

            procs[0] = Tuple.Create<string, List<string>, Object[]>(
                    Properties.Settings.Default.Schema + ".actualizarDatosCliente",
                    new List<string>() {
                        "@nombre", "@apellido", "@mail", "@dni" , "@telefono" , "@codigoPostal",
                        "@fechaNacimiento", "@direccion", "@direccion_piso", "@direccion_depto", 
                        "@direccion_localidad", "@id_cliente"
                    },
                    new string[]{
                        cli_nombre.Text, cli_apellido.Text, cli_mail.Text,
                        cli_dni.Text, cli_telefono.Text, cli_cp.Text, cli_fechaNacimiento.Value.ToShortDateString(),
                        dir_calle.Text + " " + dir_numero.Text, dir_piso.Text, dir_depto.Text, dir_localidad.Text,
                        id_cliente.ToString()
                    }
            );

            if (passwordNueva1.Text != "" && passwordNueva2.Text != "")
            {
                procs[1] = Tuple.Create<string, List<string>, Object[]>(
                    Properties.Settings.Default.Schema + ".cambiarContraseniaCliente",
                    new List<string>() {
                            "@id_cliente" , "@password"
                        },
                    new string[]{
                            id_cliente.ToString(), passwordNueva1.Text
                        }
                );

                procs[2] = Tuple.Create<string, List<string>, Object[]>(
                    Properties.Settings.Default.Schema + ".cambiarNombreUsuario",
                    new List<string>() {
                            "@nombreActual", "@nombreNuevo"
                        },
                    new string[]{
                            usuario, username.Text
                        }
                );
            }
            else
            {
                procs[1] = Tuple.Create<string, List<string>, Object[]>(
                    Properties.Settings.Default.Schema + ".cambiarNombreUsuario",
                    new List<string>() {
                            "@nombreActual", "@nombreNuevo"
                        },
                    new string[]{
                            usuario, username.Text
                        }
                );
            }

            try
            {
                new ConexionBD.Conexion().executeStoredTransaction(procs);
                MessageBox.Show("Datos actualizados correctamente");
                Logeo.username = username.Text;
                this.Hide();
                new Perfil(username.Text).Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al actualizar los datos");
            }
        }

        private void guardarDatosProveedor()
        {

        }

        private void guardarDatosAdmin()
        {

        }
    }
}
