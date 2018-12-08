using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebOne.Models
{
    [Table("people")]
    public class Person
    {
        public Person()
        {
        }

        [Column("id")]
        public int Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("birth_date")]
        public DateTime BirthDate { get; set; }
    
    }
}
