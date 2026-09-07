Console.WriteLine("=== C# 15 union types ===");

PaymentMethod[] methods =
[
    new Cash(500m),
    new CreditCard("4111-2222-3333-4444", 1200m),
    new BankTransfer("987654321", 800m)
];

foreach (PaymentMethod method in methods)
{
    Console.WriteLine(Describe(method));
}

static string Describe(PaymentMethod method) => method switch
{
    Cash cash => "Cash: " + cash.Amount,
    CreditCard card => "Credit card " + card.CardNumber + ": " + card.Amount,
    BankTransfer bank => "Bank account " + bank.AccountNo + ": " + bank.Amount
};

public record class Cash(decimal Amount);
public record class CreditCard(string CardNumber, decimal Amount);
public record class BankTransfer(string AccountNo, decimal Amount);
public union PaymentMethod(Cash, CreditCard, BankTransfer);
