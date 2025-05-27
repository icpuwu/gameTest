
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

    List<string> texts = new List<string>();
    List<string> emo = new List<string>();
    List<string> stages = new List<string>();
    public int index = 0;
    bool appearLine = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textBoxAudio = GetComponent<AudioSource>();
        loadText(txt);

        //Ë˚é¶ëÊàÍãÂë‰éå/ï\èÓ
        EmotionController(index);
        text.text = texts[index+1];
        index+=2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            

            if (index < texts.Count)
            {
                SceneLoader(index);
                if(appearLine)
                dialogue(texts[index + 1]);
            }

            
        }
    }

    void loadText(TextAsset t)
    {
        texts.Clear();
        emo.Clear();
        stages.Clear();

        var textdata =  t.text.Split("\n");
        var emotiondata = emotion.text.Split("\n");
        var sta = stagess.text.Split("\n");

        foreach(var tt in textdata)
        {
            texts.Add(tt);
        }
        foreach(var e in emotiondata)
        {
            emo.Add(e);
        }
        foreach(var ss in sta)
        {
            stages.Add(ss);
        }
    }

    void dialogue(string t) {

        
            EmotionController(index);
            text.text = t;
            textBoxAudio.PlayOneShot(popSound);
            index += 2;
        
        Debug.Log(index);
    }

    void EmotionController(int i)
    {
        if (texts[i] == emo[0])//Set Inormal to active
        {
            Inormal.gameObject.SetActive(true);
            ISmile.gameObject.SetActive(false);
            IHappy.gameObject.SetActive(false);
            

        }
        else if (texts[i] == emo[1]) //Set ISmile to active
        {
            Inormal.gameObject.SetActive(false);
            IHappy.gameObject.SetActive(false);
            ISmile.gameObject.SetActive(true);
        }
        else if (texts[i] == emo[2]) //Set IHappy to active
        {
            Inormal.gameObject.SetActive(false);
            ISmile.gameObject.SetActive(false);
            IHappy.gameObject.SetActive(true);
        }
        else if (texts[i] == emo[3]) //Set Bg to stage
        {
            Panel.SetActive(false);
            stageImage.SetActive(true);
        }
        else if (texts[i] == emo[4])
        {
            Panel.SetActive(true);
            stageImage.SetActive(false);
        }
        else if (texts[i] == emo[5])
        {
            Inormal.gameObject.SetActive(false);
            ISmile.gameObject.SetActive(false);
            IHappy.gameObject.SetActive(false);
        }
        else
            Debug.Log(texts[i]);
    }

    void SceneLoader(int i)
    {
        if (texts[i] == stages[0])
        {
            appearLine = false;
            SceneManager.LoadScene("level 1");
        }
        else if (texts[i] == stages[1])
        {
            appearLine = false;
            SceneManager.LoadScene("level 2");
        }
    }
}
