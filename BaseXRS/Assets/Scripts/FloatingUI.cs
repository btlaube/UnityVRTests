using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingUI : MonoBehaviour
{

    public GameObject Base;
    public float floatDistance;
    void LateUpdate()
    {
        transform.LookAt(Camera.main.transform);
        transform.position = new Vector3(Base.transform.position.x, Base.transform.position.y + floatDistance, Base.transform.position.z);
    }
}
