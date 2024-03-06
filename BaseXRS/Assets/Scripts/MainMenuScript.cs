using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public void LoadGame()
    {
        LevelLoader.instance.LoadScene(1);
    }

    public void LoadLevel(int sceneIndex)
    {
        LevelLoader.instance.LoadScene(sceneIndex);
    }

}
