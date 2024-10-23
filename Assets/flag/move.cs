using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float SpeedX;
    public float SpeedY;
    public Vector2 screenSize;
    public Vector2 flagSize;




    // Start is called before the first frame update
    void Start()
    {
        flagSize = GetComponent<SpriteRenderer>().bounds.size;
        screenSize = Camera.main.ViewportToWorldPoint(Vector2.one) - Camera.main.ViewportToWorldPoint(Vector2.zero);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(SpeedX * Time.deltaTime, SpeedY * Time.deltaTime, 0);
        if (transform.position.y > (screenSize.y / 2) - flagSize.y/2)
        {
            SpeedY = -SpeedY;
        }
        if (transform.position.y < (-screenSize.y / 2) + flagSize.y/2)
        {
            SpeedY = -SpeedY;
        }
        if (transform.position.x > (screenSize.x / 2) - flagSize.x/2)
        {
            SpeedX = -SpeedX;
        }
        if (transform.position.x < (-screenSize.x / 2)+ flagSize.y/2)
        {
            SpeedX = -SpeedX;
        }
    }
}
