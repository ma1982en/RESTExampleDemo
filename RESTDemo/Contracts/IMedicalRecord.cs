using RESTDemo.Models.Internal;

namespace RESTDemo.Contracts;

public interface IMedicalRecord
{
    public List<MedicalRecord> MedicalRecords { get; }
    void Add(MedicalRecord medicalRecord);
    MedicalRecord Get(int mid);
    bool Update(int mid, MedicalRecord medicalRecord);
    bool Delete(int mid);
}