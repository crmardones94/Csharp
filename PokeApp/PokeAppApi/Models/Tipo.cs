namespace PokeAppApi.Models
{
    public class Tipo
    {
        public int id_tipo { get; set; }
        public string nombre { get; set; }
        public Tipo(int id_tipo, string nombre)
        {
            this.id_tipo = id_tipo;
            this.nombre = nombre;
        }
        public Tipo()
        {
            this.id_tipo = new int();
            this.nombre = string.Empty;
        }



    }
}
