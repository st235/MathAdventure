using UnityEngine;
using System.Collections;

public class OperationProvider
{
    public int FirstFactor { get; private set; }
    public int SecondFactor { get; private set; }
    public int Solution { get; private set; }
    public char Sign { get; private set; }

    public OperationProvider(int firstFactor, 
                             int secondFactor,
                             int solution,
                             char sign) {
        FirstFactor = firstFactor;
        SecondFactor = secondFactor;
        Solution = solution;
        Sign = sign;
    }

    public override string ToString()
    {
        return string.Format("{0}{1}{2}", FirstFactor, Sign, SecondFactor);
    }
}
