using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunOptionColliderScript : MonoBehaviour
{

    private RunOptionScript runOption;

    void Awake()
    {
        runOption = GetComponentInParent<RunOptionScript>();
    }

    public void OnTriggerEnter(Collider other)
    {
        DebugCanvasController.ShowDebugMessage("Chosen this door");
        runOption.ChoseOption();
    }
}
