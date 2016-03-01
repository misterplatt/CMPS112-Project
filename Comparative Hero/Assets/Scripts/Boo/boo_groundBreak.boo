import UnityEngine
import System.Collections


public class boo_groundBreak(MonoBehaviour):

	
	private def OnCollisionEnter2D(col as Collision2D):
		if (col.gameObject.tag == 'Player') and (col.gameObject.GetComponent[of Rigidbody2D]().velocity.y < (-21.5F)):
			Debug.Log(('Downward force: ' + col.gameObject.GetComponent[of Rigidbody2D]().velocity.y))
			Destroy(gameObject)
