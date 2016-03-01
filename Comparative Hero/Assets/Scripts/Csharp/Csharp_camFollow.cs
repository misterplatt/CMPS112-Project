using UnityEngine;
using System.Collections;

public class Csharp_camFollow : MonoBehaviour {

    public GameObject player;

    float smoothrate = 0.5f;
    Vector2 velocity = new Vector2(.5f, .5f);

    Vector2 newPos2D = Vector2.zero;
	
	// Update is called once per frame
	void Update () {
        //Smoothdamp the x and y values between the player and the camera
        newPos2D.x = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothrate);
        newPos2D.y = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothrate);

        //Set the camera's position to the smooth-damped value
        transform.position = new Vector3(newPos2D.x, newPos2D.y, transform.position.z);
    }
}
