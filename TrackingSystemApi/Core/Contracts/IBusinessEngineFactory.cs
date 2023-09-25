namespace TrackingSystemApi.Core.Contracts;

public interface IBusinessEngineFactory
{
    T GetBusinessEngine<T>() where T : IBusinessEngine;
}

public interface IBusinessEngine
{
}