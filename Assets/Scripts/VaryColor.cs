using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaryColor : MonoBehaviour
{
    Material myColor;
    public float colorChangeInterval = 2f;
    // Start is called before the first frame update
    void Start()
    {
        myColor = GetComponent<Renderer>().material; 
        StartCoroutine(VaryColorOnInterval(colorChangeInterval));
    }

IEnumerator VaryColorOnInterval(float interval)
    {
        WaitForSeconds _interval = new WaitForSeconds(interval);

        while (true)
        {
            myColor.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

            yield return _interval;
        }
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
