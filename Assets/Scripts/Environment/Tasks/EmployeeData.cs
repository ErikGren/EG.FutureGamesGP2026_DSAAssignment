using System;
using System.Collections.Generic;



[Serializable]
public class EmployeeData {

    public EmployeeJson[] employees;
}

[Serializable]
public class Employee {

    public string name;

    public int employeeId;

    public bool hasEngineRoomClearance;

    public DateTime lastEntranceInEngineRoom;

    public DateTime lastExitFromEngineRoom;



}

[Serializable]
public class EmployeeJson {

    public string name;

    public int employeeId;

    public bool hasEngineRoomClearance;

    public string lastEntranceInEngineRoom;

    public string lastExitFromEngineRoom;


}
