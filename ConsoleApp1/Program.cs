using System;
using Newtonsoft.Json.Linq;
using Lab09_LINQ.Classes;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Lab09_LINQ
{
    class Program
    {
           public static string path = "../../../data.json";
            public static string readFile = File.ReadAllText(path);
            public static JObject json = JObject.Parse(readFile);
            public static Example listOfPlaces = JsonConvert.DeserializeObject<Example>(readFile);
        static void Main(string[] args)
        {
            GetAllNeighborhoods();
            FilterOutNoNames(listOfPlaces);
            FilterOutDuplicates(listOfPlaces);
            MasterQuery(listOfPlaces);
            QueryMethods(listOfPlaces);
        }

        static void GetAllNeighborhoods()
        {
            int countForDisplay = 1;
            foreach (Feature place in listOfPlaces.features)
            {
                Console.WriteLine($"{countForDisplay}. {place.properties.neighborhood}");
                countForDisplay++;
            }
        }

        static void FilterOutNoNames(Example places)
        {
            var query = from feature in places.features
                        select feature.properties.neighborhood;
            int counterForDisplay = 1;
            foreach(var feature in query)
            {
                if (feature != null)
                {
                    Console.WriteLine($"{counterForDisplay}. {feature}");
                    counterForDisplay++;
                }
            
            }           
        }
        
        static void FilterOutDuplicates(Example places)
        {
            var query = from feature in places.features
                        where feature.properties.neighborhood != ""
                        select feature.properties.neighborhood;

            var noDuplicates = query.Distinct();
            
            
            int counterForDisplay = 1;
            foreach (var feature in noDuplicates)
            {
                Console.WriteLine($"{counterForDisplay}. {feature}");
                counterForDisplay++;
            }
        }
        static void MasterQuery(Example places)
        {
            var query = (from feature in places.features
                         where feature.properties.neighborhood != ""
                         select feature.properties.neighborhood).Distinct();

            int counterForDisplay = 1;
            foreach (var feature in query)
            {
                Console.WriteLine($"{counterForDisplay}. {feature}");
                counterForDisplay++;
            }
        }

        public static void QueryMethods(Example places)
        {
            int counterForDisplay = 1;
            var query = places.features.Select(feature => feature.properties.neighborhood);
           
            foreach (var feature in query)
            {
                Console.WriteLine($"{counterForDisplay}. {feature}");
                counterForDisplay++;
            }

        }
    }

}
