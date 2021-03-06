using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    /// <summary>
    /// An object pooler creates a collection (_PoolSize) of GameObjects (_ObjectPrefab) and stores them in a named Object Pooler (_ObjectPoolerName) during start up. 
    /// During runtime other Gameobjects should use the named GameObject functions (GetGameObjectFromPool) to retrieve a reference to a generated gameobject.
    ///
    /// Note: Object Pooler will expand upward if needed. 
    /// </summary>


    [SerializeField] protected GameObject _ObjectPrefab;
    [SerializeField] protected int _PoolSize = 10;
    [SerializeField] protected string _ObjectPoolerName;

    protected GameObject _ParentPooledObject;
    protected List<GameObject> _PooledObjects;

    //public string ObjectPoolerName { get => _ObjectPoolerName; set => _ObjectPoolerName = value; }
    public GameObject ParentPoolObject { get => _ParentPooledObject; set => _ParentPooledObject = value; }
    public List<GameObject> PooledObjects { get => _PooledObjects; set => _PooledObjects = value; }
    public int PoolSize {get => _PoolSize; set => _PoolSize = value; }

    protected void Start()
    {
        ParentPoolObject = new GameObject(ObjectPoolerName());
        ParentPoolObject.AddComponent(typeof(Savable));
        Refill();
    }

    protected void Refill(){
        if(PooledObjects == null){
            PooledObjects = new List<GameObject>();
            for (int i = 0; i < _PoolSize; i++)
            {
                AddGameObjectToPool();
            }
        }
    }

    protected void AddGameObjectToPool(){
        GameObject newObject = Instantiate(_ObjectPrefab, _ParentPooledObject.transform);
        newObject.SetActive(false);
        _PooledObjects.Add(newObject);
    } 

    protected virtual string ObjectPoolerName(){
        if(_ObjectPoolerName != "") return _ObjectPoolerName + "_ObjectPooler";
        return "BrokenObjectPooler";
    }

    public GameObject GetGameObjectFromPool(){
        for (int i = 0; i < _PooledObjects.Count; i++)
        {
            // Check if the pooledObject is already active, if it isn't;
            if (!_PooledObjects[i].activeInHierarchy)
            {
                return _PooledObjects[i];
            }
        
            if (i == _PooledObjects.Count - 2)
            {
                AddGameObjectToPool();
            }
        }

        return null;
    }
}
