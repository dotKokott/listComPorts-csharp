using System;
using System.Management;
using System.Text.RegularExpressions;

namespace listComPorts {
    class Program {
        static void Main(string[] args) {
            var searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity");
            Regex comRegex = new Regex(@"COM[0-9]+");

            foreach(var obj in searcher.Get()) {
                var name = (string)obj["Name"];
                if (name == null) continue;

                var match = comRegex.Match(name);
                if(match.Success) {
                    Console.WriteLine(match.Value + " " + (string)obj["DeviceID"]);
                }   
            }     
        }
    }
}
