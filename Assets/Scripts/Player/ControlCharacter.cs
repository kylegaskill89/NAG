using UnityEngine;
using System.Collections;

public class ControlCharacter : MonoBehaviour
{

	public float speed = 5f;
    public float slowSpeed;
    public float rotateSpeed;
    public float slowRotate;
    public float speedJump;
    public float speedSlowJump;
    public float timer = 0f;
    public float iFrameLength;
    public float rollLength;

    [Space(20)]
    public float jumpHeight = 300f;
    public bool isJumping = false;
    public bool isSlowJumping = false;
    public bool isRolling = false;


    public Rigidbody rb;


    public bool isSlow = false;
    public bool canDamage = true;
    public bool canRotate = true;
    public bool canJump = true;


	void Start ()
	{
        rb = GetComponent<Rigidbody>();
	}

    void Update()
    {

        if (isSlow)
        {
            // Forward + Backward Movement

            if (Input.GetAxis("Vertical") > 0 && !isRolling)
            {
                gameObject.transform.Translate(Vector3.forward * slowSpeed * Time.deltaTime);
            }
            else if (Input.GetAxis("Vertical") < 0 && !isRolling)
            {
                gameObject.transform.Translate(-Vector3.forward * slowSpeed * Time.deltaTime);
            }

            // Left + Right Movement

            if (Input.GetAxis("Horizontal") > 0 && !isRolling)
            {
                gameObject.transform.Translate(Vector3.right * slowSpeed / 2 * Time.deltaTime);
            }
            else if (Input.GetAxis("Horizontal") < 0 && !isRolling)
            {
                gameObject.transform.Translate(-Vector3.right * slowSpeed / 2 * Time.deltaTime);
            }

            // Rotate Character + Camera

            if (Input.GetButton("RotateRight") && canRotate)
            {
                gameObject.transform.Rotate(Vector3.up, slowRotate * Time.deltaTime);
            }

            if (Input.GetButton("RotateLeft") && canRotate)
            {
                gameObject.transform.Rotate(Vector3.up, -slowRotate * Time.deltaTime);
            }
        }
        else
        {
            // Forward + Backward Movement

            if (Input.GetAxis("Vertical") > 0 && !isRolling)
            {
                gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            else if (Input.GetAxis("Vertical") < 0 && !isRolling)
            {
                gameObject.transform.Translate(-Vector3.forward * speed * Time.deltaTime);
            }

            // Left + Right Movement

            if (Input.GetAxis("Horizontal") > 0 && !isRolling)
            {
                gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            else if (Input.GetAxis("Horizontal") < 0 && !isRolling)
            {
                gameObject.transform.Translate(-Vector3.right * speed * Time.deltaTime);
            }

            // Rotate Character + Camera

            if (Input.GetButton("RotateRight") && canRotate)
            {
                gameObject.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
            }

            if (Input.GetButton("RotateLeft") && canRotate)
            {
                gameObject.transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);
            }

            // Quick Turn

            if (Input.GetAxis("Vertical") < 0)
            {
                if (Input.GetButtonDown("Slow"))
                {
                    gameObject.transform.Rotate(Vector3.up, 180);
                }
            }

        }

        // Dodge and iFrames

        if (Input.GetButton("RotateRight") && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            canDamage = false;
            RollRight();
        }

        if (Input.GetButton("RotateLeft") && Input.GetButtonDown("Jump"))
        {
            canDamage = false;
            isJumping = true;
            RollLeft();
        }

        //Handle iFrame + Roll timing

        if (isRolling)
        {
            timer += Time.deltaTime;
            canRotate = false;
        }

        if (timer > iFrameLength)
        {
            canDamage = true;
        }

        if (timer > rollLength)
        {
            isJumping = false;
            isRolling = false;
            canRotate = true;
            timer = 0;
        }

        //Handle jumping

        if (Input.GetButtonDown("Jump") && rb.velocity.magnitude != 0 && !isJumping)
        {
            Jump();
        }
        if (Input.GetButtonDown("Jump") && rb.velocity.magnitude == 0 && !isJumping)
        {
            isSlowJumping = true;
            Jump();
        }



        if (Input.GetButton("Slow") && !isJumping)
        {
            isSlow = true;
        }
        else
        {
            isSlow = false;
        }

        if (isJumping)
        {
            speed = speedJump;
        }
        else
        {
            speed = 10;
        }
        if (isSlowJumping)
        {
            speed = speedSlowJump;
        }
        else
        {
            speed = 10;
        }

    }



    void Jump()
    {
        rb.AddForce(Vector3.up * jumpHeight);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Floor")
        {
        isJumping = false;
        isSlowJumping = false;
        }
    }

    void RollRight()
    {
        isRolling = true;
    }

    void RollLeft()
    {
        isRolling = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            isJumping = true;
        }
    }
}
