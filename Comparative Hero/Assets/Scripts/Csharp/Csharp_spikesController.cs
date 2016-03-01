using UnityEngine;
using System.Collections;

public class Csharp_spikesController : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player") col.transform.position = new Vector3(-4, 3, 0);
    }
}
