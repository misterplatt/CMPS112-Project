import UnityEngine
import System.Collections


public class boo_enemyController(MonoBehaviour):

	
	public speed as single = 3.0F

	
	protected initialPosition as Vector3

	protected left = false

	
	// Use this for initialization
	protected virtual def Start():
		initialPosition = transform.position

	
	// Update is called once per frame
	protected virtual def Update():
		if transform.position.x >= (initialPosition.x + 3):
			left = true
		if transform.position.x < initialPosition.x:
			left = false
		
		if not left:
			transform.Translate(((Vector3.right * Time.deltaTime) * speed))
		if left:
			transform.Translate(((Vector3.left * Time.deltaTime) * speed))

	
	protected virtual def OnCollisionEnter2D(col as Collision2D):
		if col.gameObject.tag == 'Player':
			col.transform.position = Vector3(-4, 3, 0)