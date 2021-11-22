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
                    this.rtbEstadisticas.Text = this.CalcularMujeresBajoPeso(this.agenda);
                    break;
                case 1:
                    this.rtbEstadisticas.Text = this.CalcularPromedioImc(this.agenda);
                    break;
                case 2:
                    this.rtbEstadisticas.Text = this.CalcularMujeresObesidadGrado3(this.agenda);
                    break;
                case 3:
                    this.rtbEstadisticas.Text = this.CalcularHombresObesidadGrado1(this.agenda);
                    break;
                case 4:
                    this.rtbEstadisticas.Text = this.CalcularPersonasConPesoNormal(this.agenda);
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
        /// Analiza una Agenda para buscar a las mujeres con bajo peso
        /// </summary>
        /// <param name="agendaContacto">agenda a analizar</param>
        /// <returns>retorna los datos de las mujeres con bajo peso</returns>
        private string CalcularMujeresBajoPeso(AgendaSaludable<Contacto> agendaContacto)
        {
            StringBuilder sb = new StringBuilder();
            string auxStr = "";
            int cantidadBajoPeso = 0;
            int totalMujeres = 0;
            double porcentaje = 0;

            foreach (Contacto contacto in agendaContacto.ListaPersonas)
            {
                if(contacto.Sexo == "Mujer")
                {
                    totalMujeres++;
                    if(contacto.ComposicionCorporal == EComposicionCorporal.Bajo_peso)
                    {
                        cantidadBajoPeso++;
                        auxStr += contacto.ToString() + "\n";
                    }
                }
            }

            if(totalMujeres > 0)
            {
                porcentaje = Math.Round((double)cantidadBajoPeso / totalMujeres * 100, 2);
            }
            
            sb.AppendLine("*** MUJERES CON BAJO PESO ***\n");
            sb.AppendLine($"Cantidad: {cantidadBajoPeso}  (sobre un total de {totalMujeres} mujeres)");
            sb.AppendLine($"Porcentaje: {porcentaje} %\n");
            sb.AppendLine("Listado:");
            sb.AppendLine(auxStr);

            return sb.ToString();
        }

        /// <summary>
        /// Analiza una Agenda para calcular el promedio de IMC, discriminando entre hombre y mujeres,
        /// luego define quien tiene el mayor promedio
        /// </summary>
        /// <param name="agendaContacto">agenda a analizar</param>
        /// <returns>retorna los promedios calculados</returns>
        private string CalcularPromedioImc(AgendaSaludable<Contacto> agendaContacto)
        {
            StringBuilder sb = new StringBuilder();
            double totalImcHombres = 0;
            double totalImcMujeres = 0;
            double promedioImcHombres = 0;
            double promedioImcMujeres = 0;
            int cantidadHombres = 0;
            int cantidadMujeres = 0;

            foreach (Contacto contacto in agendaContacto.ListaPersonas)
            {
                if (contacto.Sexo == "Mujer")
                {
                    cantidadMujeres++;
                    totalImcMujeres += contacto.Imc;
                }
                else
                {
                    cantidadHombres++;
                    totalImcHombres += contacto.Imc;
                }
            }

            if(cantidadHombres > 0)
            {
                promedioImcHombres = Math.Round(totalImcHombres / cantidadHombres, 2);
            }

            if(cantidadMujeres > 0)
            {
                promedioImcMujeres = Math.Round(totalImcMujeres / cantidadMujeres, 2);
            }

            sb.AppendLine("*** PROMEDIO DE IMC ***\n");
            sb.AppendLine($"Cantidad de personas: {agendaContacto.ListaPersonas.Count}");
            sb.AppendLine($"Promedio de IMC en hombres: {promedioImcHombres}, sobre una cantidad de {cantidadHombres} hombres.");
            sb.AppendLine($"Promedio de IMC en Mujeres: {promedioImcMujeres}, sobre una cantidad de {cantidadMujeres} mujeres.\n");
            
            if(promedioImcHombres > promedioImcMujeres)
            {
                sb.AppendLine($"     *****   Los hombres poseen mayor promedio de IMC ({promedioImcHombres})   *****");
            }
            else if(promedioImcMujeres > promedioImcHombres)
            {
                sb.AppendLine($"     *****   Las mujeres poseen mayor promedio de IMC ({promedioImcMujeres})   *****");
            }
            else
            {
                sb.AppendLine($"     *****   Hombres y mujeres poseen el mismo promedio de IMC ({promedioImcHombres})   *****");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Analiza una Agenda para encontrar a aquellas mujeres mayores de 30 años y que posean un
        /// grado de obesidad nivel 3.
        /// </summary>
        /// <param name="agendaContacto">agenda a analizar</param>
        /// <returns>retorna todos los datos de las mujeres que cumplen con la condicion</returns>
        private string CalcularMujeresObesidadGrado3(AgendaSaludable<Contacto> agendaContacto)
        {
            StringBuilder sb = new StringBuilder();
            string auxStr = "";
            int cantidad = 0;
            int totalMujeres = 0;
            double porcentaje = 0;

            foreach (Contacto contacto in agendaContacto.ListaPersonas)
            {
                if (contacto.Sexo == "Mujer")
                {
                    totalMujeres++;
                    if (contacto.Edad > 30 && contacto.GradoObesidad == EGradoObesidad.Grado_3)
                    {
                        cantidad++;
                        auxStr += contacto.ToString() + "\n";
                    }
                }
            }

            if(totalMujeres > 0)
            {
                porcentaje = Math.Round((double)cantidad / totalMujeres * 100, 2);
            }
            
            sb.AppendLine("*** MUJERES CON MAS DE 30 AÑOS Y OBESIDAD GRADO 3 ***\n");
            sb.AppendLine($"Cantidad: {cantidad}  (sobre un total de {totalMujeres} mujeres)");
            sb.AppendLine($"Porcentaje: {porcentaje} %\n");
            sb.AppendLine("Listado:");
            sb.AppendLine(auxStr);

            return sb.ToString();

        }

        /// <summary>
        /// Analiza una Agenda para encontrar a aquellos hombre menores de 30 años y que posean un 
        /// grado de obesidad nivel 1.
        /// </summary>
        /// <param name="agendaContacto"> agenda a analizar</param>
        /// <returns>retorna todos los datos de los hombres que cumplen con la condicion</returns>
        private string CalcularHombresObesidadGrado1(AgendaSaludable<Contacto> agendaContacto)
        {
            StringBuilder sb = new StringBuilder();
            string auxStr = "";
            int cantidad = 0;
            int totalhombres = 0;
            double porcentaje = 0;

            foreach (Contacto contacto in agendaContacto.ListaPersonas)
            {
                if (contacto.Sexo == "Hombre")
                {
                    totalhombres++;
                    if (contacto.Edad < 30 && contacto.GradoObesidad == EGradoObesidad.Grado_1)
                    {
                        cantidad++;
                        auxStr += contacto.ToString() + "\n";
                    }
                }
            }

            if(totalhombres > 0)
            {
                porcentaje = Math.Round((double)cantidad / totalhombres * 100, 2);
            }
            
            sb.AppendLine("*** HOMBRES CON MENOS DE 30 AÑOS Y OBESIDAD GRADO 1 ***\n");
            sb.AppendLine($"Cantidad: {cantidad}  (sobre un total de {totalhombres} hombres)");
            sb.AppendLine($"Porcentaje: {porcentaje} %\n");
            sb.AppendLine("Listado:");
            sb.AppendLine(auxStr);

            return sb.ToString();
        }

        /// <summary>
        /// Analiza una Agenda para encontrar a aquellas personas que presentan un peso normal
        /// </summary>
        /// <param name="agendaContacto">agenda a analizar</param>
        /// <returns>retorna todos los datos de las personas que cumplen con la condicion</returns>
        private string CalcularPersonasConPesoNormal(AgendaSaludable<Contacto> agendaContacto)
        {
            StringBuilder sb = new StringBuilder();
            string auxStr = "";
            int cantidad = 0;
            int totalPersonas = agendaContacto.ListaPersonas.Count;
            double porcentaje = 0;

            foreach (Contacto contacto in agendaContacto.ListaPersonas)
            {
                if (contacto.ComposicionCorporal == EComposicionCorporal.Normal)
                {
                    cantidad++;
                    auxStr += contacto.ToString() + "\n";
                }
            }

            if (totalPersonas > 0)
            {
                porcentaje = Math.Round((double)cantidad / totalPersonas * 100, 2);
            }

            sb.AppendLine("*** PERSONAS CON PESO NORMAL ***\n");
            sb.AppendLine($"Cantidad: {cantidad}  (sobre un total de {totalPersonas} personas)");
            sb.AppendLine($"Porcentaje: {porcentaje} %\n");
            sb.AppendLine("Listado:");
            sb.AppendLine(auxStr);

            return sb.ToString();
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
