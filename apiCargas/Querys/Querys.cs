using Microsoft.Extensions.Options;
using System.Data;

namespace apiCargas.Querys
{
    public class Querys
    {
        public string usuarios = "SELECT *   FROM [NAT_Usuario]";
        public string INSERT = "INSERT INTO [dbo].[Usuarios] ([IdUsuario],[IdSector],[NombreUsuario],[Apellido],[Estado],[Permiso]) VALUES()";
        public string UPDATE = "";

    }
}
