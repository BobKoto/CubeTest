using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleTheObject : MonoBehaviour
{// Component of MovingSquare(s)
    public float speed = 10;
    public float speedUpdateInterval = 5f;
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
        StopAllCoroutines();
    }
    void Start()
    {
        hoopStartPosition = transform.position;
        StartCoroutine(RandomizeSpeed(speedUpdateInterval));
    }
    void SetIgnoreAllMovement()
    {
        ignoreAllMovement = !ignoreAllMovement;
    }
    void SetCanMove()  //user pressed start so now the hoops' movement is controlled by the move/stop button - why? may never know...
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
    IEnumerator RandomizeSpeed(float speedUpdateInterval)
        
    {
       var  _delay = new WaitForSeconds(speedUpdateInterval);
        while (true)
        {
            yield return _delay;
            speed = Random.Range(6f, 13f); //another eyeball range
        }

    }
}
