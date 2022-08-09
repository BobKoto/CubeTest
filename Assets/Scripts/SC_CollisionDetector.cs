// You are free to use this script in Free or Commercial projects
// sharpcoderblog.com @2019
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_CollisionDetector : MonoBehaviour
{
    // This script is assignrd automatically to Flappy Cube by 
    // SC_FlappyCubeGame and will be used to detect the collisions
    [HideInInspector]
    public SC_FlappyCubeGame fcg;

    private void OnCollisionEnter(Collision collision)
    {
        // print ("OnCollisionEnter");
        fcg.GameOver();
    }
}
