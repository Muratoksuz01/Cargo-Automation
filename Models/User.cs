namespace Cargo.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Şifreyi güvenli tutmak için hashlemen gerekir
    }
}
