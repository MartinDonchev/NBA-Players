using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NBA
{    
    class Program
    {
        static void Main(string[] args)
        {
            var strResultJason = File.ReadAllText("../../../players.json");
            var resultPlayer = JsonConvert.DeserializeObject<Player[]>(strResultJason);

            Console.Write("Enter years to qualify: ");
            var maxYearPlayed = int.Parse(Console.ReadLine());
            Console.Write("Enter rating: ");
            var minRateToQualify = int.Parse(Console.ReadLine());
            var yearNow = DateTime.Today;

            var yearsPlayed = yearNow.Year - maxYearPlayed;

            StringBuilder csvcontent = new StringBuilder();
            csvcontent.AppendLine("Name,Rating");
            string csvpath = "F:\\MentorMate\\NBA\\NBA\\player.csv";


            foreach (var item in resultPlayer.OrderByDescending(x => x.Rating).ThenBy(x => x.Name))
            {
                if (item.PlayerSince > yearsPlayed && item.Rating > minRateToQualify)
                {
                    //Console.WriteLine($"{item.Name}, {item.Rating:f1}");
                    csvcontent.AppendLine($"{item.Name}, {item.Rating}");
                }
                
            }

            File.AppendAllText(csvpath, csvcontent.ToString());                                  

        }
    }
}
