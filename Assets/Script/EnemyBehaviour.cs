using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] GameObject EnemyExplosion;
    [SerializeField] float _Speed =5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _Speed * Time.deltaTime);
        if (transform.position.y < -7)
        {
            float Xram = Random.Range(-8, 8);
            transform.position = new Vector3(Xram, 7, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            if (collision.transform.parent != null)
            {
                Destroy(collision.transform.parent.gameObject);
            }
            Destroy(collision.gameObject);
            Instantiate(EnemyExplosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (collision.tag == "Player")
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.Demage();
            }
            Instantiate(EnemyExplosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
