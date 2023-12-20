using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleTheObject : MonoBehaviour
{// Component of MovingSquare(s)
    float speed = 10;
    //public float speedUpdateInterval = 5f;
    public int cyclesForPositionChange;
   // public int changeOnCycleCount = 5;
   // public Transform camTransform;
    public bool ignoreAllMovement = true;  //so we can test/see performance with/without object movement especially on handheld browsers
    Vector3 hoopStartPosition;
    bool canMove;
    public MovingSquareConfigSO config;
    // Start is called before the first frame update
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
        speed = config.speed;
        //Debug.Log("Scriptable speed is " + config.speed);
        //hoopStartPosition = transform.position;  //preserves Y position
        RandomizeHoopStartPosition();
        //hoopStartPosition.z = config.GetRandomZStartPosition(); //
        //hoopStartPosition.x = config.GetRandomXStartPosition(); //
        //transform.position = hoopStartPosition;
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
            MoveHoop();
        }

    }

    void MoveHoop()
    {

       transform.position += speed * Time.deltaTime * Vector3.back;

        if (transform.position.z < -.2f)
        {
            cyclesForPositionChange++;
            if (cyclesForPositionChange >= config.changeOnCycleCount)
            {
                //  hoopStartPosition.z = Mathf.Floor(Random.Range(44f, 54f)); //12/17/23 
                //  hoopStartPosition.x = Mathf.Floor(Random.Range(-3f, 3f)); //12/17/23 
                //hoopStartPosition.z = config.GetRandomZStartPosition();
                RandomizeHoopStartPosition();
                cyclesForPositionChange = 0;
            }

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
