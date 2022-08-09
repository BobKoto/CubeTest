using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyObject : MonoBehaviour
{
    //A new sphere
    GameObject newSphere1;
    Rigidbody newSphere1Rigidbody;
    Vector3 newSphere1Position;
    Vector3 newSphere1Scale;
    Color newSphere1Color = Color.magenta;

    float vX = 70f;
    float vY;
    private float waitTime = .2f;
    private float timer = 0.0f;
    bool scaleDown = false;
    float positionX, positionY, positionZ;

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeRight;
        newSphere1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        newSphere1Position = new Vector3(vX, 10.5f, 18f);
        newSphere1Scale = new Vector3(2f, 2f, 2f);
        newSphere1.transform.localScale = newSphere1Scale; 
        newSphere1.transform.position = newSphere1Position;
        newSphere1Rigidbody = newSphere1.AddComponent<Rigidbody>();
        newSphere1Rigidbody.useGravity = false;
        MeshRenderer mr = newSphere1.GetComponent<MeshRenderer>();
        mr.sharedMaterial = new Material(Shader.Find("Legacy Shaders/Diffuse"));
        mr.sharedMaterial.color = newSphere1Color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > waitTime)
        {
            if (!scaleDown) vX++;
            if (scaleDown) vX--;
            vY = vX / 7;
            newSphere1Position = new Vector3(vX, vY + 1f, 18f);
            /* vScale.x = vXYZ;
             vScale.y = vXYZ;
             vScale.z = vXYZ;
             vPosition.y = vXYZ; */
            newSphere1.transform.position = newSphere1Position;
                //    transform.position = vPosition;;
            timer -= waitTime;
            if (vX >= 70) scaleDown = true;
            if (vX <= 50) scaleDown = false;
           // Debug.Log(" in update");

        }
    }
}
