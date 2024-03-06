using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.HandGrab;

public class ResetWeapon : MonoBehaviour
{
    // [SerializeField] HandGrabInteractor grabbedObjectLeft;
    // [SerializeField] HandGrabInteractor grabbedObjectRight;
    private Pose originalPoint;
    private Rigidbody rb;

    // private void OnEnableLeft() => grabbedObjectLeft.selectExited.AddListener(ObjectReleased);
    // private void OnEnableRight() => grabbedObjectRight.selectExited.AddListener(ObjectReleased);
    // private void OnDisableLeft() => grabbedObjectLeft.selectExited.RemoveListener(ObjectReleased);
    // private void OnDisableRight() => grabbedObjectRight.selectExited.RemoveListener(ObjectReleased);
    
    private void Awake()
    {
        originalPoint.position = this.transform.position;
        originalPoint.rotation = this.transform.rotation;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (this.transform.position != originalPoint.position)
        {
            rb.Sleep();
            GetComponent<Collider>().enabled = false;
            this.transform.position = originalPoint.position;
            this.transform.rotation = originalPoint.rotation;
            rb.WakeUp();
            GetComponent<Collider>().enabled = true;
        }
    }

    // private void ObjectReleased(SelectExitEventArgs arg0)
    // {
    //     rb.Sleep();
    //     GetComponent<Collider>().enabled = false;

    //     this.transform.position = originalPoint.position;
    //     this.transform.rotation = originalPoint.rotation;

    //     rb.WakeUp();
    //     GetComponent<Collider>().enabled = true;
    // }
}
