using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFrameRate : MonoBehaviour
{

    private void Start()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = -1;

        Debug.Log("Target Frame rate is " + Application.targetFrameRate);
    }

}
