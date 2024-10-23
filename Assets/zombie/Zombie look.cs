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
        float opposite = Mathf.Abs(Player.transform.position.y - transform.position.y);
        float adjacent = Mathf.Abs(Player.transform.position.x - transform.position.x);
        angle = Mathf.Atan(opposite/ adjacent) * (180/Mathf.PI);
        Debug.Log(angle);

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
