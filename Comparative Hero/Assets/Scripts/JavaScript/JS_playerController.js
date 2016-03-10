#pragma strict

public var speed : float = 5f;
public var jumpForce : float = 600f;
public var poundForce : float = 800f;

public static var doubleJumpUnlocked : boolean = false;
public static var groundPoundUnlocked : boolean = false;
public static var playerWin : boolean = false;

public var GroundRayStart : Transform;
public var whatIsGround : LayerMask;
private var raycastLength : float = 0.15f;

private var grounded : boolean = true;
private var canDoubleJump : boolean = false;

function Update () {
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
        GetComponent(Rigidbody2D).AddForce(new Vector2(0, -poundForce));
    }

    //Jumping
    if (Input.GetKeyDown(KeyCode.Space)) {
        Debug.Log(groundPoundUnlocked);
        if (isGrounded())
        {
            GetComponent(Rigidbody2D).velocity = new Vector2(GetComponent(Rigidbody2D).velocity.x, 0);
            GetComponent(Rigidbody2D).AddForce(new Vector2(0, jumpForce));
            if (doubleJumpUnlocked) canDoubleJump = true;
        }
        else if (canDoubleJump) {
            canDoubleJump = false;
            GetComponent(Rigidbody2D).velocity = new Vector2(GetComponent(Rigidbody2D).velocity.x, 0);
            GetComponent(Rigidbody2D).AddForce(new Vector2(0, jumpForce));
        }
    }
}

function isGrounded(){
	return Physics2D.Raycast(GroundRayStart.position, -Vector2.up, raycastLength, whatIsGround);
}