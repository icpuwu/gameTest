using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/*         ＬＯＯＫ　ＨＥＲＥ　！！！

if the annotation r Garbled characters pls turn ur own computer code to japanese computer code
cuz mine computer is japanese computer code :D
or find a way to decode it urself idk

i already try turn all the script to UTF-8 code but idk its successful or not

*/

//和Scripts - PlayerController.cs 的東西差不多只是多了些方法
public class PlayController : MonoBehaviour
{
    bool prepared = false;
    //Player Movement
    Vector3 playermove;
    public float speed;
    Animator playerAni;
    public float turnSpeed = 20f;
    Rigidbody playerRb;
    Quaternion rotation = Quaternion.identity; //參考Unity Learn的單位四元數


    public GameObject bullet;
    public GameObject newbullet;
    public Transform shootpoint;
    bool shooting = false;
    bool shootCD = true;
    bool sprintCD = true;
    playerBlood playerblood;

    //sound(SE)
     AudioSource playerAudio;
     public AudioClip shootingSound;
     public AudioClip sprintSound;
     public AudioClip dyingSound;
     bool alreadyPlay = false;

    public bool isRunning;

    void Start()
    {

        playerAni = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();

        playerblood = GetComponent<playerBlood>();

        playerAudio = GetComponent<AudioSource>();
        StartCoroutine(prepare());


    }

    private void Update()
    {
        if (prepared && playerblood.gameover == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)&& shootCD == true)//shoot bullets
            {
                shooting = true;
                shootCD = false;
                playerAni.SetBool("shooting", true);
                Vector3 fwd = transform.forward;
                newbullet = Instantiate(bullet, shootpoint.position, Quaternion.LookRotation(fwd));
                Rigidbody newrb = newbullet.GetComponent<Rigidbody>();
                newrb.linearVelocity = fwd * 100.0f; // the speed of bullet
                playerAudio.PlayOneShot(shootingSound);
                StartCoroutine(shootEnd());

            }

            if (Input.GetKeyDown(KeyCode.Mouse1) && sprintCD)//sprint
            {
                float vertical = Input.GetAxis("Vertical");
                float horizontal = Input.GetAxis("Horizontal");
                playerAni.SetBool("sprint", true);
                sprintCD = false;
                StartCoroutine(sprintEnd());
                playerRb.AddForce(playermove * 50, ForceMode.Impulse);
                playerAudio.PlayOneShot(sprintSound);
            }

            
                
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        playermove.Set(horizontal, 0f, vertical);
        playermove.Normalize();

        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool hashorizontal = !Mathf.Approximately(horizontal, 0f);
        isRunning = hashorizontal || hasVerticalInput;

        playerAni.SetBool("isRunning", isRunning);


        // <<以下為參考unity Learn的程式碼>>
        //詳情參 PlayerController.cs

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, playermove, turnSpeed * Time.deltaTime, 0f);
        rotation = Quaternion.LookRotation(desiredForward); //單位四元數（Unit quaternion）可以用於表示三維空間裡的旋轉

       //<<至此>>

        if (!shooting && playerblood.gameover == false)//when shooting or gameover,cant move
        playerRb.AddForce(playermove * speed);

        if (playerblood.gameover == true && alreadyPlay == false)
        {
            playerAudio.PlayOneShot(dyingSound);
            alreadyPlay = true;
        }

    }

    private void OnAnimatorMove() // <= 此方法推薦來自GPT
    {
       
        if(playerblood.gameover ==false) //when gameover,cant rotate
        playerRb.MoveRotation(rotation);
    }

    IEnumerator shootEnd() //the Cd of shooting Bullet(player)
    {
        yield return new WaitForSeconds(0.4f);
        playerAni.SetBool("shooting", false);
        shooting = false;
        shootCD = true;
    }

    IEnumerator sprintEnd() // the Cd of sprint
    {
        yield return new WaitForSeconds(0.3f);
        playerAni.SetBool("sprint", false);
        sprintCD = true;
    }

    IEnumerator prepare()
    {
        yield return new WaitForSeconds(0.5f);
        prepared = true;
    }

}
