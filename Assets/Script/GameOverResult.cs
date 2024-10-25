using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverResult : GameStart
{
    //intだとfloatに変換できないので変更しないように
    public float ScoreEndCount;
    public TextMeshProUGUI TextmeasureM;
    Image fadealpha;

    private bool FadeOutTorF;          //フェードアウトのフラグ変数
    // Start is called before the first frame update
    void Start()
    {
        fadealpha = Panelfade.GetComponent<Image>(); //パネルのイメージ取得
        alpha = fadealpha.color.a;                 //パネルのalpha値を取得
        //Playerから静的なメソッドのstatic float ScoreEndを持ってくる
        ScoreEndCount = Player.ScoreEnd();

      TextmeasureM.text = "Score:"+ ScoreEndCount.ToString("F1")+("M");
    }
    void Update()
    {
        if (FadeOutTorF == true)
        {
            GameOverSceene();
        }
    }
    public void GameOverSceene()
    {
        FadeOutTorF = true;
        alpha += 0.01f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if (alpha >= 1)
        {
            SceneManager.LoadScene("GameStart");
            FadeOutTorF = false;
        }
    }
}
