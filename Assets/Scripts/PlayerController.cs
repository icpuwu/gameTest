using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //Player Movement
    Vector3 playermove;
    public float speed;
    Animator playerAni;
    public float turnSpeed = 20f;
    Rigidbody playerRb;
    Quaternion rotation = Quaternion.identity;

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

            bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
            bool hashorizontal = !Mathf.Approximately(horizontal, 0f);
            isRunning = hashorizontal || hasVerticalInput;

            playerAni.SetBool("isRunning", isRunning);



            Vector3 desiredForward = Vector3.RotateTowards(transform.forward, playermove, turnSpeed * Time.deltaTime, 0f);
            rotation = Quaternion.LookRotation(desiredForward); //單位四元數（Unit quaternion）可以用於表示三維空間裡的旋轉
            playerRb.AddForce(playermove * speed);
        }

        if(!once && isRunning)
        {
            StartCoroutine(running());
        }
        if (!isRunning)
        {
            playerAudio.Stop();
            once = false;
        }
    }

    private void OnAnimatorMove()
    {
        //playerRb.MovePosition(playerRb.position + playermove * playerAni.deltaPosition.magnitude*speed);
        if(dooropen.freezePlayer!=true)
        playerRb.MoveRotation(rotation);
    }

    IEnumerator running()
    {
        once = true;
        playerAudio.PlayOneShot(runningSound);
        yield return new WaitForSeconds(4.0f);
        once = false;
    }
}
