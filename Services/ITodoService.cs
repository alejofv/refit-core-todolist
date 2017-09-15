using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;

namespace TodoClient.Services
{
    [Headers("Accept: application/json")]
    public interface ITodoService
    {
        [Get("/todo/")]
        Task<IList<Models.TodoItem>> Get();

        [Get("/todo/all")]
        Task<IList<Models.TodoItem>> GetAll();

        [Get("/todo/{id}")]
        Task<Models.TodoItem> GetItem(string id);

        [Post("/todo")]
        Task<string> Create([Body]string title);

        [Put("/todo/{id}/complete")]
        Task<Models.TodoItem> Complete(string id);
    }
}