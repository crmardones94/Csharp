using System.Reflection.Metadata.Ecma335;

namespace prueba.Models
{
    public class pokemon
    {
        public pokemon(int id, string nombre, int estatura, int peso, bool isShiny)
        {
            this.id = id;
            this.nombre = nombre;
            this.estatura = estatura;
            this.peso = peso;
            this.isShiny = isShiny;
        }

        public pokemon()
        {
            this.id = 0;
            this.nombre = "";
            this.estatura = 0;
            this.peso = 0;
            this.isShiny = false;
        }

        public int id { get; set; }
        public string nombre { get; set; }
        public int estatura { get; set; }
        public int peso { get; set; }
        public Boolean isShiny { get; set; }
    }
}
