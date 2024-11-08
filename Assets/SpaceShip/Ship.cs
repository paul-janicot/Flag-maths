using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Vector2 screenSize;
    public Vector2 speed;
    public float acceleration;
    // Start is called before the first frame update
    void Start()
    {
        screenSize = Camera.main.ViewportToWorldPoint(Vector2.one) - Camera.main.ViewportToWorldPoint(Vector2.zero);
    }

    // Update is called once per frame
    void Update()
    {
        speed += new Vector2(acceleration * Time.deltaTime, 0);
        transform.position += new Vector3(speed.x, 0, 0);
        if (transform.position.x > screenSize.x-5)
        {
            transform.position = new Vector3(-screenSize.x+5, 0, 0);
        }
    }
}
