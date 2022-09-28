using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lazy
{
    [Table("People")]
    public class User
    {
        [Column("user_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public int Age { get; set; }

        public User(string name, int age)
        {
            Name = name;
            Age = age;
            Console.WriteLine($"Вызов конструктора для объекта {name}");
        }
    }

    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
    public class Country
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
