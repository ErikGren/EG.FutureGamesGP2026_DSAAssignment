
using UnityEngine;
using System;
using System.Collections.Generic;
using Stopwatch = System.Diagnostics.Stopwatch;

namespace Environment.Tasks {

    [CreateAssetMenu(
        fileName = "BinarySearchTree Task",
        menuName = "BinarySearchTree Task"
    )]

    public class BinarySearchTreeTask : Task {

        [SerializeField]
        private InsertEmployeesTask insertEmployeesTask;

        
        private class Node {

            public DateTime date;
            public List<Employee> employees;

            public Node left;
            public Node right;

            public Node(Employee employee) {

                date = employee.lastEntranceInEngineRoom;

                employees = new List<Employee>();
                employees.Add(employee);
            }
        }

        private Node root;


        public override void Execute() {

            Employee[] employees = insertEmployeesTask.employees;

            if(employees == null || employees.Length == 0) {

                Debug.LogWarning("No employees found");

                return;


            }

            

            root = null;

            Stopwatch buildTimer = new Stopwatch();

            buildTimer.Start();


            foreach(Employee employee in employees) {

                root = InsertNode(root, employee);

            }

            buildTimer.Stop();

            Debug.Log("BinarySearch Tree created");

            Debug.Log($"Tree grow time: " + $"{buildTimer.Elapsed.TotalMilliseconds} ms");


            

            DateTime startDate = new DateTime(1970, 1, 1);
            DateTime endDate = new DateTime(1972, 1, 1);

            Stopwatch treeTimer = new Stopwatch();

            treeTimer.Start();

            List<Employee> treeResults =
                SearchRange(root, startDate, endDate);

            treeTimer.Stop();


            Debug.Log("Search results:");

            foreach(Employee employee in treeResults) {

                Debug.Log($"{employee.name}: {employee.lastEntranceInEngineRoom}");
            }

            Debug.Log($"Employees found: {treeResults.Count}");

            Debug.Log($"Search time: " + $"{treeTimer.Elapsed.TotalMilliseconds} ms");


            

            Employee[] sortedEmployees = (Employee[])employees.Clone();

            Array.Sort(sortedEmployees, (a, b) =>a.lastEntranceInEngineRoom.CompareTo(b.lastEntranceInEngineRoom ));

            Stopwatch arrayTimer = new Stopwatch();

            arrayTimer.Start();

            List<Employee> arrayResults = BinarySearchRange(
                sortedEmployees,
                startDate,
                endDate
            );

            arrayTimer.Stop();

            Debug.Log($"Search time: " + $"{arrayTimer.Elapsed.TotalMilliseconds} ms");

            Debug.Log($"Employees found: {arrayResults.Count}");
        }


        

        private Node InsertNode(Node node, Employee employee) {

            if(node == null) {

                return new Node(employee);

            }

            DateTime employeeDate = employee.lastEntranceInEngineRoom;

            int comparison = employeeDate.CompareTo(node.date);

            if(comparison < 0) {

                node.left = InsertNode(node.left, employee);

            }

            else if(comparison > 0) {

                node.right = InsertNode(node.right, employee);

            }

            else {

                node.employees.Add(employee);

            }

            return node;



        }


        

        private List<Employee> SearchRange(
            Node node,
            DateTime startDate,
            DateTime endDate
        ) {

            List<Employee> results = new List<Employee>();

            SearchRangeRecursive(

                node,
                startDate,
                endDate,
                results

            );

            return results;


        }


        private void SearchRangeRecursive(
            Node node,
            DateTime startDate,
            DateTime endDate,
            List<Employee> results
        ) {

            if(node == null) {

                return;

            }

            if(node.date >= startDate) {

                SearchRangeRecursive(
                    node.left,
                    startDate,
                    endDate,
                    results
                );

            }

            if(node.date >= startDate && node.date < endDate) {

                results.AddRange(node.employees);

            }

            if(node.date < endDate) {

                SearchRangeRecursive(
                    node.right,
                    startDate,
                    endDate,
                    results
                );
            }

        }


        

        private List<Employee> BinarySearchRange(
            Employee[] employees,
            DateTime startDate,
            DateTime endDate
        ) {

            List<Employee> results = new List<Employee>();

            int left = 0;
            int right = employees.Length;

            while(left < right) {

                int middle = left + (right - left) / 2;

                if(employees[middle].lastEntranceInEngineRoom < startDate) {

                    left = middle + 1;

                }

                else {

                    right = middle;

                }


            }

            for(int i = left; i < employees.Length; i++) {

                DateTime date = employees[i].lastEntranceInEngineRoom;

                if(date >= endDate) {

                    break;

                }

                results.Add(employees[i]);

            }

            return results;


        }
    }


}
