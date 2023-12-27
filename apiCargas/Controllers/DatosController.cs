using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using apiCargas.Querys;
using System.Data.SqlClient;
using System.Data;
using apiCargas.Models;

namespace apiCargas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosController : ControllerBase
    {

        private readonly string cadenaSQL;
        string sql1 = "Select *  from Usuarios";
        Consultas query = new Consultas();


        public DatosController(IConfiguration config)
        {

            cadenaSQL = config.GetConnectionString("SQLConnection");
        }


        [HttpPost]
        [Route("Cargar")]

        public async Task<IActionResult> InsertarObjetos([FromBody] List<DatosPersonales> objetos)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaSQL))
                {
                    await connection.OpenAsync();

                    foreach (DatosPersonales objeto in objetos)
                    {
                        using (SqlCommand command = new SqlCommand("InsertarDatosPersonales", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            // Configura los parámetros del stored procedure con los valores del objeto
                            command.Parameters.AddWithValue("@nombre", objeto.nombre);
                            command.Parameters.AddWithValue("@apellido", objeto.apellido);
                            command.Parameters.AddWithValue("@correo", objeto.Email);
                            // Agrega otros parámetros según tu estructura

                            await command.ExecuteNonQueryAsync();
                        }
                    }

                    return Ok("Objetos insertados correctamente");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar objetos: {ex.Message}");
            }
        }

    }
}
