using UnityEngine;
using System.Collections;

public class Csharp_groundBreak : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && (col.gameObject.GetComponent<Rigidbody2D>().velocity.y < -21.5f)) {
            Debug.Log("Downward force: " + col.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            Destroy(gameObject);
        } 
    }
}
