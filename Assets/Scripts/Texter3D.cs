using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


/*         ＬＯＯＫ　ＨＥＲＥ　！！！

if the annotation r Garbled characters pls turn ur own computer code to japanese computer code
cuz mine computer is japanese computer code :D
or find a way to decode it urself idk

i already try turn all the script to UTF-8 code but idk its successful or not

*/


namespace text
{
    class Texter3D : Text //給3d npc用的
    {
        GameObject icpcam; //照3d人的
        GameObject mark; //!　UI
        GameObject e; //"調查/E"　UI

        GameObject player; //玩家

        public void init(TextMeshProUGUI text,GameObject panel, GameObject icpcam, GameObject mark, GameObject e, GameObject player)
        {
            this.text = text;
            this.panel = panel;
            this.icpcam = icpcam;
            this.mark = mark;
            this.e = e;
            this.player = player;

        }

        //text controll
        public override void loadText(TextAsset t)
        {

            texts.Clear();

            var textdata = t.text.Split("\n");
            foreach (var tt in textdata)
            {
                texts.Add(tt);
            }

        }

        public override void dialogue()
        {
            string t = texts[index+1];
            EmotionController3D(index);
            text.text = t;
            index += 2;

        }

        public int TextCount() => texts.Count; //算句數
        public void dialogueEnd()
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


        //emo ocntroll

        public void Emotion3DBullider(SkinnedMeshRenderer smr, Animator ani)
        {
            this.smr = smr;
            this.ani = ani;
        }

        public void EmotionController3D(int i) //controll 3D npc emotion //使用這個請先使用上面那個建構!!!
        {
            if (texts[i] == texts[0])
            {
                smr.SetBlendShapeWeight(1, 100f);//笑い
                smr.SetBlendShapeWeight(7, 70f);//あ
                ani.SetBool("thinking", true);
            }
            else if (texts[i] == "")
            {

            }
            else
                Debug.Log(texts[i]);
        }

        //set up

        public void SetUP(TextAsset t) //重複對話時回到初始狀態(重作start項目)
        {
            index = 0;
            loadText(t);
            EmotionController3D(index);
            text.text = texts[index + 1];
            player.SetActive(false);
            mark.SetActive(false);
            index += 2;
        }
    }
}