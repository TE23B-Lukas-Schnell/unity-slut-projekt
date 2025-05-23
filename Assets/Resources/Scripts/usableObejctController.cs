using System.Collections.Generic;
using UnityEngine;

public class UsableObejctController : MonoBehaviour
{
    [SerializeField]
    GameObject objectPrefab;

    [SerializeField]
    string prefabFilePath;

    //kallas när man ska plocka upp ett föremål
    public void PickedUp(List<GameObject> listToAdd)
    {
        listToAdd.Add(objectPrefab);
        Destroy(gameObject);
    }

    void Start()
    {
        objectPrefab = Resources.Load<GameObject>(prefabFilePath);
    }


    void Update()
    {

    }
}
