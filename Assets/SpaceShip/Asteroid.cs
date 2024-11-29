using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AsteroidSize
{
    Big,
    Medium,
    Small
}


public class Asteroid : MonoBehaviour
{
    public AsteroidSize currentSize = AsteroidSize.Big;
    [SerializeField] private GameObject mediumAsteroid;
    [SerializeField] private GameObject smallAsteroid;
    //[SerializeField] private int numberOfAsteroid;
    
    [SerializeField] private float asteroidSpeed;
    public Vector2 screenSize;

    // Start is called before the first frame update
    void Start()
    {
        screenSize = Camera.main.ViewportToWorldPoint(Vector2.one) - Camera.main.ViewportToWorldPoint(Vector2.zero);
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0,359));
       

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * asteroidSpeed*Time.deltaTime;
        if (transform.position.x > screenSize.x - 5)
        {
            transform.position = new Vector3(-screenSize.x / 2, transform.position.y, 0);
        }
        if (transform.position.x < -screenSize.x / 2)
        {
            transform.position = new Vector3(screenSize.x / 2, transform.position.y, 0);
        }
        if (transform.position.y > screenSize.y / 2)
        {
            transform.position = new Vector3(transform.position.x, -screenSize.y / 2, 0);
        }
        if (transform.position.y < -screenSize.y / 2)
        {
            transform.position = new Vector3(transform.position.x, screenSize.y /2, 0);
        }
     


    }
    public void AsteroidDestroy()
    {
        GameObject asteroid;
        if (currentSize == AsteroidSize.Big)
        {
            asteroid = mediumAsteroid;
        }
        else if (currentSize == AsteroidSize.Small)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            asteroid = smallAsteroid;
        }
        Debug.Log("Key pressed");
        Instantiate(asteroid, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 359)));
        Instantiate(asteroid, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 359)));
        Destroy(gameObject);
    }
}
