using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

/// <summary>
/// AUTHOR: @Joona H.
/// Last modified: 1 Dec 2022 by @Daniel K.
/// </summary>
public class EnemyAI : MonoBehaviour
{
    /* EXPOSED FIELDS: */
    public Transform target;
    public Transform enemyGraphics;
    public float speed = 200f;
    public float waypointDistance = 3f;

    /* HIDDEN FIELDS: */
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
        
    }
    void UpdatePath()
    {
        if (seeker.IsDone())
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // if (CameraController.GetIsInRoom()) return;
        
        if (path == null)
            return;
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * (speed * Time.deltaTime);

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < waypointDistance)
        {
            currentWaypoint++;
        }

        if (force.x >= 0.01f)
        {
            enemyGraphics.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
            ;
        }
        else if (force.x <= -0.01f)
        {
            enemyGraphics.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
    }
}
