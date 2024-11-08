using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Vector2 screenSize;
    public Vector2 speed;
    public float acceleration;
    public float maxSpeed;
    public float angle;
    private Vector3 tempMouse;
    
    
    // Start is called before the first frame update
    void Start()
    {
        screenSize = Camera.main.ViewportToWorldPoint(Vector2.one) - Camera.main.ViewportToWorldPoint(Vector2.zero);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float opposite = ((Input.mousePosition.x-Camera.main.WorldToScreenPoint(transform.position).x) - transform.position.x);
        float adjacent = ((Input.mousePosition.y - Camera.main.WorldToScreenPoint(transform.position).y) - transform.position.y);
        float distance = (tempMouse.x - Input.mousePosition.x) * (tempMouse.x - Input.mousePosition.x) + (tempMouse.y - Input.mousePosition.y) * (tempMouse.y - Input.mousePosition.y);
        angle = 180 - Mathf.Atan2(opposite, adjacent) * (180 / Mathf.PI);
        if(distance<1.1 && Input.mousePosition != tempMouse)
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        if (Input.GetKey(KeyCode.E))
            speed += new Vector2(acceleration * Time.deltaTime, 0);
        transform.position += -transform.up * speed.x;
        if (transform.position.x > screenSize.x-5)
        {
            transform.position = new Vector3(-screenSize.x+5, 0, 0);
        }
        if(speed.x > maxSpeed)
        {
            speed = new Vector2(maxSpeed, 0);
        }
        tempMouse = Input.mousePosition;

    }
}
