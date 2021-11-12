using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    class UniquePersons
    {
        ///Name
        public string Name { get; set; }
        
        ///Unique Id
        public int UniqueId { get; set; }
#nullable enable
        ///Location
        public string? Location { get; set; }
#nullable disable
    }
}
