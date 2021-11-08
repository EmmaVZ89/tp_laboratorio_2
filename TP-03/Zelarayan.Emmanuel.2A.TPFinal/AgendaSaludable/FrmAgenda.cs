using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace AgendaSaludable
{
    public partial class FrmAgenda : Form
    {
        AgendaSaludable<Contacto> contactosAgenda;
        public FrmAgenda()
        {
            InitializeComponent();
            this.contactosAgenda = new AgendaSaludable<Contacto>();
        }

        private void btnAgregarContacto_Click(object sender, EventArgs e)
        {
            FrmAltaModificacion altaContacto = new FrmAltaModificacion();

            DialogResult dialogResult = altaContacto.ShowDialog();

            if(dialogResult == DialogResult.OK)
            {
                if(this.contactosAgenda != altaContacto.NuevoContacto)
                {
                    this.contactosAgenda += altaContacto.NuevoContacto;
                    this.lstContactos.Items.Add(altaContacto.NuevoContacto);
                }
                else
                {
                    MessageBox.Show("El contacto ya existe.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int indiceContacto = this.lstContactos.SelectedIndex;

            if(indiceContacto != -1)
            {
                Contacto contactoAModificar = this.contactosAgenda.ListaPersonas[indiceContacto];

                FrmAltaModificacion contactoModificacion = new FrmAltaModificacion(contactoAModificar);

                if (contactoModificacion.ShowDialog() == DialogResult.OK)
                {
                    this.ActualizarListBox();
                    MessageBox.Show("Contacto Modificado");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int indiceContactoSeleccionado = this.ObtenerIndiceContactoSeleccionado();

            if (this.lstContactos.SelectedItem is not null)
            {
                this.contactosAgenda.ListaPersonas.RemoveAt(indiceContactoSeleccionado);
                //GuardarDatos();
                this.ActualizarListBox();
            }
        }


        private int ObtenerIndiceContactoSeleccionado()
        {
            int indiceContactoSeleccionado = this.lstContactos.SelectedIndex;
            if (indiceContactoSeleccionado == -1)
            {
                MessageBox.Show("Debe seleccionar un contacto de la lista.", "Validacion",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return indiceContactoSeleccionado;
        }

        private void ActualizarListBox()
        {
            this.lstContactos.DataSource = null;
            this.lstContactos.DataSource = this.contactosAgenda.ListaPersonas;
        }

    }
}
