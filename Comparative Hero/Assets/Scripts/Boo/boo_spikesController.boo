import UnityEngine
import System.Collections


public class boo_spikesController(MonoBehaviour):

	
	private def OnCollisionEnter2D(col as Collision2D):
		if col.gameObject.tag == 'Player':
			col.transform.position = Vector3(-4, 3, 0)