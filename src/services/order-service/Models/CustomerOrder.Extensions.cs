namespace OrderService.Models;

public partial class CustomerOrder
{
    public static CustomerOrder Create(Guid userId, decimal totalAmount)
    {
        if (userId == Guid.Empty)
            throw new ArgumentNullException("UserId must not be empty.");

        if (totalAmount < (decimal)0.01)
            throw new ArgumentOutOfRangeException("TotalAmount must be a positive value");
        
        return new CustomerOrder
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            CreatedAt = DateTime.UtcNow,
            Status = "Created",
            TotalAmount = totalAmount
        };
    }
}
