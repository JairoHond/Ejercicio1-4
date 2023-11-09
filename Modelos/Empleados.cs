using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace Ejercicio1_4.Modelos
{
    public class Empleados
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public byte[] Imagen { get; set; }
        public string Descripcion { get; set; }
    }
}
