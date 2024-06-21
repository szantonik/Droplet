﻿using Droplet.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace Droplet.Models.Entities
{
    public class Recipent
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string PESEL { get; set; } = default!;
        public BloodTypeEnum BloodType { get; set; } = default!;
    }
}
