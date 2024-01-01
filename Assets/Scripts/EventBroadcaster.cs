using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EventBroadcaster : MonoBehaviour   //and half-assed game setup/manager
{//Component of EventBroadcasts   

    public delegate void GameStartPressed();
    public static event GameStartPressed OnGameStartPressed;

    public delegate void IgnoreMovementPressed();
    public static event IgnoreMovementPressed OnIgnoreMovementPressed;

    public delegate void RestartPressed();
    public static event RestartPressed OnRestartPressed;

    public delegate void ReportHit();
    public static event ReportHit ReportHitEvent;

    public delegate void ReportRoundOver();
    public static event ReportRoundOver ReportRoundOverEvent;

    GameObject buttonStart, titleText, touchscreenNote, onScreenJoystick;
    static TextMeshProUGUI hoopsHitNumber, yourTimeNumber;
    static GameObject buttonRestart, buttonIntro, buttonIgnoreMovement ;
    public static int hoopSuccess;
    public static int hoopsHitLimit = 50;
    static int seconds;
    static bool timerOn;
    Coroutine yourTimerIE;
    static AudioSource audioSource;

    private void Start()
    {
        buttonStart = GameObject.Find("ButtonStart");
       // if (buttonStart) buttonStart.SetActive(false);
        buttonRestart = GameObject.Find("ButtonRestart");
        buttonIntro = GameObject.Find("ButtonIntro");
        buttonRestart.SetActive(false);

        buttonIgnoreMovement = GameObject.Find("ButtonIgnoreMovement");
        buttonIgnoreMovement.SetActive(false);

        hoopsHitNumber = GameObject.Find("HoopsHitNumber").GetComponent<TextMeshProUGUI>();
        yourTimeNumber = GameObject.Find("YourTimeNumber").GetComponent<TextMeshProUGUI>();
        //yourTimerIE = StartCoroutine( YourTimer());

        onScreenJoystick = GameObject.Find("UI_Virtual_Joystick_Move");
        if (onScreenJoystick) onScreenJoystick.SetActive(false);
        touchscreenNote = GameObject.Find("TouchscreenNote");
        touchscreenNote.SetActive(false);
        if (Input.touchSupported)
        {
            onScreenJoystick.SetActive(true);
            StartCoroutine(ShowTouchscreenNote(5));
            //Cursor.lockState = CursorLockMode.Locked;
            Debug.Log("Input.touchSupported is " + Input.touchSupported + " If True broadcast something if we want to modify UI/Gamepad");

        }
        audioSource = GetComponent<AudioSource>();
    }
    public static void UpdateScore(int addScore)
    {
        //Debug.Log("We got a hit in EventBroadcaster................... addScore = " + addScore);
        if (ReportHitEvent != null)
            ReportHitEvent();
        hoopSuccess += addScore;
        hoopsHitNumber.text = hoopSuccess.ToString();
        if (hoopSuccess >= hoopsHitLimit)
        {
            if (OnIgnoreMovementPressed != null)
                OnIgnoreMovementPressed();
            if (ReportRoundOverEvent != null)
                ReportRoundOverEvent();
           // buttonRestart = GameObject.Find("ButtonRestart");
            buttonRestart.SetActive(true);
            hoopSuccess = 0;
           // seconds = 0;
            timerOn = false;
            audioSource.Pause();
            if (buttonIgnoreMovement) buttonIgnoreMovement.SetActive(false);
        }
    }
    IEnumerator ShowTouchscreenNote(int _delay)
    {
        //yield return new WaitForSeconds(_delay);
        touchscreenNote.SetActive(true);
        yield return new WaitForSeconds(_delay);
        touchscreenNote.SetActive(false);
    }
    //public void OnIntroButtonClicked()
    //{
    //    buttonIntro.SetActive(false);
    //    buttonStart.SetActive(true);
    //}
    public void OnStartButtonClicked()
    {
        if (buttonIntro) buttonIntro.SetActive(false);
        if (OnGameStartPressed != null)
            OnGameStartPressed();     //tell listeners - and now WebGL should be safe to look at new input devices (GamePad for example)

        buttonStart.SetActive(false);
        yourTimerIE = StartCoroutine(YourTimer());
        titleText = GameObject.Find("TitleText");
        titleText.SetActive(false);
        timerOn = true;
        audioSource.Play();
        if (buttonIgnoreMovement) buttonIgnoreMovement.SetActive(true);
    }
    public void OnRestartButtonClicked()
    {
        if (OnRestartPressed != null)
            OnRestartPressed();     //tell listeners - and now WebGl should be safe to look at new input devices (GamePad for example)
        buttonRestart = GameObject.Find("ButtonRestart");
        buttonRestart.SetActive(false);
        seconds = 0;
        timerOn = true;
        audioSource.Play();
        if (buttonIgnoreMovement) buttonIgnoreMovement.SetActive(true);
    }
    public void OnIgnoreMovementButtonClicked()
    {
        //string flipMoveStopText = "";  //placeholder. we'll flip the text from like Stop/Go if we want to keep
        if (OnIgnoreMovementPressed != null)
            OnIgnoreMovementPressed();
        timerOn = !timerOn;
        if (!timerOn) audioSource.Pause(); else audioSource.Play();
    }
    static IEnumerator YourTimer()
    {
        //int seconds = 0;
        WaitForSeconds _oneSecond = new WaitForSeconds(1);
        while (true)
        {
            if (timerOn)
            {
                seconds++;
            if (seconds <= 9999)   //12/22/23 so text field stays 4 chars. user "could" leave it running, 's all we're doin for now
                {
                    yourTimeNumber.text = seconds.ToString();
                }
            }
            yield return _oneSecond;
        }
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
