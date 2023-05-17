using PokeAppApi.Models;

namespace PokeAppApi.Services.Implementacion
{
    public class AtaqueService : IAtaque
    {

        static IList<Ataque> lista = new List<Ataque>();
        public AtaqueService()
        {
            if (lista.Count == 0)
            {
                lista.Add(new Ataque
                {
                    id_ataque = 1,
                    nombre = "placaje",
                    precision = 100,
                    pp = 30,
                    damage = 100,
                    tipo = new Tipo
                    {
                        id_tipo = 1,
                        nombre = "normal"
                    }
                });
            }
        }

        public void Create(Ataque obj)
        {
            lista.Add(obj);
        }

        public void Delete(int id)
        {
            lista.Remove(lista.FirstOrDefault(x => x.id_ataque== id));
        }

        public IList<Ataque> listar()
        {
            return lista;
        }

        public Ataque Read(int id)
        {
            return lista.FirstOrDefault(x => x.id_ataque == id);
        }

        public void Update(int id, Ataque obj)
        {            
            lista.Remove(lista.FirstOrDefault(x => x.id_ataque == id));
            lista.Add(obj);
        }
    }
}
