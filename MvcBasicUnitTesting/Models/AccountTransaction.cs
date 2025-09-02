using System.ComponentModel;

namespace WebApplication3.Models;

public class AccountTransaction
{
    [DisplayName("Šifra transakcije")]
    public Guid Id { get; set; }

    [DisplayName("Iznos transakcije")]  
    public decimal Amount { get; set; }
}
