using UnityEngine;
using System.Collections;

public class Csharp_playerController : MonoBehaviour {

    public float speed = 5f;
    public float jumpForce = 250f;

    //Ability unlocks
    public static bool doubleJump = false;
    public static bool groundPound = false;

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

        //Left-Right Movement
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            transform.localScale = new Vector3(-(Mathf.Abs(transform.localScale.x)), transform.localScale.y, transform.localScale.z);
        }
        if (Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (isGrounded())
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
                if (doubleJump) canDoubleJump = true;
            }
            else if (canDoubleJump) {
                canDoubleJump = false;
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            }
        }
    }

    public bool isGrounded() {
        return Physics2D.Raycast(GroundRayStart.position, -Vector2.up, raycastLength, whatIsGround);
    }
}
