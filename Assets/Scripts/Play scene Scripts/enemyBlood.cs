using UnityEngine;
using UnityEngine.UI;
using En;
public class enemyBlood : MonoBehaviour
{
    public Image bloodBar;
    public ParticleSystem boom;
  

    Enemy en;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        en = GetComponent<Enemy>();
        en.SetBloodBar(bloodBar);
        en.SetEnemyHp(120);
        en.SetFullhp();
    }

    // Update is called once per frame
    void Update()
    {
        if (!en.GetOnce() && en.GetEnemyHp() <= 0)
        {
            boom.Play();
            en.SetOnce(true);
        }
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
