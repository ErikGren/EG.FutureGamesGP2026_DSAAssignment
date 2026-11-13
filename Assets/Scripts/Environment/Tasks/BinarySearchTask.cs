using UnityEngine;
using System.Collections.Generic;
using Stopwatch = System.Diagnostics.Stopwatch;

namespace Environment.Tasks {

    [CreateAssetMenu(
        fileName = "BinarySearch Task",
        menuName = "BinarySearch Task"
    )]

    public class BinarySearchTask : Task {

        [SerializeField]
        private InsertEmployeesTask insertEmployeesTask;

        public override void Execute() {

            Employee[] employees = insertEmployeesTask.employees;

            if(employees == null || employees.Length == 0) {

                Debug.LogWarning("No employees found");
                return;

            }

            

            int startYear = 1970;
            int endYear = 1971;

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            List<Employee> matchingEmployees = BinarySearchRange(employees, startYear, endYear);

            stopwatch.Stop();

            Debug.Log("Employees found between 1970 and 1971:");




            foreach(Employee employee in matchingEmployees) {

                Debug.Log(

                    $"{employee.name}: {employee.lastEntranceInEngineRoom}"

                );

            }


            Debug.Log($"Total employees found: {matchingEmployees.Count}");


            Debug.Log(
                $"Binary Search execution time: " +
                $"{stopwatch.Elapsed.TotalMilliseconds} ms"
            );


        }


        private List<Employee> BinarySearchRange(

            Employee[] employees,
            int startYear,
            int endYear

        ) {

            List<Employee> results = new List<Employee>();

            int left = 0;
            int right = employees.Length;

            
            while(left < right) {

                int middle = left + (right - left) / 2;

                if(employees[middle].lastEntranceInEngineRoom.Year < startYear) {

                    left = middle + 1;

                }

                else {

                    right = middle;

                }


            }

            
            for(int i = left; i < employees.Length; i++) {

                int year = employees[i].lastEntranceInEngineRoom.Year;

                if(year > endYear) {
                    break;
                }

                results.Add(employees[i]);

            }

            return results;


        }


    }






}
