using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MuhtarlıkOtomasyon.Models
{
    public class BloodGroup
    {
        [Key]
        public int Id { get; set; }
        public string Kan_Grup { get; set; }

    }
}
