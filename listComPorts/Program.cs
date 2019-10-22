using System;
using System.Management;
using System.Text.RegularExpressions;

namespace listComPorts {
    class Program {
        static void Main(string[] args) {
            var query = @"SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%(COM%'";
            
            var comRegex = new Regex(@"COM[0-9]+");

            var searcher = new ManagementObjectSearcher("root\\CIMV2", query);
            foreach (var obj in searcher.Get()) {
                var name = (string)obj["Name"];
                if (name == null) continue;

                var match = comRegex.Match(name);
                if(match.Success) {
                    Console.WriteLine(match.Value + " - " + (string)obj["DeviceID"]);
                }   
            }
        }
    }
}
