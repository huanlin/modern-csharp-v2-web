OrderState[] states =
[
    new Pending(),
    new Paid(new DateTime(2026, 9, 1)),
    new Shipped("JP123456789"),
    new Cancelled("支払い期限切れ")
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
    Console.WriteLine($"手数料: {CalculateFee(payment)}");
}

static string GetStatusText(OrderState state) => state switch
{
    Pending => "支払い待ち",
    Paid paid => $"{paid.PaidAt:yyyy-MM-dd} に支払い済み",
    Shipped shipped => $"発送済み、追跡番号: {shipped.TrackingNumber}",
    Cancelled cancelled => $"注文をキャンセルしました（理由: {cancelled.Reason}）"
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
