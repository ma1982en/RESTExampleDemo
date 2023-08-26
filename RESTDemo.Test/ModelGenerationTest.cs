using System.Xml;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTDemo.Models.Internal;

namespace RESTDemo.Test;

[TestClass]
public class ModelGenerationTest
{
    [TestMethod]
    public void GenerateXmlTestData()
    {
        //arrange

        var medicalRecordEntryDocument = new MedicalRecordEntryDocument
        {
            Id = 1,
            Name = "Krankenschein 2023 1 12",
            Type = MedicalRecordEntryDocumentType.Krankenschein
        };
        
        var medicalRecordEntry = new MedicalRecordEntry
        {
            Id = 1,
            LastVisitDoc = DateTime.Parse("23.12.23"),
            MedicalReason = "Schnupfen",
        };
        medicalRecordEntry.MedicalRecordEntryDocuments.Add(medicalRecordEntryDocument);

        var patientAdress = new PatientAdress
        {
            Id = 1,
            City = "DD",
            Nr = "3",
            Plz = "01425",
            Street = "Telomer Str"
        };

        var patient = new Patient
        {
            Id = 1,
            BirthDate = DateTime.Parse("4.4.1974"),
            Firstname = "Liza",
            LastName = "Schmidt",
        };
        patient.PatientAdresses.Add(patientAdress);

        var medicalRecord = new MedicalRecord
        {
            Id = 1,
            Patient = patient
        };
        medicalRecord.MedicalRecordEntries.Add(medicalRecordEntry);

        
        var xmlWriter = XmlWriter.Create(Console.Out);
        var xmlSerializer = new XmlSerializer(typeof(MedicalRecord));
        xmlSerializer.Serialize(xmlWriter,medicalRecord);
    }
}