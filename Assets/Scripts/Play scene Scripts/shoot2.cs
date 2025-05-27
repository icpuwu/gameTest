using UnityEngine;
using En;
using System.Collections;

/*         ＬＯＯＫ　ＨＥＲＥ　！！！

if the annotation r Garbled characters pls turn ur own computer code to japanese computer code
cuz mine computer is japanese computer code :D
or find a way to decode it urself idk

i already try turn all the script to UTF-8 code but idk its successful or not

*/



 //給非自瞄且非被攻擊對象敵人的enemy用的script


public class shoot2 : MonoBehaviour
{
   
    public Transform shootPoint; //詳細參Enemy.cs(Enemy class)
    public GameObject bullet;
    GameObject newbullet;
    Enemy en;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        en = GetComponent<Enemy>();
        en.Init(bullet);
        en.StartPrepare();
    }

    // Update is called once per frame
    void Update()
    {
        en.NormalEnemyAttack(shootPoint);
    }

   
}
