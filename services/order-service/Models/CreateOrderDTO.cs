using System.ComponentModel.DataAnnotations;
using OrderService.Validation;

namespace OrderService.Models;

public class CreateOrderDTO
{
    [Required]
    public Guid UserId { get; set; }
    // Custom Attribute for DTO validation
    [PositiveDecimal]
    public decimal TotalAmount { get; set; }
}
