using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoint : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    float moveSpeed = 6.0f;

    int waypointIndex = 0;

    public Animator animator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("moving", true);
        if (waypointIndex == 1)
        {
            animator.SetInteger("direction", 2);
        }
        else if (waypointIndex == 2)
        {
            animator.SetInteger("direction", 3);
        }
        else if (waypointIndex == 3)
        {
            animator.SetInteger("direction", 0);
        }
        else if (waypointIndex == 0)
        {
            animator.SetInteger("direction", 1);
        }
        Move();

    }
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
        if(transform.position == waypoints[waypointIndex].transform.position)
        {
            waypointIndex += 1;
        }
        if (waypointIndex == waypoints.Length)
            waypointIndex = 0;
    }
}
