using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourDemo
{
    public class CreateKitty
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public List<Participant> ParticipantsList { get; set; }
        public HomeCurrency MoneyType { get; set; }


        public List<Participant> Participants { get; set; }
        public CreateKitty()
        {
            Participants = new List<Participant>();
        }
    }
}
