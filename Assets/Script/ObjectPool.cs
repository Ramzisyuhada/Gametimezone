using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public List<GameObject> objects;
    public GameObject objectToPool;
    public int amountToPool;
    private void Awake()
    {
        instance = this;

    }

    void Start()
    {
        GameObject lsr;
        objects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            lsr = Instantiate(objectToPool);
            lsr.SetActive(false);
            objects.Add(lsr);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!objects[i].activeInHierarchy)
            {
                return objects[i];
            }
        }
        return null;

    }

}
