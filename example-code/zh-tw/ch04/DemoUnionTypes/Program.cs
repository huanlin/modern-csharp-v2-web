Console.WriteLine("=== C# 15 聯合型別 ===");

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
    Cash cash => "現金：" + cash.Amount,
    CreditCard card => "信用卡 " + card.CardNumber + "：" + card.Amount,
    BankTransfer bank => "銀行帳戶 " + bank.AccountNo + "：" + bank.Amount
};

public record class Cash(decimal Amount);
public record class CreditCard(string CardNumber, decimal Amount);
public record class BankTransfer(string AccountNo, decimal Amount);
public union PaymentMethod(Cash, CreditCard, BankTransfer);
