using System.Text.Json;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using ToDo_List;

public class Program
{
    public static TaskManager taskManager = new TaskManager();
    public static void Main(string[] args)
    {
        int option;
        do
        {
            Console.WriteLine("TO-DO LIST");
            Console.WriteLine("1. Add Task \n2. Delete Task \n3. View Task\n4. Complete Task \n5. Save To File\n6. Load From File\n7. Exit");
            option = Convert.ToInt32(Console.ReadLine());
            if (option != 7) taskToPerform(option);
        } while (option != 7);
    }

    public static void taskToPerform(int option)
    {
        if(option == 1)
        {
            Console.WriteLine("Enter The Task");
            String taskToAdd = Console.ReadLine();
            Program.taskManager.AddTask(taskToAdd);
            
        }
        else if(option == 2)
        {
            Console.WriteLine("What Task To Delete");
            Program.taskManager.ViewTasks();
            int taskToDelete = Convert.ToInt32(Console.ReadLine());
            Program.taskManager.DeleteTask(taskToDelete - 1);
        }
        else if(option == 3)
        {
            Console.WriteLine(Program.taskManager.ViewTasks());
        }
        else if(option == 4)
        {
            Console.WriteLine("Enter Task To Complete");
            Console.WriteLine(Program.taskManager.ViewTasks());
            int taskToComplete = Convert.ToInt32(Console.ReadLine());
            Program.taskManager.CompleteTask(taskToComplete - 1);
        }
        else if(option == 5)
        {
            try
            {
                Program.taskManager.SaveToFile();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        else if(option == 6)
        {
            Program.taskManager.LoadFromFile();
        }
    }
}