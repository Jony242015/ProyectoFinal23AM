using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal23AM.Entities
{
    public class Usuario
    {
        [Key] public int PkUsuario { get; set; }
        public string Nombre { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        //SE DECLARA LA LLAVE FORANEA PROVENIENTE DE LA TABLA ROL Y ENLAZA LA FK
        [ForeignKey("Roles")] public int? FkRol { get; set; }
        //SE MANDA A LLAMAR A LA TABLA ROLL PARA ENLAZAR EL FK
        public Rol Roles { get; set; }
    }
}
