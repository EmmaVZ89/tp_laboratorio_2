using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ContactoDao
    {
        static string cadenaConexion;
        static SqlCommand comando;
        static SqlConnection conexion;

        /// <summary>
        /// Constructor de ContactoDao
        /// </summary>
        static ContactoDao()
        {
            ContactoDao.cadenaConexion = @"Data Source=.;Initial Catalog=agenda_db;Integrated Security=True";
            ContactoDao.comando = new SqlCommand();
            ContactoDao.conexion = new SqlConnection(ContactoDao.cadenaConexion);
            ContactoDao.comando.Connection = ContactoDao.conexion;
            ContactoDao.comando.CommandType = System.Data.CommandType.Text;
        }

        /// <summary>
        /// Lee todos los datos de una tabla en una base de datos y los guarda en una Agenda
        /// </summary>
        /// <returns>retorna una agenda con los contactos cargados</returns>
        public static AgendaSaludable<Contacto> Leer()
        {
            AgendaSaludable<Contacto> agendaContactos = null;

            try
            {
                ContactoDao.conexion.Open();
                ContactoDao.comando.CommandText = "SELECT nombre, edad, sexo, telefono, peso, altura, imc, composicion_corporal, grado_obesidad FROM CONTACTOS ORDER BY nombre";
                SqlDataReader dataReader = ContactoDao.comando.ExecuteReader();
                agendaContactos = new AgendaSaludable<Contacto>();

                while (dataReader.Read())
                {
                    agendaContactos += (new Contacto(dataReader["nombre"].ToString(),
                                                    Convert.ToInt32(dataReader["edad"]),
                                                    dataReader["sexo"].ToString(),
                                                    Convert.ToInt32(dataReader["telefono"]),
                                                    Convert.ToDouble(dataReader["peso"]),
                                                    Convert.ToDouble(dataReader["altura"])
                                                    ));
                }
                dataReader.Close();
            }
            catch (Exception)
            {
                //throw ex;
            }
            finally
            {
                ContactoDao.conexion.Close();
            }

            return agendaContactos;
        }
        
        /// <summary>
        /// Guarda un nuevo contacto en la base de datos
        /// </summary>
        /// <param name="contacto">contacto a guardar</param>
        public static void Guardar(Contacto contacto)
        {
            try
            {
                ContactoDao.comando.Parameters.Clear();
                ContactoDao.conexion.Open();
                ContactoDao.comando.CommandText = "INSERT INTO CONTACTOS (nombre, edad, sexo, telefono, peso, altura, imc, composicion_corporal, grado_obesidad) " +
                                                  "VALUES (@nombre, @edad, @sexo, @telefono, @peso, @altura, @imc, @composicion_corporal, @grado_obesidad)";
                ContactoDao.comando.Parameters.AddWithValue("@nombre", contacto.Nombre); // parametrizacion para evitar la inyeccion SQL
                ContactoDao.comando.Parameters.AddWithValue("@edad", contacto.Edad);
                ContactoDao.comando.Parameters.AddWithValue("@sexo", contacto.Sexo);
                ContactoDao.comando.Parameters.AddWithValue("@telefono", contacto.Telefono);
                ContactoDao.comando.Parameters.AddWithValue("@peso", contacto.Peso);
                ContactoDao.comando.Parameters.AddWithValue("@altura", contacto.Altura);
                ContactoDao.comando.Parameters.AddWithValue("@imc", contacto.Imc);
                ContactoDao.comando.Parameters.AddWithValue("@composicion_corporal", contacto.ComposicionCorporal.ToString());
                ContactoDao.comando.Parameters.AddWithValue("@grado_obesidad", contacto.GradoObesidad.ToString());

                ContactoDao.comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ContactoDao.conexion.Close();
            }

        }

        /// <summary>
        /// Elimina un contacto de una base de datos en base a su numero de telefono
        /// </summary>
        /// <param name="telefono">telefono del contacto a eliminar</param>
        public static void Eliminar(int telefono)
        {
            try
            {
                ContactoDao.conexion.Open();
                ContactoDao.comando.CommandText = $"DELETE FROM CONTACTOS WHERE telefono = {telefono}";
                ContactoDao.comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ContactoDao.conexion.Close();
            }
        }

        /// <summary>
        /// Modifica los datos de un contacto en la base de datos
        /// </summary>
        /// <param name="contacto">contacto a modificar</param>
        public static void Modificar(Contacto contacto)
        {
            try
            {
                ContactoDao.comando.Parameters.Clear();
                ContactoDao.conexion.Open();
                ContactoDao.comando.CommandText = "UPDATE CONTACTOS SET nombre = @nombre, edad = @edad, sexo = @sexo, telefono = @telefono, peso = @peso, "+
                    $"altura = @altura, imc = @imc, composicion_corporal = @composicion_corporal, grado_obesidad = @grado_obesidad WHERE telefono = {contacto.Telefono}";
                ContactoDao.comando.Parameters.AddWithValue("@nombre", contacto.Nombre);
                ContactoDao.comando.Parameters.AddWithValue("@edad", contacto.Edad);
                ContactoDao.comando.Parameters.AddWithValue("@sexo", contacto.Sexo);
                ContactoDao.comando.Parameters.AddWithValue("@telefono", contacto.Telefono);
                ContactoDao.comando.Parameters.AddWithValue("@peso", contacto.Peso);
                ContactoDao.comando.Parameters.AddWithValue("@altura", contacto.Altura);
                ContactoDao.comando.Parameters.AddWithValue("@imc", contacto.Imc);
                ContactoDao.comando.Parameters.AddWithValue("@composicion_corporal", contacto.ComposicionCorporal.ToString());
                ContactoDao.comando.Parameters.AddWithValue("@grado_obesidad", contacto.GradoObesidad.ToString());

                ContactoDao.comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ContactoDao.conexion.Close();
            }


        }
    }
}
