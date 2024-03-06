using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public float timer, interval = 2f;

    [SerializeField]
    private GameObject menu;

    public bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(isActive); //disables the menu when the scene starts
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            if(isActive == false){
                menu.SetActive(true);
                isActive = true;
                timer = 0;
            }
            else if(isActive == true){
                menu.SetActive(false);
                isActive = false;
                timer = 0;
            }
        }
    }
}
