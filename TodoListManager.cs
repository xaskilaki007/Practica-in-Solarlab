using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TodoListApp
{
    public class TodoListManager
    {
        private List<TodoItem> todoList = new List<TodoItem>();
        private const string filePath = "todoList.txt";

        public void AddTask()
        {
            Console.WriteLine("Введите описание задачи:");
            string description = Console.ReadLine();
            todoList.Add(new TodoItem { Description = description, IsCompleted = false });
            Console.WriteLine("Задача добавлена.");
        }

        public void ListTasks()
        {
            if (todoList.Count == 0)
            {
                Console.WriteLine("Список задач пуст.");
            }
            else
            {
                Console.WriteLine("Список задач:");
                for (int i = 0; i < todoList.Count; i++)
                {
                    var task = todoList[i];
                    Console.WriteLine($"{i + 1}. [{(task.IsCompleted ? "X" : " ")}] {task.Description}");
                }
            }
        }

        public void MarkTaskAsDone()
        {
            Console.WriteLine("Введите номер выполненной задачи:");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= todoList.Count)
            {
                todoList[index - 1].IsCompleted = true;
                Console.WriteLine("Задача отмечена как выполненная.");
            }
            else
            {
                Console.WriteLine("Неверный номер задачи.");
            }
        }

        public void DeleteTask()
        {
            Console.WriteLine("Введите номер задачи для удаления:");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= todoList.Count)
            {
                todoList.RemoveAt(index - 1);
                Console.WriteLine("Задача удалена.");
            }
            else
            {
                Console.WriteLine("Неверный номер задачи.");
            }
        }

        public void FilterTasks()
        {
            Console.WriteLine("Введите фильтр (done или notdone):");
            string filter = Console.ReadLine().ToLower();
            List<TodoItem> filteredList = filter switch
            {
                "done" => todoList.Where(t => t.IsCompleted).ToList(),
                "notdone" => todoList.Where(t => !t.IsCompleted).ToList(),
                _ => null
            };

            if (filteredList != null)
            {
                Console.WriteLine("Отфильтрованный список задач:");
                for (int i = 0; i < filteredList.Count; i++)
                {
                    var task = filteredList[i];
                    Console.WriteLine($"{i + 1}. [{(task.IsCompleted ? "X" : " ")}] {task.Description}");
                }
            }
            else
            {
                Console.WriteLine("Неверный фильтр.");
            }
        }

        public void SaveTasks()
        {
            using StreamWriter writer = new StreamWriter(filePath);
            foreach (var task in todoList)
            {
                writer.WriteLine($"{task.Description}|{task.IsCompleted}");
            }
            Console.WriteLine("Список задач сохранен.");
        }

        public void LoadTasks()
        {
            if (File.Exists(filePath))
            {
                todoList.Clear();
                string[] lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    todoList.Add(new TodoItem { Description = parts[0], IsCompleted = bool.Parse(parts[1]) });
                }
                Console.WriteLine("Список задач загружен.");
            }
            else
            {
                Console.WriteLine("Файл со списком задач не найден.");
            }
        }
    }
}
