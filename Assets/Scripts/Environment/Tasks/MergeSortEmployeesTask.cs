using UnityEngine;

namespace Environment.Tasks {

    [CreateAssetMenu(
        fileName = "MergeSort Employees Task",
        menuName = "MergeSort Employees Task"

    )]
    public class MergeSortEmployeesTask : Task {
        [SerializeField]
        private InsertEmployeesTask insertEmployeesTask;

        public override void Execute() {

            
            Employee[] employees = insertEmployeesTask.employees;

            if(employees == null) {

                Debug.LogWarning("No employees");
                return;


            }


            MergeSort(employees, 0, employees.Length - 1);

            Debug.Log("Employees sorted");

            foreach(Employee employee in employees) {

                Debug.Log($"{employee.name}: {employee.lastEntranceInEngineRoom}");
            }


        }

        private void MergeSort(Employee[] employees, int left, int right) {

            if(left >= right) {
                return;
            }

            int middle = left + (right - left) / 2;

            MergeSort(employees, left, middle);

            MergeSort(employees, middle + 1, right);

            Merge(employees, left, middle, right);


        }





        private void Merge(

            Employee[] employees,
            int left,
            int middle,
            int right

        ) {
            int leftSize = middle - left + 1;
            int rightSize = right - middle;

            Employee[] leftArray = new Employee[leftSize];
            Employee[] rightArray = new Employee[rightSize];

            for(int i = 0; i < leftSize; i++) {

                leftArray[i] = employees[left + i];

            }

            for(int j = 0; j < rightSize; j++) {

                rightArray[j] = employees[middle + 1 + j];

            }



            int leftIndex = 0;
            int rightIndex = 0;
            int mergedIndex = left;

            while(leftIndex < leftSize && rightIndex < rightSize) {

                if(leftArray[leftIndex].lastEntranceInEngineRoom <= rightArray[rightIndex].lastEntranceInEngineRoom) {

                    employees[mergedIndex] = leftArray[leftIndex];

                    leftIndex++;

                }

                else {
                    employees[mergedIndex] = rightArray[rightIndex];

                    rightIndex++;
                }

                mergedIndex++;
            }

            while(leftIndex < leftSize) {

                employees[mergedIndex] = leftArray[leftIndex];
                leftIndex++;
                mergedIndex++;

            }

            while(rightIndex < rightSize) {

                employees[mergedIndex] = rightArray[rightIndex];
                rightIndex++;
                mergedIndex++;

            }
        }
    }
}
