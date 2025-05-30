using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace ToDo_List
{
    public class TaskManager
    {
        private List<Task> allTask;
        
        public TaskManager()
        {
            allTask = new List<Task>();
        }

        public void AddTask(String taskTitle)
        {
            allTask.Add(new Task(taskTitle, false));
        }

        public String ViewTasks()
        {
            String ViewAllTasks = "";
            int i = 1;
            foreach(Task curr in allTask)
            {
                ViewAllTasks +=  i + ". " + curr.ToString() + "\n";
                i++;
            }
            return ViewAllTasks;
        }

        public void DeleteTask(int index)
        {
            if (index < 0)
            {
                Console.WriteLine("Enter A Value Greater Than 0");
            }
            else if (index > allTask.Count()) Console.WriteLine("Value Is Greater Than Task Count");
                allTask.RemoveAt(index);
        }

        public void CompleteTask(int index)
        {
            if(index < 0)
            {
                Console.WriteLine("Please Enter A Value Greater than or Equal To 0");
            }
            else if (index > allTask.Count()) Console.WriteLine("Value Is Greater Than Task Count");
            else
            {
                Task curr = allTask[index];
                curr.MarkAsCompleted();
            }
        }

        async public void SaveToFile()
        {
            string filepath = "../Files.json";
            try
            {
                if (File.Exists(filepath))
                {
                    Console.WriteLine("File Exists Overwriting File");
                }
                String json = JsonSerializer.Serialize(allTask);
                File.WriteAllText(filepath, json);
                Console.WriteLine("Completed");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async void LoadFromFile()
        {
            string filepath = "../Files.json";
            List<Task> curr = new List<Task>();
            try
            {
                string json = await File.ReadAllTextAsync(filepath);
                Console.WriteLine(json);
                curr = JsonSerializer.Deserialize<List<Task>>(json);
                Console.WriteLine(" File Loaded Succeessfully ");
            }
            catch(Exception e)
            {
                Console.WriteLine("File Does not exist");
                Console.WriteLine(e);
            }
            finally
            {
                allTask = curr;
            }
        }
    }
}
