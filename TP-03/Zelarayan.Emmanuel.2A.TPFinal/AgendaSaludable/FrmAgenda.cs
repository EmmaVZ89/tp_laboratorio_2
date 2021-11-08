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
using AgendaVista;
using System.IO;
using System.Xml.Serialization;

namespace AgendaSaludable
{
    public partial class FrmAgenda : Form
    {
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private static string archivo;
        AgendaSaludable<Contacto> contactosAgenda;

        public FrmAgenda()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivo XML|*.xml";
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo XML|*.xml";
            this.contactosAgenda = new AgendaSaludable<Contacto>();
            string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string nombreArchivo = "datosContactos.xml";
            FrmAgenda.archivo = Path.Combine(rutaEscritorio, nombreArchivo);
        }

        private string Archivo
        {
            get
            {
                return FrmAgenda.archivo;
            }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    FrmAgenda.archivo = value;
                }
            }
        }
        private void FrmAgenda_Load(object sender, EventArgs e)
        {
            if (File.Exists(archivo))
            {
                this.RecuperarDatos();
                this.ActualizarListBox();
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FrmAgenda.archivo = openFileDialog.FileName;

                try
                {
                    switch (Path.GetExtension(FrmAgenda.archivo))
                    {
                        case ".xml":
                            this.RecuperarDatos();
                            this.ActualizarListBox();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MostrarError(ex);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.GuardarDatos();
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

        private void btnFicha_Click(object sender, EventArgs e)
        {
            int indiceContacto = this.lstContactos.SelectedIndex;

            if (indiceContacto != -1)
            {
                Contacto contactoFicha = this.contactosAgenda.ListaPersonas[indiceContacto];

                FrmFicha contactoAMostrar = new FrmFicha(contactoFicha);

                if (contactoAMostrar.ShowDialog() == DialogResult.OK)
                {
                    this.ActualizarListBox();
                    MessageBox.Show("Contacto Modificado");
                }
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

        private void RecuperarDatos()
        {
            using (StreamReader streamReader = new StreamReader(FrmAgenda.archivo))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(this.contactosAgenda.GetType());
                this.contactosAgenda = xmlSerializer.Deserialize(streamReader) as AgendaSaludable<Contacto>;
            }
        }

        private void GuardarDatos()
        {
            using (StreamWriter streamWriter = new StreamWriter(FrmAgenda.archivo))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(this.contactosAgenda.GetType());
                xmlSerializer.Serialize(streamWriter, this.contactosAgenda);
            }
        }

        private void MostrarError(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Error: {ex.Message}");
            sb.AppendLine("Detalle:");
            sb.AppendLine(ex.StackTrace);
            MessageBox.Show(sb.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
