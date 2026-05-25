using System;
using System.ComponentModel.DataAnnotations;

namespace Project08_TodoDatabaseStore.Models
{
    public class TodoTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}