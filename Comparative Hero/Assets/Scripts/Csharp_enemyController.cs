using UnityEngine;
using System.Collections;

public class Csharp_enemyController : MonoBehaviour {

    public float speed = 3f;

    protected Vector3 initialPosition;
    protected bool left = false;

	// Use this for initialization
	virtual protected void Start () {
        initialPosition = transform.position;
	}

    // Update is called once per frame
    virtual protected void Update () {
        if (transform.position.x >= initialPosition.x + 3) left = true;
        if (transform.position.x < initialPosition.x) left = false;

        if (!left)transform.Translate(Vector3.right * Time.deltaTime * speed);
        if (left)transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    virtual protected void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player") col.transform.position = new Vector3(-4, 3, 0);
    }
}
