using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{

    Animator animator;
    float velocity = 0.0f;
    public float acceleration = 0.1f;
    public float deceleration = 0.5f;
    int velocityHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //SetStateByBool();
        SetStateByFloat();
    }
    void SetStateByFloat()
    {
        bool isForwardPressed = Input.GetKey("w");
        bool isSpeedupPressed = Input.GetKey(KeyCode.LeftShift);
        bool isWalking = animator.GetBool("isWalking");
        bool isRunning = animator.GetBool("isRunning");

        if (isForwardPressed)
        {
            velocity =  velocity + acceleration * Time.deltaTime;
            if(velocity > 1)
                velocity = 1;
        }
        if (!isForwardPressed)
        {
            velocity = velocity - deceleration * Time.deltaTime;
            if (velocity < 0)
                velocity = 0;
        }

        animator.SetFloat("Velocity", velocity);
    }
    void SetStateByBool()
    {
        bool isForwardPressed = Input.GetKey("w");
        bool isSpeedupPressed = Input.GetKey(KeyCode.LeftShift);
        bool isWalking = animator.GetBool("isWalking");
        bool isRunning = animator.GetBool("isRunning");
        if (isForwardPressed && !isWalking)
        {
            animator.SetBool("isWalking", true);
        }
        if (!isForwardPressed && isWalking)
        {
            animator.SetBool("isWalking", false);
        }
        if (!isRunning && isSpeedupPressed)
        {
            animator.SetBool("isRunning", true);
        }
        if (isRunning && !isSpeedupPressed)
        {
            animator.SetBool("isRunning", false);
        }
    }

}
