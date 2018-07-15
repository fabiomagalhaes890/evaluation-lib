using EvaluationLib.DTO;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvaluationLib.Models
{
    [Table("BOOK")]
    public class Book
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("REGISTRATION_DATE")]
        public DateTime RegistrationDate { get; set; }
    }
}
