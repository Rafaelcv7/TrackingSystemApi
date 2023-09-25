using Microsoft.AspNetCore.Mvc;
using TrackingSystemApi.Business.Engines.Contracts;
using TrackingSystemApi.Business.Entities;
using TrackingSystemApi.Core.Contracts;

namespace TrackingSystemApi.Controllers;

[ApiController]
[Route("api/individuals")]
public class IndividualsController : Controller
{
    private readonly IBusinessEngineFactory _businessEngineFactory;

    private readonly IIndividualsEngine _individualsEngine;

    public IndividualsController(IBusinessEngineFactory businessEngineFactory)
    {
        _businessEngineFactory = businessEngineFactory;
        _individualsEngine = _businessEngineFactory.GetBusinessEngine<IIndividualsEngine>();
    }
    
    [HttpGet("/")]
    public ActionResult<IEnumerable<IndividualTracking>> GetAllDiagnosedIndividuals()
    {
        var results = _individualsEngine.GetAllDiagnosedIndividuals();
        return Ok(results);
    }

    [HttpGet("/{id}")]
    public ActionResult<IndividualTracking> GetIndividualById(int id)
    {
        if(id == null) return BadRequest();
        
        var result = _individualsEngine.GetIndividualById(id);
        
        return result != null 
            ? Ok(result) 
            : NotFound();
    }

    [HttpPost("/")]
    public ActionResult<IndividualTracking> CreateIndividual([FromBody] IndividualTracking individualData)
    {
        var result =  _individualsEngine.CreateIndividual(individualData);
        return result != null
            ? CreatedAtAction(nameof(CreateIndividual), result)
            : BadRequest("Failed to create the resource.");
    }

    [HttpPut("/{id}")]
    public ActionResult<IndividualTracking> UpdateIndividualById(int id, [FromBody] IndividualTracking individualData)
    {
        if(id == null || individualData == null || id != individualData.Id) return BadRequest();

        var result = _individualsEngine.UpdateIndividualById(id, individualData);

        return result != null
            ? result
            : NotFound();
    }
}