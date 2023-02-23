using System;
using System.Windows.Forms;

namespace Personas_Formulario
{
    internal class Contacto : Persona
    {
        private string telefono;
        private string correo;
        
              
        public string Telefono
        {
            get { return telefono; }
            set
            { 
                telefono = value.Replace(" ", "").Replace("-", "");
            }
        }
        public string Correo 
        {
            get { return correo; }
            set { correo = value; }
        }
       /* public Contacto(string nombre, string correo, string telefono, DateTime? fechaNacimiento) : base()
        {
            this.nombre = nombre;
            this.correo = correo;
            this.telefono = telefono;
            this.fechaNacimiento = fechaNacimiento;
        }*/       
                                
        

      
    }
}
