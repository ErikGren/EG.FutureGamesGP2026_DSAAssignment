using System;
using UnityEngine;


namespace Environment.Tasks {
    [CreateAssetMenu(
        fileName = "LoadEmployees Task",
        menuName = "LoadEmployees Task"
    )]




    public class LoadEmployeesTask : Task {
        [SerializeField]
        private TextAsset jsonFile;

        public Employee[] employees = Array.Empty<Employee>();

        public override void Execute() {

            EmployeeData data;

            try {
                data = JsonUtility.FromJson<EmployeeData>(jsonFile.text);
            }
            catch(Exception e) {
                Debug.LogError($"Failed to parse JSON: {e.Message}");
                return;
            }


            Employee[] loadedEmployees = new Employee[data.employees.Length];

            for(int i = 0; i < data.employees.Length; i++) {

                EmployeeJson source = data.employees[i];

                try {

                    loadedEmployees[i] = new Employee {
                        name = source.name,

                        employeeId = source.employeeId,

                        hasEngineRoomClearance = source.hasEngineRoomClearance,

                        lastEntranceInEngineRoom = DateTime.Parse(source.lastEntranceInEngineRoom),

                        lastExitFromEngineRoom = DateTime.Parse(source.lastExitFromEngineRoom)

                    };
                }

                catch(Exception e) {
                    Debug.LogError(
                        $"Failed to parse {i}: {e.Message}"
                    );
                    return;
                }
            }

            employees = loadedEmployees;

            Debug.Log($"Loaded {employees.Length} employees");
        }
    }



}
