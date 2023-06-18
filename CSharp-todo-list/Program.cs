using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            TodoList todo = new TodoList();

            bool exitFlag = false;

            List<String> todoItems = todo.GetTodos();

            while (!exitFlag)
            {
                todo.DisplayOptions();
                string optionsInputted = Console.ReadLine();

                switch (optionsInputted)
                {
                    case "1":
                        // Add Todo option
                        Console.WriteLine("Please add Todo.");
                        String value = Console.ReadLine();
                        bool addResult = todo.AddTodo(value);
                        if (addResult)
                        {
                            Console.WriteLine("Todo added successfully!");
                            todoItems = todo.GetTodos(); // Update todoItems after adding a todo
                            Console.WriteLine("");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add todo.");
                        }
                        break;

                    case "2":
                        // Get Todo's option
                        if (todoItems == null || todoItems.Count == 0)
                        {
                            Console.WriteLine("There are no Todos");
                            Console.WriteLine("");
                            optionsInputted = null; // Clear options input to display menu again
                        }
                        else
                        {
                            Console.WriteLine("");
                            todo.ListTodos();
                            Console.WriteLine("");
                        }
                        break;

                    case "3":
                        // Remove Todo option
                        if (todoItems == null || todoItems.Count == 0)
                        {
                            Console.WriteLine("There are no Todos to remove");
                            Console.WriteLine("");
                            optionsInputted = null; // Clear options input to display menu again
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Please select the Todo number you would like to remove");
                            todo.ListTodos();
                            int todoSelected = int.Parse(Console.ReadLine());
                            todoSelected -= 1;
                            bool removeResult = todo.RemoveTodo(todoSelected);
                            if (removeResult)
                            {
                                Console.WriteLine("Todo removed successfully!");
                                todoItems = todo.GetTodos(); // Update todoItems after removing a todo
                            }
                            else
                            {
                                Console.WriteLine("Invalid index or failed to remove the Todo.");
                            }
                        }
                        break;

                    case "4":
                        // Exit option
                        exitFlag = true;
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
        }
    }

    class TodoList
    {
        private List<String> tasks;

        public TodoList()
        {
            tasks = new List<string>();
        }

        public void DisplayOptions()
        {
            Console.WriteLine("1. Add Todo");
            Console.WriteLine("2. Get Todos");
            Console.WriteLine("3. Remove Todo");
            Console.WriteLine("4. Exit Todos");
        }

        public bool AddTodo(string input)
        {
            try
            {
                tasks.Add(input);
                return true; // Task added successfully
            }
            catch (Exception)
            {
                return false; // Failed to add task
            }
        }

        public List<String> GetTodos()
        {
            return tasks;
        }

        public bool RemoveTodo(int index)
        {
            try
            {
                if (index >= 0 && index < tasks.Count)
                {
                    tasks.RemoveAt(index);
                    return true; // Task removed successfully
                }
                else
                {
                    return false; // Invalid index
                }
            }
            catch (Exception)
            {
                return false; // Failed to remove task
            }
        }

        public void ListTodos()
        {
            Console.WriteLine("Todo List:");
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }
    }
}
