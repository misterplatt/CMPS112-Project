using UnityEngine;
using System.Collections;

public class Csharp_playerController : MonoBehaviour {

    public float speed = 5f;
    public float jumpForce = 600f;
    public float poundForce = 800f;

    //Ability unlocks
    public static bool doubleJumpUnlocked = false;
    public static bool groundPoundUnlocked = false;
	public static bool playerWin = false;

    public Transform GroundRayStart;
    public LayerMask whatIsGround;
    float raycastLength = 0.15f;

    private bool grounded = true;
    private bool canDoubleJump = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.U)) {
            doubleJumpUnlocked = true;
            groundPoundUnlocked = true;
        } 

        //Left-Right Movement
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            transform.localScale = new Vector3(-(Mathf.Abs(transform.localScale.x)), transform.localScale.y, transform.localScale.z);
        }
        if (Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        //Ground Pounding
        if (Input.GetKeyDown(KeyCode.S) && groundPoundUnlocked && !isGrounded())
        {
            Debug.Log("groundpound");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -poundForce));
        }

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log(groundPoundUnlocked);
            if (isGrounded())
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
                if (doubleJumpUnlocked) canDoubleJump = true;
            }
            else if (canDoubleJump) {
                canDoubleJump = false;
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            }
        }
    }

    public bool isGrounded() {
        return Physics2D.Raycast(GroundRayStart.position, -Vector2.up, raycastLength, whatIsGround);
    }
}
