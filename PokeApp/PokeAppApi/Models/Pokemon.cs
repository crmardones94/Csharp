using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Cryptography.X509Certificates;

namespace PokeAppApi.Models
{
    public class Pokemon
    {
        public int id_pokemon { get; set; }
        public string nombre { get; set; }
        public float estatura { get; set; }
        public float peso { get; set; }
        public bool isShiny { get; set; }

        public Tipo tipo { get; set; }
        public Tipo tipo2 { get; set; }

        public Sexualidad sexo { get; set; }

        public IList<Ataque> ataques { get; set; }

        public Pokemon(int id_pokemon, string nombre, float estatura, float peso, bool isShiny, Tipo tipo, Tipo tipo2,Sexualidad sexo, Ataque ataque)
        {
            this.id_pokemon = id_pokemon;
            this.nombre = nombre;
            this.estatura = estatura;
            this.peso = peso;
            this.isShiny = isShiny;
            this.tipo = tipo;
            this.tipo2 = tipo2;
            this.sexo = sexo;


        }

        public Pokemon()
        {
            this.id_pokemon = new int();
            this.nombre = string.Empty;
            this.estatura = new float();
            this.peso = new float();
            this.isShiny = false;
            this.tipo = new Tipo();
            this.tipo2 = new Tipo();
            this.sexo = Sexualidad.SinIndicar;
            
        }





    }
}
