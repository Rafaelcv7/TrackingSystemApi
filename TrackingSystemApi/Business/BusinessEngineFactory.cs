
using TrackingSystemApi.Core.Contracts;

namespace TrackingSystemApi.Business
{
    /// <summary>
    /// Importable class that represents a factory of Business Engines
    /// </summary>
    public class BusinessEngineFactory : IBusinessEngineFactory
    {
        private readonly IServiceProvider _services;

        public BusinessEngineFactory(IServiceProvider services)
        {
            _services = services;
        }

        public T GetBusinessEngine<T>() where T : IBusinessEngine
        {
            //Import instance of T from the DI container where T is a BusinessEngine
            return _services.GetService<T>();
        }
    }
}