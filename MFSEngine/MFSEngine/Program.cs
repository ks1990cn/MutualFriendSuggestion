using System;
using System.Collections.Generic;
using System.Linq;

namespace MFSEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Person> people = new Dictionary<int, Person>();
            people.Add(1, new Person() { location = "Uttar Pradesh", school = "ABC" });
            people.Add(2, new Person() { location = "Uttar Pradesh", school = "ABC" });
            people.Add(3, new Person() { });
            people.Add(4, new Person() { });
            people.Add(5, new Person() { });
            people.Add(6, new Person() { });
            people.Add(7, new Person() { location = "Uttar Pradesh", school = "XYZ" });
            people.Add(8, new Person() { });

            BFS breadthFirstSearch = new BFS(people.Count + 1);
            var number1 = people.FirstOrDefault(a => a.Key == 1).Key;
            var number2 = people.FirstOrDefault(a => a.Key == 2).Key;
            var number3 = people.FirstOrDefault(a => a.Key == 3).Key;
            var number4 = people.FirstOrDefault(a => a.Key == 4).Key;
            var number5 = people.FirstOrDefault(a => a.Key == 5).Key;
            var number6 = people.FirstOrDefault(a => a.Key == 6).Key;
            var number7 = people.FirstOrDefault(a => a.Key == 7).Key;

            breadthFirstSearch.AddEdge(number1, number2);
            breadthFirstSearch.AddEdge(number1, number3);
            breadthFirstSearch.AddEdge(number1, number4);
            breadthFirstSearch.AddEdge(number4, number5);
            breadthFirstSearch.AddEdge(number4, number6);
            breadthFirstSearch.AddEdge(number5, number7);
            breadthFirstSearch.BFSTraversal(number5, people);
        }
    }
}
