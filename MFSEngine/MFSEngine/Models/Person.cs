using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFSEngine.Models
{
    class Person
    {
        [BsonId]
        public int Id { get; set; }

        public string location;

        public string school;

        public string college;

        public string workPlace;

        public LinkedList<Person> friends;
    }
}
