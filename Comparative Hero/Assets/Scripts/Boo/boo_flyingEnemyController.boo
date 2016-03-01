import UnityEngine
import System.Collections


public class boo_flyingEnemyController(boo_enemyController):

	public riseSpeed as single = 3.0F

	
	private timer as single = 0.0F

	private dropped = false

	private rising = false

	
	private defaultHeight as single

	
	protected override def Start():
		super.Start()
		defaultHeight = transform.position.y

	
	// Update is called once per frame
	protected override def Update():
		super.Update()
		if playerBelow():
			dropped = true
			GetComponent[of Rigidbody2D]().AddForce(Vector2(0, -120))
		if dropped:
			timer += Time.deltaTime
			if timer > 1.20000004768F:
				dropped = false
				rising = true
				timer = 0.0F
		if rising:
			if transform.position.y < defaultHeight:
				transform.Translate(((Vector3.up * riseSpeed) * Time.deltaTime))
			else:
				rising = false

	
	public def playerBelow() as bool:
		hit as RaycastHit2D = Physics2D.Raycast(transform.position, -Vector2.up)
		//Debug.Log(hit.collider.name);
		if hit.collider.name == 'Player':
			return true
		else:
			return false

