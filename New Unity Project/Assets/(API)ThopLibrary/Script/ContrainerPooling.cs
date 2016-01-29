using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ContrainerPooling : MonoBehaviour
{
    public string nameSetPool;
    public GameObject objPool;
    public int countPool;
    List<GameObject> pooledObjects;
    public Transform PositionInst;
    public bool onNewPosition = true;
    public bool onNewRotation = true;
    void Start()
    {
        SetUpPooling();
    }

    public void SetUpPooling()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < countPool; i++)
        {
            GameObject obj = (GameObject)Instantiate(this.objPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
        //ApiThop.Debug("Create " + nameSetPool + " Pooling Complete..");
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                if (onNewPosition)
                    pooledObjects[i].transform.position = PositionInst.transform.position;
                if (onNewRotation)
                    pooledObjects[i].transform.rotation = PositionInst.transform.rotation;
                return pooledObjects[i];
            }
        }
        GameObject obj = (GameObject)Instantiate(this.objPool);
        pooledObjects.Add(obj);
        if (onNewPosition)
            obj.transform.position = PositionInst.transform.position;
        if (onNewRotation)
            obj.transform.rotation = PositionInst.transform.rotation;
        countPool++;
        return obj;
    }
    public void ReLoad()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i].activeInHierarchy)
                pooledObjects[i].SetActive(false);
        }

    }

}
