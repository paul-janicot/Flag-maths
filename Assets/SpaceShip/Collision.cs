using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public Ship trackedObject;
    private Vector2 difference;
    private float SquareDistance;
    public float radius;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        difference = trackedObject.transform.position - transform.position;
        SquareDistance = (difference.x * difference.x) + (difference.y * difference.y);
        if (trackedObject && SquareDistance < ((radius * radius) + (trackedObject.radius * radius)))
        {
            GetComponent<Asteroid>().AsteroidDestroy();
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
