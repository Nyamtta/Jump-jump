using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;

public class ObjectPool :MonoBehaviour {
    public static ObjectPool Instans {get; private set;}

    [SerializeField] private List<GameObject> Pools; 

    private Dictionary<PoolTag.Tag, Queue<GameObject>> PoolDictionary; 

    private void Awake()
    {
        #region singlton
        if(Instans == null)
        {
            Instans = this;
        }
        else
        {
            Destroy(this);
        }
        #endregion

        PoolDictionary = new Dictionary<PoolTag.Tag, Queue<GameObject>>();

        foreach(var pool in Pools)
        {
            PoolDictionary.Add(pool.GetComponent<ObstacleControler>().GetTag(), new Queue<GameObject>());
        }

    }

    public GameObject GetObgectOfTag(PoolTag.Tag tag, Vector3 pos, Transform per, Quaternion rot)
    {
        if(PoolDictionary.ContainsKey(tag) == false)
        {
            print("Not Corect Tag");
            return null;
        }


        if(PoolDictionary[tag].Count == 0)
        {
            foreach(var pf in Pools)
            {
                if(tag == pf.GetComponent<ObstacleControler>().GetTag())
                {
                    return Instantiate(pf, pos, rot, per);
                }
            }
        }
        
        GameObject temp = PoolDictionary[tag].Dequeue();
        temp.SetActive(true);
        temp.transform.position = pos;
        temp.transform.rotation = rot;

        return temp;
    }

    public void ReturnToPool(GameObject obj)
    {
        ObstacleControler temp = obj.GetComponent<ObstacleControler>();
        if(temp == false)
        {
            Debug.Log("Not corect Object");
            return;
        }    

        obj.SetActive(false);
        PoolDictionary[temp.GetTag()].Enqueue(obj);
    }

}
