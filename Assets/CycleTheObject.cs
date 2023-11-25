using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleTheObject : MonoBehaviour
{
    public float speed = 10;
    public Transform camTransform;
    public bool ignoreAllMovement = true;  //so we can test/see performance with/without object movement especially on handheld browsers
    Vector3 hoopStartPosition;
    bool canMove;
    // Start is called before the first frame update
    private void OnEnable()
    {
        EventBroadcaster.OnGameStartPressed += SetCanMove;
        EventBroadcaster.OnIgnoreMovementPressed += SetIgnoreAllMovement;
    }
    private void OnDisable()
    {
        EventBroadcaster.OnGameStartPressed -= SetCanMove;
        EventBroadcaster.OnIgnoreMovementPressed -= SetIgnoreAllMovement;
    }
    void Start()
    {
        hoopStartPosition = transform.position;
    }
    void SetIgnoreAllMovement()
    {
        ignoreAllMovement = !ignoreAllMovement;
    }
    void SetCanMove()
    {
        canMove = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (canMove && !ignoreAllMovement)
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
