using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PatientCodeGenerator
{
    public class PatientInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CI { get; set; }
    }

    public class PatientCodeGenerator
    {
        private readonly HttpClient _httpClient;

        public PatientCodeGenerator(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GeneratePatientCodeAsync(string firstName, string lastName, string ci)
        {
            try
            {
                var patientInfo = new PatientInfo { FirstName = firstName, LastName = lastName, CI = ci };
                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(patientInfo), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("https://localhost:5001/api/PatientCode/GeneratePatientCode", content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception($"Error al generar el código de paciente. Status Code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al comunicarse con el Proyecto 3: {ex.Message}");
            }
        }
    }
}

