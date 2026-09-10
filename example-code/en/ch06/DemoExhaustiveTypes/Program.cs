OrderState[] states =
[
    new Pending(),
    new Paid(new DateTime(2026, 9, 1)),
    new Shipped("US123456789"),
    new Cancelled("Payment overdue")
];

foreach (OrderState state in states)
{
    Console.WriteLine(GetStatusText(state));
}

PaymentMethod[] paymentMethods =
[
    new Cash(),
    new CreditCard(),
    new BankTransfer()
];

foreach (PaymentMethod payment in paymentMethods)
{
    Console.WriteLine($"Fee: {CalculateFee(payment)}");
}

static string GetStatusText(OrderState state) => state switch
{
    Pending => "Pending payment",
    Paid paid => $"Paid on {paid.PaidAt:yyyy-MM-dd}",
    Shipped shipped => $"Shipped, tracking number: {shipped.TrackingNumber}",
    Cancelled cancelled => $"Order cancelled (reason: {cancelled.Reason})"
};

static decimal CalculateFee(PaymentMethod payment) => payment switch
{
    Cash => 0m,
    CreditCard => 15m,
    BankTransfer => 10m
};

public closed record class OrderState;

public sealed record class Pending : OrderState;
public sealed record class Paid(DateTime PaidAt) : OrderState;
public sealed record class Shipped(string TrackingNumber) : OrderState;
public sealed record class Cancelled(string Reason) : OrderState;

public record class Cash;
public record class CreditCard;
public record class BankTransfer;

public union PaymentMethod(Cash, CreditCard, BankTransfer);
