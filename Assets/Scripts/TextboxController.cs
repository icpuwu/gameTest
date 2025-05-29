using text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using Unity.Jobs;

/*         ÇkÇnÇnÇjÅ@ÇgÇdÇqÇdÅ@ÅIÅIÅI

if the annotation r Garbled characters pls turn ur own computer code to japanese computer code
cuz mine computer is japanese computer code :D
or find a way to decode it urself idk

i already try turn all the script to UTF-8 code but idk its successful or not

*/


//gonna this change to oop if i have time
//if i didnt forget this and i have time to change this to oop i will write annotation maybe


public class TextboxController : MonoBehaviour
{
    Texter2D te2d;
    public TextMeshProUGUI text;
    public Image Inormal;
    public Image ISmile;
    public Image IHappy;
    public GameObject Panel;
    public GameObject stageImage;
    public AudioClip popSound;
    AudioSource textBoxAudio;

    //load text and Emotion
    public TextAsset txt;
    public TextAsset emotion;
    public TextAsset stagess;

    public int index = 0;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        te2d = GetComponent<Texter2D>();
        textBoxAudio = GetComponent<AudioSource>();
        te2d.init(emotion, stagess,text,Panel,textBoxAudio, popSound);
        te2d.EmoInit(Inormal, ISmile, IHappy, stageImage);
        te2d.loadText(txt);

        //Ë˚é¶ëÊàÍãÂë‰éå/ï\èÓ
        te2d.EmotionController();
        te2d.showTextWhenSceneOPen();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            

            if (te2d.GetIndex() < te2d.GetTextsNum())
            {
                te2d.SceneLoader();
                if(te2d.GetAppearLine())
                te2d.dialogue();
            }

            
        }
    }




  
   
}
