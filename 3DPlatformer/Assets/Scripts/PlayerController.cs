using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {
    public float speed;
    public float jumpSpeed;
    

    Rigidbody rb;
    bool isJumping;
    bool facingRight;
    
	// Use this for initialization
	void Start () {
        facingRight = true;
        isJumping = false;
        rb = GetComponent<Rigidbody>();		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        ProcessInput();
       
	}

    void ProcessInput() {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        if (Input.GetKey(KeyCode.D))
            MoveRight();
     
        if (Input.GetKey(KeyCode.A))
            MoveLeft();
    }

    void Jump()
    {
        if (isJumping == false) { 
            rb.AddForce(Vector3.up * jumpSpeed);
        }
       
        isJumping = true;
    }

   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
    }

    void MoveRight()
    {
        facingRight = true;
        rb.velocity = new Vector3(
              speed * Time.deltaTime,
              rb.velocity.y,
              rb.velocity.z
              );
    }

    void MoveLeft()
    {
        facingRight = false;
        rb.velocity = new Vector3(
              -speed * Time.deltaTime,
              rb.velocity.y,
              rb.velocity.z
              );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ObsticleController>() != null)
            Destroy(gameObject);
        if(other.gameObject.tag == "WinPoint")
        {
            Win();
        }
    }

    public void Win()
    {
        rb.useGravity = false;
        rb.isKinematic = true;
    }
}
