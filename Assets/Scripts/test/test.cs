using UnityEngine;

public class test : MonoBehaviour
{
    Rigidbody DropBallRg;
    public int speed = 10;
    bool collideWithFloor = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DropBallRg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        DropBallRg.AddForce(Vector3.down * speed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("floor"))
        {
            collideWithFloor = true;
            DropBallRg.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }

}