using System.Collections;
using UnityEngine;

public class running : MonoBehaviour
{
    public AudioClip runSound;
    AudioSource playerAudio;
    public PlayController playcontr;
    bool isrun;
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
            once = false;
        }
    }

    IEnumerator run()
    {
        once = true;
        playerAudio.PlayOneShot(runSound);
        yield return new WaitForSeconds(4.0f);
        once = false;
    }
}
