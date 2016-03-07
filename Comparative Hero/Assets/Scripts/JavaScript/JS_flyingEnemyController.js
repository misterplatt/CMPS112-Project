#pragma strict

public var riseSpeed : float = 3f;
public var speed : float = 3f;

private var timer : float = 0f;
private var dropped : boolean = false;
private var rising : boolean = false;

protected var initialPosition : Vector3;
protected var left : boolean = false;

private var defaultHeight : float;

public function Start () {
	initialPosition = transform.position;
	defaultHeight = transform.position.y;
}

public function Update () {
	if(transform.position.x >= initialPosition.x + 3) left = true;
	if (transform.position.x < initialPosition.x) left = false;

    if (!left)transform.Translate(Vector3.right * Time.deltaTime * speed);
    if (left)transform.Translate(Vector3.left * Time.deltaTime * speed);

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

public function OnCollisionEnter2D(col : Collision2D){
	if (col.gameObject.tag == "Player") col.transform.position = new Vector3(-4, 3, 0);
}

public function playerBelow(){
	var hit : RaycastHit2D = Physics2D.Raycast(transform.position, -Vector2.up);
	if (hit.collider.name == "Player") return true;
    else return false;
}