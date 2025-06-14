﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkUtitlity.Ping
{
    public class NetworkService
    {
        public string SendPing()
        {
            //SearchDNS();
            //BuildPacket();
            return "Success: Ping Sent!";
        }

        public int PingTimeout(int a, int b)
        {
            return a + b;
        }

        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }

        public PingOptions GetPingOptions()
        {
            return new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
        }

        public IEnumerable<PingOptions> MostREcentPings()
        {
            IEnumerable<PingOptions> pingOptions = new[]
            {
                new PingOptions(){ DontFragment = true, Ttl = 1},
                new PingOptions() { DontFragment = false, Ttl = 2 },
                new PingOptions() { DontFragment = true, Ttl = 3 }
            };

            return pingOptions;
        }

    }
}
