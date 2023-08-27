using RESTDemo.Contracts;
using RESTDemo.Models.Internal;

namespace RESTDemo.Services;

public class MedicalRecordHandler : IMedicalRecord
{
    private readonly List<Models.Internal.MedicalRecord> _medicalRecords = new List<Models.Internal.MedicalRecord>();

    public List<Models.Internal.MedicalRecord> MedicalRecords => _medicalRecords;

    public void Add(Models.Internal.MedicalRecord medicalRecord)
    {
        _medicalRecords.Add(medicalRecord);
    }

    public Models.Internal.MedicalRecord Get(int mid)
    {
        return _medicalRecords[mid];
    }

    public bool Update(int mid, Models.Internal.MedicalRecord medicalRecord)
    {
        _medicalRecords.Insert(mid,medicalRecord);
        return true;
    }

    public bool Delete(int mid)
    {
        var medicalRecord = _medicalRecords[mid];
        _medicalRecords.Remove(medicalRecord);
        return true;
    }
}