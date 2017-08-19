using UnityEngine;
using System.Collections;

public interface Operation
{
    char GetSign();
    OperationProvider Generate();
}
