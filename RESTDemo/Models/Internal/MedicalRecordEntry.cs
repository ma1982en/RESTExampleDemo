namespace RESTDemo.Models.Internal;

public record MedicalRecordEntry
{
    public int Id { get; set; }
    public DateTime LastVisitDoc { get; set; } = DateTime.MinValue;
    public string MedicalReason { get; set; } = "";
    public List<MedicalRecordEntryDocument> MedicalRecordEntryDocuments { get; set; } = new List<MedicalRecordEntryDocument>();
    
}