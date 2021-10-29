using System;
using System.Collections.Generic;
using System.Linq;

namespace MFSEngine
{
    class Program
    {
        static void Main(string[] args)
        {

            HashSet<Person> people = new HashSet<Person>();
            people.Add(new Person() { uniqueNumber = 1 });
            people.Add(new Person() { uniqueNumber = 2 });
            people.Add(new Person() { uniqueNumber = 3 });
            people.Add(new Person() { uniqueNumber = 4 });
            people.Add(new Person() { uniqueNumber = 5 });
            people.Add(new Person() { uniqueNumber = 6 });
            people.Add(new Person() { uniqueNumber = 7 });

            BFS breadthFirstSearch = new BFS(people.Count + 1);
            var number1 = people.FirstOrDefault(a => a.uniqueNumber == 1).uniqueNumber;
            var number2 = people.FirstOrDefault(a => a.uniqueNumber == 2).uniqueNumber;
            var number3 = people.FirstOrDefault(a => a.uniqueNumber == 3).uniqueNumber;
            var number4 = people.FirstOrDefault(a => a.uniqueNumber == 4).uniqueNumber;
            var number5 = people.FirstOrDefault(a => a.uniqueNumber == 5).uniqueNumber;
            var number6 = people.FirstOrDefault(a => a.uniqueNumber == 6).uniqueNumber;
            var number7 = people.FirstOrDefault(a => a.uniqueNumber == 7).uniqueNumber;

            breadthFirstSearch.AddEdge(number1, number2);
            breadthFirstSearch.AddEdge(number1, number3);
            breadthFirstSearch.AddEdge(number1, number4);
            breadthFirstSearch.AddEdge(number4, number5);
            breadthFirstSearch.AddEdge(number4, number6);
            breadthFirstSearch.AddEdge(number5, number7);
            breadthFirstSearch.BFSTraversal(number1);
        }
    }
}
