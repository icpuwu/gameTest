using System.Collections;
using UnityEngine;

/*         ＬＯＯＫ　ＨＥＲＥ　！！！

if the annotation r Garbled characters pls turn ur own computer code to japanese computer code
cuz mine computer is japanese computer code :D
or find a way to decode it urself idk

i already try turn all the script to UTF-8 code but idk its successful or not

*/


//this script is use for controll running sound

public class running : MonoBehaviour
{
    public AudioClip runSound;
    AudioSource playerAudio;
    public PlayController playcontr;
    
    bool once = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playcontr.isRunning == true && !once)  
        {
           
            StartCoroutine(run());
        }
        if(playcontr.isRunning == false)
        {
            playerAudio.Stop();
            once = false; //確保停下後立即再跑會馬上有聲音
        }
    }

    IEnumerator run()
    {
        once = true; 
        playerAudio.PlayOneShot(runSound);
        yield return new WaitForSeconds(4.0f); //跑步的se 時長為4 sec
        once = false;
    }
}
