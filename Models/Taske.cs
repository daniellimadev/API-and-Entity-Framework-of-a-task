using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_and_Entity_Framework_of_a_task.Models
{
    public class Taske
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public EnumStatusTask Status { get; set; }
    }
}