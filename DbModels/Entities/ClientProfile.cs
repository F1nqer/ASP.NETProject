using ASP.NETProject.DbModels.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbModels.Entities
{
    public class ClientProfile
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        [Index(IsUnique = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

    }
}
