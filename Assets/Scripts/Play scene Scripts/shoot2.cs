using UnityEngine;
using En;
using System.Collections;

public class shoot2 : MonoBehaviour
{
    bool attack = false;
    public Transform shootPoint;
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
