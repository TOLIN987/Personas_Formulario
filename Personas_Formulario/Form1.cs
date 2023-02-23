using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Personas_Formulario
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        private Contacto[] arreglocontactos;

        private void txtCantidadcontactos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtCantidadcontactos.Text.Contains('.'))
            {
                e.Handled = true;
            }
        }

        private void btnempezar_Click(object sender, EventArgs e)
        {
            

            if (txtCantidadcontactos.Text.Contains('.') && txtCantidadcontactos.Text.Contains(null))
            {
                MessageBox.Show("Ingrese un numero entero");
                txtCantidadcontactos.Clear();
                return;
            }
            if (!txtCantidadcontactos.Text.Contains('.'))
            {             
                
                txtCantidadcontactos.Enabled = false;
            }
            int cantidadContactos = int.Parse(txtCantidadcontactos.Text);
            arreglocontactos = new Contacto[cantidadContactos];
            txtCorreo.Visible = true;
            txtNombre.Visible = true;
            txtNumero.Visible = true;
            dtpFechanacimiento.Visible = true;
        }


        private void btmGuardar_Click(object sender, EventArgs e)
        {
            int cantidadContactos = int.Parse(txtCantidadcontactos.Text);
            bool validacion = false;
            validacion = Validar(txtCorreo.Text);

            if (validacion == false)
            {
                MessageBox.Show("Ingrese un correo valido");
                txtCorreo.Clear();
                return;
                
            }
            for (int i = 0; i < cantidadContactos; i++)
            {
                arreglocontactos[i] = new Contacto();
                
                
                
                if (validacion == true)
                {
                    arreglocontactos[i].FechaNacimiento = DateTime.Parse(dtpFechanacimiento.Text);
                    arreglocontactos[i].Nombre = txtNombre.Text;
                    arreglocontactos[i].Telefono = txtNumero.Text;
                    arreglocontactos[i].Correo = txtCorreo.Text;

                    dtpFechanacimiento.Value = DateTime.Now;
                    txtNombre.Clear();
                    txtNumero.Clear();
                    txtCorreo.Clear();
                }
                
                
            }

        }
        public bool Validar(string correo)
        {
            if (string.IsNullOrEmpty(correo))
            {
                return false;
            }

            if (!correo.Contains("@"))
            {
                return false;
            }

            string[] partesCorreo = correo.Split('@');

            if (partesCorreo.Length != 2)
            {
                return false;
            }

            if (string.IsNullOrEmpty(partesCorreo[0]) || string.IsNullOrEmpty(partesCorreo[1]))
            {
                return false;
            }

            if (partesCorreo[1].IndexOf(".") == -1)
            {
                return false;
            }

            return true;

        }
    }
}
