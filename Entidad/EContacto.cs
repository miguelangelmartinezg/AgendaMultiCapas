using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EContacto
    {
        private int _IdContacto;
        private int _EstadoCivil;
        private string _Nombre;
        private string _Apellido;
        private string _Direccion;
        private string _Genero;
        private string _Telefono;
        private string _Celular;
        private string _Email;
        private DateTime _FechaNac;

        public int IdContacto { get => _IdContacto; set => _IdContacto = value; }
        public int EstadoCivil { get => _EstadoCivil; set => _EstadoCivil = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Genero { get => _Genero; set => _Genero = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Celular { get => _Celular; set => _Celular = value; }
        public string Email { get => _Email; set => _Email = value; }
        public DateTime FechaNac { get => _FechaNac; set => _FechaNac = value; }
    }
}
