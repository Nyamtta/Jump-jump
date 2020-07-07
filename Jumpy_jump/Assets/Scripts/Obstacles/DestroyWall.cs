using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<ObstacleControler>() == false)
            return;

        ObjectPool.Instans.ReturnToPool(collision.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

}
