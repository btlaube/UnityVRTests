using UnityEngine;
using OculusSampleFramework;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject UIHelper;
    public OVRHand hand;
    public int pinchCount = 0;
    public float offsetFromPlayer;
    public Camera mainCamera;

    private bool isPinchActive;
    private Transform playerTransform;

    void Awake()
    {
        playerTransform = GameObject.Find("PlayerController").transform;
    }

    private void Start()
    {
        // hand = GetComponent<OVRHand>();
        isPinchActive = false;
        SetMenuState(false); // Start with the menu closed.
        SetCanvasPosition();
    }

    private void Update()
    {
        if (!isPinchActive && hand.GetFingerIsPinching(OVRHand.HandFinger.Index) && hand.GetFingerIsPinching(OVRHand.HandFinger.Thumb))
        {
            // Check if the pinch gesture is detected and it wasn't active before.
            isPinchActive = true;
            SetMenuState(!pauseMenu.activeSelf); // Open the menu.
            pinchCount++;
            // DebugCanvasController.ShowDebugMessage("Left hand pinched " + pinchCount + " times");
        }
        else if (isPinchActive && !(hand.GetFingerIsPinching(OVRHand.HandFinger.Index) && hand.GetFingerIsPinching(OVRHand.HandFinger.Thumb)))
        {
            // Check if the pinch was active and is now released.
            isPinchActive = false;
        }
    }

    private void SetMenuState(bool isOpen)
    {
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(isOpen);
            UIHelper.SetActive(isOpen);
            if(isOpen)
            {
                // transform.position = playerTransform.position + offsetFromPlayer;
                // transform.LookAt(Camera.main.transform);
                // transform.position = Camera.main.transform.position + offsetFromPlayer;
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
            pauseMenu.transform.position = newPosition;

            // Rotate the canvas
            // pauseMenu.transform.LookAt(Camera.main.transform);
            // Get the current rotation
            Vector3 currentRotation = pauseMenu.transform.eulerAngles;
            // Set X-axis rotation to 0
            currentRotation.x = 0;
            currentRotation.y = mainCamera.transform.eulerAngles.y;
            // Apply the new rotation
            pauseMenu.transform.eulerAngles = currentRotation;
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
}
