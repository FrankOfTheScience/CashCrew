namespace CashCrew.Maui.DTO
{
    public class SignUpDTO
    {
        [Required, System.ComponentModel.DataAnnotations.MaxLength(20)]
        public string Username { get; set; }
        [Required, System.ComponentModel.DataAnnotations.MaxLength(20)]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
    }
}
