using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

/*         ＬＯＯＫ　ＨＥＲＥ　！！！

if the annotation r Garbled characters pls turn ur own computer code to japanese computer code
cuz mine computer is japanese computer code :D
or find a way to decode it urself idk

i already try turn all the script to UTF-8 code but idk its successful or not

*/

//這份script大致上是用來搞sampleSecne 的Player行為的

public class PlayerController : MonoBehaviour
{
    //Player Movement
    Vector3 playermove;
    public float speed;
    Animator playerAni;
    public float turnSpeed = 20f;
    Rigidbody playerRb;
    Quaternion rotation = Quaternion.identity; //參考Unity Learn的單位四元數

    CharacterController cc;

    //freeze player when talking or making desicion
    doorOpen dooropen;
    public GameObject door;

   //sound(SE)
    AudioSource playerAudio;
    public AudioClip runningSound;
    bool once = false;
    bool isRunning;


    void Start()
    {
        
        playerAni = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        dooropen = door.GetComponent<doorOpen>();
        
        
        playerAudio = GetComponent<AudioSource>();

        
    }
   
   
   
    // Update is called once per frame
    void FixedUpdate()
    {
        if (dooropen.freezePlayer != true)
        {
            float vertical = Input.GetAxis("Vertical");
            float horizontal = Input.GetAxis("Horizontal");

            playermove.Set(horizontal, 0f, vertical);
            playermove.Normalize();

            // <<以下為參考unity Learn的程式碼>>

            //搞旋轉的
            bool hasVerticalInput = !Mathf.Approximately(vertical, 0f); //與後面的數比較 vertical的數若靠近0 為true 
            bool hashorizontal = !Mathf.Approximately(horizontal, 0f); //同上

            isRunning = hashorizontal || hasVerticalInput;//這個不是
            playerAni.SetBool("isRunning", isRunning); //這個不是


            //平滑地旋轉朝向另一個方向(目前方向,要朝向的方向,旋轉速,向量長度變化的最大量)
            Vector3 desiredForward = Vector3.RotateTowards(transform.forward, playermove, turnSpeed * Time.deltaTime, 0f);

            rotation = Quaternion.LookRotation(desiredForward); //單位四元數（Unit quaternion）可以用於表示三維空間裡的旋轉
            playerRb.AddForce(playermove * speed);

            //<<至此>>
        }

        if(!once && isRunning) //搞跑步動畫和音效的
        {
            StartCoroutine(running());
        }
        if (!isRunning)
        {
            playerAudio.Stop();
            once = false; //確保停以後再跑可以馬上播音效
        }
    }

    private void OnAnimatorMove() //門開時凍人的 
    {
        if(dooropen.freezePlayer!=true)
        playerRb.MoveRotation(rotation);
    }

    IEnumerator running()
    {
        once = true; //確保只播一次 播完後才會再播(se長度:4秒)
        playerAudio.PlayOneShot(runningSound);
        yield return new WaitForSeconds(4.0f);
        once = false;
    }
}
