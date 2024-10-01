using Newtonsoft.Json;
using HttpClient_Test.Domain;
using System.Net;

namespace HttpClient_Test.Handlers;

public class ToDoListHandler
{
    private static readonly HttpClient client = new HttpClient()
    {
        BaseAddress = new Uri("https://localhost:7057")
    };

    public string GetAllTasks()
    {
        var response = client.GetAsync("api/ToDo").Result;

        var content = response.Content.ReadAsStringAsync().Result;
        return content;
    }
    public bool CreateTask(CreateTaskDto dto)
    {
        var response = client.PostAsJsonAsync("api/ToDo",dto).Result;

        if(response.StatusCode != HttpStatusCode.NoContent)
        {
            return false;
        }
        return true;
    }
    public bool Mark(int id)
    {
        var response = client.PatchAsJsonAsync($"api/ToDo/mark/{id}",new object()).Result;
    
        if(response.StatusCode != HttpStatusCode.NoContent)
        {
            return false;
        }
        return true;
    }
    public bool Unmark(int id)
    {
        var response = client.PatchAsJsonAsync($"api/ToDo/unmark/{id}", new object()).Result;

        if(response.StatusCode != HttpStatusCode.NoContent)
        {
            return false;
        }
        return true;
    }
    public bool DeleteTask(int id)
    {
        var response = client.DeleteAsync($"api/ToDo/{id}").Result;

        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            return false;
        }
        return true;
    }
}
