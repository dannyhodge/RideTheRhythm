using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveChar : MonoBehaviour
{
    public bool isGrounded = true;
    public bool isDashing = false;
    public double jumpSpeed = 5.0f;
    public GameObject childAnimator;
    public AnimationClip duck;
    public AnimationClip dash;
    public float dashTime = 2.0f;
    public float dashTimer = 0f;
    void Start()
    {
        childAnimator = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if(isDashing && dashTimer < dashTime) {
            dashTimer += Time.deltaTime;
        }
        if(dashTimer >= dashTime) {
            isDashing = false;
            dashTimer = 0.0f;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                isGrounded = false;
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * (int)jumpSpeed);
            }
        }
        if (Input.GetButtonDown("Duck"))
        {
            if (isGrounded)
            {
                childAnimator.GetComponent<Animation>().clip = duck;
                childAnimator.GetComponent<Animation>().Play();
            }
        }
    }

    void FixedUpdate()
    {
        if (Input.GetAxis("Dash") >= 0.8)
        {
                dashTimer = 0f;
                isDashing = true;
                childAnimator.GetComponent<Animation>().clip = dash;
                childAnimator.GetComponent<Animation>().Play();
                
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Ground") {
            isGrounded = true;
        }

        if(other.transform.tag == "Breakable") {
            if(isDashing)  Destroy(other.transform.gameObject);
        }
    }
}