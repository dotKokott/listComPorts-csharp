using System;
using System.Management;
using System.Text.RegularExpressions;

namespace listComPorts {
    class Program {
        static void showUsage() {
            Console.WriteLine("Usage: listComPorts [-h] [-s <search>]");
            Console.WriteLine("\t-s <search> : Search by any string contained in device description");
            Console.WriteLine("\t-h : This help message");

            Environment.Exit(1);
        }

        static void Main(string[] args) {
            var searchString = "";
            for(int i = 0; i < args.Length; i++) {
                var arg = args[i];
                if(arg.Equals("-h")) {
                    showUsage();
                } else if(arg.Equals("-s")) {
                    searchString = args[++i];
                }
            }

            var query = @"SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%(COM%'";
            
            var comRegex = new Regex(@"COM[0-9]+");

            var searcher = new ManagementObjectSearcher("root\\CIMV2", query);
            foreach (var obj in searcher.Get()) {
                var name = (string)obj["Name"];
                if (name == null) continue;

                //TODO: Move this into the query
                var deviceID = (string)obj["DeviceID"];
                if (!string.IsNullOrEmpty(searchString) && !deviceID.Contains(searchString)) continue;

                var match = comRegex.Match(name);
                if(match.Success) {
                    Console.WriteLine(match.Value + " - " + (string)obj["DeviceID"]);
                }   
            }
        }
    }
}
