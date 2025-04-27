using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net.NetworkInformation;

public class playerBlood : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int blood = 3;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    bool godTime = false;
    public bool gameover;

    
    Animator playerani;
    SkinnedMeshRenderer smr;
    public GameObject dyingCamera;
    
   
    void Start()
    {
        playerani = GetComponent<Animator>();
        smr = GameObject.Find("icpFix/Body").GetComponent<SkinnedMeshRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (blood <= 0)
        {
            Debug.Log("u lose");

        }

        if (blood < 3 && blood > 1)
            heart1.SetActive(false);

        if (blood < 2 && blood > 0)
            heart2.SetActive(false);

        if (blood <= 0)
        {
            heart3.SetActive(false);
            playerani.SetBool("dying", true);
            dyingCamera.SetActive(true);
            StartCoroutine(closeEyes()); // just use this to close model eyes after 0.5 sec i dunno y i write this shit
            gameover = true;
            StartCoroutine(goToGameOverScene());
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet") && godTime == false)
        {
            godTime = true;
            Debug.Log("player been hit!!");
            blood -= 1;
            Destroy(other.gameObject);
            StartCoroutine(GodTime());
        }
    }

    IEnumerator GodTime()
    {
        yield return new WaitForSeconds(0.7f);
        godTime = false;
    }

    IEnumerator closeEyes()
    {
        yield return new WaitForSeconds(0.5f);
        smr.SetBlendShapeWeight(0, 100f);
    }

    IEnumerator goToGameOverScene()
    {
        yield return new WaitForSeconds(2.7f);
        SceneManager.LoadScene("gameOver");
    }
   
}
