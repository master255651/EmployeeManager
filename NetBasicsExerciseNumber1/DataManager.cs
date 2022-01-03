using NetBasicsExerciseNumber1.Enums;
using NetBasicsExerciseNumber1.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetBasicsExerciseNumber1
{
    class DataManager
    {
        public static List<Task> Tasks = new List<Task>();
        public static List<Employee> Employees = new List<Employee>();
        public static List<int> FibonacciNumbers = new List<int>() { 1, 2, 3, 5, 8, 13, 21};
        public static List<int> allowedNumbersForPriority = new List<int>() { 0, 1, 2 };

        public static void AddBasicInformation()
        {
            Task firstTask = new Task("AM .NET Jira", new DateTime(2021, 9, 20), new DateTime(2021, 9, 25),
                "Jira is a proprietary issue tracking product developed by Atlassian that allows bug tracking and agile project management.",
                TaskPriority.Medium, 13, true);
            Task secondTask = new Task("AM .NET C# Basics", new DateTime(2021, 9, 25), new DateTime(2021, 9, 26),
                "Jira is a proprietary issue tracking product developed by Atlassian that allows bug tracking and agile project management.",
                TaskPriority.High, 21, true);
            Employee firstEmployee = new Employee("Iurie", "Starenco", "I_Starenco");
            firstEmployee.AddTaskToEmployee(firstTask);
            Employee secondEmployee = new Employee("Olga", "Ungureanu", "O_Ungureanu");
            secondEmployee.AddTaskToEmployee(secondTask);
            DataManager.Tasks.Add(firstTask);
            DataManager.Tasks.Add(secondTask);
            DataManager.Employees.Add(firstEmployee);
            DataManager.Employees.Add(secondEmployee);
        }

        public static void AddNewEmployee(string name, string surname, string nickname)
        {
            Employee newEmployee = new Employee(name, surname, nickname);
            DataManager.Employees.Add(newEmployee);
        }

        public static void DeleteSelectedEmployee(Employee oldEmployee)
        {
            DataManager.Employees.Remove(oldEmployee);
        }

        public static void DeleteSelectedTask(Task oldTask)
        {
            DataManager.Tasks.Remove(oldTask);

            foreach(Employee employee in Employees)
            {
                for(int i = 0; i < employee.AllTasks.Count; i++)
                {
                    if (employee.AllTasks[i] == oldTask)
                    {
                        employee.AllTasks.RemoveAt(i);
                        employee.CalculateAllResolvedTaskCost();
                    }
                        
                }
            }
        }

        public static Employee GetEmployeeBySurname(string surname)
        {
            foreach(Employee employee in Employees)
            {
                if (Equals(employee.Surname, surname))
                    return employee;
            }
            return null;
        }

        public static void ChangeEmployeeInformation(Employee employeeToChange, string newName, string newSurname, string newNickname)
        {
            if(!Equals(newName, ""))
            {
                employeeToChange.Name = newName;
            }
            if (!Equals(newSurname, ""))
            {
                employeeToChange.Surname = newSurname;
            }
            if (!Equals(newNickname, ""))
            {
                employeeToChange.Nickname = newNickname;
            }
        }

        public static void ChangeTaskInformation(Task taskToChange, string newTaskName, DateTime creationDate,
            DateTime effectuationDate, string additionalDetails, TaskPriority priority, bool state, int TaskCost)
        {
            if (!Equals(newTaskName, ""))
                taskToChange.TaskName = newTaskName;
            if (!Equals(creationDate.ToShortDateString(), "01.01.0001"))
                taskToChange.CreationDate = creationDate;
            if (!Equals(effectuationDate.ToShortDateString(), "01.01.0001"))
                taskToChange.EffectuationDate = effectuationDate;
            if (!Equals(additionalDetails, ""))
                taskToChange.AdditionalDetails = additionalDetails;
            taskToChange.Priority = priority;
            taskToChange.State = state;
            taskToChange.TaskCost = TaskCost;
            RecalculationAllResolvedTaskCost();
        }

        public static Task GetTaskByName(string name)
        {
            foreach (Task task in Tasks)
            {
                if (Equals(task.TaskName, name))
                    return task;
            }
            return null;
        }

        public static void RecalculationAllResolvedTaskCost()
        {
            foreach(Employee employee in Employees)
            {
                employee.CalculateAllResolvedTaskCost();
            }
        }

        public static Task AddNewTask()
        {
            string taskName;
            string additionalDetails;
            int indexPriority = 0;
            int taskCost = 1;
            Console.Write("Enter a name for the new task: ");
            taskName = Console.ReadLine();
            Console.Write("Enter additional information: ");
            additionalDetails = Console.ReadLine();
            Console.Write("Enter priority (0 or 1 or 2): ");
            int enteredNumber = ConvertingString.StringToInt(Console.ReadLine());
            if (DataManager.allowedNumbersForPriority.Contains(enteredNumber))
            {
                indexPriority = enteredNumber;
            }
            TaskPriority priority = (TaskPriority)indexPriority;
            Console.Write("Enter task cost: ");
            taskCost = ConvertingString.StringToInt(Console.ReadLine());
            Task newTask = new Task(taskName, DateTime.Today, new DateTime(), additionalDetails, priority, taskCost, false);
            DataManager.Tasks.Add(newTask);
            return newTask;
        }

        public static void AddNewEmployee()
        {
            Console.Write("Enter the name of new employee: ");
            string name = Console.ReadLine();
            Console.Write("Enter the surname of new employee: ");
            string surname = Console.ReadLine();
            Console.Write("Enter the nickname of new employee: ");
            string nickname = Console.ReadLine();
            Console.WriteLine();
            DataManager.AddNewEmployee(name, surname, nickname);
        }

        public static void DeleteEmployee(Employee employee)
        {
            DataManager.DeleteSelectedEmployee(employee);
            Console.WriteLine("The selected employee was successfully deleted");
        }

        public static void DeleteTask(Task task)
        {
            DataManager.DeleteSelectedTask(task);
            Console.WriteLine("The selected task was successfully deleted");
        }

        public static void ChangeEmployeeInformation(Employee employee)
        {
            Console.WriteLine($"Old information: {employee.Name} {employee.Surname} ({employee.Nickname})");
            Console.Write("Enter new name of the employee (Press enter if you don't want to change): ");
            string name = Console.ReadLine();
            Console.Write("Enter new surname of the employee (Press enter if you don't want to change): ");
            string surname = Console.ReadLine();
            Console.Write("Enter new nickname of the employee (Press enter if you don't want to change): ");
            string nickname = Console.ReadLine();
            Console.WriteLine();
            DataManager.ChangeEmployeeInformation(employee, name, surname, nickname);
        }

        public static void ChangeTaskInformation(Task task)
        {
            string taskName;
            DateTime creationDate = new DateTime();
            DateTime effectuationDate = new DateTime();
            string additionalDetails;
            int indexPriority = 0;
            bool state = false;
            int taskCost = 1;
            Console.WriteLine($"Old information: {task.TaskName} {task.CreationDate.ToShortDateString()} {task.EffectuationDate.ToShortDateString()} {task.AdditionalDetails} {task.Priority} {task.State} {task.TaskCost}");
            Console.Write("Enter new task name (Press enter if you don't want to change): ");
            taskName = Console.ReadLine();
            Console.Write("Enter creation date (dd/mm/yyyy): ");
            creationDate = ConvertingString.StringToDateTime(Console.ReadLine());
            Console.Write("Enter effectuation date (dd/mm/yyyy): ");
            effectuationDate = ConvertingString.StringToDateTime(Console.ReadLine());
            Console.Write("Enter additional information (Press enter if you don't want to change): ");
            additionalDetails = Console.ReadLine();
            Console.Write("Enter priority (0 or 1 or 2): ");
            int enteredNumber = ConvertingString.StringToInt(Console.ReadLine());
            if (DataManager.allowedNumbersForPriority.Contains(enteredNumber))
            {
                indexPriority = enteredNumber;
            }
            TaskPriority priority = (TaskPriority)indexPriority;
            Console.Write("Enter task status (false or true): ");
            state = ConvertingString.StringToBoolean(Console.ReadLine());
            Console.Write("Enter task cost: ");
            taskCost = ConvertingString.StringToInt(Console.ReadLine());
            Console.WriteLine();
            DataManager.ChangeTaskInformation(task, taskName, creationDate, effectuationDate, additionalDetails, priority, state, taskCost);
        }
    }
}
