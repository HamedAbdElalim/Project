﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Project01.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageURL { get; set; }
        public string? Address { get; set; }
        public string? Grade { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }


        public ICollection<CrsResult>? CrsResults { get; set; }
    }
}
