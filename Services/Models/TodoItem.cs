using System;

namespace TodoClient.Services.Models
{
    public class TodoItem
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            return $"{this.Title, -50} ({(this.IsCompleted ? "X" : "_")})";
        }
    }
}