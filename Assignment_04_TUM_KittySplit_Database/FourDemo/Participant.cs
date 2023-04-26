using FourDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourDemo
{
    public class Participant
    {
        public int ParticipantId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Expense>? Expenses { get; set; }
        public List<Income>? Incomes { get; set; }
        public List<MoneyGiven>? MoneyGiven { get; set; }
        public List<Comment> Comments { get; set; }
        
        public Participant()
        {
            Expenses = new List<Expense>();
            MoneyGiven = new List<MoneyGiven>();
            Incomes = new List<Income>();
            Comments = new List<Comment>();
            
            
        }

        public int CreateKittaId { get; set; }
        public CreateKitty CreateKitty { get; set; }

    }
}
