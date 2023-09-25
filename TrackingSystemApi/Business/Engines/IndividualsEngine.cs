using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TrackingSystemApi.Business.Engines.Contracts;
using TrackingSystemApi.Business.Entities;
using TrackingSystemApi.Data;

namespace TrackingSystemApi.Business.Engines;

public class IndividualsEngine: IIndividualsEngine
{
    private readonly DataContext _context;

    public IndividualsEngine(DataContext dataContext)
    {
        _context = dataContext;
    }

    public IEnumerable<IndividualTracking> GetAllDiagnosedIndividuals()
    {
        return _context.IndividualTracking.Where(x => x.IsDiagnosed);
    }

    public IndividualTracking GetIndividualById(int id)
    {
        return _context.IndividualTracking.FirstOrDefault(x => x.Id == id);
    }

    public IndividualTracking CreateIndividual(IndividualTracking individualData)
    {
        var result = _context.IndividualTracking.Add(individualData).Entity;
        _context.SaveChanges();
        return result;
    }

    public IndividualTracking UpdateIndividualById(int id, IndividualTracking individualData)
    {
        _context.Entry(individualData).State = EntityState.Modified;
        _context.SaveChanges();
        
        var result = _context.IndividualTracking.FirstOrDefault(x => x.Id == id);

        return result;
    }
}