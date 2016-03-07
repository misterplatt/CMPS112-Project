#pragma strict

function OnCollisionEnter2D(col : Collision2D){
	if (col.gameObject.tag == "Player") col.transform.position = new Vector3(-4, 3, 0);
}
