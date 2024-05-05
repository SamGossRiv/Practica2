using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace PatientManager
{
    public class Patient
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CI { get; set; }
        public string BloodGroup { get; set; }
    }

    public class PatientManager
    {
        private const string FilePath = "patients.json";

        public List<Patient> ReadPatientsFromFile()
        {
            if (!File.Exists(FilePath))
            {
                return new List<Patient>();
            }

            string json = File.ReadAllText(FilePath);
            return JsonConvert.DeserializeObject<List<Patient>>(json);
        }

        public void WritePatientsToFile(List<Patient> patients)
        {
            string json = JsonConvert.SerializeObject(patients);
            File.WriteAllText(FilePath, json);
        }
    }
}
