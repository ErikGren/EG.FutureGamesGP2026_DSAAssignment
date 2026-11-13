using System.Collections.Generic;
using UnityEngine;
using Environment.Tasks;

namespace Environment {
    public class TaskStack : MonoBehaviour {
        [SerializeField]
        private List<Task> tasks = new List<Task>();

        public void Push(Task task) {
            if(task != null) {
                tasks.Add(task);
            }
        }

        public Task Pop() {
            if(tasks.Count == 0) {
                Debug.Log("No tasks left!");
                return null;
            }

            int lastTask = tasks.Count - 1;
            Task task = tasks[lastTask];

            tasks.RemoveAt(lastTask);

            return task;
        }

        public Task Peek() {
            if(tasks.Count == 0) {
                return null;
            }

            return tasks[tasks.Count - 1];
        }

        
    }
}
