using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ToDo_List
{
    internal class Task
    {
        public String title { get; set; }
        public bool isCompleted { get; set; }

        public Task(String title, bool isCompleted)
        {
            this.title = title;
            this.isCompleted = isCompleted;
        }

        public void MarkAsCompleted()
        {
            isCompleted = true;
        }

        public String ToString()
        {
            return ("Task Title: " + title + "\n   Is Completed: " + isCompleted);
        }
    }
}
