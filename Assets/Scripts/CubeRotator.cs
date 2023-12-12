using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotator : MonoBehaviour
{
    public float speed = 50;
    bool shouldSpin;
    // Start is called before the first frame update
    void Start()
    {
        shouldSpin = true;
        speed = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            speed -= 50;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            speed += 50;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            shouldSpin = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            shouldSpin = false;
        }
        if (shouldSpin)
        {
            transform.Rotate(0f, Time.deltaTime * speed, 0);
        }
    }
    public void OnStopPressed()
    {
        shouldSpin = false;
    }
    public void OnSpinPressed()
    {
        shouldSpin = true;
    }

    public void OnRightPressed()
    {
        speed -= 50;
    }
    public void OnLeftPressed()
    {
        speed += 50;


    }
}
