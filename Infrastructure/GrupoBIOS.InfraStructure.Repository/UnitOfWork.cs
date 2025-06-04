using GrupoBIOS.InfraStructure.Interface;

namespace GrupoBIOS.InfraStructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<Type, object> _repositories = new();

        public UnitOfWork(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        // Propiedad específica
        public IUsuarioRepository Usuarios => GetRepository<IUsuarioRepository>();
        public IClaseRepository Clases => GetRepository<IClaseRepository>();
        public IParametroRepository Parametros => GetRepository<IParametroRepository>();
        public ICompaniaRepository Compania => GetRepository<ICompaniaRepository>();
        public ICentroOperativoRepository CentroOperativo => GetRepository<ICentroOperativoRepository>();
        public IExcepcionRepository Excepcion => GetRepository<IExcepcionRepository>();
        public IPncRepository Pnc => GetRepository<IPncRepository>();

        // Método genérico para obtener cualquier repositorio
        public TRepository GetRepository<TRepository>() where TRepository : class
        {
            var type = typeof(TRepository);

            if (_repositories.TryGetValue(type, out var repository))
            {
                return (TRepository)repository;
            }

            // Versión corregida
            var repoInstance = _serviceProvider.GetService(type) as TRepository ??
                throw new InvalidOperationException($"Repository {type.Name} is not registered");

            _repositories.Add(type, repoInstance);
            return repoInstance;
        }

        public void Dispose()
        {
            foreach (var repo in _repositories.Values.OfType<IDisposable>())
            {
                repo.Dispose();
            }
            _repositories.Clear();
            GC.SuppressFinalize(this);
        }
    }
}
