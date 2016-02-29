using UnityEngine;
using System.Collections;

public class Csharp_spikesController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player") col.transform.position = new Vector3(-4, 3, 0);
    }
}
