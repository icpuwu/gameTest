using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/*         ＬＯＯＫ　ＨＥＲＥ　！！！

if the annotation r Garbled characters pls turn ur own computer code to japanese computer code
cuz mine computer is japanese computer code :D
or find a way to decode it urself idk

i already try turn all the script to UTF-8 code but idk its successful or not

*/


//這份script大致上是用來按sample scene的按鈕後會發生啥


public class ButtonClicker : MonoBehaviour
{
    public Button enterBt; //進入bt
    public Button leaveBt; //離開bt
    public Button no;      //"看新手教學"bt
    public Button yes;     //"不看新教"bt

    public GameObject textbackG; //Text backgroound
    public GameObject butE; //進入bt
    public GameObject butL; //離開bt
    public GameObject q; //"要觀看新手教學嗎?" 提示面板
    public GameObject e; //"調查/E" 提示面板

    doorOpen DoorOpen; //doorOpen script
    public GameObject door; //Sci Fi Door

  
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DoorOpen = door.GetComponent<doorOpen>();
        leaveBt.onClick.AddListener(LeaveButtonClick); //給按鈕掛方法
        enterBt.onClick.AddListener(EnterButtonClick);
        no.onClick.AddListener(ButtonNoClick);
        yes.onClick.AddListener(ButtonYesClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LeaveButtonClick() //leave but(不進入) 的方法 解凍player 關畢除 "調查/E" 提示面板 以外的UI
    {
        e.SetActive(true);
        DoorOpen.freezePlayer = false; 
        textbackG.SetActive(false);
        butE.SetActive(false);
        butL.SetActive(false);
    }

    void EnterButtonClick() //enter but(進入) 的方法 總之就是和上面反著來
    {
        q.SetActive(true);
        textbackG.SetActive(false);
        butE.SetActive(false);
        butL.SetActive(false);
    }

    void ButtonNoClick() //jump to level 1 scene
    {
        SceneManager.LoadScene("level 1");
        DoorOpen.freezePlayer = false;
    }

    void ButtonYesClick() //jump to talk scene
    {
        SceneManager.LoadScene("talkScene");
        DoorOpen.freezePlayer = false;
    }
   
}
