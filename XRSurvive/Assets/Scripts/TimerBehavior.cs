using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class TimerBehavior : MonoBehaviour
{
    private float timeDuration = 0;

    public float timer;

    private bool hasBeenChosenProcessed = false;

    [SerializeField]
    private TextMeshProUGUI timerDisplay;

    public static bool isPaused = false;

    public ResultScreenScript result;

    public RunOptionScript runOption;

    void Start() 
    {
        Scene currentScene = SceneManager.GetActiveScene();
        switch (currentScene.name)
        {
            case "School Hallway":
                SetTimerDuration(30f);
                break;

            case "School Fight":
                SetTimerDuration(60f);
                break;

            case "School Hide":
                SetTimerDuration(60f * 2f);
                break;

            case "Restaurant Run":
                SetTimerDuration(25f);
                break;
            
            case "Restaurant Fight":
                SetTimerDuration(30f);
                break;
            
            case "Restaurant Hide":
                SetTimerDuration(60f * 2f);
                break;

            case "Concert Hide":
                SetTimerDuration(60f * 2f);
                break;

            default:
                SetTimerDuration(20f);
                break;
        }
        ResetTimer();
        UpdateTimerDisplay(timer);
        hasBeenChosenProcessed = false;
        RunOptionScript.hasBeenChosen = false;

    }

    void Update()
    {   
        if (!OVRManager.hasInputFocus || !OVRManager.hasVrFocus) 
        {
            isPaused = true;
            Time.timeScale = 0;
        }

        else
        {
            isPaused = false;
            Time.timeScale = 1;
        }

        if (!isPaused)
        {
            if (timer > 0) 
            {
                timer -= Time.deltaTime;

                if (RunOptionScript.hasBeenChosen == true && hasBeenChosenProcessed == false)
                {
                    SetTimerDuration(2f);
                    ResetTimer();
                    hasBeenChosenProcessed = true;
                }

                UpdateTimerDisplay(timer);

            }
            
            else
            {
                result.SetMenuState(true);
            }
        }
    }

    private void ResetTimer() 
    {
        timer = timeDuration;
    }

    private void UpdateTimerDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}:{1:00}", minutes, seconds);
        timerDisplay.text = currentTime;
        if(timer <= 0)
        {
            timerDisplay.text = "00:00";
        }
    }

    private void SetTimerDuration(float time)
    {
        timeDuration = time;
    }
}
