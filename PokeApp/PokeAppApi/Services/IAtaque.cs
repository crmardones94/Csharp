using PokeAppApi.Models;

namespace PokeAppApi.Services
{
    public interface IAtaque
    {
        //crud
        public void Create(Ataque obj);
        public Ataque Read(int id);
        public IList<Ataque> listar();
        public void Update(int id, Ataque obj);
        public void Delete(int id);
         
    }
}
