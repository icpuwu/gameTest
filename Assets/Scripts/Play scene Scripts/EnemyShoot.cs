using En;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
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
 
    Quaternion q;

    public Image bloodBar;

    //ENEMY HP
    public ParticleSystem boom;
    public GameObject wincamera;
    Animator enemyan;
    AudioSource emenyad;
    public AudioClip booom;
    
    Enemy en;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        emenyrb = GetComponent<Rigidbody>();
        enemyan = GetComponent<Animator>();
        playerrg = player.GetComponent<Rigidbody>();
        emenyad = GetComponent<AudioSource>();
        playcontroller = player.gameObject.GetComponent<PlayController>();



        en = GetComponent<Enemy>(); //ˆömonoBehavior–³–@”í›‰—á‰»
                                    //ŠˆÈİ”‡’¼Úæ“¾Enemy class

        en.Init(playerrg, emenyrb, bloodBar, Bullet);
        en.SetEnemyBeenKill(enemyan, player, wincamera, boom, emenyad, booom);
        en.StartPrepare(); //’´“‰„Œn“


    }

    // Update is called once per frame
    void Update()
    {
        en.EnemyAttack(shootPoint);
    }


    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("playerBullet"))
        {

            en.EnemyGetDamage(20);
            Destroy(other.gameObject);
        }
    }

  
}
