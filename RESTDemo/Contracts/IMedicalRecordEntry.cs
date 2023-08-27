using RESTDemo.Models.Internal;

namespace RESTDemo.Contracts;

public interface IMedicalRecordEntry
{
    MedicalRecordEntry Add(int mid, MedicalRecordEntry medicalRecordEntry);
    MedicalRecordEntry Get(int mid, int eid);
    void Update(int mid, int eid, MedicalRecordEntry medicalRecordEntry);
    void Delete(int mid, int eid);
}