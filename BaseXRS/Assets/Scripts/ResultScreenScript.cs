using UnityEngine;
using OculusSampleFramework;
using TMPro;

public class ResultScreenScript : MonoBehaviour
{
    public GameObject resultScreen;
    public GameObject UIHelper;
    public float offsetFromPlayer;
    public Camera mainCamera;

    [SerializeField]
    private TextMeshProUGUI resultText;

    private Transform playerTransform;

    void Awake()
    {
        playerTransform = GameObject.Find("PlayerController").transform;
    }

    private void Start()
    {
        SetMenuState(false); // Start with the menu closed.
        SetCanvasPosition();
    }

    public void SetMenuState(bool isOpen)
    {
        if (resultScreen != null)
        {
            resultScreen.SetActive(isOpen);
            UIHelper.SetActive(isOpen);
            if(isOpen)
            {
                SetCanvasPosition();
            }
        }
    }

    private void SetCanvasPosition()
    {
        // Make sure to assign a valid camera reference (e.g., Camera.main or another camera in your scene).
        // Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            // Calculate the new position in front of the camera.
            Vector3 newPosition = mainCamera.transform.position + (mainCamera.transform.forward * offsetFromPlayer);

            // Set the object's position to the new position.
            resultScreen.transform.position = newPosition;

            // Rotate the canvas
            // pauseMenu.transform.LookAt(Camera.main.transform);
            // Get the current rotation
            Vector3 currentRotation = resultScreen.transform.eulerAngles;
            // Set X-axis rotation to 0
            currentRotation.x = 0;
            currentRotation.y = mainCamera.transform.eulerAngles.y;
            // Apply the new rotation
            resultScreen.transform.eulerAngles = currentRotation;
        }
        else
        {
            Debug.LogError("No valid camera reference found.");
        }
    }

    public void LoadMainMenu()
    {
        LevelLoader.instance.LoadScene(0);
    }

    public void SetResult(bool isGoodOption)
    {
        if (isGoodOption == true)
        {
            resultText.text = "Good Job!";
        }
        else if (isGoodOption == false)
        {
            resultText.text = "There are better options!";
        }
        else
        {
            resultText.text = "Error!";
        }
    }
}
