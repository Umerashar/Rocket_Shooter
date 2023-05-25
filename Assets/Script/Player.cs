using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject shieldGameObject;
    [SerializeField] GameObject playerExpo;
    [SerializeField]
     float _speed= 5f;
    public GameObject laser;
    public GameObject triplelaser;
    [SerializeField] float _fireRate = 0.25f;
     float _canFire = 0.0f;
    public bool cantripleShoort = false;
    public bool boostSpeed = false;
    public bool IsShieldEnable = false;
    [SerializeField] int Lives = 3;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
       
    }

    // Update is called once per frame
    void Update()

    {
        Movements();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
            
        }
    }
    void Shoot()
    {
        if (Time.time > _canFire)
        {
            if (cantripleShoort == true)
            {
                Instantiate(triplelaser, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(laser, transform.position + new Vector3(0f, 1.298f, 0f), Quaternion.identity);
            }
            
            _canFire = Time.time + _fireRate;
        }
    }
    void Movements()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vartical = Input.GetAxis("Vertical");
        if (boostSpeed == true)
        {
            transform.Translate(transform.right * horizontal * _speed *1.5f * Time.deltaTime);
            transform.Translate(transform.up * vartical * _speed * 1.5f * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * horizontal * _speed * Time.deltaTime);
            transform.Translate(transform.up * vartical * _speed * Time.deltaTime);
        }
       

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
    public void Demage()
    {
        if (IsShieldEnable ==true)
        {
            IsShieldEnable = false;
            shieldGameObject.SetActive(false);
            return;
        }
        Lives--;
        if (Lives<1)
        {
            Instantiate(playerExpo, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    public void SheldActiveOn()
    {
        IsShieldEnable = true;
        shieldGameObject.SetActive(true);
    }
    public void TripleShootOn()
    {
        cantripleShoort = true;
        StartCoroutine(PowerUpTime());
    }
    public void BoostSpeedOn()
    {
        boostSpeed = true;
        StartCoroutine(SpeedBostTime());
        

    }
    IEnumerator PowerUpTime()
    {
        yield return new WaitForSeconds(5.0f);
        cantripleShoort = false;
        
    }
    IEnumerator SpeedBostTime()
    {
        yield return new WaitForSeconds(5.0f);
        boostSpeed = false;
    }
}
