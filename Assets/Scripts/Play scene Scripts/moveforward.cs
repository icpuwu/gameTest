using UnityEngine;

public class moveforward : MonoBehaviour
{
    Rigidbody bulletrg;
    public float speed = 30.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bulletrg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletrg.AddForce(Vector3.forward * speed );
    }
}
