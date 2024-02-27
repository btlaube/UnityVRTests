using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WorldDistributor : MonoBehaviour
{
    public List<Transform> objectsToDistribute;
    public float radius = 5.0f;
    public int numberOfObjects = 8;

    private void Start()
    {
        DistributeObjectsInCircle();
    }

    private void DistributeObjectsInCircle()
    {
        if (objectsToDistribute.Count == 0)
        {
            Debug.LogWarning("No objects to distribute.");
            return;
        }

        float angleStep = 360.0f / numberOfObjects;

        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * angleStep;
            float radians = angle * Mathf.Deg2Rad;
            Vector3 newPosition = transform.position + new Vector3(Mathf.Cos(radians) * radius, 0, Mathf.Sin(radians) * radius);

            if (i < objectsToDistribute.Count)
            {
                objectsToDistribute[i].position = newPosition;
            }
            else
            {
                // If there are more objects in the list than positions, create new objects.
                GameObject newObject = new GameObject("DistributedObject " + i);
                newObject.transform.position = newPosition;
            }
        }
    }
}
