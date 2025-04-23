using UnityEngine;
using System.Collections.Generic;

public class TriggerAreaDetector : MonoBehaviour
{
    public static TriggerAreaDetector Instance { get; private set; }

    private HashSet<GameObject> objectsInArea = new HashSet<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        objectsInArea.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        objectsInArea.Remove(other.gameObject);
    }

    void Update()
    {
        PlayerPrefs.SetInt("ObjectsInArea", objectsInArea.Count);
        PlayerPrefs.Save();
        //Debug.Log("Objetos dentro del área: " + objectsInArea.Count);
    }

    public int ObjectsInArea()
    {
        return objectsInArea.Count;
    }
}
