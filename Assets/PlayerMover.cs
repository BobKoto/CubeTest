using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float playerSpeed = 10;
    float horizontalSpeed = .1f;
    float verticalSpeed = .1f;
    float h, v;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        h = horizontalSpeed * Input.GetAxis("Horizontal");
        v = verticalSpeed * Input.GetAxis("Vertical");
        MovePlayer();
    }
    void MovePlayer()
    {

        transform.position += new Vector3(h, v, 0) * Time.deltaTime * playerSpeed;

    }
}

