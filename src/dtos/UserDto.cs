using System.ComponentModel.DataAnnotations;

namespace Catedra1AlbertoLyons.src.dtos
{
    public class UserDto
    {
        [StringLength(10), MinLength(7)]
        public required string Rut { get; set; }
        [StringLength(100), MinLength(3)]
        public required string Name { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        [RegularExpression(@"masculino|femenino|otro|prefiero no decirlo")]
        public required string Gender { get; set; }
        [DataType(DataType.Date)]
        public required DateTime Birthdate { get; set; }
    }
}