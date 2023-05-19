using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed= 5f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
       
    }

    // Update is called once per frame
    void Update()

    {
        Movements();
    }
    void Movements()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vartical = Input.GetAxis("Vertical");
        transform.Translate(transform.right * horizontal * speed * Time.deltaTime);
        transform.Translate(transform.up * vartical * speed * Time.deltaTime);

        if (transform.position.y > 2.96f)
        {
            transform.position = new Vector3(transform.position.x, 2.96f, 0);
        }
        else if (transform.position.y < -3.46f)
        {
            transform.position = new Vector3(transform.position.x, -3.46f, 0);
        }
        if (transform.position.x > 7.3f)
        {
            transform.position = new Vector3(7.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -7.3f)
        {
            transform.position = new Vector3(-7.3f, transform.position.y, 0);
        }
    }
}
