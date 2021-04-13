using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting
{
    public class GeneratorArrays
    {
        private readonly long lengthArray;

        private readonly long lengthStrInArray;

        private readonly long countArrays;

        private const string GenerateStr = "qwertyuiopasdfghjklzxcvbnm";


        public GeneratorArrays(long lengthArray, long lengthStrInArray, long countArrays)
        {
            this.lengthArray = lengthArray;
            this.lengthStrInArray = lengthStrInArray;
            this.countArrays = countArrays;
        }

        private string[] GenerateArray()
        {
            var random = new Random();
            var result = new string[lengthArray];
            for (var i = 0; i < lengthArray; i++)
            {
                var builder = new StringBuilder();
                for (var j = 0; j < lengthStrInArray; j++)
                {
                    builder.Append(GenerateStr[random.Next(0, GenerateStr.Length - 1)]);
                }
                result[i] = builder.ToString();
            }
            return result;
        }


        public string[][] GenerateArrays()
        {
            var result = new List<string[]>();
            for (var i = 0; i < countArrays; i++)
            {
                result.Add(GenerateArray());
            }

            return result.ToArray();
        }

    }
}