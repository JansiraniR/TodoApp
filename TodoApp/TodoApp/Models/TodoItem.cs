using System;
namespace TodoApp.Models
{
    public class TodoItem
    {
        
      //  [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Task { get; set; }
        public string Notes { get; set; }
        public string Status { get; set; }
        public bool Done { get; set; }
        public DateTime TaskDateTime { get; set; }
    }
}
