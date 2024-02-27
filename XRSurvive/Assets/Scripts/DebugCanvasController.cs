using UnityEngine;
using TMPro;

public class DebugCanvasController : MonoBehaviour
{
    public TMP_Text debugText;
    public Canvas debugCanvas;

    private static DebugCanvasController instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Multiple instances of DebugCanvas detected. Only one should exist.");
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        // Deactivate the canvas on start.
        if (debugCanvas != null)
        {
            debugCanvas.gameObject.SetActive(false);
        }
    }

    public static void ShowDebugMessage(string message)
    {
        Debug.Log(message);
        if (instance != null && instance.debugText != null)
        {
            instance.debugText.text = message;
            if (instance.debugCanvas != null)
            {
                instance.debugCanvas.gameObject.SetActive(true);
            }
        }
    }

    public static void ClearDebugMessage()
    {
        // if (instance != null && instance.debugText != null)
        // {
        //     instance.debugText.text = "";
        //     if (instance.debugCanvas != null)
        //     {
        //         instance.debugCanvas.gameObject.SetActive(false);
        //     }
        // }
    }
}