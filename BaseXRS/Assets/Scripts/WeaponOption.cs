using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.HandGrab;

public class WeaponOption : MonoBehaviour
{
    public List<HandGrabInteractor> hands = new List<HandGrabInteractor>();
    public bool isGoodOption;

    private bool hasBeenChosen;
    private bool isGrabbed;
    private Transform originalParent;
    public GameObject highlight;
    public GameObject chosenOptionVisual;

    private PlayerWeaponController weaponController;

    void Awake()
    {
        weaponController = GameObject.Find("PlayerController").GetComponent<PlayerWeaponController>();
    }

    void Start()
    {
        Unhighlight();
        HideChosenOptionVisual();
        originalParent = transform.parent;

        // Find the PlayerController object and get its HandGrabInteractor components including children
        GameObject playerControllerObject = GameObject.Find("PlayerController"); // Change "PlayerController" to the actual tag or name of your PlayerController object

        if (playerControllerObject != null)
        {
            // Get components from the PlayerController object and its children
            hands.AddRange(playerControllerObject.GetComponentsInChildren<HandGrabInteractor>(true));
        }
        else
        {
            Debug.LogError("PlayerController object not found. Make sure it has the correct tag or name.");
        }
    }

    void Update()
    {
        if (IsBeingGrabbed())
        {
            ChoseOption();
        }
        else
        {
            DebugCanvasController.ClearDebugMessage();
            Drop();
        }
    }

    bool IsBeingGrabbed()
    {
        foreach (HandGrabInteractor hand in hands)
        {
            if (hand.TargetInteractable == gameObject.GetComponent<HandGrabInteractable>())
            {
                return true;
            }
        }

        return false;
    }

    public void Highlight()
    {
        if(!hasBeenChosen)
        {
            highlight.SetActive(true);
        }
    }

    public void Unhighlight()
    {
        highlight.SetActive(false);
    }

    public void ShowChosenOptionVisual()
    {
        chosenOptionVisual.SetActive(true);
    }

    public void HideChosenOptionVisual()
    {
        chosenOptionVisual.SetActive(false);
    }

    public void ChoseOption()
    {
        if (hasBeenChosen) return;
        hasBeenChosen = true;
        Unhighlight();
        ShowChosenOptionVisual();
        weaponController.grabbedWeapon = this;
        if (isGoodOption)
        {
            DebugCanvasController.ShowDebugMessage("You chose a good option");
        }
        else
        {
            DebugCanvasController.ShowDebugMessage("You chose a bad option");
        }
    }

    private void Drop()
    {
        if (!hasBeenChosen) return;
        hasBeenChosen = false;
        HideChosenOptionVisual();
        weaponController.grabbedWeapon = null;
    }
}
