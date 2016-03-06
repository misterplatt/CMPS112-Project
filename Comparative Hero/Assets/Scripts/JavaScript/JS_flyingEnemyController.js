#pragma strict

var riseSpeed : float = 3f;

private var timer : float = 0f;
private var dropped : boolean = false;
private var rising : boolean = false;

private var defaultHeight : float;

public class Enemy {
	public function Start () {
		super.Start();
		defaultHeight = transform.position.y;
	}

	public function Update () {
		super.Update();
		if (playerBelow()) {
            dropped = true;
            GetComponent(Rigidbody2D).AddForce(new Vector2(0, -80));
    	}
    	if (dropped) {
        timer += Time.deltaTime;
        if (timer > 1.2f) {
            dropped = false;
            rising = true;
            timer = 0f;
        } 
    	}
    	if (rising) {
        	if (transform.position.y < defaultHeight) transform.Translate(Vector3.up * riseSpeed * Time.deltaTime);
        	else rising = false;
    	}
	}
}
