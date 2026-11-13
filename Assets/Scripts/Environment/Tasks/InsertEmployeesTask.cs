using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(
        fileName = "InsertEmployees Task",
        menuName = "InsertEmployees Task"
    )]
    public class InsertEmployeesTask : Task {
        [SerializeField]
        private LoadEmployeesTask loadEmployeesTask;

        public Employee[] employees = System.Array.Empty<Employee>();

        public override void Execute() {
            

            Employee[] loadedEmployees = loadEmployeesTask.employees;

            if(loadedEmployees == null) {
                Debug.LogError("No array");
                return;
            }

            employees = new Employee[loadedEmployees.Length];

            for(int i = 0; i < loadedEmployees.Length; i++) {

                employees[i] = loadedEmployees[i];

            }

            Debug.Log($"Inserted {employees.Length} employees into the array");
        }
    }




}
