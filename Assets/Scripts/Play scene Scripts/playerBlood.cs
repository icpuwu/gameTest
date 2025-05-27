using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*         ＬＯＯＫ　ＨＥＲＥ　！！！

if the annotation r Garbled characters pls turn ur own computer code to japanese computer code
cuz mine computer is japanese computer code :D
or find a way to decode it urself idk

i already try turn all the script to UTF-8 code but idk its successful or not

*/

//yay this script is use for playerblood

public class playerBlood : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int blood = 3; //玩家血量
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    bool godTime = false; 
    public bool gameover;

    
    Animator playerani;
    SkinnedMeshRenderer smr;
    public GameObject dyingCamera; //the camera which use for track player when player die
    
    
   
    void Start()
    {
        playerani = GetComponent<Animator>();
        smr = GameObject.Find("icpFix/Body").GetComponent<SkinnedMeshRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
       

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
        if (other.CompareTag("bullet") && godTime == false) //when player been hit by enemy
        {
            godTime = true;
            Debug.Log("player been hit!!");
            blood -= 1;
            Destroy(other.gameObject);
            StartCoroutine(GodTime());
        }
    }

    IEnumerator GodTime() //0.2s無敵時間
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
