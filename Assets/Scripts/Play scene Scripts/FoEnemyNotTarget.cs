using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using En;

/*         ＬＯＯＫ　ＨＥＲＥ　！！！

if the annotation r Garbled characters pls turn ur own computer code to japanese computer code
cuz mine computer is japanese computer code :D
or find a way to decode it urself idk

i already try turn all the script to UTF-8 code but idk its successful or not

*/

//給自瞄但非被攻擊對象敵人用的script

public class FoEnemyNotTarget : MonoBehaviour
{
    //this is use for shooting player.

    
    public GameObject player;
    public GameObject Bullet;
    public Transform shootPoint;

    Rigidbody emenyrb;
    Rigidbody playerrg;

    Enemy en; //詳請請看Enemy.cs內介紹(enemy class)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        emenyrb = GetComponent<Rigidbody>();
        playerrg = player.GetComponent<Rigidbody>();

        en = GetComponent<Enemy>();  //因monoBehavior無法被實例化
                                     //所以在這直接取得Enemy class
        en.Init(playerrg, emenyrb, Bullet,player);
        en.StartPrepare();

    }

    // Update is called once per frame
    void Update()
    {
        en.StaticEnemyAttack(shootPoint);
    }

  
}
