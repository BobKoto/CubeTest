// You are free to use this script in Free or Commercial projects 
// sharpcoderblog.com @2019
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_TriggerDetector : MonoBehaviour

{
    // This script is assigned automatically to a Pillar Trigger Collider
    // by SC_FlappyCubeGame and will be used to count points
    [HideInInspector]
    public SC_FlappyCubeGame fcg;

    private void OnTriggerEnter(Collider other)
    {
        fcg.AddPoint();
    }
}
