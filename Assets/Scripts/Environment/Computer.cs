using Environment.Tasks;
using UnityEngine;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        [SerializeField]
        private TaskStack taskStack;

        public void OnInteract() {
            if(taskStack == null) {

                return;
            }

            Task task = taskStack.Pop();

            if(task != null) {
                task.Execute();
            }
        }
    }
}

