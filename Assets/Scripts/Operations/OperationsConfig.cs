using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OperationsConfig : ScriptableObject
{
    private List<Operation> _operations = new List<OperationsConfig>() {
        new Additon()
    };

    public List<Operation> GetOperations() {
        return _operations;
    }
}
