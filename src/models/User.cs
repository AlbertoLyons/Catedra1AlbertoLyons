using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catedra1AlbertoLyons.src.models
{
    public class User
    {
        [Key]
        public string Rut { get; set; }
        [StringLength(100), MinLength(3)]
        public string Name { get; set; }
        public string Email { get; set; }
        [RegularExpression(@"masculino|femenino|otro|prefiero no decirlo")]
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
    }
}