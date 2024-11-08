using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Zombielook : MonoBehaviour
{
    // Start is called before the first frame update
    public float angle;

    public Transform Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float opposite = (Player.transform.position.x - transform.position.x);
        float adjacent = (Player.transform.position.y - transform.position.y);
        angle = 180 - Mathf.Atan2(opposite, adjacent) * (180/Mathf.PI);
        Debug.Log(angle);

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    
}
