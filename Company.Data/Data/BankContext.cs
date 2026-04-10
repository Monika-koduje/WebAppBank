using Microsoft.EntityFrameworkCore;
using Company.Data.Data.CMS;
using Company.Data.Data;

namespace Company.Data.Data
{
    public class BankContext : DbContext
    {
        public BankContext (DbContextOptions<BankContext> options)
            : base(options)
        {
        }

        public DbSet<News> News { get; set; } = default!;
        public DbSet<Page> Page { get; set; } = default!;
        public DbSet<CardType> CardType { get; set; } = default!;
        public DbSet<Card> Card { get; set; } = default!;
        public DbSet<Account> Account { get; set; } = default!;
        public DbSet<BankProduct> BankProduct { get; set; } = default!;
        public DbSet<Branch> Branch { get; set; } = default!;
        public DbSet<Client> Client { get; set; } = default!;
        public DbSet<ClientBankProduct> ClientBankProduct { get; set; } = default!;
        public DbSet<Employee> Employee { get; set; } = default!;
        public DbSet<Notification> Notification { get; set; } = default!;
        public DbSet<Transaction> Transaction { get; set; } = default!;
        public DbSet<AboutPageSection> AboutPageSection { get; set; } = default!;
        public DbSet<ContactPageSection> ContactPageSection { get; set; } = default!;
        public DbSet<PolicyPageSection> PolicyPageSection { get; set; } = default!;
    }
}
