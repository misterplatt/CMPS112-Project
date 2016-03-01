import UnityEngine
import System.Collections


public class boo_playerController(MonoBehaviour):

	public speed as single = 5.0F

	public jumpForce as single = 600.0F

	public poundForce as single = 800.0F

	//Ability unlocks
	public static doubleJump = false

	public static groundPound = false

	public GroundRayStart as Transform

	public whatIsGround as LayerMask

	private raycastLength as single = 0.15000000596F

	private grounded = true

	private canDoubleJump = false

	public static groundPounding as bool

	// Use this for initialization
	private def Start():
		pass

	// Update is called once per frame
	private def Update():
		
		//Left-Right Movement
		if Input.GetKey(KeyCode.A):
			transform.Translate(((Vector3.left * Time.deltaTime) * speed))
			transform.localScale = Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z)
		if Input.GetKey(KeyCode.D):
			transform.Translate(((Vector3.right * Time.deltaTime) * speed))
			transform.localScale = Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z)
		
		//Ground Pounding
		if (Input.GetKeyDown(KeyCode.S) and groundPound) and (not isGrounded()):
			Debug.Log('groundpound')
			GetComponent[of Rigidbody2D]().AddForce(Vector2(0, -poundForce))
		
		//Jumping
		if Input.GetKeyDown(KeyCode.Space):
			Debug.Log(groundPound)
			if isGrounded():
				GetComponent[of Rigidbody2D]().velocity = Vector2(GetComponent[of Rigidbody2D]().velocity.x, 0)
				GetComponent[of Rigidbody2D]().AddForce(Vector2(0, jumpForce))
				if doubleJump:
					canDoubleJump = true
			elif canDoubleJump:
				canDoubleJump = false
				GetComponent[of Rigidbody2D]().velocity = Vector2(GetComponent[of Rigidbody2D]().velocity.x, 0)
				GetComponent[of Rigidbody2D]().AddForce(Vector2(0, jumpForce))

	
	public def isGrounded() as bool:
		return Physics2D.Raycast(GroundRayStart.position, -Vector2.up, raycastLength, whatIsGround)

