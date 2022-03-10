using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotTouchController : MonoBehaviour
{
    public float moveSpeed = 30f;
    public float turnSpeed = 5f;

    private Animator robotAnim;
    private Rigidbody robotRigidbody;
    private Joystick joystick;

    // Start is called before the first frame update
    void OnEnable()
    {
        robotAnim = GetComponent<Animator>();
        robotRigidbody = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {
        // forward movement of the robot
        if(joystick.Direction.magnitude >= 0.2f)
        {
            robotRigidbody.AddForce(transform.forward * moveSpeed);
            robotAnim.SetBool("Walk_Anim", true);
        }
        else
        {
            robotAnim.SetBool("Walk_Anim", false);
        }

        // rotate the robot with the joystick
        Vector3 targetDirection = new Vector3(joystick.Direction.x, 0, joystick.Direction.y);
        Vector3 direction = Vector3.RotateTowards(transform.forward, targetDirection, Time.deltaTime * turnSpeed, 0.0f);
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
