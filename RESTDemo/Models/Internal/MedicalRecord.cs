namespace RESTDemo.Models.Internal;

public record MedicalRecord
{
    public int Id { get; set; } = 0;
    public Patient? Patient { get; set; }
    public List<MedicalRecordEntry> MedicalRecordEntries { get; set; } = new List<MedicalRecordEntry>();

}