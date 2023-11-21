using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBroadcaster : MonoBehaviour
{//Component of EventBroadcasts   
    public delegate void GameStartPressed();
    public static event GameStartPressed OnGameStartPressed;
    GameObject buttonStart, titleText, touchscreenNote;
    private void Start()
    {
        touchscreenNote = GameObject.Find("TouchscreenNote");
        touchscreenNote.SetActive(false);
        if (Input.touchSupported)
        {
            StartCoroutine(ShowTouchscreenNote(5));
        }
        Debug.Log("Input.touchSupported is " + Input.touchSupported);
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
}
