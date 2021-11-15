using System;
using System.Collections.Generic;
using System.Linq;
using MFSEngine.Logic;
using MFSEngine.Models;
using DAL;
namespace MFSEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            string databaseName = "MFSDatabase";
            string tableName = "peopleRecord";

            MongoDataProvider mongoDataProvider = new MongoDataProvider(databaseName);
            //mongoDataProvider.InsertRecord(tableName, new Person() { Id =1, location = "Uttar Pradesh", school = "ABC" });
            //mongoDataProvider.InsertRecord(tableName, new Person() { Id = 2, school = "ABC" });
            //mongoDataProvider.InsertRecord(tableName, new Person() { Id = 3});
            //mongoDataProvider.InsertRecord(tableName, new Person() { Id = 4, location = "Uttar Pradesh"});
            //mongoDataProvider.InsertRecord(tableName, new Person() { Id = 5, location = "Uttar Pradesh", school = "xyz" });
            //mongoDataProvider.InsertRecord(tableName, new Person() { Id = 6 });
            //mongoDataProvider.InsertRecord(tableName, new Person() { Id = 7  });
            //mongoDataProvider.InsertRecord(tableName, new Person() { Id = 8, location = "Uttar Pradesh", school = "ABC" });
            var newList=mongoDataProvider.LoadRecords<Person>(tableName,3);

            foreach (var item in newList)
            {
                Console.WriteLine(item.location + " " + item.Id+" "+item.school);
            }
            //Dictionary to create our cases
            Dictionary<int, Person> people = new Dictionary<int, Person>();
            people.Add(1, new Person() { location = "Uttar Pradesh", school = "ABC" });
            people.Add(2, new Person() { school = "ABC" });
            people.Add(3, new Person() { });
            people.Add(4, new Person() { location = "Uttar Pradesh" });
            people.Add(5, new Person() { location = "Uttar Pradesh" });
            people.Add(6, new Person() { });
            people.Add(7, new Person() { location = "Uttar Pradesh", school = "XYZ" });
            people.Add(8, new Person() { });
            //Number of vertices
            var number1 = people.FirstOrDefault(a => a.Key == 1).Key;
            var number2 = people.FirstOrDefault(a => a.Key == 2).Key;
            var number3 = people.FirstOrDefault(a => a.Key == 3).Key;
            var number4 = people.FirstOrDefault(a => a.Key == 4).Key;
            var number5 = people.FirstOrDefault(a => a.Key == 5).Key;
            var number6 = people.FirstOrDefault(a => a.Key == 6).Key;
            var number7 = people.FirstOrDefault(a => a.Key == 7).Key;
            MFSGraph connections = new MFSGraph(people.Count + 1);
            connections.AddEdge(number1, number2);
            connections.AddEdge(number1, number3);
            connections.AddEdge(number1, number4);
            connections.AddEdge(number4, number5);
            connections.AddEdge(number4, number6);
            connections.AddEdge(number5, number7);
            /* These edges are joined to form a graph.
             * 1->2,1->3,1->4
             * 4->5,4->6
             * 5->7
             */
            BFS bFS = new BFS();
            MFSOutput mFSOutput = new MFSOutput(bFS);
            mFSOutput.mutualFriendsList(connections, number4);
        }
    }
}
