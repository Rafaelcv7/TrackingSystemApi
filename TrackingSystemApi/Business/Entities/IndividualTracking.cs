using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace TrackingSystemApi.Business.Entities;

public class IndividualTracking
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int Age { get; set; }
    
    [NotMapped]
    public List<string> Symptoms
    {
        get => JsonConvert.DeserializeObject<List<string>>(SymptomsDb) ?? new List<string>();
        set => SymptomsDb = JsonConvert.SerializeObject(value);
    }
    public bool IsDiagnosed { get; set; }
    public DateTime? Date_Diagnosed { get; set; } = null;
    
    internal string SymptomsDb { get; set; }
}