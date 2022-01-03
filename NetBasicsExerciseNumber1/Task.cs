using System;
using NetBasicsExerciseNumber1.Enums;
using System.Collections.Generic;
using System.Text;

namespace NetBasicsExerciseNumber1
{
    class Task
    {
        private int _taskCost = 1;

        public string TaskName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EffectuationDate { get; set; }
        public string AdditionalDetails { get; set; }
        public TaskPriority Priority { get; set; }
        public bool State { get; set; }
        public int TaskCost
        {
            get => _taskCost;
            set
            {
                if (DataManager.FibonacciNumbers.Contains(value))
                {
                    _taskCost = value;
                }
            }
        }

        public Task(string taskName, DateTime creationDate, DateTime effectuationDate,
            string additionalDetails, TaskPriority priority, int taskCost, bool state)
        {
            this.TaskName = taskName;
            this.CreationDate = creationDate;
            this.EffectuationDate = effectuationDate;
            this.AdditionalDetails = additionalDetails;
            this.Priority = priority;
            this.TaskCost = taskCost;
            this.State = state;
        }

        public string ShowInfo(int i)
        {
            string infoString = $"{i}) {this.TaskName} {this.CreationDate.ToShortDateString()} {this.EffectuationDate.ToShortDateString()}" +
                $" {this.Priority} {this.State} {this.TaskCost}\n";
            return infoString;
        }

        public void ChangeTaskState()
        {
            this.State = true;
            this.EffectuationDate = DateTime.Today;
            DataManager.RecalculationAllResolvedTaskCost();
        }

        public static void ForeachTaskInfo(List<Task> tasks, ref string infoString)
        {
            int counter = 1;
            foreach (Task task in tasks)
            {
                infoString += "\t" + task.ShowInfo(counter++);
            }
        }

        public static void ForeachTaskCost(List<Task> tasks, ref decimal allResolvedTaskCost)
        {
            foreach (Task task in tasks)
            {
                if (task.State)
                {
                    allResolvedTaskCost += task.TaskCost;
                }
            }
        }
    }
}
