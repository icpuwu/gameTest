using UnityEngine;
using System.Collections;

public class shoot2 : MonoBehaviour
{
    bool attack = false;
    public Transform shootPoint;

    public GameObject bullet;
    GameObject newbullet;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(prepare());
    }

    // Update is called once per frame
    void Update()
    {
        if (attack == true)
        {
            Vector3 fwd = transform.forward;
            newbullet = Instantiate(bullet, shootPoint.position, Quaternion.LookRotation(fwd));
            Rigidbody newrb = newbullet.GetComponent<Rigidbody>();
            newrb.linearVelocity = fwd * 100.0f; // the speed of bullet
            attack = false;
            StartCoroutine(shooot());
        }
    }

    IEnumerator shooot()
    {
        yield return new WaitForSeconds(2.0f);
        attack = true;

    }

    IEnumerator prepare()
    {
        yield return new WaitForSeconds(0.5f);
        attack = true;
    }
}
