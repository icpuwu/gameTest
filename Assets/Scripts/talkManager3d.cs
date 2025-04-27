using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class talkManager3d : MonoBehaviour
{
    bool once = false;
    enterTrigger enter;
    public Animator ani;
    public TextMeshProUGUI text;
    public TextAsset txt;
    List<string> texts = new List<string>();
    int index = 0;

    public GameObject icpcam;
    public GameObject panel;
    public GameObject player;
    public GameObject mark;
    public GameObject e;

    private SkinnedMeshRenderer smr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        smr = GameObject.Find("icpR/Body").GetComponent<SkinnedMeshRenderer>();
        enter = GameObject.Find("icpR").GetComponent<enterTrigger>();
        loadText(txt);
        EmotionController(index);
        text.text = texts[index + 1];
        index += 2;
       
        
    }

    // Update is called once per frame
    void Update()
    {

        if (once == true )
        {

            index = 0;
            loadText(txt);
            EmotionController(index);
            text.text = texts[index + 1];
            player.SetActive(false);
            mark.SetActive(false);
            index += 2;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (index < texts.Count)
            {
                dialogue(texts[index + 1]);
            }
            else
            {
                
                icpcam.SetActive(false);
                panel.SetActive(false);
                player.SetActive(true);
                mark.SetActive(true);
                ani.SetBool("thinking", false);
                //reset emotion
                smr.SetBlendShapeWeight(1, 0f);
                smr.SetBlendShapeWeight(7, 0f);//a
                index = 0;
                once = true;
                e.SetActive(true);

            }

           
               
            
        }
    }

    void loadText(TextAsset t)
    {
        texts.Clear();

        var textdata = t.text.Split("\n");
        foreach (var tt in textdata)
        {
            texts.Add(tt);
        }
    }
    void EmotionController(int i)
    {
        if (texts[i] == texts[0] )
        {
            smr.SetBlendShapeWeight(1, 100f);//Î‚¢
            smr.SetBlendShapeWeight(7, 70f);//‚ 
            ani.SetBool("thinking", true);
        }
        else if (texts[i] == "") 
        {
            
        }
        else
            Debug.Log(texts[i]);
    }

    void dialogue(string t)
    {
        EmotionController(index);
        text.text = t;
        index += 2;

    }
}