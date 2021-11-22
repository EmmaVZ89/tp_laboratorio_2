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
        ExtensionXml<AgendaSaludable<Contacto>> extensionXml;

        /// <summary>
        /// Constructor de FrmAgenda
        /// </summary>
        public FrmAgenda()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivo XML|*.xml";
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo XML|*.xml";
            this.contactosAgenda = new AgendaSaludable<Contacto>();
            this.extensionXml = new ExtensionXml<AgendaSaludable<Contacto>>();
            string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string nombreArchivo = "datosContactos.xml";
            FrmAgenda.archivo = Path.Combine(rutaEscritorio, nombreArchivo);
        }

        /// <summary>
        /// Propiedad de lectura y escritura del campo archivo
        /// </summary>
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

        /// <summary>
        /// Evento FrmAgenda_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAgenda_Load(object sender, EventArgs e)
        {
            if (File.Exists(archivo))
            {
                this.RecuperarDatos();
                this.ActualizarListBox();
            }
        }

        /// <summary>
        /// Evento btnAbrir_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Evento btnGuardar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.GuardarDatos();
        }

        /// <summary>
        /// Evento btnGuardarComo_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarComo_Click(object sender, EventArgs e)
        {
            this.GuardarDatosComo();
        }

        /// <summary>
        /// Evento btnAgregarContacto_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarContacto_Click(object sender, EventArgs e)
        {
            FrmAltaModificacion altaContacto = new FrmAltaModificacion();

            DialogResult dialogResult = altaContacto.ShowDialog();

            if(dialogResult == DialogResult.OK)
            {
                if(this.contactosAgenda != altaContacto.NuevoContacto)
                {
                    this.lstContactos.DataSource = null;
                    this.contactosAgenda += altaContacto.NuevoContacto;
                    this.lstContactos.Items.Add(altaContacto.NuevoContacto);
                    this.ActualizarListBox();
                }
                else
                {
                    MessageBox.Show("El contacto ya existe.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Evento btnModificar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Evento btnEliminar_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Evento btnFicha_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Evento btnEstadisticas_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            FrmEstadisticas estadisticas = new FrmEstadisticas(this.contactosAgenda);

            estadisticas.ShowDialog();

        }

        /// <summary>
        /// Obtiene el indice seleccionado en un listbox
        /// </summary>
        /// <returns>retorna el indice seleccionado, si no hay nada seleccionado retorna -1</returns>
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

        /// <summary>
        /// Actualiza el DataSource de un listbox
        /// </summary>
        private void ActualizarListBox()
        {
            this.lstContactos.DataSource = null;
            this.lstContactos.DataSource = this.contactosAgenda.ListaPersonas;
        }

        /// <summary>
        /// Lee los datos de un archivo y los carga en una Agenda
        /// </summary>
        private void RecuperarDatos()
        {
            using (StreamReader streamReader = new StreamReader(FrmAgenda.archivo))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(this.contactosAgenda.GetType());
                this.contactosAgenda = (AgendaSaludable<Contacto>) xmlSerializer.Deserialize(streamReader);
            }
        }

        /// <summary>
        /// Guarda los datos de un listbox en un archivo xml predefinido
        /// </summary>
        private void GuardarDatos()
        {
            try
            {
                switch (Path.GetExtension(archivo))
                {
                    case ".xml":
                        extensionXml.GuardarArchivo(archivo, this.contactosAgenda);
                        break;
                }
            }
            catch (Exception ex)
            {
                this.MostrarError(ex);
            }
        }

        /// <summary>
        /// Guarda los datos de un listbox en un archivo xml a eleccion.
        /// </summary>
        private void GuardarDatosComo()
        {
            Archivo = SeleccionarUbicacionGuardado();

            try
            {
                switch (Path.GetExtension(Archivo))
                {
                    case ".xml":
                        extensionXml.GuardarArchivoComo(Archivo, this.contactosAgenda);
                        break;
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        /// <summary>
        /// Selecciona la ubicacion donde se va a guardar un archivo
        /// </summary>
        /// <returns>retorna la ubicacion</returns>
        private string SeleccionarUbicacionGuardado()
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }

            return string.Empty;
        }

        /// <summary>
        /// Muestra un mensaje de error
        /// </summary>
        /// <param name="ex"></param>
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
