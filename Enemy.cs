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
using Sisus.Init;


namespace En
{
    public class Enemy: MonoBehaviour
    {
        Rigidbody playerrg;
        Rigidbody emenyrb;
        Quaternion q;
        public bool attack = false;
        bool once = false;

        float emenyHp = 100;
        float bulletSpeed = 100.0f;
        Image bloodBar;

        Animator enemyan;
        GameObject player;
        GameObject wincamera;
        ParticleSystem boom;
        AudioSource emenyad;
        AudioClip booom;

        GameObject Bullet;
        GameObject newBullet;

       

        //MonoBehaviour類無法用new實例化_(:3?z)_
        public void Init(Rigidbody playerrg,Rigidbody emenyrb, Image bloodBar, GameObject bullet) //給不屑設HP的傢伙
        {
            this.playerrg = playerrg;
            this.emenyrb = emenyrb;
            this.bloodBar = bloodBar;
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

        public float GetEnemyHp() => emenyHp;
        public void SetEnemyHp(float hp)
        {
            hp = this.emenyHp;
        }

        public void SetBulletSpeed(float sp)
        {
            bulletSpeed = sp;
        }

        public void lookForPlayer() //使物件朝著玩家看去
        {
            Vector3 dir = playerrg.position - enemyrb.transform.position;
            q = Quaternion.LookRotation(dir);
            emenyrb.MoveRotation(q);
        }

        public void EnemyGetDamage(float damage) 
        {
            emenyHp = emenyHp - damage;
            bloodBar.fillAmount = emenyHp / 100.0f;
        }
      
        public void EnemyAttack(Transform shootPoint)
        {
            if (emenyHp > 0)
                lookForPlayer();
            if (attack == true)
            {
                newBullet = Instantiate(Bullet, shootPoint.position, q);
                Rigidbody newrb = newBullet.GetComponent<Rigidbody>();
                newrb.linearVelocity = transform.forward * 100.0f; // the speed of bullet
                attack = false;
                StartCoroutine(shooot());
            }

            if (emenyHp <= 0 && !once)
            {
                EnemyBeenKill();
            }
        }
        

        public void EnemyBeenKill(Animator enemyan, GameObject player, GameObject wincamera,
            ParticleSystem boom, AudioSource emenyad, AudioClip booom)
        {
            enemyan.enabled = false; // let the animator stop
            player.SetActive(false);
            wincamera.SetActive(true);
            boom.Play();
            emenyad.PlayOneShot(booom);
            StartCoroutine(toOtherLevel());
            once = true;
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

        void EnemyBeenKill() //用這記得先建構!!!上面那個
        {
            enemyan.enabled = false; // let the animator stop
            player.SetActive(false);
            wincamera.SetActive(true);
            boom.Play();
            emenyad.PlayOneShot(booom);
            StartCoroutine(toOtherLevel());
            once = true;
        }

        public void StartPrepare() //開場延時用
        {
            StartCoroutine(prepare());
        }

        IEnumerator shooot()
        {
            yield return new WaitForSeconds(2.0f);
            attack = true;

        }

        IEnumerator prepare()
        {
            yield return new WaitForSeconds(1.5f);
            attack = true;
        }

        IEnumerator toOtherLevel()
        {
            yield return new WaitForSeconds(0.7f);
            SceneManager.LoadScene("talkScene");

        }
    }
}
