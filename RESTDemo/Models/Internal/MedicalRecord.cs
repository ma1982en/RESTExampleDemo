using RiskFirst.Hateoas.Models;

namespace RESTDemo.Models.Internal;

public class MedicalRecord : LinkContainer
{
    public int Id { get; set; } = 0;
    public Patient? Patient { get; set; }
    public List<MedicalRecordEntry> MedicalRecordEntries { get; set; } = new List<MedicalRecordEntry>();
    
}