using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedMotion : MonoBehaviour
{// Component of CurvingSphere(s) 
    float speed = 10;
    public int cyclesForPositionChange;
    public bool ignoreAllMovement; // = true;  //so we can test/see performance with/without object movement especially on handheld browsers
    Vector3 hoopStartPosition;
    bool canMove;
    public MovingSquareConfigSO config;
    public Vector3 v1, v2, v3;
    //public float distanceOffset = .7f;  //12/21/23 replaced with scriptable obj.
    //public Transform t1, t2, t3;
    public bool point1Hit, point2Hit, point3Hit;
    bool letsDebug;
    bool gameStarted;
    float zPositionLastFrame, zPositionThisFrame;
    private void OnEnable()
    {
        EventBroadcaster.OnGameStartPressed += StartGame;
        EventBroadcaster.OnIgnoreMovementPressed += SetIgnoreAllMovement;
       // EventBroadcaster.OnRestartPressed += OnRestartPressed;//RandomizeHoopStartPosition;
        EventBroadcaster.ReportRoundOverEvent += OnReportRoundOver;
    }
    private void OnDisable()
    {
        EventBroadcaster.OnGameStartPressed -= StartGame;
        EventBroadcaster.OnIgnoreMovementPressed -= SetIgnoreAllMovement;
     //   EventBroadcaster.OnRestartPressed -= OnRestartPressed;//RandomizeHoopStartPosition;
        EventBroadcaster.ReportRoundOverEvent -= OnReportRoundOver;
        StopAllCoroutines();
    }
    void Start()
    {
        hoopStartPosition = transform.position;
        speed = config.speed;

       // RandomizeHoopStartPosition();
        if (config.allowLetsDebugTrace)
        {
            if (name == "CurvingSphere (10)")  // limit trace to this gameobject
            {
                Debug.Log(name + " is Found see inside for debug options");
                letsDebug = true; //uncomment this block esp. to temporarily enable (lots of) debug logs
            }
        }
        StartCoroutine(RandomizeSpeed(config.speedUpdateInterval));
    }
    void RandomizeHoopStartPosition()  //When restart is pressed & in  on Start()  - with a random stretch of Z 
    {
        hoopStartPosition.z = config.GetRandomZStartPosition(); 
        hoopStartPosition.x = config.GetRandomXStartPosition(); 
        hoopStartPosition.y = config.GetRandomYStartPosition(); 
        transform.position = hoopStartPosition;
        zPositionLastFrame = transform.position.z + 1;
        canMove = true; //need for restart 
        point1Hit = false;
        point2Hit = false;
        point3Hit = false;
    }
    //void RandomizeHoopStartRecyclePosition()  //When object(sphere) hits front send it back
    //{
    //    hoopStartPosition.z = config.GetRandomZStartPosition(); //
    //    hoopStartPosition.x = config.GetRandomXStartPosition(); //
    //    hoopStartPosition.y = config.GetRandomYStartPosition(); //
    //    transform.position = hoopStartPosition;
    //    zPositionLastFrame = transform.position.z + 1;
    //    canMove = true; //need for restart 
    //}
    void SetIgnoreAllMovement()
    {
        if(gameStarted) ignoreAllMovement = !ignoreAllMovement;
    }
    void StartGame()  //user pressed start so now the hoops' movement is controlled by the move/stop button - why? may never know...
    {
        RandomizeHoopStartPosition();
        gameStarted = true;
        ignoreAllMovement = false;
        canMove = true;
    }

    void ResetCanMove()    //from SendMessage in ScoreHit
    {
        //Debug.Log(this.name + "  recvd msg from ScoreHit to reset canMove to false .......");
        canMove = false;
    }
    
    void OnReportRoundOver()
    {
        gameStarted = false;
    }
    void OnRestartPressed()
    {
        ignoreAllMovement = false;
        gameStarted = true;
        RandomizeHoopStartPosition();
    }
    void Update()
    {
        Time.timeScale = config.setTimeScale;
        if (canMove && !ignoreAllMovement)
        {
            MoveSphere();
        }
    }

    void MoveSphere()
    {   //proof of concept (visual) - not final code!
        var step = speed * Time.deltaTime; // calculate distance to move
        if (!point1Hit)
        {
            transform.position = Vector3.MoveTowards(transform.position, v1, step);
            if (Vector3.Distance(transform.position, v1) < config.distanceOffset)  //set to 3 because .001 stalled 
            {
                point1Hit = true;
               if (letsDebug) Debug.Log(name + " POINT 1 hit at " + transform.position);
            }
        }
        else
        if (!point2Hit)
        {
            transform.position = Vector3.MoveTowards(transform.position, v2, step);
            if (Vector3.Distance(transform.position, v2) < config.distanceOffset)
            {
                point2Hit = true;
                if (letsDebug) Debug.Log(name + " POINT 2 hit at " + transform.position);
            }
        }
        else
        if (!point3Hit)
        {
            transform.position = Vector3.MoveTowards(transform.position, v3, step);
            if (Vector3.Distance(transform.position, v3) < config.distanceOffset)
            {
                point3Hit = true;
                if (letsDebug) Debug.Log(name + " POINT 3 hit at " + transform.position);
            }
        }
        if (transform.position.z < -.2f)
        {
            point1Hit = false;
            point2Hit = false;
            point3Hit = false;
            if (letsDebug) Debug.Log(name + " *FRONTEND* hit at " + transform.position);
            RandomizeHoopStartPosition();
        }
        else
        {
            transform.position += speed * Time.deltaTime * Vector3.back;
        }
        //Did it stall?
        zPositionThisFrame = transform.position.z;
        var progress = zPositionLastFrame - zPositionThisFrame;   //moving backward 
        if (progress <= .05)  //if stalled try moving it
        {
            //Debug.Log(this.name +  " Stalled !!!! zThisFrame = " 
            //    + zPositionThisFrame + "  zLastFrame = " + zPositionLastFrame + " progress = " + progress);
            transform.position += speed * Time.deltaTime * Vector3.back;
            zPositionThisFrame = transform.position.z;
        }
        zPositionLastFrame = zPositionThisFrame;
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

