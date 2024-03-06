using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeController : MonoBehaviour
{
    public float raycastDistance = 10f; //the maximum distance of the raycast
    public LayerMask runOptions;
    public LayerMask weaponOptions;
    public Camera mainCamera;
    public GameObject lookedAt;
    RunOptionScript runOption = null;
    WeaponOption weaponOption = null;

    // Start is called before the first frame update
    void Start()
    {
        //lookedAt = null;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
        RaycastHit hit;
        

        if (Physics.Raycast(ray, out hit, raycastDistance, runOptions))
        {
            DebugCanvasController.ShowDebugMessage(hit.collider.gameObject.name);
            //lookedAt = hit.collider.gameObject;
            runOption = hit.collider.gameObject.GetComponent<RunOptionScript>();
            runOption.Highlight();

        }
        else if (Physics.Raycast(ray, out hit, raycastDistance, weaponOptions))
        {
            weaponOption = hit.collider.gameObject.GetComponentInParent<WeaponOption>();
            weaponOption.Highlight();
        }
        else
        {
            if (runOption != null)
            {
                DebugCanvasController.ShowDebugMessage(runOption.gameObject.name);
                runOption.Unhighlight();
                runOption = null;
            }
            if (weaponOption != null)
            {
                weaponOption.Unhighlight();
                weaponOption = null;
            }
            
        }
    }
}
