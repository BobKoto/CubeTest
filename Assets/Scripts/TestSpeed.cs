using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpeed : MonoBehaviour
{
    Animator m_Animator;
    //Value from the slider, and it converts to speed level
    float m_MySliderValue;

    void Start()
    {
        //Get the animator, attached to the GameObject you are intending to animate.
        m_Animator = gameObject.GetComponent<Animator>();
    }

    void OnGUI()
    {
        //Create a Label in Game view for the Slider
        GUI.Label(new Rect(50, 35, 50, 70), "Speed");
        //Create a horizontal Slider to control the speed of the Animator. Drag the slider to 1 for normal speed.

        m_MySliderValue = GUI.HorizontalSlider(new Rect(95, 40, 305, 95), m_MySliderValue, 0.0F, 1.0F);
        //Make the speed of the Animator match the Slider value
        m_Animator.speed = m_MySliderValue;
    }
}