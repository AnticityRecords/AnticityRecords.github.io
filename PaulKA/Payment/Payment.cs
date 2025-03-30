public class PaymentDetails
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; } = string.Empty; // Initialize with a default value
    public string Status { get; set; } = string.Empty; // Initialize with a default value
}
