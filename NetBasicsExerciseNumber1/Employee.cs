using System;
using System.Collections.Generic;
using System.Text;

namespace NetBasicsExerciseNumber1
{
    class Employee
    {
        private decimal _allResolvedTaskCost;

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        public List<Task> AllTasks { get; set; }
        public decimal AllResolvedTaskCost
        {
            get => _allResolvedTaskCost;
        }

        public Employee(string name, string surname, string nickname)
        {
            this.Name = name;
            this.Surname = surname;
            this.Nickname = nickname;
            this.AllTasks = new List<Task>();
        }

        public void AddTaskToEmployee(Task neededTask)
        {
            AllTasks.Add(neededTask);
            if(neededTask.State)
                CalculateAllResolvedTaskCost();
        }

        public string ShowInfoWithTasks(int i)
        {
            string infoString = $"{i}) {this.Name} {this.Surname} ({this.Nickname}) {this.AllResolvedTaskCost}\n";
            Task.ForeachTaskInfo(AllTasks, ref infoString);
            return infoString;
        }

        public void CalculateAllResolvedTaskCost()
        {
            _allResolvedTaskCost = 0;
            Task.ForeachTaskCost(AllTasks, ref _allResolvedTaskCost);
        }
    }
}
