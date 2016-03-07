#pragma strict

function OnCollisionEnter2D(col : Collision2D){
	if (col.gameObject.tag == "Player" && (col.gameObject.GetComponent(Rigidbody2D).velocity.y < -21.5f)) {
        Debug.Log("Downward force: " + col.gameObject.GetComponent(Rigidbody2D).velocity.y);
        Destroy(gameObject);
    } 
}
