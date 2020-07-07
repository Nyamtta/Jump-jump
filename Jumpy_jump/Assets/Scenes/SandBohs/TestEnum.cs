using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnum : MonoBehaviour
{
    public enum TestEnume { One }

    Dictionary<string, int> te = new Dictionary<string, int>();

    private void Start()
    {


    }

    private void PrintEnum(TestEnume t)
    {
        print(t);
    }

    

}
