using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


/*         ＬＯＯＫ　ＨＥＲＥ　！！！

if the annotation r Garbled characters pls turn ur own computer code to japanese computer code
cuz mine computer is japanese computer code :D
or find a way to decode it urself idk

i already try turn all the script to UTF-8 code but idk its successful or not

*/



//use this to show random texts

public class randomTexter : MonoBehaviour
{
    
    public TextMeshProUGUI text; //the text whic is show on panel
    public List<TextAsset> txts; //diologue txt
    List<string> texts = new List<string>(); //where u store txts lines
    int index = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextAsset txt = txts[Random.Range(0, txts.Count)]; //隨便抽一份txt讀入
        loadText(txt); //store txt data into txts
        text.text = texts[index]; //show word from index0
        index ++;


    }

    // Update is called once per frame
    void Update()
    {
        //太短了 也沒有加新功能的打算 所以不使用Texter2D class了 _(:3 /z)_

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (index < texts.Count)
            {
                dialogue(texts[index]);
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


        void dialogue(string t)
        {
            text.text = t;
            index += 1;
        }
    }
