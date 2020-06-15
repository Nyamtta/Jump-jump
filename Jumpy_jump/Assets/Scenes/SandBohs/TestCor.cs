using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCor : MonoBehaviour
{
    public float ds;

    private void Start()
    {
        StartCoroutine(Test(ds)); 
    }

    private IEnumerator Test(float s)
    {
        print(1);
        yield return new WaitForSeconds(s);
        print(0);
        yield return StartCoroutine(Test(s));
    }
        

}
