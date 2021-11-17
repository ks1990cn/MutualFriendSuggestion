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
            //mongoDataProvider.InsertRecord(tableName, new Person() { Id = 1, location = "Uttar Pradesh", school = "ABC",friendsId =new List<int>(){2,3,4 } });
            //mongoDataProvider.InsertRecord(tableName, new Person() { Id = 2, school = "ABC" });
            //mongoDataProvider.InsertRecord(tableName, new Person() { Id = 3 });
            //mongoDataProvider.InsertRecord(tableName, new Person() { Id = 4, location = "Uttar Pradesh" ,friendsId = new List<int>() { 1,5,6 } });
            //mongoDataProvider.InsertRecord(tableName, new Person() { Id = 5, location = "Uttar Pradesh", school = "xyz",friendsId = new List<int>() { 4,7} });
            //mongoDataProvider.InsertRecord(tableName, new Person() { Id = 6 });
            //mongoDataProvider.InsertRecord(tableName, new Person() { Id = 7 });
            //mongoDataProvider.InsertRecord(tableName, new Person() { Id = 8, location = "Uttar Pradesh", school = "ABC" });
            // var newList=mongoDataProvider.LoadRecords<Person>(tableName,100);


            //Imagine we are currently on id=4
            int currentGuy = 4;
            List<int> currentGuyFriends = mongoDataProvider.LoadRecordsById<Person>(tableName, currentGuy).friendsId;
            MFSGraph mFSGraph = new MFSGraph(50);
            foreach (var item in currentGuyFriends)
            {
                mFSGraph.AddEdge(item, currentGuy);
                if (item != currentGuy)
                {
                    List<int> mutualFriendsLoader = mongoDataProvider.LoadRecordsById<Person>(tableName, item).friendsId;
                    if(mutualFriendsLoader != null) 
                    foreach (var mutualFriends in mutualFriendsLoader)
                    {
                        mFSGraph.AddEdge(item, mutualFriends);
                    }
                }
            }
            BFS bFS = new BFS();
            MFSOutput mFSOutput = new MFSOutput(bFS);
            mFSOutput.mutualFriendsList(mFSGraph, currentGuy);
        }
    }
}
