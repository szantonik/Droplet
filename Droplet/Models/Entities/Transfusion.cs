namespace Droplet.Models.Entities
{
    public class Transfusion
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public Recipent Recipent { get; set; } = default!;
        public Hospital Hospital { get; set; } = default!;
        public Doctor Doctor { get; set; } = default!;

        public ICollection<Bank> BloodUsed { get; set; } = default!;
    }
}
