using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleTheObject : MonoBehaviour
{
    public float speed = 10, playerSpeed = 10;
    public Transform camTransform;
    Vector3 hoopStartPosition;
    bool canMove;
    // Start is called before the first frame update
    private void OnEnable()
    {
        EventBroadcaster.OnGameStartPressed += SetCanMove;
    }
    private void OnDisable()
    {
        EventBroadcaster.OnGameStartPressed -= SetCanMove;
    }
    void Start()
    {
        hoopStartPosition = transform.position;
    }
    void SetCanMove()
    {
        canMove = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            MoveHoop();
        }

    }

    void MoveHoop()
    {
       transform.position += speed * Time.deltaTime * Vector3.back;

        if (transform.position.z < -.2f)
        {
            transform.position = hoopStartPosition;
        }
    }
}
