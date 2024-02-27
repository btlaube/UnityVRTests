using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunOptionScript : MonoBehaviour
{
    [SerializeField]
    public GameObject highlight;
    public GameObject chosenOptionVisual;
    public bool isGoodOption;
    public static bool hasBeenChosen;
    public ResultScreenScript result;

    void Start()
    {
        Unhighlight();
        HideChosenOptionVisual();
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

        hasBeenChosen = true;
        Unhighlight();
        ShowChosenOptionVisual();
        result.SetResult(isGoodOption);

    }
}
