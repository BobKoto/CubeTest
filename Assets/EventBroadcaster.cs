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
    GameObject buttonStart, titleText, touchscreenNote, buttonIgnoreMovement, onScreenJoystick;
    static TextMeshProUGUI hoopsHitNumber;
    public static int hoopSuccess;
    private void Start()
    {
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
                OnGameStartPressed();     //tell listeners - and now WegGl should be safe to look at new input devices (GamePad for example)
        buttonStart = GameObject.Find("ButtonStart");
        buttonStart.SetActive(false);
        titleText = GameObject.Find("TitleText");
        titleText.SetActive(false);
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
