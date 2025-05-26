using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using En;
public class FoEnemyNotTarget : MonoBehaviour
{
    //this is use for shooting player.

    
    public GameObject player;
    public GameObject Bullet;
    public Transform shootPoint;

    Rigidbody emenyrb;
    Rigidbody playerrg;

    Quaternion q;

    Enemy en;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        emenyrb = GetComponent<Rigidbody>();
        playerrg = player.GetComponent<Rigidbody>();

        en = GetComponent<Enemy>();  //ˆömonoBehavior–³–@”í›‰—á‰»
                                     //ŠˆÈİ”‡’¼Úæ“¾Enemy class
        en.Init(playerrg, emenyrb, Bullet,player);
        en.StartPrepare();

    }

    // Update is called once per frame
    void Update()
    {
        en.StaticEnemyAttack(shootPoint);
    }

  
}
