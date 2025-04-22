using UnityEngine;
using System.Collections.Generic;

public class TriggerAreaDetector : MonoBehaviour
{
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
        //Debug.Log("Objetos dentro del área: " + (objectsInArea.Count - 1));
    }
}
