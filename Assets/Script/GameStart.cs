using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameStart : MonoBehaviour
{
    //フェードアウト
    public GameObject Panelfade;   //フェードパネルの取得
    Image fadealpha;        //フェードパネルのイメージ取得変数
    public float alpha;           //パネルのalpha値取得変数
    private bool FadeOutTorF;          //フェードアウトのフラグ変数
    // Start is called before the first frame update
    void Start()
    {
        fadealpha = Panelfade.GetComponent<Image>(); //パネルのイメージ取得
        alpha = fadealpha.color.a;                 //パネルのalpha値を取得
        FadeOutTorF = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(FadeOutTorF ==true)
        {
            FadeOut();
        }
    }
    public void FadeOut()
    {
        FadeOutTorF = true;
        alpha += 0.01f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if (alpha >= 1)
        {
            SceneManager.LoadScene("SampleScene");
            FadeOutTorF = false;
        }
    }
}
