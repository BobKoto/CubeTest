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
    {//either look for specific NewInput system input here or  do a controller  
        h = horizontalSpeed * Input.GetAxis("Horizontal");
        v = verticalSpeed * Input.GetAxis("Vertical");
        MovePlayer();
    }
    void MovePlayer()
    {

        transform.position += playerSpeed * Time.deltaTime * new Vector3(h, v, 0);

    }
    public void OnButtonDownPress()
    {
        transform.position += playerSpeed * Time.deltaTime * Vector3.down;
    }
    public void OnButtonUpPress()
    {
        transform.position += playerSpeed * Time.deltaTime * Vector3.up;
    }
    public void OnButtonLeftPress()
    {
        transform.position += playerSpeed * Time.deltaTime * Vector3.left;
    }
    public void OnButtonRightPress()
    {
        transform.position += playerSpeed * Time.deltaTime * Vector3.right;
    }
}

/*    //a way for using new input without 
 *     
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
 
public class cubemovernew : MonoBehaviour
{
    private Keyboard kb;
    private Gamepad pad;
 
    public float speed = 2.0F;
 
    // Start is called before the first frame update
    void Start()
    {
        kb = Keyboard.current; // in WebGL build will always be null on Start()
        pad = Gamepad.current; // in WebGL build will always be null on Start()
    }
 
    // Update is called once per frame
    void Update()
    {
        var x = transform.position.x;
 
        if (kb != null)
        {
            x += kb.dKey.ReadValue() * Time.deltaTime * speed;
            x -= kb.aKey.ReadValue() * Time.deltaTime * speed;
        }
        else
        {
            kb = Keyboard.current; // as a workaround: keep assigning the device value until it's not null
        }
 
        if (pad != null)
        {
            x += pad.leftStick.ReadValue().x * Time.deltaTime * speed;
        }
        else
        {
            pad = Gamepad.current; // as a workaround: keep assigning the device value until it's not null
        }
 
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
 */