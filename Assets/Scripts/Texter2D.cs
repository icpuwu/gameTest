using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/*         ÇkÇnÇnÇjÅ@ÇgÇdÇqÇdÅ@ÅIÅIÅI

if the annotation r Garbled characters pls turn ur own computer code to japanese computer code
cuz mine computer is japanese computer code :D
or find a way to decode it urself idk

i already try turn all the script to UTF-8 code but idk its successful or not

*/

namespace text
{
    class Texter2D : Text //ãã2d npcópìI
    {
        //text asset
        TextAsset emotion;
        TextAsset stagess;

        //emotion
        Image Inormal; //emotion normal
        Image ISmile; //emo smile
        Image IHappy; //emo happy
        GameObject stageImage; // background Image(stage)

        List<string> emo = new List<string>();
        List<string> stages = new List<string>();

        //se
        AudioSource textBoxAudio;
        AudioClip popSound;

        bool appearLine = true; //çTêßé·SceneLoaderÊ\·¢ê¨å˜ ïsÊ\·¢dialogue

        public void init(TextAsset emo,TextAsset sta,TextMeshProUGUI text,GameObject panel,AudioSource textBoxAudio,AudioClip popSound)
        {
            emotion = emo;
            stagess = sta;
            this.text = text;
            this.panel = panel;
            this.popSound = popSound;
            this.textBoxAudio = textBoxAudio;
        }

        public void EmoInit(Image Inormal,Image ISmile,Image IHappy,GameObject stageImage) //dont forget to use this once u use emoController!!
        {
            this.Inormal = Inormal;
            this.ISmile = ISmile;
            this.IHappy = IHappy;
            this.stageImage = stageImage;
        }
        public override void loadText(TextAsset t)
        {
            texts.Clear();
            emo.Clear();
            stages.Clear();

            var textdata = t.text.Split("\n");
            var emotiondata = emotion.text.Split("\n");
            var sta = stagess.text.Split("\n");

            foreach (var tt in textdata)
            {
                texts.Add(tt);
            }
            foreach (var e in emotiondata)
            {
                emo.Add(e);
            }
            foreach (var ss in sta)
            {
                stages.Add(ss);
            }
        }

        public override void dialogue()
        {
            string t = texts[index+1];
            EmotionController();
            text.text = t;
            textBoxAudio.PlayOneShot(popSound);
            index += 2;
        }

        public int GetTextsNum() => texts.Count;
        public bool GetAppearLine() => appearLine;

        public void EmotionController()
        {
            if (texts[index] == emo[0])//Set Inormal to active
            {
                Inormal.gameObject.SetActive(true);
                ISmile.gameObject.SetActive(false);
                IHappy.gameObject.SetActive(false);


            }
            else if (texts[index] == emo[1]) //Set ISmile to active
            {
                Inormal.gameObject.SetActive(false);
                IHappy.gameObject.SetActive(false);
                ISmile.gameObject.SetActive(true);
            }
            else if (texts[index] == emo[2]) //Set IHappy to active
            {
                Inormal.gameObject.SetActive(false);
                ISmile.gameObject.SetActive(false);
                IHappy.gameObject.SetActive(true);
            }
            else if (texts[index] == emo[3]) //Set Bg to stage
            {
                panel.SetActive(false);
                stageImage.SetActive(true);
            }
            else if (texts[index] == emo[4]) //closs Bg
            {
                panel.SetActive(true);
                stageImage.SetActive(false);
            }
            else if (texts[index] == emo[5]) //closs all emo
            {
                Inormal.gameObject.SetActive(false);
                ISmile.gameObject.SetActive(false);
                IHappy.gameObject.SetActive(false);
            }
            else
                Debug.Log(texts[index]);
        }

        public void SceneLoader()
        {
            if (texts[index] == stages[0])
            {
                appearLine = false;
                SceneManager.LoadScene("level 1");
            }
            else if (texts[index] == stages[1])
            {
                appearLine = false;
                SceneManager.LoadScene("level 2");
            }
        }
    }
}