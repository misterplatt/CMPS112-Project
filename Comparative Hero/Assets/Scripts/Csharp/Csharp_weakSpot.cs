using UnityEngine;
using System.Collections;

public class Csharp_weakSpot : MonoBehaviour {

    public float knockup = 900f;
    public int health = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if(gameObject.tag == "DownBoss"){
			if(col.gameObject.GetComponent<Rigidbody2D>().velocity.y < -21.5f){
			Destroy(gameObject.transform.parent.gameObject);
			}
			
			}else{
			
			health -= 1;
            Rigidbody2D r = col.gameObject.GetComponent<Rigidbody2D>();
            r.velocity = new Vector2(r.velocity.x, 0);
            r.AddForce(new Vector2(0, knockup));
            if (health <= 0) {
                if (gameObject.tag == "RightBoss") Csharp_playerController.doubleJump = true;
                if (gameObject.tag == "LeftBoss") Csharp_playerController.groundPound = true;
                Destroy(gameObject.transform.parent.gameObject);
            } 
			}
        }
    }
}
