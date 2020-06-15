using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;

public class ObjectPool :MonoBehaviour {

    [SerializeField] private List<Pool> Pools; 

    public static ObjectPool Instans {get; private set;}

    private Dictionary<string, Queue<GameObject>> PoolDictionary; 

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

        PoolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(var pool in Pools)
        {
            Queue<GameObject> prifab = new Queue<GameObject>();
            prifab.Enqueue(pool.prifab);

            PoolDictionary.Add(pool.tag, new Queue<GameObject>());
        }

    }

    public GameObject GetObgectOfTag(string tag, Vector3 pos = default, Transform per = default, Quaternion rot = default)
    {
        if(PoolDictionary.ContainsKey(tag) == false)
        {
            return null;
        }


        if(PoolDictionary[tag].Count == 0)
        {
            foreach(var pf in Pools)
            {
                if(tag == pf.tag)
                {
                    return Instantiate(pf.prifab, pos, rot, per);
                }
            }
        }
        
        GameObject temp = PoolDictionary[tag].Dequeue();
        temp.SetActive(true);
        temp.transform.position = pos;
        temp.transform.rotation = rot;

        return temp;
    }

    public void ReturnToPool(string tag, GameObject obj)
    {

        if(PoolDictionary.ContainsKey(tag) == false)
        {
            Debug.Log("Not corect tag");
            return;
        }    

        obj.SetActive(false);
        PoolDictionary[tag].Enqueue(obj);
    }



    [System.Serializable]
    public class Pool {

        public GameObject prifab;
        public string tag;
        public int size;
    }
}
