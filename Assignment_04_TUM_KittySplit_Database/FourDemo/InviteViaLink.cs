using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourDemo
{
    public class InviteViaLink
    {
        public string Link { get; set; }

        public void CreateShareLink(CreateKitty kitty)
        {
            Console.WriteLine("The sharing link for the kitty: {0} is: Link", kitty.EventName);
        }

    }
}
