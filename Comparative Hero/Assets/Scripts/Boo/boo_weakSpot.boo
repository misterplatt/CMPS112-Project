import UnityEngine
import System.Collections


public class boo_weakSpot(MonoBehaviour):

	
	public knockup as single = 500.0F

	public health = 1

	
	// Use this for initialization
	private def Start():
		pass
		

	
	// Update is called once per frame
	private def Update():
		pass
		

	
	private def OnTriggerEnter2D(col as Collider2D):
		if col.gameObject.tag == 'Player':
			if gameObject.tag == 'DownBoss':
				if col.gameObject.GetComponent[of Rigidbody2D]().velocity.y < (-10F):
					boo_playerController.playerWin = true
					Destroy(gameObject.transform.parent.gameObject)
			else:
				
				
				health -= 1
				r as Rigidbody2D = col.gameObject.GetComponent[of Rigidbody2D]()
				r.velocity = Vector2(r.velocity.x, 0)
				r.AddForce(Vector2(0, knockup))
				if health <= 0:
					if gameObject.tag == 'RightBoss':
						boo_playerController.doubleJump = true
					if gameObject.tag == 'LeftBoss':
						boo_playerController.groundPound = true
					Destroy(gameObject.transform.parent.gameObject)