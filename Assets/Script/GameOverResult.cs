using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverResult : GameStart
{
    //int����float�ɕϊ��ł��Ȃ��̂ŕύX���Ȃ��悤��
    public float ScoreEndCount;
    public TextMeshProUGUI TextmeasureM;
    Image fadealpha;

    private bool FadeOutTorF;          //�t�F�[�h�A�E�g�̃t���O�ϐ�
    // Start is called before the first frame update
    void Start()
    {
        fadealpha = Panelfade.GetComponent<Image>(); //�p�l���̃C���[�W�擾
        alpha = fadealpha.color.a;                 //�p�l����alpha�l���擾
        //Player����ÓI�ȃ��\�b�h��static float ScoreEnd�������Ă���
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
