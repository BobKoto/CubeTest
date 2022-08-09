using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTest : MonoBehaviour
{
    Vector3 vScale, vPosition;
      //  float speed = 1.2f;
    float vXYZ = 3f;
    private float waitTime = .2f;
    private float timer = 0.0f;
    bool scaleDown = false;
    float positionX, positionY, positionZ;
    // Start is called before the first frame update
    void Start()
    {
        /* vScale = transform.localScale;
         Debug.Log("vScale before change: " + vScale.ToString());
         vScale.x = 5;
         vScale.y = 5;
         vScale.z = 5;
         transform.localScale = vScale;
         */
        positionX = transform.position.x;
        positionY = transform.position.y;
        positionZ = transform.position.z;
        vPosition.x = positionX;
        vPosition.y = positionY;
        vPosition.z = positionZ;
    }

    // Update is called once per frame
    void FixedUpdate()     
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            if (!scaleDown) vXYZ++;
            if (scaleDown)   vXYZ--;
              
            vScale.x = vXYZ;
            vScale.y = vXYZ;
            vScale.z = vXYZ;
            vPosition.y = vXYZ;
            transform.localScale = vScale;
        //    transform.position = vPosition;;
            timer -= waitTime;
            if (vXYZ >= 7) scaleDown = true;
            if (vXYZ <= 3) scaleDown = false;
           
        }
       
    }
}
