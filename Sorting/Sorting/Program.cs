using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path to file .json format:");
            var pathToJson = Console.ReadLine();
            Console.WriteLine("Enter path to save file:");
            var pathToSaveFile = Console.ReadLine();
            var file = new StreamReader(pathToJson);
            var json = file.ReadToEnd();
            var jObject = JObject.Parse(json);
            var results = jObject["experiments"]?.Children().ToList();
            var experimentModels = results
                .Select(item => item.ToObject<ExperimentModel>())
                .ToList();
            var resultsSorted = new Dictionary<long, long>();
            foreach (var experimentModel in experimentModels)
            {
                var generator = new GeneratorArrays(experimentModel.LengthArray,
                    experimentModel.LengthStrInArray,
                    experimentModel.CountArrays);
                var experimentsArrays = generator.GenerateArrays();
                var allCountOperation = experimentsArrays
                    .Sum(array => new Sorter(array).Sorted());
                resultsSorted.Add(experimentModel.LengthArray, allCountOperation);
            }

            var builder = new StringBuilder();
            foreach (var (lengthArray, countOperation) in resultsSorted)
            {
                builder.Append(lengthArray + " " + countOperation + "\n");
            }

            var writer = new StreamWriter(pathToSaveFile, 
                false, Encoding.Default);
            Console.WriteLine(builder.ToString());
            writer.Write(builder.ToString());
        }
    }
}