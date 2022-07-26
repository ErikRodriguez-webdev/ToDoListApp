using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
