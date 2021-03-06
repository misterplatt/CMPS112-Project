﻿using UnityEngine;
using System.Collections;

public class Csharp_weakSpot : MonoBehaviour {

    public float knockup = 500f;
    public int health = 1;

	void Start(){
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
			if(gameObject.tag == "DownBoss"){
				if(col.gameObject.GetComponent<Rigidbody2D>().velocity.y < -10f){
					Csharp_playerController.playerWin = true;
					Destroy(gameObject.transform.parent.gameObject);
				}
			
			}else{
			
			health -= 1;
            Rigidbody2D r = col.gameObject.GetComponent<Rigidbody2D>();
            r.velocity = new Vector2(r.velocity.x, 0);
            r.AddForce(new Vector2(0, knockup));
            if (health <= 0) {
                if (gameObject.tag == "RightBoss") Csharp_playerController.doubleJumpUnlocked = true;
                if (gameObject.tag == "LeftBoss") Csharp_playerController.groundPoundUnlocked = true;
                Destroy(gameObject.transform.parent.gameObject);
            } 
			}
        }
    }
}
