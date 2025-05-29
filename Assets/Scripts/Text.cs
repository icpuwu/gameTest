using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


/*         ＬＯＯＫ　ＨＥＲＥ　！！！

if the annotation r Garbled characters pls turn ur own computer code to japanese computer code
cuz mine computer is japanese computer code :D
or find a way to decode it urself idk

i already try turn all the script to UTF-8 code but idk its successful or not

*/


namespace text
{
    public abstract class Text : MonoBehaviour
    {

        protected bool once = false; //檢測是否有重複對話過
        protected List<string> texts = new List<string>();

        //emotion
        protected SkinnedMeshRenderer smr;
        protected Animator ani;

        //text contorll
        protected int index = 0;
        protected TextMeshProUGUI text; //會出現在panel上的文字

        //asset
        protected GameObject panel;


        public void showTextWhenSceneOPen() //務必在Start裡先使用!!!!
        {
            text.text = texts[index + 1];
            index += 2;
        }

        public abstract void loadText(TextAsset t); //將Txt文本存入list裡
       
        public abstract void dialogue(); //使文本切換

        public bool GetOnce() => once;

        public int GetIndex() => index;
    }

   

}