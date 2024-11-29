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
    private Vector3 goalPosition;
    private Vector3 tempMouse;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float coolDown;
    [SerializeField] private float nextShoot;
    public List<GameObject> listOfBullet;
    public float radius;
    // Start is called before the first frame update
    void Start()
    {
        goalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        screenSize = Camera.main.ViewportToWorldPoint(Vector2.one) - Camera.main.ViewportToWorldPoint(Vector2.zero);
        nextShoot = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (goalPosition != Camera.main.ScreenToWorldPoint(Input.mousePosition))
        {
            goalPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 difference = goalPosition - transform.position;
            transform.rotation = Quaternion.Euler(0, 0,180 -Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg);
        }


        //float opposite = ((Input.mousePosition.x-Camera.main.WorldToScreenPoint(transform.position).x) - transform.position.x);
        //float adjacent = ((Input.mousePosition.y - Camera.main.WorldToScreenPoint(transform.position).y) - transform.position.y);
        //float distance = (tempMouse.x - Input.mousePosition.x) * (tempMouse.x - Input.mousePosition.x) + (tempMouse.y - Input.mousePosition.y) * (tempMouse.y - Input.mousePosition.y);
        //angle = 180 - Mathf.Atan2(opposite, adjacent) * (180 / Mathf.PI);
        //if(distance<1.1 && Input.mousePosition != tempMouse)
        //    transform.rotation = Quaternion.Euler(0f, 0f, angle);



        if (Input.GetKey(KeyCode.E))
            speed += new Vector2(acceleration * Time.deltaTime, 0);
        transform.position += -transform.up * speed.x;
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
            transform.position = new Vector3(transform.position.x, screenSize.y / 2, 0);
        }
        if (speed.x > maxSpeed)
        {
            speed = new Vector2(maxSpeed, 0);
        }
        //tempMouse = Input.mousePosition;

        if (Input.GetKeyDown(KeyCode.Q) && Time.time>nextShoot)
        {

            listOfBullet.Add(Instantiate(bullet, transform.position, transform.rotation)); 
            nextShoot = Time.time+coolDown;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);

    }
}
