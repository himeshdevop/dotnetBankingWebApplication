using DBWebEFAPI.Models;
using Microsoft.EntityFrameworkCore;
using DBWebEFAPI.Data;
namespace DBWebEFAPI.Data
{
    public class DBManage : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Bank.db;");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        public DbSet<Audit> Audits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<User> users = new List<User>();
            List<Account> accounts = new List<Account>();
            List<Transaction> transactions = new List<Transaction>();
            List<Audit> audits = new List<Audit>();

            
            modelBuilder.Entity<User>().HasKey(a => a.Id);

            users.AddRange(new List<User>
    {
        new User { Id = 1, name = "Himesh", email = "hh@gmail.com", address = "No.55, Street 5, Colombo", password = "test1", picture = "gamer.png", phone = "0712345678" },
        new User { Id = 2, name = "Rivin", email = "rivin.r@gmail.com", address = "No.1, Street 1, Colombo", password = "test2", picture = "man.png", phone = "0722345678" },
        new User { Id = 3, name = "Dilhan", email = "dilhan.d@gmail.com", address = "No.2, Street 2, Colombo", password = "test3", picture = "woman.png", phone = "0732345678" },
        new User { Id = 4, name = "Anuk", email = "anuk.a@gmail.com", address = "No.3, Street 3, Colombo", password = "test4", picture = "profile.png", phone = "0742345678" },
        new User { Id = 5, name = "Yasith", email = "yasith.y@gmail.com", address = "No.4, Street 4, Colombo", password = "test5", picture = "programmer.png", phone = "0752345678" },
        new User { Id = 6, name = "Thinali", email = "thinali.t@gmail.com", address = "No.6, Street 6, Colombo", password = "test6", picture = "cat.png", phone = "0762345678" },
        new User { Id = 1000, name = "Admin1", email = "admin1.t@gmail.com", address = "No.6, Street 6, Colombo", password = "test1000", picture = "cat.png", phone = "0762345678" },
        new User { Id = 1001, name = "Admin2", email = "admin2.t@gmail.com", address = "No.6, Street 6, Colombo", password = "test1001", picture = "gamer.png", phone = "0762345678" }

    });

            
            modelBuilder.Entity<Account>().HasKey(a => a.accountNO);

    accounts.AddRange(new List<Account>
    {
        new Account { accountNO = 1, name = "Himesh", email = "himesh.h@gmail.com", address = "No.55, Street 5, Colombo", phone = "0711234567", balance = "1000.00" },
        new Account { accountNO = 2, name = "Rivin", email = "rivin.r@gmail.com", address = "No.1, Street 1, Colombo", phone = "0712345678", balance = "1500.00" },
        new Account { accountNO = 3, name = "Dilhan", email = "dilhan.d@gmail.com", address = "No.2, Street 2, Colombo", phone = "0713456789", balance = "2000.00" },
        new Account { accountNO = 4, name = "Anuk", email = "anuk.a@gmail.com", address = "No.3, Street 3, Colombo", phone = "0714567890", balance = "2500.00" },
        new Account { accountNO = 5, name = "Yasith", email = "yasith.y@gmail.com", address = "No.4, Street 4, Colombo", phone = "0715678901", balance = "3000.00" },
        new Account { accountNO = 6, name = "Thinali", email = "thinali.t@gmail.com", address = "No.6, Street 6, Colombo", phone = "0716789012", balance = "3500.00" }
    });

            
            modelBuilder.Entity<Transaction>().HasKey(t => t.transactionId);

    transactions.AddRange(new List<Transaction>
    {
        new Transaction { transactionId = "T001", accountNO = 1, amount = 100.00m, description = "Deposit", date = DateTime.Now.AddDays(-1) },
        new Transaction { transactionId = "T002", accountNO = 1, amount = 50.00m, description = "Withdrawal", date = DateTime.Now.AddDays(-2) },
        new Transaction { transactionId = "T003", accountNO = 1, amount = 200.00m, description = "Transfer", date = DateTime.Now.AddDays(-3) },
        new Transaction { transactionId = "T004", accountNO = 2, amount = 250.00m, description = "Deposit", date = DateTime.Now.AddDays(-1) },
        new Transaction { transactionId = "T005", accountNO = 2, amount = 100.00m, description = "Withdrawal", date = DateTime.Now.AddDays(-2) },
        new Transaction { transactionId = "T006", accountNO = 2, amount = 300.00m, description = "Transfer", date = DateTime.Now.AddDays(-3) },
        new Transaction { transactionId = "T007", accountNO = 3, amount = 400.00m, description = "Deposit", date = DateTime.Now.AddDays(-1) },
        new Transaction { transactionId = "T008", accountNO = 3, amount = 150.00m, description = "Withdrawal", date = DateTime.Now.AddDays(-2) },
        new Transaction { transactionId = "T009", accountNO = 3, amount = 500.00m, description = "Transfer", date = DateTime.Now.AddDays(-3) },
        new Transaction { transactionId = "T010", accountNO = 4, amount = 350.00m, description = "Deposit", date = DateTime.Now.AddDays(-1) },
        new Transaction { transactionId = "T011", accountNO = 4, amount = 200.00m, description = "Withdrawal", date = DateTime.Now.AddDays(-2) },
        new Transaction { transactionId = "T012", accountNO = 4, amount = 450.00m, description = "Transfer", date = DateTime.Now.AddDays(-3) },
        new Transaction { transactionId = "T013", accountNO = 5, amount = 500.00m, description = "Deposit", date = DateTime.Now.AddDays(-1) },
        new Transaction { transactionId = "T014", accountNO = 5, amount = 250.00m, description = "Withdrawal", date = DateTime.Now.AddDays(-2) },
        new Transaction { transactionId = "T015", accountNO = 5, amount = 600.00m, description = "Transfer", date = DateTime.Now.AddDays(-3) },
        new Transaction { transactionId = "T016", accountNO = 6, amount = 700.00m, description = "Deposit", date = DateTime.Now.AddDays(-1) },
        new Transaction { transactionId = "T017", accountNO = 6, amount = 300.00m, description = "Withdrawal", date = DateTime.Now.AddDays(-2) },
        new Transaction { transactionId = "T018", accountNO = 6, amount = 800.00m, description = "Transfer", date = DateTime.Now.AddDays(-3) }
    });

     modelBuilder.Entity<Audit>().HasKey(u => u.auditId);
            audits.AddRange(new List<Audit>
    {
        new Audit { auditId = "A001", auditRecord = "Admin created account with ID 1" },
        new Audit { auditId = "A002", auditRecord = "Admin created account with ID 2" },
        new Audit { auditId = "A003", auditRecord = "Admin updated account with ID 3" },
        new Audit { auditId = "A004", auditRecord = "Admin deleted account with ID 4" },
        new Audit { auditId = "A005", auditRecord = "Admin updated account with ID 5" }
    });



            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Account>().HasData(accounts);
            modelBuilder.Entity<Transaction>().HasData(transactions);
            modelBuilder.Entity<Audit>().HasData(audits);

        }
        
    }
}
