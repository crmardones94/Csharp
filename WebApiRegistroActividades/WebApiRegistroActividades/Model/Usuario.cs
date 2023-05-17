namespace WebApiRegistroActividades.Model
{

   
    public class Usuario
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidoMaterno { get; set; }
        public string apellidoPaterno { get; set; }
        public string rut { get; set; }
        public string fch_cumpleaños { get; set; }
        public string usuario { get; set; }
        public string gerencia { get; set; }
        public int permisos { get; set; }
        public int estado { get; set; }


    }

}
