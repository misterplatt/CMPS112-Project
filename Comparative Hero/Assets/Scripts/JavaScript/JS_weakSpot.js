#pragma strict

var knockup : float = 500f;
var health : int = 1;

function OnTriggerEnter2D(col : Collider2D){
	if (col.gameObject.tag == "Player"){
        if(gameObject.tag == "DownBoss"){
		if(col.gameObject.GetComponent(Rigidbody2D).velocity.y < -21.5f){
			Destroy(gameObject.transform.parent.gameObject);
		}

		}else{
		
		health -= 1;
        var r : Rigidbody2D = col.gameObject.GetComponent(Rigidbody2D);
        r.velocity = new Vector2(r.velocity.x, 0);
        r.AddForce(new Vector2(0, knockup));
        if (health <= 0) {
            if (gameObject.tag == "RightBoss") JS_playerController.doubleJumpUnlocked = true;
            if (gameObject.tag == "LeftBoss") JS_playerController.groundPoundUnlocked = true;
            Destroy(gameObject.transform.parent.gameObject);
        } 
		}
    }
}