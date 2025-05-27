using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

//gonna this change to oop if i have time
//if i didnt forget this and i have time to change this to oop i will write annotation maybe

public class randomTexter : MonoBehaviour
{
    
    public TextMeshProUGUI text;
    public List<TextAsset> txts;
    List<string> texts = new List<string>();
    int index = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextAsset txt = txts[Random.Range(0, txts.Count)];
        loadText(txt); //store txt data into txts
        text.text = texts[index]; //show word from index0
        index ++;


    }

    // Update is called once per frame
    void Update()
    {


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
