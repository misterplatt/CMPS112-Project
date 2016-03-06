#pragma strict

public var speed : float = 3f;

protected var initialPosition : Vector3;
protected var left : boolean = false;

public function Start () {
	initialPosition = transform.position;
}

public function Update () {
	if(transform.position.x >= initialPosition.x + 3) left = true;
	if (transform.position.x < initialPosition.x) left = false;

    if (!left)transform.Translate(Vector3.right * Time.deltaTime * speed);
    if (left)transform.Translate(Vector3.left * Time.deltaTime * speed);
}

public function OnCollisionEnter2D(col : Collision2D){
	if (col.gameObject.tag == "Player") col.transform.position = new Vector3(-4, 3, 0);
}