OrderState[] states =
[
    new Pending(),
    new Paid(new DateTime(2026, 9, 1)),
    new Shipped("TW123456789"),
    new Cancelled("付款逾期")
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
    Console.WriteLine($"手續費：{CalculateFee(payment)}");
}

static string GetStatusText(OrderState state) => state switch
{
    Pending => "等待付款中",
    Paid paid => $"已於 {paid.PaidAt:yyyy-MM-dd} 付款",
    Shipped shipped => $"已出貨，追蹤碼：{shipped.TrackingNumber}",
    Cancelled cancelled => $"訂單已取消（原因：{cancelled.Reason}）"
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
