using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpot1 : MonoBehaviour
{
    Vector3 vScale, vPosition;
    //  float speed = 1.2f;
    //float vXYZ = 3f;
    private float waitTime = .2f;
    private float timer = 0.0f;
    bool moveLeft = false;
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
            if (!moveLeft) positionX++;  // Starts at 70
            if (moveLeft) positionX--;

            vPosition.x = positionX;
          //  vPosition.y = vXYZ;
          //  vPosition.z = vXYZ;
          //  vPosition.y = vXYZ;
          //  transform.localScale = vScale;
             transform.position = vPosition;;
            timer -= waitTime;
            if (positionX >= 70) moveLeft = true;
            if (positionX <= 45) moveLeft = false;

        }

    }
}
