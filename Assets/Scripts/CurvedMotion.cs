using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedMotion : MonoBehaviour
{// Component of CurvingSphere(s) 
    float speed = 10;
    public int cyclesForPositionChange;
    public bool ignoreAllMovement = true;  //so we can test/see performance with/without object movement especially on handheld browsers
    Vector3 hoopStartPosition;
    bool canMove;
    public MovingSquareConfigSO config;
    public Vector3 v1, v2, v3;
    //public float distanceOffset = .7f;  //12/21/23 replaced with scriptable obj.
    //public Transform t1, t2, t3;
    public bool point1Hit, point2Hit, point3Hit;

    private void OnEnable()
    {
        EventBroadcaster.OnGameStartPressed += SetCanMove;
        EventBroadcaster.OnIgnoreMovementPressed += SetIgnoreAllMovement;
        EventBroadcaster.OnRestartPressed += RandomizeHoopStartPosition;
    }
    private void OnDisable()
    {
        EventBroadcaster.OnGameStartPressed -= SetCanMove;
        EventBroadcaster.OnIgnoreMovementPressed -= SetIgnoreAllMovement;
        EventBroadcaster.OnRestartPressed -= RandomizeHoopStartPosition;
        StopAllCoroutines();
    }
    void Start()
    {
        hoopStartPosition = transform.position;
        speed = config.speed;

        RandomizeHoopStartPosition();

        StartCoroutine(RandomizeSpeed(config.speedUpdateInterval));
    }
    void RandomizeHoopStartPosition()  //When restart is pressed & in  on Start()
    {
        hoopStartPosition.z = config.GetRandomZStartPosition(); //
        hoopStartPosition.x = config.GetRandomXStartPosition(); //
        hoopStartPosition.y = config.GetRandomYStartPosition(); //
        transform.position = hoopStartPosition;
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
            MoveSphere();
        }

    }

    void MoveSphere()
    {
        var step = speed * Time.deltaTime; // calculate distance to move
        if (!point1Hit)
        {
            transform.position = Vector3.MoveTowards(transform.position, v1, step);
            if (Vector3.Distance(transform.position, v1) < config.distanceOffset)  //set to .3 because .001 stalled 
            {
                point1Hit = true;
               // Debug.Log("POINT 1 hit");
            }
        }
        else
        if (!point2Hit)
        {
            transform.position = Vector3.MoveTowards(transform.position, v2, step);
            if (Vector3.Distance(transform.position, v2) < config.distanceOffset)
            {
                point2Hit = true;
               // Debug.Log("POINT 2 hit");
            }
        }
        else
        if (!point3Hit)
        {
            transform.position = Vector3.MoveTowards(transform.position, v3, step);
            if (Vector3.Distance(transform.position, v3) < config.distanceOffset)
            {
                point3Hit = true;
              //  Debug.Log("POINT 3 hit");
            }
        }
        if (transform.position.z < -.2f)
        {
            point1Hit = false;
            point2Hit = false;
            point3Hit = false;
            RandomizeHoopStartPosition();
            //transform.position = hoopStartPosition;
        }
        else
        {
            transform.position += speed * Time.deltaTime * Vector3.back;
        }

        //transform.position += speed * Time.deltaTime * Vector3.back;

            //if (transform.position.z < -.2f)
            //{
            //    cyclesForPositionChange++;
            //    if (cyclesForPositionChange >= config.changeOnCycleCount)
            //    {
            //        RandomizeHoopStartPosition();
            //        cyclesForPositionChange = 0;
            //    }

            //    transform.position = hoopStartPosition;
            //}
    }
    IEnumerator RandomizeSpeed(float speedUpdateInterval)

    {
        var _delay = new WaitForSeconds(speedUpdateInterval);
        while (true)
        {
            yield return _delay;
            speed = Random.Range(config.speedMin, config.speedMax); //Random.Range(6f, 13f); //eyeballed //12/21/23 use scriptable obj.
        }

    }
}

