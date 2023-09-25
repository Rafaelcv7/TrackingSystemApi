using TrackingSystemApi.Business.Entities;
using TrackingSystemApi.Core.Contracts;

namespace TrackingSystemApi.Business.Engines.Contracts;

public interface IIndividualsEngine : IBusinessEngine
{
    IEnumerable<IndividualTracking> GetAllDiagnosedIndividuals();

    IndividualTracking GetIndividualById(int id);

    IndividualTracking CreateIndividual(IndividualTracking individualData);

    IndividualTracking UpdateIndividualById(int id, IndividualTracking individualData);
}