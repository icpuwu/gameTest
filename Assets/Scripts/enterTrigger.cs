using System.Collections;
using UnityEngine;

public class enterTrigger : MonoBehaviour
{
    public bool enterIcpR = false;
    public GameObject icpCam;
    public GameObject panel;
    public GameObject player;
    public GameObject mark;


    public GameObject e;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E)&& enterIcpR)
        {
            e.SetActive(false);
            player.SetActive(false);
            mark.SetActive(false);
            icpCam.SetActive(true);

            StartCoroutine(wait());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            e.SetActive(true);
            enterIcpR = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            e.SetActive(false);
            enterIcpR = false;
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.8f);
        panel.SetActive(true);
    }
}
