using UnityEngine;
using System.Collections;

public class Csharp_playerController : MonoBehaviour {

    public float speed = 5f;
    public float jumpForce = 250f;

    private bool grounded = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        //Left-Right Movement
        if (Input.GetKey(KeyCode.A)) {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && grounded) {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            grounded = false;
        }
    }

    //Grounding
    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.tag == "ground") grounded = true;
        //if (col.gameObject.name == "weakSpot") Destroy(col.gameObject.transform.parent);
    }
}
