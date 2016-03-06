#pragma strict

public var player : GameObject;

private var smoothrate : float = 0.5f;
private var xvelocity = .5f;
private var yvelocity = .5f;

private var newPos2D : Vector2 = Vector2.zero;

function Update () {
	//Smoothdamp the x and y values between the player and the camera
	newPos2D.x = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, xvelocity, smoothrate);
	newPos2D.y = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, yvelocity, smoothrate);

	transform.position = Vector3(newPos2D.x, newPos2D.y, transform.position.z);
}