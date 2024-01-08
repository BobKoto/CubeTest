using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionJoystick : MonoBehaviour
{ //Component of EventBroadcasts  - Simple reposition of joystick via gameObject.SetActive (true/false)
    //Vector3 leftPos, centerPos, rightPos, defaultPos;
    GameObject setupUI, buttonSetupUI, buttonStart, buttonIgnoreMovement, buttonIntro; // buttonJoyLeft, buttonJoyCenter, buttonJoyRight;
    GameObject joystickLeft, joystickCenter, joystickRight;
    GameObject joyStickImageLeft, joyStickImageCenter, joyStickImageRight;
    const int enableJoyStickLeft = 1;
    const int enableJoyStickCenter = 2;
    const int enableJoyStickRight = 3;
    //bool joyStickSelected;
    int lastJoyStickSelected;
    //enum joyStickToEnable
    //{
    //    left,
    //    center,
    //    right
    //}
    public float joystickPosX;

    // Start is called before the first frame update
    void Start()
    {
        joystickRight =  GameObject.Find("JoystickRight"); //the one we start with     //("UI_Virtual_Joystick_Move");
        joystickCenter = GameObject.Find("JoystickCenter");
        joystickLeft =   GameObject.Find("JoystickLeft");
        joyStickImageRight =  GameObject.Find("JoystickImageRight"); //the one we start with     //("UI_Virtual_Joystick_Move");
        joyStickImageCenter = GameObject.Find("JoystickImageCenter");
        joyStickImageLeft =   GameObject.Find("JoystickImageLeft");
        setupUI = GameObject.Find("SetupUI");
        buttonSetupUI = GameObject.Find("ButtonSetupUI");
        buttonStart = GameObject.Find("ButtonStart");
        buttonIgnoreMovement = GameObject.Find("ButtonIgnoreMovement");
        buttonIntro = GameObject.Find("ButtonIntro");
        //buttonJoyLeft = GameObject.Find("ButtonJoyLeft");  1/6/23 these 3 not used 
        //buttonJoyCenter = GameObject.Find("ButtonJoyCenter");
        //buttonJoyRight = GameObject.Find("ButtonJoyRight");
        if (setupUI) setupUI.SetActive(false);
        DisableJoysticksAndTheirImages();  //cuz all 3 start out active = true
        if (joystickRight) joystickRight.SetActive(true);  //the default
        lastJoyStickSelected = enableJoyStickRight;  //the default
    }
    public void OnSetupUIButtonPressed()
    {
        //enable UI canvas objects(setupUI): contains position indicator buttons, and buttonSetupExit 
        //disable buttonStart and buttonIgnoreMovement and all joysticks
        if (buttonIntro) buttonIntro.SetActive(false);
        if (buttonStart) buttonStart.SetActive(false);
        if (buttonIgnoreMovement) buttonIgnoreMovement.SetActive(false);
        if (buttonSetupUI) buttonSetupUI.SetActive(false);
        if (setupUI) setupUI.SetActive(true);
        DisableJoysticksAndTheirImages();
        ShowCurrentJoystickImage();
    }
    public void OnSetupExitButtonPressed()
    {
        //disable buttonSetupUI and buttonSetupExit - reenable  buttonStart and buttonIgnoreMovement
        if (buttonStart) buttonStart.SetActive(true);
        if (buttonIgnoreMovement) buttonIgnoreMovement.SetActive(true);
        if (buttonSetupUI) buttonSetupUI.SetActive(true);
        if (setupUI) setupUI.SetActive(false);
        EnableJoystickOnSetupExit(lastJoyStickSelected);
        //joyStickSelected = false; 

    }
    void ShowCurrentJoystickImage()
    {
        switch (lastJoyStickSelected)
        {
            case enableJoyStickRight:
                if (joyStickImageRight) joyStickImageRight.SetActive(true);
                break;
            case enableJoyStickCenter:
                if (joyStickImageCenter) joyStickImageCenter.SetActive(true);
                break;
            case enableJoyStickLeft:
                if (joyStickImageLeft) joyStickImageLeft.SetActive(true);
                break;
            default:
                if (joyStickImageRight) joyStickImageRight.SetActive(true);
                break;
        }
    }
    void EnableJoystickOnSetupExit(int stickToEnable)
    {
        switch (stickToEnable)
        {
            case enableJoyStickLeft: if (joystickLeft) joystickLeft.SetActive(true);
                break;
            case enableJoyStickCenter:
                if (joystickCenter) joystickCenter.SetActive(true);
                break;
            case enableJoyStickRight:
                if (joystickRight) joystickRight.SetActive(true);
                break;
            default: if (joystickRight) joystickRight.SetActive(true);
                break;
        }
    }
    void DisableJoysticksAndTheirImages()
    {
        if (joystickCenter) joystickCenter.SetActive(false);
        if (joystickLeft) joystickLeft.SetActive(false);
        if (joystickRight) joystickRight.SetActive(false);
        if (joyStickImageCenter) joyStickImageCenter.SetActive(false);
        if (joyStickImageLeft) joyStickImageLeft.SetActive(false);
        if (joyStickImageRight) joyStickImageRight.SetActive(false);
    }
    public void OnJoyLeftButtonPressed()
    {
        DisableJoysticksAndTheirImages();
        lastJoyStickSelected = enableJoyStickLeft;
        if (joyStickImageLeft) joyStickImageLeft.SetActive(true);
    }
    public void OnJoyCenterButtonPressed()
    {
        DisableJoysticksAndTheirImages();
        lastJoyStickSelected = enableJoyStickCenter;
        if (joyStickImageCenter) joyStickImageCenter.SetActive(true);
    }
    public void OnJoyRightButtonPressed()
    {
        DisableJoysticksAndTheirImages();
        lastJoyStickSelected = enableJoyStickRight;
        if (joyStickImageRight) joyStickImageRight.SetActive(true);
    }
}
