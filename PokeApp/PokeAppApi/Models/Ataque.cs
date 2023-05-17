namespace PokeAppApi.Models
{
    public class Ataque
    {
        public int id_ataque { get; set; }
        public string nombre { get; set; }
        public Tipo tipo { get; set; }
        public int pp { get; set; }
        public int precision { get; set; }
        public int damage { get; set; }

        public Ataque()
        {
            this.id_ataque = new int();
            this.nombre = string.Empty;
            this.tipo = new Tipo();
            this.pp = new int();
            this.precision = new int();
            this.damage = new int();
        }


    }
}