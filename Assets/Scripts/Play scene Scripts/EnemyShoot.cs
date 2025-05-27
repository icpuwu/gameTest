using En;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



/*         ＬＯＯＫ　ＨＥＲＥ　！！！

if the annotation r Garbled characters pls turn ur own computer code to japanese computer code
cuz mine computer is japanese computer code :D
or find a way to decode it urself idk

i already try turn all the script to UTF-8 code but idk its successful or not

*/

//給自瞄帶血條敵人的script

public class EnemyShoot : MonoBehaviour
{
    //this is use for shooting player.
    public GameObject player;
    public GameObject Bullet;
    public Transform shootPoint;
   
  

    Rigidbody emenyrb;
    Rigidbody playerrg;
 
   

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
       



        en = GetComponent<Enemy>(); //因monoBehavior無法被實例化
                                    //所以在這直接取得Enemy class

        en.Init(playerrg, emenyrb, bloodBar, Bullet); //詳請請看Enemy.cs內介紹(enemy class)
        en.SetEnemyBeenKill(enemyan, player, wincamera, boom, emenyad, booom);
        en.StartPrepare(); //超酷延時系統


    }

    // Update is called once per frame
    void Update()
    {
        en.EnemyAttack(shootPoint);
    }


    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("playerBullet")) //被玩家子彈碰到後的行為
        {

            en.EnemyGetDamage(20);  
            Destroy(other.gameObject); //被砸到後令玩家子彈消失
        }
    }

  
}
