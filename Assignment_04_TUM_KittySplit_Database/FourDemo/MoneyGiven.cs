using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourDemo
{
    public class MoneyGiven : IExpenses
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string WhatFor { get; set; }
        public string When { get; set; }
        //Reciever
        public string ToWhom { get; set; }
        //Reciever's ID
        public int RecieverId { get; set; }

        // Foreign Key connecting MoneyGiven Class to Participant Class
        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }
    }
}
