using System.ComponentModel.DataAnnotations;

namespace Droplet.Models.Entities
{
    public class Bank
    {
        [Key]
        public int Id { get; set; }
        public DateOnly Date { get; set; } = default!;
        public Donor Donor { get; set; } = default!;

        public Transfusion? Transfusion { get; set; }
    }
}
