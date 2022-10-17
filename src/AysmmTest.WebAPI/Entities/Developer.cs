using System.ComponentModel.DataAnnotations.Schema;

namespace AysmmTest.WebAPI.Entities
{
    [Table("developers")]
    public class Developer
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("age")]
        public int Age { get; set; }

        [Column("level")]
        public string Level { get; set; }
    }
}
