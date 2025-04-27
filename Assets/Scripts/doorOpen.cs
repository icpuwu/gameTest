using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class doorOpen : MonoBehaviour
{
    Animator doorani;

    public GameObject talkBc;
    public GameObject enterBt;
    public GameObject leaveBt;

    public GameObject e;
    public bool freezePlayer = false;
    bool enter = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        doorani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enter == true && Input.GetKeyDown(KeyCode.E)){
            e.SetActive(false);
            talkBc.SetActive(true);
            enterBt.SetActive(true);
            leaveBt.SetActive(true);
            freezePlayer = true;
            //SceneManager.LoadScene("level 1");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        doorani.SetBool("doorOpen", true);
        enter = true;
    }
    private void OnTriggerExit(Collider other)
    {
        doorani.SetBool("doorOpen", false);
        enter = false;
    }



}
