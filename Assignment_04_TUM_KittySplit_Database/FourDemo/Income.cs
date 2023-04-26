using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourDemo
{
    public class Income : IExpenses, ISplit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string WhatFor { get; set; }
        public string When { get; set; }

        // Split Amount 
        public bool SplitEqually { get; set; }
        public bool SplitDifferently { get; set; }

        // Foreign Key
        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }
    }
}
