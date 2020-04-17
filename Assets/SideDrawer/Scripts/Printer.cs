using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Printer : MonoBehaviour
{
    public void Print()
    {
        Debug.Log("OnClick " + gameObject.name);
    }
}
