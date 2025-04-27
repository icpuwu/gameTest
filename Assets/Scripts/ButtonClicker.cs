using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClicker : MonoBehaviour
{
    public Button enterBt;
    public Button leaveBt;
    public Button no;
    public Button yes;

    public GameObject textbackG;
    public GameObject butE;
    public GameObject butL;
    public GameObject q;
    public GameObject e;

    doorOpen DoorOpen;
    public GameObject door;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DoorOpen = door.GetComponent<doorOpen>();
        leaveBt.onClick.AddListener(LeaveButtonClick);
        enterBt.onClick.AddListener(EnterButtonClick);
        no.onClick.AddListener(ButtonNoClick);
        yes.onClick.AddListener(ButtonYesClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LeaveButtonClick()
    {
        e.SetActive(true);
        DoorOpen.freezePlayer = false;
        textbackG.SetActive(false);
        butE.SetActive(false);
        butL.SetActive(false);
    }

    void EnterButtonClick()
    {
        q.SetActive(true);
        textbackG.SetActive(false);
        butE.SetActive(false);
        butL.SetActive(false);
    }

    void ButtonNoClick()
    {
        SceneManager.LoadScene("level 1");
        DoorOpen.freezePlayer = false;
    }

    void ButtonYesClick()
    {
        SceneManager.LoadScene("talkScene");
        DoorOpen.freezePlayer = false;
    }
   
}
