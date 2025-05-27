using System.Collections;
using UnityEngine;


/*         ＬＯＯＫ　ＨＥＲＥ　！！！

if the annotation r Garbled characters pls turn ur own computer code to japanese computer code
cuz mine computer is japanese computer code :D
or find a way to decode it urself idk

i already try turn all the script to UTF-8 code but idk its successful or not

*/

//拿來使UpEnmey 隨機生成的

public class spawnManager : MonoBehaviour
{
    public GameObject upBullet; //upEnemy
    GameObject newupEnemy; //實例化用的
    Transform d;
    bool once = false; //確保一次只會下一顆

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!once) 
        {
            once = true;
            StartCoroutine(spawn());
        }
    }

    IEnumerator spawn()
    {
        Vector3 v = new Vector3(Random.Range(-102,103), 138.0036f, Random.Range(-202,202)); //隨機位置
       
        yield return new WaitForSeconds(4f);
        newupEnemy =  Instantiate(upBullet, v, upBullet.transform.rotation);
        d = newupEnemy.transform.Find("danger"); // <= gpt推薦的方法 抓子物件用的
        StartCoroutine(hideDanger());
        once = false;
    }

    IEnumerator hideDanger() //下方的! 紅色UI
    {
        yield return new WaitForSeconds(1.5f);
        d.gameObject.SetActive(false);
    }
}
