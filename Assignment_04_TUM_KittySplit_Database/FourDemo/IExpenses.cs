using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourDemo
{
    public interface IExpenses

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string WhatFor { get; set; }
        public string When { get; set; }
        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }
    }
}
