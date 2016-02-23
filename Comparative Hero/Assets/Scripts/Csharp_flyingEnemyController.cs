using UnityEngine;
using System.Collections;

public class Csharp_flyingEnemyController : Csharp_enemyController
{

    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (playerBelow()) {
            //transform.Translate(-Vector3.up * Time.deltaTime);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -150));
        }
    }

    public bool playerBelow() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        Debug.Log(hit.collider.name);
        if (hit.collider.name == "Player") return true;
        else return false;
    }
}
