using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace AgendaVista
{
    public partial class FrmEstadisticas : Form
    {
        private AgendaSaludable<Contacto> agenda;
        private ExtensionTxt extensionTxt;
        private string archivo;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;


        /// <summary>
        /// Constructor por defecto de un FrmEstadisticas
        /// </summary>
        public FrmEstadisticas()
        {
            InitializeComponent();
            this.agenda = new AgendaSaludable<Contacto>();
            this.extensionTxt = new ExtensionTxt();
            string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string nombreArchivo = "datosAnalizados.txt";
            this.archivo = Path.Combine(rutaEscritorio, nombreArchivo);
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivo TXT|*.txt";
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo TXT|*.txt";
        }

        /// <summary>
        /// Constructor con parametros de un FrmEstadisticas
        /// </summary>
        /// <param name="agenda">agenda para asignar al campo agenda</param>
        public FrmEstadisticas(AgendaSaludable<Contacto> agenda):this()
        {
            this.agenda = agenda;
        }

        /// <summary>
        /// Evento FrmEstadisticas_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmEstadisticas_Load(object sender, EventArgs e)
        {
            this.cmbEstadisticas.Items.Add("Mujeres con bajo peso (IMC menor a 18.5).");
            this.cmbEstadisticas.Items.Add("Promedios de IMC por sexo.");
            this.cmbEstadisticas.Items.Add("Mujeres con mas de 30 años y con obesidad grado 3");
            this.cmbEstadisticas.Items.Add("Hombres con menos de 30 años y con  obesidad grado 1");
            this.cmbEstadisticas.Items.Add("Personas con un peso normal.");
            this.cmbEstadisticas.SelectedIndex = 0;
            this.rtbEstadisticas.Text = agenda.ToString();
        }

        /// <summary>
        /// Evento btnAnalizar_Click, encargado de realizar el analisis dependiendo 
        /// del indice seleccionado en el combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            switch (this.cmbEstadisticas.SelectedIndex)
            {
                case 0:
                    this.rtbEstadisticas.Text = this.agenda.CalcularMujeresBajoPeso();
                    break;
                case 1:
                    this.rtbEstadisticas.Text = this.agenda.CalcularPromedioImc();
                    break;
                case 2:
                    this.rtbEstadisticas.Text = this.agenda.CalcularMujeresObesidadGrado3();
                    break;
                case 3:
                    this.rtbEstadisticas.Text = this.agenda.CalcularHombresObesidadGrado1();
                    break;
                case 4:
                    this.rtbEstadisticas.Text = this.agenda.CalcularPersonasConPesoNormal();
                    break;
            }
        }

        /// <summary>
        /// Evento btnAbrir_Click, encargado de abrir un archivo y mostrarlo en un rich text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.archivo = openFileDialog.FileName;

                try
                {
                    switch (Path.GetExtension(this.archivo))
                    {
                        case ".txt":
                            this.rtbEstadisticas.Text = extensionTxt.LeerArchivo(this.archivo);
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
        /// Evento btnGuardarComo_Click, encargado de guardar un archivo de texto en una ubicacion a eleccion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarComo_Click(object sender, EventArgs e)
        {
            this.archivo = SeleccionarUbicacionGuardado();
            try
            {
                switch (Path.GetExtension(this.archivo))
                {
                    case ".txt":
                        extensionTxt.GuardarArchivoComo(this.archivo, this.rtbEstadisticas.Text);
                        break;
                }
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        /// <summary>
        /// Permite seleccionar la ubicacion donde se guardara un archivo
        /// </summary>
        /// <returns></returns>
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
