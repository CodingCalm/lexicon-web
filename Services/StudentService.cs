using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

public class StudentService
{
    private readonly HttpClient _httpClient;

    public StudentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // GET: api/Students
    public async Task<List<StudentDTO>> GetStudentsAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<StudentDTO>>("api/Students");
    }

    // GET: api/Students/{id}
    public async Task<StudentDTO?> GetStudentByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<StudentDTO>($"api/Students/{id}");
    }

    // POST: api/Students
    public async Task<StudentDTO?> CreateStudentAsync(StudentDTO student)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Students", student);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<StudentDTO>();
        }

        return null; // Or handle error response
    }

    // PUT: api/Students/{id}
    public async Task<bool> UpdateStudentAsync(int id, StudentDTO student)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Students/{id}", student);
        return response.IsSuccessStatusCode;
    }

    // DELETE: api/Students/{id}
    public async Task<bool> DeleteStudentAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/Students/{id}");
        return response.IsSuccessStatusCode;
    }
}

