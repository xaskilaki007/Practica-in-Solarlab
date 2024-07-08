using System;
using todo_list;

namespace TodoListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TodoListManager todoListManager = new TodoListManager();

            string command;
            do
            {
                Console.WriteLine("Введите команду: add, list, done, delete, filter, save, load, exit");
                command = Console.ReadLine().ToLower();
                switch (command)
                {
                    case "add\n":
                        todoListManager.AddTask();
                        break;
                    case "list\n":
                        todoListManager.ListTasks();
                        break;
                    case "done\n":
                        todoListManager.MarkTaskAsDone();
                        break;
                    case "delete\n":
                        todoListManager.DeleteTask();
                        break;
                    case "filter\n":
                        todoListManager.FilterTasks();
                        break;
                    case "save\n":
                        todoListManager.SaveTasks();
                        break;
                    case "load\n":
                        todoListManager.LoadTasks();
                        break;
                }
            } while (command != "exit");
        }
    }
}
