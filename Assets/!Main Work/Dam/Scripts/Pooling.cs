using System.Collections.Generic;
using UnityEngine;

namespace _Main_Work.Dam.Scripts
{
    public class Pooling:MonoBehaviour
    {
        public GameObject objectToPool;
        public int amountToPool;
        public List<GameObject> pooledObjects;
        public GameObject poolContainer;

        private Transform originalTransform;
        public void Init(GameObject objectToPool, int amountToPool, GameObject poolContainer )
        {
            this.objectToPool = objectToPool;
            this.amountToPool = amountToPool;
            this.poolContainer = poolContainer;
            this.originalTransform = this.objectToPool.transform;
            DoPooling();
        }
        
        private void DoPooling()
        {
            pooledObjects = new List<GameObject>();
            for (int i = 0; i < amountToPool; i++)
            {
                print("add object");
                GameObject obj = Instantiate(objectToPool, transform.position, objectToPool.transform.rotation);
                obj.transform.parent = poolContainer.transform;
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }


        public GameObject GetActivateObject(Vector3 activePosition)
        {
            var objectToActive = GetPooledObject();
            objectToActive.transform.position = activePosition;
            objectToActive.transform.rotation = originalTransform.rotation;
            objectToActive.SetActive(true);
            return objectToActive;
        }
        
        public void UnActiveAObject(GameObject obj)
        {
            obj.SetActive(false);
        }

        private GameObject GetPooledObject()
        {
            for (int i = 0; i < pooledObjects.Count; i++)
            {
                if (!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }
            GameObject obj = Instantiate(objectToPool, transform.position, objectToPool.transform.rotation);
            obj.transform.parent = poolContainer.transform;
            obj.SetActive(false);
            pooledObjects.Add(obj);
            return obj;
        }
    }
}