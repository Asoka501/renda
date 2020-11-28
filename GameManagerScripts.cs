using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //UI系のパーツ作るのに必要
using UnityEngine.SceneManagement;

public class GameManagerScripts : MonoBehaviour
{

    int count;
    public Text countText;　//インスペクタビューで見たいからpublicをつける
    public Text timerText;
    float timer = 10.0f;
    public Text buttonText;

    bool isPlaying = false;     //bool型(真偽値)true or falseどちらかの値を保持

    public GameObject rendaSound;

    // Start is called before the first frame update
    void Start()
    {
        buttonText.text = "スタート";
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaying == true)   //  trueの時にだけ以下の処理を行う
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("f2");
        }

        if(timer < 0)
        {
            isPlaying = false;
            timer = 0;
            timerText.text = timer.ToString("f2");
            buttonText.text = "終了";

            PlayerPrefs.SetInt("score", count);
            SceneManager.LoadScene("EndScene");
        }
    }
    public void CountUp()   // クリック連打の方
    {
        if(isPlaying == true)
        {
            count += 1;
            countText.text = count.ToString();  //intをstring型に変える
            //count++;
            Debug.Log("count");

            GameObject rendaSoundClone = Instantiate(rendaSound) as GameObject;
            Destroy(rendaSoundClone, 3.0f);
        }
        else
        {
            isPlaying = true;   // 状態をまたtrueに戻しておく
            buttonText.text = "押せ！";
        }
        
    }
}
