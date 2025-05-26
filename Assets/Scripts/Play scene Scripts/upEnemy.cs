using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upEnemy : MonoBehaviour
{
    Rigidbody upenemyRg;
    public int speed;
   
    bool collideWithFloor = false; 
    public playerBlood playerblood; 
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        upenemyRg = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!collideWithFloor)
            upenemyRg.AddForce(Vector3.down * speed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("floor"))
        {
            collideWithFloor = true;
            upenemyRg.constraints = RigidbodyConstraints.FreezePositionY;
            StartCoroutine(del());
        }

       
    }

    IEnumerator del()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
    
  
}
