using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTriangle : MonoBehaviour
{

    [SerializeField] private float MovSpeed;
    [SerializeField] private string Tag; 

    private void FixedUpdate()
    {
        Mov();
    }

    private void Mov()
    {
        transform.position += Vector3.left * MovSpeed * Time.deltaTime; 
    }

    public string GetTag()
    {
        return tag;
    }

    public Vector3 GetLowerPosition()
    {
        Vector3 pos = new Vector3(0f, GetComponent<SpriteRenderer>().bounds.max.y, 0f);
        return pos;
    }

}
