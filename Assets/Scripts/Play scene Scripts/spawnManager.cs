using System.Collections;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject upBullet;
    GameObject newupEnemy;
    Transform d;
    bool once = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!once)
        {
            once = true;
            StartCoroutine(spawn());
        }
    }

    IEnumerator spawn()
    {
        Vector3 v = new Vector3(Random.Range(-102,103), 138.0036f, Random.Range(-202,202));
       
        yield return new WaitForSeconds(4f);
        newupEnemy =  Instantiate(upBullet, v, upBullet.transform.rotation);
        d = newupEnemy.transform.Find("danger");
        StartCoroutine(hideDanger());
        once = false;
    }

    IEnumerator hideDanger()
    {
        yield return new WaitForSeconds(1.5f);
        d.gameObject.SetActive(false);
    }
}
