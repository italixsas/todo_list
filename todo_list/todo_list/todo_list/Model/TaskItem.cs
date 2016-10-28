using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace todo_list.Model
{
    public class TaskItem
    {
        [PrimaryKey] 
        public int Id { get; set; }
        [Indexed]
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Tags { get; set; }
    }
}
