
using Microsoft.EntityFrameworkCore;

namespace FourDemo
{
    public class TransactionContext: DbContext
    {
        
        public DbSet<Participant> Participants { get; set; }
        public DbSet<CreateKitty> CreateKitties { get; set; }
        public DbSet<Comment> Comments { get; set; }
        //public DbSet<MoneyTransaction> MoneyTransactions { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<MoneyGiven> MoneyGiven { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // change this with your local machine path
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\ataca\\OneDrive\\Masaüstü\\FinalAssignment4GroupF\\FourDemo\\FourDemo\\ParticipantDatabase.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Relationship between Participant and Expenses entities 
            modelBuilder.Entity<Expense>()
                .HasOne(e => e.Participant)
                .WithMany(p => p.Expenses)
                .HasForeignKey(e => e.ParticipantId);
            #endregion

            #region Relationship between Participant and Incomes entities 
            modelBuilder.Entity<Expense>()
                .HasOne(e => e.Participant)
                .WithMany(p => p.Expenses)
                .HasForeignKey(e => e.ParticipantId);
            #endregion

            #region Relationship between Participant and MoneyGIven entities 
            modelBuilder.Entity<MoneyGiven>()
                .HasOne(e => e.Participant)
                .WithMany(p => p.MoneyGiven)
                .HasForeignKey(e => e.ParticipantId);
            #endregion




            #region Relationship between CreateKitty and Participant
            modelBuilder.Entity<Participant>()
                .HasOne(e => e.CreateKitty)
                .WithMany(p => p.Participants)
                .HasForeignKey(e => e.CreateKittaId);
            #endregion
            #region Relationship between Participant and Comment
            modelBuilder.Entity<Comment>()
                .HasOne(e => e.Participant)
                .WithMany(p => p.Comments)
                .HasForeignKey(e => e.ParticipantId);
            #endregion



        }
    }
}

