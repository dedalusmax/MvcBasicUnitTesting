using System.ComponentModel;

namespace WebApplication3.Models;

public class Account
{
    [DisplayName("Šifra računa")]
    public int Id { get; set; }

    [DisplayName("Naziv računa")]
    public string Name { get; set; }

    [DisplayName("Saldo računa")]
    public decimal Total { get; set; }

    public List<AccountTransaction> Transactions { get; set; } = [];

    public Account()
    {
        this.Transactions.Add(new AccountTransaction { Id = Guid.NewGuid(), Amount = 500.00M });
        this.Transactions.Add(new AccountTransaction { Id = Guid.NewGuid(), Amount = -40.00M });
        this.Transactions.Add(new AccountTransaction { Id = Guid.NewGuid(), Amount = 25.00M });
    }
}
