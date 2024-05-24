namespace CashCrew.Maui.DTO
{
    public class SignInDTO
    {
        [Required, System.ComponentModel.DataAnnotations.MaxLength(20)]
        public string Username { get; set; }
        [Required, System.ComponentModel.DataAnnotations.MaxLength(20)]
        public string Password { get; set; }
    }
}
