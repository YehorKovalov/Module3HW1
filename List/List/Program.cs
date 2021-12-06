using System;
using System.Collections.Generic;

namespace List
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var objectTestVector = new List<TestObject>()
            {
                new TestObject
                {
                    Id = 1,
                    Name = "Yehor"
                },
                new TestObject
                {
                    Id = 3,
                    Name = "Yehor"
                }
            };

            var list = new List<TestObject>();
            list.AddRange(objectTestVector);
            list.Add(new TestObject()
            {
                Id = 2,
                Name = "Yehor"
            });
            list.Sort(new IdComparer());
            list.RemoveAt(2);
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Id} {item.Name}");
            }
        }
    }
}
