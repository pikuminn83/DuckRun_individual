using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameStart : MonoBehaviour
{
    //�t�F�[�h�A�E�g
    public GameObject Panelfade;   //�t�F�[�h�p�l���̎擾
    Image fadealpha;        //�t�F�[�h�p�l���̃C���[�W�擾�ϐ�
    public float alpha;           //�p�l����alpha�l�擾�ϐ�
    private bool FadeOutTorF;          //�t�F�[�h�A�E�g�̃t���O�ϐ�
    // Start is called before the first frame update
    void Start()
    {
        fadealpha = Panelfade.GetComponent<Image>(); //�p�l���̃C���[�W�擾
        alpha = fadealpha.color.a;                 //�p�l����alpha�l���擾
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
