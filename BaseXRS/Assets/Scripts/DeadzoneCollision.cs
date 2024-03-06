using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class DeadzoneCollision : MonoBehaviour
{
    public enum Action 
    {
        Run,
        Hide,
        Fight
    }
    public Action myAction;

    private TimerBehavior timer;

    private bool not_behind_counter = false;

    private Scene currentScene;

    [SerializeField]
    private TextMeshProUGUI resultText;

    private PlayerWeaponController weaponController;

    void Awake()
    {
        weaponController = GameObject.Find("PlayerController").GetComponent<PlayerWeaponController>();
        timer = GameObject.Find("PlayerController").GetComponentInChildren<TimerBehavior>();
    }

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        int i = (int) myAction;
        switch(i) 
            {
                // hide
                case 1:
                {

                    if (currentScene.name == "School Hide")
                    {
                        resultText.text = "This is not a good hiding spot as it is too visible.\nIt is better to hide behind closed doors if possible, like in the stalls.";
                    } 
                    else if (currentScene.name == "Restaurant Hide")
                    {
                        resultText.text = "This is not a good hiding spot as it is too visible.\nIt is better to hide in closed areas or behind/inside objects if possible, like in the walk-in fridge or inside/behind boxes in the storage room.";
                    }
                    else if (currentScene.name == "Concert Hide")
                    {
                        // TODO: improve message
                        resultText.text = "This is not a good hiding spot";
                    }
                    break;
                }

                // fight
                case 2:
                {
                    if (currentScene.name == "School Fight")
                    {
                        resultText.text = "Make sure to grab an item and get to a good position.\nA good position may be near the door, out of sight.";
                    }
                    else if (currentScene.name == "Restaurant Fight")
                    {
                        resultText.text = "Make sure to grab an item and get to a good position.\nA good position may be behind the bar, out of sight.";
                    }
                    break;
                }

                default: break;
            }
    }

    void Update()
    {

    }

    public void OnTriggerStay(Collider other) 
    {
        int i = (int) myAction;
        if(timer.timer > 0) 
        {
            switch(i) 
            {

                // hide
                case 1:
                {

                    if (currentScene.name == "School Hide")
                    {
                        resultText.text = "This is a good hiding spot because it is completely hidden from view.\nIf you had in stalls with doors that don't touch the ground stand on the toilet!";
                    } 
                    else if (currentScene.name == "Restaurant Hide")
                    {
                        resultText.text = "This is a good hiding spot because it is behind a strong, closed door.\nIf there are object that can be pushed in front of the door, barricade the door.";
                    }
                    else if (currentScene.name == "Restaurant Fight")
                    {
                        not_behind_counter = true;
                    }
                    else if (currentScene.name == "Concert Hide")
                    {
                        // TODO: improve message
                        resultText.text = "This is a good hiding spot";
                    }
                    break;
                }

                // fight
                case 2:
                {
                    if (weaponController.grabbedWeapon != null)
                    {
                        if (currentScene.name == "School Fight")
                        {
                            resultText.text = $"{weaponController.grabbedWeapon.gameObject.name} is a {weaponController.grabbedWeapon.isGoodOption} item to defend against the assailant with.\nThis positioning is good because it can allow you a preemptive strike.";
                        }
                        else if (currentScene.name == "Restaurant Fight")
                        {
                            // if (not_behind_counter)
                            // {
                            //     resultText.text = $"{weaponController.grabbedWeapon.gameObject.name} is a {weaponController.grabbedWeapon.isGoodOption} item to defend with against the assailant with.\nBehind the bar is a good positioning, but make sure that no part of your body is visible above the bar.";
                            // }
                            // else
                            // {
                                resultText.text = $"{weaponController.grabbedWeapon.gameObject.name} is a {weaponController.grabbedWeapon.isGoodOption} item to defend with against the assailant with.\nThis positioning is good because it is hidden from view and allows for a preemptive strike.";
                            // }
                        }
                    }
                    else
                    {
                        if (currentScene.name == "School Fight")
                        {
                            resultText.text = "Make sure to grab item to defend against the assailant with.\nThis positioning is good because it can allow you a preemptive strike.";
                        }
                        else if (currentScene.name == "Restaurant Fight")
                        {
                            // if (not_behind_counter)
                            // {
                            //     resultText.text = "Make sure to grab an item to defend with against the assailant with.\nBehind the bar is a good positioning, but make sure that no part of your body is visible above the bar.";
                            // }
                            // else
                            // {
                                resultText.text = "Make sure to grab an item to defend with against the assailant with.\nThis positioning is good because it is hidden from view and allows for a preemptive strike.";
                            // }
                        }
                    }
                    break;
                }

                default: break;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        int i = (int) myAction;
        if (timer.timer > 0)
        {
            switch(i) 
            {

                // run
                case 0:
                {
                    break;
                }

                // hide
                case 1:
                {

                    if (currentScene.name == "School Hide")
                    {
                        resultText.text = "This is not a good hiding spot as it is too visible.\nIt is better to hide behind closed doors if possible, like in the stalls.";
                    } 
                    else if (currentScene.name == "Restaurant Hide")
                    {
                        resultText.text = "This is not a good hiding spot as it is too visible.\nIt is better to hide in closed areas or behind/inside objects if possible, like in the walk-in fridge or inside/behind boxes in the storage room.";
                    }
                    else if (currentScene.name == "Restaurant Fight")
                    {
                        not_behind_counter = false;
                    }
                    else if (currentScene.name == "Concert Hide")
                    {
                        // TODO: improve message
                        resultText.text = "This is not a good hiding spot";
                    }
                    break;
                }

                // fight
                case 2:
                {
                    if (weaponController.grabbedWeapon != null)
                    {
                        if (currentScene.name == "School Fight")
                        {
                            resultText.text = $"{weaponController.grabbedWeapon.gameObject.name} is a {weaponController.grabbedWeapon.isGoodOption} item to defend with against the assailant.\nNow make sure to get into a good position.\nA good position may be near the door, out of sight.";
                        }
                        else if (currentScene.name == "Restaurant Fight")
                        {
                            resultText.text = $"{weaponController.grabbedWeapon.gameObject.name} is a {weaponController.grabbedWeapon.isGoodOption} item to defend with against the assailant.\nNow make sure to get into a good position.\nA good position may be behind the bar, out of sight.";
                        }
                    }
                    else
                    {
                        if (currentScene.name == "School Fight")
                        {
                            resultText.text = "Make sure to grab an item and get to a good position.\nA good position may be near the door, out of sight.";
                        }
                        else if (currentScene.name == "Restaurant Fight")
                        {
                            resultText.text = "Make sure to grab an item and get to a good position.\nA good position may be behind the bar, out of sight.";
                        }
                    }
                    break;
                }

                default: break;
            }
        }
    }
}
