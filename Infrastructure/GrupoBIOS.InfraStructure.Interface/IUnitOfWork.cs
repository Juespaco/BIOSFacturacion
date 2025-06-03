using System;

namespace GrupoBIOS.InfraStructure.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository Usuarios { get; }  // Mantenemos la propiedad específica        
        IClaseRepository Clases { get; }  // Mantenemos la propiedad específica        
        IParametroRepository Parametros { get; }  // Mantenemos la propiedad específica                
        ICompaniaRepository Compania { get; }  // Mantenemos la propiedad específica                
        ICentroOperativoRepository CentroOperativo { get; }  // Mantenemos la propiedad específica                
        TRepository GetRepository<TRepository>() where TRepository : class;  // Método genérico
    }
}
