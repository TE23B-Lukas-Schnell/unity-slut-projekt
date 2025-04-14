using System.Collections.Generic;
using UnityEngine;

public class UsableObejctController : MonoBehaviour
{
    [SerializeField]
    GameObject objectPrefab;

    public void PickedUp(List<GameObject> listToAdd)
    {
        listToAdd.Add(objectPrefab);
        Destroy(gameObject);
    }

    void Start()
    {
        objectPrefab = Resources.Load<GameObject>("Prefabs/sphereObject");
    }


    void Update()
    {

    }
}
