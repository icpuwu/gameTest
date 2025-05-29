using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using text;


/*         ＬＯＯＫ　ＨＥＲＥ　！！！

if the annotation r Garbled characters pls turn ur own computer code to japanese computer code
cuz mine computer is japanese computer code :D
or find a way to decode it urself idk

i already try turn all the script to UTF-8 code but idk its successful or not

*/


public class talkManager3d : MonoBehaviour
{
   
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

    Texter3D te3d; //詳參Texter3D.cs 與Text.cs (Texter3d class的父類別)

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        te3d = GetComponent<Texter3D>();

        smr = GameObject.Find("icpR/Body").GetComponent<SkinnedMeshRenderer>();
        enter = GameObject.Find("icpR").GetComponent<enterTrigger>();

        te3d.init(text, panel, icpcam, mark, e, player);
        te3d.Emotion3DBullider(smr, ani);

        te3d.loadText(txt);
        te3d.EmotionController3D(index);
        te3d.showTextWhenSceneOPen();
       
        
    }

    // Update is called once per frame
    void Update()
    {

        if (te3d.GetOnce() == true )
        {
            te3d.SetUP(txt);
          
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (index < texts.Count)
            {
                te3d.dialogue();
            }
            else
            {

                te3d.dialogueEnd();

            }

           
               
            
        }
    }

    
}