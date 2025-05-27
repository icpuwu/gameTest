using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/*         ＬＯＯＫ　ＨＥＲＥ　！！！

if the annotation r Garbled characters pls turn ur own computer code to japanese computer code
cuz mine computer is japanese computer code :D
or find a way to decode it urself idk

i already try turn all the script to UTF-8 code but idk its successful or not

*/

//這是enemy class

namespace En
{
    public class Enemy: MonoBehaviour
    {
        Rigidbody playerrg;
        Rigidbody emenyrb;
        Quaternion q;
        bool attack = false;
        bool once = false;

        float emenyHp = 100;
        float bulletSpeed = 100.0f;
        Image bloodBar; //血量條

        Animator enemyan;
        GameObject player;
        GameObject wincamera; //照emeny的攝象機
        ParticleSystem boom;  //爆炸粒子
        AudioSource emenyad;
        AudioClip booom;  //爆炸音效

        GameObject Bullet; 
        GameObject newBullet; //實例化用

        float fullHp = 100.0f;


        //monobehavior 參數無法用new 實例化_(:3/z)_
        //所以只好寫方法傳參數
        public void Init(Rigidbody playerrg,Rigidbody emenyrb, Image bloodBar, GameObject bullet) //給不屑設HP的傢伙
        {
            this.playerrg = playerrg;
            this.emenyrb = emenyrb;
            this.bloodBar = bloodBar;
            Bullet = bullet;
        }
        public void Init(Rigidbody playerrg, Rigidbody emenyrb, GameObject bullet,GameObject player) //給自瞄但非被攻擊對象敵人的enemy用的 
        {
            this.playerrg = playerrg;
            this.emenyrb = emenyrb;
            Bullet = bullet;
            this.player = player;
        }

        public void Init(GameObject bullet) //給非自瞄且非被攻擊對象敵人的enemy用的 
        {
            Bullet = bullet;           
        }
        public void Init(Rigidbody playerrg, Rigidbody emenyrb, Image bloodBar,GameObject bullet,float emenyHP) 
        {
            this.playerrg = playerrg;
            this.emenyrb = emenyrb;
            this.bloodBar = bloodBar;
            this.Bullet = bullet;
            this.emenyHp = emenyHP;
        }

        public void SetBloodBar(Image bloodbar)
        {
            this.bloodBar = bloodbar;
        }
        
        public void SetFullhp()
        {
            fullHp = GetEnemyHp();
        }
        public bool GetOnce() => once;
        public void SetOnce(bool b) {
            once = b;
        }
        public float GetEnemyHp() => emenyHp;
        public void SetEnemyHp(float hp)
        {
            this.emenyHp = hp;
        }

        public void SetBulletSpeed(float sp)
        {
            bulletSpeed = sp;
        }

        public void lookForPlayer() //使物件朝著玩家看去
        {
            Vector3 dir = playerrg.position - emenyrb.transform.position;
            q = Quaternion.LookRotation(dir);
            emenyrb.MoveRotation(q);
        }

        public void EnemyGetDamage(float damage) 
        {
            emenyHp = emenyHp - damage;
            bloodBar.fillAmount = emenyHp / fullHp;
        }
      
        public void EnemyAttack(Transform shootPoint) //給自瞄敵人的attack
        {
            if (emenyHp > 0)
                lookForPlayer();
            if (attack == true)
            {
                newBullet = Instantiate(Bullet, shootPoint.position, q);
                Rigidbody newrb = newBullet.GetComponent<Rigidbody>();
                newrb.linearVelocity = transform.forward * bulletSpeed; // the speed of bullet
                attack = false;
                StartCoroutine(shooot());
            }

            if (emenyHp <= 0 && !once)
            {
                EnemyBeenKill();
            }
        }
        
        public void StaticEnemyAttack(Transform shootPoint) //給自瞄但非被攻擊對象敵人的attack
        {
            lookForPlayer();
            if (attack == true)
            {
                newBullet = Instantiate(Bullet, shootPoint.position, q);
                Rigidbody newrb = newBullet.GetComponent<Rigidbody>();
                newrb.linearVelocity = transform.forward * bulletSpeed; // the speed of bullet
                attack = false;
                StartCoroutine(shooot());
            }
        }

        public void NormalEnemyAttack(Transform shootPoint) //給非自瞄且非被攻擊對象敵人的enemy用的 
        {
            if (attack == true)
            {
                if (attack == true)
                {
                    Vector3 fwd = transform.forward;
                    newBullet = Instantiate(Bullet, shootPoint.position, Quaternion.LookRotation(fwd));
                    Rigidbody newrb = newBullet.GetComponent<Rigidbody>();
                    newrb.linearVelocity = fwd * bulletSpeed; // the speed of bullet
                    attack = false;
                    StartCoroutine(shooot());
                }
            }
        }
     

        public void SetEnemyBeenKill(Animator enemyan, GameObject player, GameObject wincamera, 
            ParticleSystem boom, AudioSource emenyad, AudioClip booom)
        {
            this.enemyan = enemyan;
            this.player = player;
            this.wincamera = wincamera;
            this.boom = boom;
            this.emenyad = emenyad;
            this.booom = booom;

        }

        void EnemyBeenKill() //用這記得先建構!!!上面那個  //處理死亡動畫/聲音/到下個scene
        {
            enemyan.enabled = false; // let the animator stop
            player.SetActive(false);
            wincamera.SetActive(true);
            boom.Play();
            emenyad.PlayOneShot(booom);
            ToOtherLevel("talkScene");
            once = true;
        }

        public void ToOtherLevel(string s)
        {
            StartCoroutine(toOtherLevel(s));
        }
        public void StartPrepare() //開場延時用
        {
            StartCoroutine(prepare());
        }

        IEnumerator shooot() //發射子彈的CD
        {
            yield return new WaitForSeconds(2.0f);
            attack = true;

        }

        IEnumerator prepare() //開場延時用
        {
            yield return new WaitForSeconds(1.5f);
            attack = true;
        }

        IEnumerator toOtherLevel(string s) //到指定的scene
        {
            yield return new WaitForSeconds(0.7f);
            SceneManager.LoadScene(s);

        }
    }
}
