using NetBasicsExerciseNumber1.Enums;
using NetBasicsExerciseNumber1.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetBasicsExerciseNumber1
{
    class MenuManager
    {
        static string menuInfo = "Menu:\n1)Show all employees\n2)Add new employee\n3)Delete employee" +
            "\n4)Select a specific employee\n5)Modify employee data\n" +
            "6)Change task data\n7)Delete task\n8)Exit from application\n\nSelect a menu item: ";

        public static void OnStart()
        {
            DataManager.AddBasicInformation();
            ShowMenu();
        }

        static void ShowMenu()
        {
            Console.Write(menuInfo);
            var userChoice = Console.ReadKey();
            Console.WriteLine();
            switch (userChoice.KeyChar)
            {
                case '1':
                    {
                        UserChoices.ShowEmployees();
                    }
                    break;
                case '2':
                    {
                        UserChoices.AddNewEmployee();
                    }
                    break;
                case '3':
                    {
                        UserChoices.DeleteEmployee();
                    }
                    break;
                case '4':
                    {
                        UserChoices.SelectEmployee();
                    }
                    break;
                case '5':
                    {
                        UserChoices.ModifyEmployee();
                    }
                    break;
                case '6':
                    {
                        UserChoices.ChangeTaskData();
                    }
                    break;
                case '7':
                    {
                        UserChoices.DeleteTask();
                    }
                    break;
                case '8':
                    {
                        return;
                    }
                default:
                    {
                        Console.WriteLine("You entered the wrong value!");
                    }
                    break;
            }

            ShowMenu();
        }

    }
}
