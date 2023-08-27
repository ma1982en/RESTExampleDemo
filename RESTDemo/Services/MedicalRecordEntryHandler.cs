using RESTDemo.Contracts;
using RESTDemo.Models.Internal;

namespace RESTDemo.Services;

public class MedicalRecordEntryHandler : IMedicalRecordEntry
{
    private readonly IMedicalRecord _medicalRecord;

    public MedicalRecordEntryHandler(IMedicalRecord medicalRecord)
    {
        _medicalRecord = medicalRecord;
    }
    public MedicalRecordEntry Add(int mid, MedicalRecordEntry medicalRecordEntry)
    {
        _medicalRecord.MedicalRecords[mid].MedicalRecordEntries.Add(medicalRecordEntry);
        var resultMedicalRecordEntry = _medicalRecord.MedicalRecords[mid].MedicalRecordEntries.Last();
        return resultMedicalRecordEntry;
    }

    public MedicalRecordEntry Get(int mid, int eid)
    {
        throw new NotImplementedException();
    }

    public void Update(int mid, int eid, MedicalRecordEntry medicalRecordEntry)
    {
        throw new NotImplementedException();
    }

    public void Delete(int mid, int eid)
    {
        throw new NotImplementedException();
    }
}