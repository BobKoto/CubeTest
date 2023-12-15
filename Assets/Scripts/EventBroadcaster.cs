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

    GameObject buttonStart, titleText, touchscreenNote, buttonIgnoreMovement, onScreenJoystick;
    static TextMeshProUGUI hoopsHitNumber;
    static GameObject buttonRestart;
    public static int hoopSuccess;

    private void Start()
    {
        buttonRestart = GameObject.Find("ButtonRestart");
        buttonRestart.SetActive(false);
        hoopsHitNumber = GameObject.Find("HoopsHitNumber").GetComponent<TextMeshProUGUI>();
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
    }
    public static void UpdateScore(int addScore)
    {
        //Debug.Log("We got a hit in EventBroadcaster................... addScore = " + addScore);
        hoopSuccess += addScore;
        hoopsHitNumber.text = hoopSuccess.ToString();
        if (hoopSuccess >= 9)
        {
            if (OnIgnoreMovementPressed != null)
                OnIgnoreMovementPressed();
           // buttonRestart = GameObject.Find("ButtonRestart");
            buttonRestart.SetActive(true);
            hoopSuccess = 0;
        }
    }
    IEnumerator ShowTouchscreenNote(int _delay)
    {
        //yield return new WaitForSeconds(_delay);
        touchscreenNote.SetActive(true);
        yield return new WaitForSeconds(_delay);
        touchscreenNote.SetActive(false);
    }
    public void OnStartButtonClicked()
    {
            if (OnGameStartPressed != null)
                OnGameStartPressed();     //tell listeners - and now WebGl should be safe to look at new input devices (GamePad for example)
        buttonStart = GameObject.Find("ButtonStart");
        buttonStart.SetActive(false);
        titleText = GameObject.Find("TitleText");
        titleText.SetActive(false);
    }
    public void OnRestartButtonClicked()
    {
        if (OnRestartPressed != null)
            OnRestartPressed();     //tell listeners - and now WebGl should be safe to look at new input devices (GamePad for example)
        buttonRestart = GameObject.Find("ButtonRestart");
        buttonRestart.SetActive(false);

    }
    public void OnIgnoreMovementButtonClicked()
    {
        //string flipMoveStopText = "";  //placeholder. we'll flip the text from like Stop/Go if we want to keep
        if (OnIgnoreMovementPressed != null)
            OnIgnoreMovementPressed();
        buttonIgnoreMovement = GameObject.Find("ButtonIgnoreMovement");
        //string s = CursorLockMode;
      //  Debug.Log("IgnoreMovement Button pressed.... Mouse Cursor lock mode = " + CursorLockMode.Locked);

    }
}
