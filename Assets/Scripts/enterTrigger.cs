using System.Collections;
using UnityEngine;

/*         ＬＯＯＫ　ＨＥＲＥ　！！！

if the annotation r Garbled characters pls turn ur own computer code to japanese computer code
cuz mine computer is japanese computer code :D
or find a way to decode it urself idk

i already try turn all the script to UTF-8 code but idk its successful or not

*/

//這份script大致上是用來搞接近白髮NPC行為和調查NPC行為的

public class enterTrigger : MonoBehaviour
{
    public bool enterIcpR = false;
    public GameObject icpCam; //照白髮角色的camera
    public GameObject panel; //text box background
    public GameObject player; //玩家
    public GameObject mark; //在白髮上轉的 ! UI

    public GameObject e;  //"調查/E" 提示面板

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E)&& enterIcpR) //若在白髮碰撞箱內&&按了E 把調查UI && ! UI關了 然後開照白髮角色的camera
        {
            e.SetActive(false);
            player.SetActive(false);
            mark.SetActive(false);
            icpCam.SetActive(true);

            StartCoroutine(wait());
        }
    }

    private void OnTriggerEnter(Collider other) //進入白髮範圍內
    {
        if (other.CompareTag("Player"))
        {
            e.SetActive(true); //顯示調查UI
            enterIcpR = true; //進入範圍內
        }
    }
    private void OnTriggerExit(Collider other) //和上面反著來
    {
        if (other.CompareTag("Player"))
        {
            e.SetActive(false); 
            enterIcpR = false;
        }
    }

    IEnumerator wait() //延時機 使攝像頭就定位後再出現text background
    {
        yield return new WaitForSeconds(0.8f);
        panel.SetActive(true);
    }
}
