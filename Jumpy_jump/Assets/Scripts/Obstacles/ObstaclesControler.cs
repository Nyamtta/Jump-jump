using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesControler : MonoBehaviour
{

    [SerializeField] GameObject[] ObstaclesPrifabs;
    [SerializeField] Transform[] InstantiatePoint;
    [SerializeField] float InstactiateTime;

    private float ConstantTime;

    private void Start()
    {
        ConstantTime = InstactiateTime;
    }

    private void Update()
    {
        InstactiateTime -= Time.deltaTime;
        if(InstactiateTime <= 0)
        {
            InstactiateTime = ConstantTime;
            CreateObstacles();
        }
    }

    private void CreateObstacles()
    {
        var obs = Instantiate(ObstaclesPrifabs[Random.Range(0, ObstaclesPrifabs.Length)], InstantiatePoint[Random.Range(0, InstantiatePoint.Length)].position, Quaternion.identity, transform);
    }
}
