using FourDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourDemo
{
    public class Comment
    {
        public int Id { get; set; }
        public string PersonWhoCreate { get; set; }
        public string CommentText { get; set; }

        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }
    }
}

