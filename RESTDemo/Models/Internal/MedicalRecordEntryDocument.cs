namespace RESTDemo.Models.Internal;

public record MedicalRecordEntryDocument
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = "";
    public MedicalRecordEntryDocumentType Type { get; set; } = MedicalRecordEntryDocumentType.Undefiniert;
}