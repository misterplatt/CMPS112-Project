import UnityEngine
import System.Collections

public class boo_enemyController(MonoBehaviour):

	
	public speed as single = 3.0F

	
	private initialPosition as Vector3

	private left = false

	
	// Use this for initialization
	private def Start():
		initialPosition = transform.position

	
	// Update is called once per frame
	private def Update():
		if transform.position.x >= (initialPosition.x + 3):
			left = true
		if transform.position.x < initialPosition.x:
			left = false
		
		if not left:
			transform.Translate(((Vector3.right * Time.deltaTime) * speed))
		if left:
			transform.Translate(((Vector3.left * Time.deltaTime) * speed))

	
	private def OnCollisionEnter2D(col as Collision2D):
		if col.gameObject.tag == 'Player':
			Destroy(col.gameObject)