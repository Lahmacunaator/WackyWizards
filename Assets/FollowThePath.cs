using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    (SerializeField)
        private transform() waypoints;

          (SerializeField)
        private float movespeed = 2f;

    private int waypointIndex = 0;

    // Start is called before the first frame update
   private void Start()
    {
        transform.position = waypointIndex(waypontIndex).transform.position;
    }

    // Update is called once per frame
   private void Update()
    {
        movespeed();
        {
            private void Move()
                private void move() 
            
                if (waypointIndex <= waypoint.Length - 1)
            {
                transform.posistion = Vector2.MoveTowards(transform.position, waypoints(waypointIndex).transform.position, moveSpeed * Time.deltaTime);

                if (transform.position == waypoints(waypointIndex).transform.position) 
                {
                waypointIndex += 1:
                }
            }
        }
    }


}
