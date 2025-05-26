using UnityEngine;

public class DropBall : MonoBehaviour
{
    Rigidbody DropBallRg;
    public int speed = 10;

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
            upenemyRg.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }

}
