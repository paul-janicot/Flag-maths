using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    public Ship ship;
    
    private Vector2 differenceShip;
    private Vector2 differenceBullet;
    private float SquareDistance;
    private float distanceBullet;
    public float radius;
    

    // Start is called before the first frame update
    void Start()
    {
        ship = FindObjectOfType<Ship>();
        
    }

    // Update is called once per frame
    void Update()
    {
        differenceShip = ship.transform.position - transform.position;
        SquareDistance = (differenceShip.x * differenceShip.x) + (differenceShip.y * differenceShip.y);
        if (ship && SquareDistance < ((ship.radius + radius) * (ship.radius + radius)))
        {
            SceneManager.LoadScene(1);
        }
        foreach(GameObject bullet in ship.listOfBullet)
        {
            differenceBullet = bullet.transform.position - transform.position;
            distanceBullet = differenceBullet.sqrMagnitude;
            if(distanceBullet < radius)
            {
                GetComponent<Asteroid>().AsteroidDestroy();
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
