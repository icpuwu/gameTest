
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TextboxController : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image Inormal;
    public Image ISmile;
    public AudioClip popSound;
    AudioSource textBoxAudio;

    //load text and Emotion
    public TextAsset txt;
    List<string> texts = new List<string>();
    int index = 0;

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
                dialogue(texts[index + 1]);
            }
            
        }
    }

    void loadText(TextAsset t)
    {
        texts.Clear();

        var textdata =  t.text.Split("\n");
        foreach(var tt in textdata)
        {
            texts.Add(tt);
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
        if (texts[i] == texts[0])//Set Inormal to active
        {
            Inormal.gameObject.SetActive(true);
            ISmile.gameObject.SetActive(false);

        }
        else if (texts[i] == texts[2]) //Set ISmile to active
        {
            Inormal.gameObject.SetActive(false);
            ISmile.gameObject.SetActive(true);
        }
        else
            Debug.Log(texts[i]);
    }
}
