using UnityEngine;


/*         ‚k‚n‚n‚j@‚g‚d‚q‚d@III

if the annotation r Garbled characters pls turn ur own computer code to japanese computer code
cuz mine computer is japanese computer code :D
or find a way to decode it urself idk

i already try turn all the script to UTF-8 code but idk its successful or not

*/

//gqœ[Œü‘OˆÚ“®

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
