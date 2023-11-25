using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBroadcaster : MonoBehaviour
{//Component of EventBroadcasts   
    public delegate void GameStartPressed();
    public static event GameStartPressed OnGameStartPressed;
    public delegate void IgnoreMovementPressed();
    public static event IgnoreMovementPressed OnIgnoreMovementPressed;
    GameObject buttonStart, titleText, touchscreenNote, buttonIgnoreMovement ;
    private void Start()
    {
        touchscreenNote = GameObject.Find("TouchscreenNote");
        touchscreenNote.SetActive(false);
        if (Input.touchSupported)
        {
            StartCoroutine(ShowTouchscreenNote(5));
            Cursor.lockState = CursorLockMode.Locked;
            Debug.Log("Input.touchSupported is " + Input.touchSupported + " If True lock mouse cursor & broadcast something if we want to modify UI/Gamepad");

        }
    }
    IEnumerator ShowTouchscreenNote(int _delay)
    {
        yield return new WaitForSeconds(_delay);
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
