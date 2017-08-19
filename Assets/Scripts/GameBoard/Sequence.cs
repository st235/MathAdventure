using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence {
    
    public string LeftHand { get; private set; }
    public string RightHand { get; private set; }

    public bool Fair { get; private set; }

    public Sequence(string leftHand, string rightHand, bool fair) {
        LeftHand = leftHand;
        RightHand = rightHand;
        Fair = fair;
    }

    public override string ToString()
    {
        return string.Format("{0}\n=\n{1}", LeftHand, RightHand);
    }
}
