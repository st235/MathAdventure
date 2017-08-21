using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OperationsConfig : ScriptableObject
{
    private List<Operation> _operations = new List<Operation> {
        new Addition(), new Subtraction(),
        new Multiplication(), new Division()
    };

    public List<Operation> GetOperations() {
        return _operations;
    }
}
