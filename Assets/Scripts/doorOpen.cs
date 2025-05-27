using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/*         ＬＯＯＫ　ＨＥＲＥ　！！！

if the annotation r Garbled characters pls turn ur own computer code to japanese computer code
cuz mine computer is japanese computer code :D
or find a way to decode it urself idk

i already try turn all the script to UTF-8 code but idk its successful or not

*/


//這份script大致上是用來搞開關門行為和調查行為的

public class doorOpen : MonoBehaviour
{
    Animator doorani; //門的動畫

    public GameObject talkBc; //talk background
    public GameObject enterBt; //enter button
    public GameObject leaveBt; //leave button

    public GameObject e; //"調查/E" 提示面板
    public bool freezePlayer = false; //管控玩家位置凍結
    bool enter = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        doorani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enter == true && Input.GetKeyDown(KeyCode.E)){  //按E時把對話選項UI打開
            e.SetActive(false);
            talkBc.SetActive(true);
            enterBt.SetActive(true);
            leaveBt.SetActive(true);
            freezePlayer = true;
            //SceneManager.LoadScene("level 1");
        }
    }

    private void OnTriggerEnter(Collider other) //進入門的碰撞箱時顯示 調查/E" 提示面板 開門動畫的觸發參數設成true
    {
        e.SetActive(true);
        doorani.SetBool("doorOpen", true);
        enter = true;
    }
    private void OnTriggerExit(Collider other) //離開門的碰撞箱時顯示 和上面反著搞
    {
        e.SetActive(false);
        doorani.SetBool("doorOpen", false);
        enter = false;
    }



}
