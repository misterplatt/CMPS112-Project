import UnityEngine
import System.Collections

public class boo_camFollow(MonoBehaviour):

	public player as GameObject

	private smoothrate as single = 0.5F

	private velocity = Vector2(0.5F, 0.5F)

	private newPos2D as Vector2 = Vector2.zero

	// Update is called once per frame
	private def Update():
		//Smoothdamp the x and y values between the player and the camera
		newPos2D.x = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, velocity.x, smoothrate)
		newPos2D.y = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, velocity.y, smoothrate)
		
		//Set the camera's position to the smooth-damped value
		transform.position = Vector3(newPos2D.x, newPos2D.y, transform.position.z)