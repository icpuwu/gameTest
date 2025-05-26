using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class returnBut : MonoBehaviour
{
    public Button returnbutton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        returnbutton.onClick.AddListener(returnbutClick);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void returnbutClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
