using System.Collections.Generic;
using UnityEngine;

public class UsableObejctController : MonoBehaviour
{
    [SerializeField]
    GameObject objectPreFab;

    public void pickedUp(List<GameObject> listToAdd)
    {
        listToAdd.Add(objectPreFab);
        Destroy(gameObject);
    }

    void Start()
    {

    }


    void Update()
    {

    }
}
