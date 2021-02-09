using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieWayPoints : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float moveSpeed = 3.5f;

    int waypointIndex = 0;

    public bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pointsmove();
    }

    void FixedUpdate()
    {

        float h = Input.GetAxisRaw("Horizontal");
        
        if(h > 0 && !facingRight)
        {
            Flip();
        }
        else if(h < 0 && facingRight)
        {
            Flip();
        }
    }

    void pointsmove()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

        if (transform.position == waypoints [waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }
        
        if(waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
    void Flip ()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
