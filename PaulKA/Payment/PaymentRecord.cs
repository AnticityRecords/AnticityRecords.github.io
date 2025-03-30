using System.ComponentModel.DataAnnotations;

public class PaymentRecord
{
    [Key]
    public int PaymentRecordId { get; set; }
    public string StripeSessionId { get; set; }
    public string Status { get; set; }
}
