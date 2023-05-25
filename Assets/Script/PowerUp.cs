using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] float _speed = 3f;
    [SerializeField] int _BoostID;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag== "Player")
        {
            Player player = collision.GetComponent<Player>();
           if(player !=null)
            {
                if (_BoostID ==0)
                {
                    player.TripleShootOn();
                }
                else if (_BoostID== 1)
                {
                    player.BoostSpeedOn();
                }
                else if (_BoostID==2)
                {
                    player.SheldActiveOn();
                }
                
            }
            Destroy(gameObject);
        }
        
        
    }
}
