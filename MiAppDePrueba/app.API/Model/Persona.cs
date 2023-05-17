namespace app.API.Model
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rut { get; set; }

        public Persona() {
            Nombre = "";
            Apellido = "";
            Rut = "";
        }

        public Persona(string nombre, string apellido, string rut)
        {
            Nombre = nombre;
            Apellido = apellido;
            Rut = rut;
        }
    }
}
