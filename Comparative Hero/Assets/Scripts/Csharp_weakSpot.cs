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
            health -= 1;
            col.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, knockup));
            if (health <= 0) {
                if (gameObject.tag == "RightBoss") Csharp_playerController.doubleJump = true;
                Destroy(gameObject.transform.parent.gameObject);
            } 
        }
    }
}
