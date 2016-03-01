using UnityEngine;
using System.Collections;

public class Csharp_flyingEnemyController : Csharp_enemyController
{
    public float riseSpeed = 3f;

    private float timer = 0f;
    private bool dropped = false;
    private bool rising = false;

    private float defaultHeight;

    protected override void Start()
    {
        base.Start();
        defaultHeight = transform.position.y;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (playerBelow()) {
            dropped = true;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -80));
        }
        if (dropped) {
            timer += Time.deltaTime;
            if (timer > 1.2f) {
                dropped = false;
                rising = true;
                timer = 0f;
            } 
        }
        if (rising) {
            if (transform.position.y < defaultHeight) transform.Translate(Vector3.up * riseSpeed * Time.deltaTime);
            else rising = false;
        }
    }

    public bool playerBelow() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        //Debug.Log(hit.collider.name);
        if (hit.collider.name == "Player") return true;
        else return false;
    }
}
