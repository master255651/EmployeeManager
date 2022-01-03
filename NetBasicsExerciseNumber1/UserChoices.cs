using System;
using System.Collections.Generic;
using System.Text;

namespace NetBasicsExerciseNumber1
{
    class UserChoices
    {
        static string subMenuInfo = "\nSubMenu:\n1)Show all tasks of chosen Employee\n2)Add task to chosen Employee" +
    "\n3)Complete one of current Employee’s tasks\n4)Exit from SubMenu\n\nSelect a SubMenu item: ";

        public static void ShowEmployees()
        {
            int counter = 1;
            foreach (Employee employee in DataManager.Employees)
            {
                Console.WriteLine(employee.ShowInfoWithTasks(counter++));
            }
        }

        public static void AddNewEmployee()
        {
            DataManager.AddNewEmployee();
        }

        public static void DeleteEmployee()
        {
            Console.Write("Enter the name of the employee you want to remove: ");
            Employee selectedEmployee = DataManager.GetEmployeeBySurname(Console.ReadLine());
            if (selectedEmployee == null)
            {
                Console.WriteLine("Employee with this name does not exist.");
            }
            else
            {
                DataManager.DeleteEmployee(selectedEmployee);
            }
        }

        public static void SelectEmployee()
        {
            Console.Write("Enter the name of the employee you want to select: ");
            Employee selectedEmployee = DataManager.GetEmployeeBySurname(Console.ReadLine());
            if (selectedEmployee == null)
            {
                Console.WriteLine("Employee with this name does not exist.");
                return;
            }
            while (true)
            {
                Console.Write(subMenuInfo);
                var userChoice = Console.ReadKey();
                Console.WriteLine();
                switch (userChoice.KeyChar)
                {
                    case '1':
                        {
                            Console.WriteLine(selectedEmployee.ShowInfoWithTasks(1));
                        }
                        break;
                    case '2':
                        {
                            selectedEmployee.AddTaskToEmployee(DataManager.AddNewTask());
                        }
                        break;
                    case '3':
                        {
                            Console.Write("Enter the name of the task you want to complete: ");
                            Task selectedTask = DataManager.GetTaskByName(Console.ReadLine());
                            if (selectedTask == null)
                            {
                                Console.WriteLine("Task with this name does not exist.");
                            }
                            else
                            {
                                selectedTask.ChangeTaskState();
                                Console.WriteLine("Task status has been successfully changed.");
                            }
                        }
                        break;
                    case '4':
                        {
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("You entered the wrong value!");
                        }
                        break;
                }
            }
        }

        public static void ModifyEmployee()
        {
            Console.Write("Enter the name of the employee you want to change: ");
            Employee selectedEmployee = DataManager.GetEmployeeBySurname(Console.ReadLine());
            if (selectedEmployee == null)
            {
                Console.WriteLine("Employee with this name does not exist.");
                return;
            }
            DataManager.ChangeEmployeeInformation(selectedEmployee);
        }

        public static void ChangeTaskData()
        {
            Console.Write("Enter the name of the task you want to change: ");
            Task selectedTask = DataManager.GetTaskByName(Console.ReadLine());
            if (selectedTask == null)
            {
                Console.WriteLine("Task with this name does not exist.");
                return;
            }
            DataManager.ChangeTaskInformation(selectedTask);
        }

        public static void DeleteTask()
        {
            Console.Write("Enter the name of the task you want to delete: ");
            Task selectedTask = DataManager.GetTaskByName(Console.ReadLine());
            if (selectedTask == null)
            {
                Console.WriteLine("Task with this name does not exist.");
                return;
            }
            else
            {
                DataManager.DeleteTask(selectedTask);
            }
        }
    }
}
