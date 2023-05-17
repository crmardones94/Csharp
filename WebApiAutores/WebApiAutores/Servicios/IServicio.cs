namespace WebApiAutores.Servicios
{
    public interface IServicio
    {
        Guid obtenerScoped();
        Guid obtenerSingleton();
        Guid obtenerTransient();
        void RealizarTarea();
    }

    public class ServicioA : IServicio
    {
        private readonly ILogger<ServicioA> logger;
        private readonly ServicioTransient servicioTransient;
        private readonly ServicioScoped servicioScoped;
        private readonly ServicioSingleton servicioSingleton;

        public ServicioA(ILogger<ServicioA> logger, ServicioTransient servicioTransient, ServicioScoped servicioScoped, ServicioSingleton servicioSingleton)
        {
            this.logger = logger;
            this.servicioTransient = servicioTransient;
            this.servicioScoped = servicioScoped;
            this.servicioSingleton = servicioSingleton;
        }

        public Guid obtenerTransient() { return servicioTransient.guid; }
        public Guid obtenerScoped() { return servicioScoped.guid; }
        public Guid obtenerSingleton() { return servicioSingleton.guid; }
        public void RealizarTarea()
        {
        }
    }
    public class ServicioB : IServicio
    {
        public void RealizarTarea()
        {

        }

        Guid IServicio.obtenerScoped()
        {
            throw new NotImplementedException();
        }

        Guid IServicio.obtenerSingleton()
        {
            throw new NotImplementedException();
        }

        Guid IServicio.obtenerTransient()
        {
            throw new NotImplementedException();
        }

        void IServicio.RealizarTarea()
        {
            throw new NotImplementedException();
        }
    }

    public class ServicioTransient
    {
        public Guid guid = Guid.NewGuid();
    }

    public class ServicioScoped
    {
        public Guid guid = Guid.NewGuid();
    }
    public class ServicioSingleton
    {
        public Guid guid = Guid.NewGuid();
    }
}
