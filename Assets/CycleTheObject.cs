using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleTheObject : MonoBehaviour
{
    public float speed = 10;
    public Transform camTransform;
    public float transformZ;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        transformZ = camTransform.position.z + 50;
        startPosition = transform.position;
        transform.Translate(0, 0, transformZ);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime);
        if (transform.position.z < 10)
        {
            transform.position = startPosition;
        }

    }
    //private void OnBecameInvisible()
    //{
    //    Debug.Log(" frame became invisible...." + transform.position);
    //    transform.position = startPosition;
    //}
}
