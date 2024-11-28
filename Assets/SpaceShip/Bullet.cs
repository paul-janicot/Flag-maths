using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
     [SerializeField] private float bulletSpeed;
    [SerializeField] private Vector2 screenSize;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        screenSize = Camera.main.ViewportToWorldPoint(Vector2.one) - Camera.main.ViewportToWorldPoint(Vector2.zero);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.up*Time.deltaTime*bulletSpeed;
        if ((startPosition-transform.position).magnitude > screenSize.x/2)
        {
            Destroy(gameObject);
        }
    }
}
