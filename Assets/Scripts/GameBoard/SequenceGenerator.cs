using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceGenerator {

    private List<Operation> _operations;

    public SequenceGenerator(List<Operation> operations) {
        _operations = operations;
    }

    public Sequence Generate() {
        OperationProvider provider = ApplyRandomOperation();
        bool isRightHandIncluded = IsRightHandIncluded();

        string leftHand = provider.ToString();
        string rightHand = (isRightHandIncluded ? provider.Solution : GenerateRightHand(provider.Solution)).ToString();

        return new Sequence(leftHand, rightHand, isRightHandIncluded);
    }

    private OperationProvider ApplyRandomOperation() {
        int index = Random.Range(0, _operations.Count);
        return _operations[index].Generate();
    }

    private bool IsRightHandIncluded() {
        return Random.value > 0.5f;
    }

    private int GenerateRightHand(int val) {
        int result;

        do
        {
            result = Random.Range(val - 5, val + 5);
        } while (result == val);

        return result;
    }
}
