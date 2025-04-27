using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShoot : MonoBehaviour
{
    //this is use for shooting player.

    
    public GameObject player;
    public GameObject Bullet;
    public Transform shootPoint;
    GameObject newBullet;
    PlayController playcontroller;

    Rigidbody emenyrb;
    Rigidbody playerrg;
    bool attack = false;

    Quaternion q;

    public Image bloodBar;

    //ENEMY HP
    public float emenyHp = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        emenyrb = GetComponent<Rigidbody>();
        playerrg = player.GetComponent<Rigidbody>();
        StartCoroutine(prepare());
        playcontroller = player.gameObject.GetComponent<PlayController>();

    }

    // Update is called once per frame
    void Update()
    {
        lookForPlayer();
       if(attack == true)
        {
            newBullet = Instantiate(Bullet, shootPoint.position, q);
            Rigidbody newrb = newBullet.GetComponent<Rigidbody>();
            newrb.linearVelocity = transform.forward * 100.0f; // the speed of bullet
            attack = false;
            StartCoroutine(shooot());
        }
    }

    public void lookForPlayer()
    {
        Vector3 dir = playerrg.position - transform.position;
        q = Quaternion.LookRotation(dir);
        emenyrb.MoveRotation(q);
        
    }

    IEnumerator shooot()
    {
        yield return new WaitForSeconds(2.0f);
        attack = true;
        
    }

    IEnumerator prepare()
    {
        yield return new WaitForSeconds(0.5f);
        attack = true;
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("playerBullet"))
        {
            
            emenyHp = emenyHp - 20;
            bloodBar.fillAmount = emenyHp / 100.0f;
            Destroy(other.gameObject);
        }
    }

   
}
