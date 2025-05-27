using UnityEngine;
using UnityEngine.UI;
using En;
using UnityEngine.SceneManagement;
using System.Collections;


/*         ＬＯＯＫ　ＨＥＲＥ　！！！

if the annotation r Garbled characters pls turn ur own computer code to japanese computer code
cuz mine computer is japanese computer code :D
or find a way to decode it urself idk

i already try turn all the script to UTF-8 code but idk its successful or not

*/


//人頭敵人

public class enemyBlood : MonoBehaviour
{
    public Image bloodBar;
    public ParticleSystem boom;
  

    Enemy en;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        en = GetComponent<Enemy>(); //詳請請看Enemy.cs內介紹(enemy class)
        en.SetBloodBar(bloodBar);
        en.SetEnemyHp(120);
        en.SetFullhp();
    }

    // Update is called once per frame
    void Update()
    {
        if (!en.GetOnce() && en.GetEnemyHp() <= 0) //死掉後的動作 只搞一次
        {
            boom.Play();
            en.SetOnce(true);
            en.ToOtherLevel("SampleScene");
        }
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

