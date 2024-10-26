namespace Cargo.Models
{
    public class CargoModel // İsmi değiştirildi
    {
        public int Id { get; set; }
        public string? currentSube { get; set; }
        public string? ReceiverId { get; set; }
        public string? SenderId { get; set; }
        public string? Status { get; set; }
        public string[]? Process { get; set; }
    }
}
