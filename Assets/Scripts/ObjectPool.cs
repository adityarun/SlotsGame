using DevCommon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolItem
{
    public GameObject Prefab;
}
public class ObjectPool : Singleton<ObjectPool>
{
    public List<PoolItem> PoolItems = new List<PoolItem>();
    
    public static GameObject Spawn(int index)
    {
        GameObject obj = null;

        for (int i = 0; i <  ObjectPool.Instance.PoolItems.Count; i++)
        {
            if (i == index)
                obj = ObjectPool.Instance.PoolItems[i].Prefab;
        }

        return obj;
    }
}
