using UnityEngine;
using UnityEditor;
using System.Threading.Tasks;
using Unity.VisualScripting;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MyObject
{
    [SerializeField]
    private float Movespeed = 0.0f;
    [SerializeField]
    private float Jumpspeed = 0.0f;
    [SerializeField]
    protected float _torque = 0f;
    [SerializeField]
    GameObject StartRain;
    [SerializeField]
    private AudioSource BomeSE;
    private int jumpCount = 1;
    //�^�C�}�[�̕ϐ�
    private float DestroyPlayer = 0f;

    public TextMeshProUGUI Textmeasure;

    //�t�F�[�h�A�E�g
    public GameObject Panelfade;   //�t�F�[�h�p�l���̎擾
    Image fadealpha;               //�t�F�[�h�p�l���̃C���[�W�擾�ϐ�
    private float alpha;           //�p�l����alpha�l�擾�ϐ�
    private bool FadeOutTorF;          //�t�F�[�h�A�E�g�̃t���O�ϐ�

    public static float dis;

    public ParticleSystem particl;
    // Start is called before the first frame update
    new public void Start()
    {
        base.Start();
        _spr.drawMode = SpriteDrawMode.Simple;
        this.transform.localScale = Vector3.one * 0.5f;
        _spr.sortingOrder = 1;
        _rigidbody.useGravity = true;
        //�@�@�@�@�@����
        _rigidbody.mass = 50;
        _rigidbody.constraints
            = RigidbodyConstraints.FreezePositionZ
            | RigidbodyConstraints.FreezeRotationZ
            | RigidbodyConstraints.FreezeRotationX
            | RigidbodyConstraints.FreezeRotationY;
        //Continuous Dynamic�F���݂��������I�u�W�F�N�g�ŁA�ړ����x�������Ƃ��ɗp����B
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        //�J������player�̎q�ɂ���
        //_camera.transform.SetParent(this.transform);
        fadealpha = Panelfade.GetComponent<Image>(); //�p�l���̃C���[�W�擾
        alpha = fadealpha.color.a;                 //�p�l����alpha�l���擾
        GetComponent<AudioSource>().Stop();
        particl.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        FadeOutTorF = false;


    }

    protected override void AddCollider()
    {
        var cupsuleCollider
            = this.AddComponent<CapsuleCollider>();
        cupsuleCollider.direction = 0;
        cupsuleCollider.radius = 0.9f;
        cupsuleCollider.height = 0.9f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        //�v���C���[�̃W�����v
        if (Input.GetKey("w") && jumpCount == 0)
        {

            this._rigidbody.AddForce(Vector3.up * Jumpspeed * 100);
        }
        //�v���C���[�̈ړ�
        if (Input.GetKey("a"))
        {
            //�u�ԓI�ɗ͂������Ď��ʂ𖳎�����
            this._rigidbody.AddForce(Vector3.left * Movespeed * _torque, ForceMode.VelocityChange);
            this._rigidbody.transform.rotation = Quaternion.Euler(0, 180, 0);
            //force.x -= Movespeed;
            //transform.position = force;
        }
        if (Input.GetKey("d"))
        {
            this._rigidbody.AddForce(Vector3.right * Movespeed * _torque, ForceMode.VelocityChange);
            this._rigidbody.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (this._rigidbody.transform.position.x > 0)
        {
            dis = Vector3.Distance(this.transform.position, StartRain.transform.position);
        }
        else
        {
            dis = 0;
        }
        Textmeasure.text = dis.ToString("F1") + ("M");

        //Debug.Log("���� : " + dis);
        if (FadeOutTorF == true)
        {
            FadeOut();
        }
    }
    //�X�R�A�̒l�����̃V�[���ɓn��
    //�ǂ̃N���X����ł��A�N�Z�X�ł��Ă��܂��ו���p���N���肤��B
    //�ÓI���\�b�h�̒��Ŏg�p�ł���t�B�[���h��static�t�B�[���h�݂̂ł��B
    public static float ScoreEnd()
    {

        return dis;
    }
    void OnCollisionStay(Collision col)
    {
        jumpCount = 0;
    }
    async void OnCollisionExit(Collision colExit)
    {
        //1000��1�b500��0.5�b
        //0.25�b�x����������
        await Task.Delay(250);
        jumpCount = 1;
    }

    //�J�����̉�ʊO�̏���
    void OnBecameInvisible()
    {
        DestroyPlayer += Time.time;
        //�v���C���[�̎��S����
        if (DestroyPlayer > 5.0f)
        {
            FadeOutTorF = true;
            BomeSE.Play();
            particl.Play(true);

            _rigidbody.constraints
               = RigidbodyConstraints.FreezePositionZ
                | RigidbodyConstraints.FreezePositionX
                | RigidbodyConstraints.FreezePositionY;
            Invoke("ScennGameOver", 1.5f);
        }

    }
    public void ScennGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    //�J�����̉�ʓ��̏���
    void OnBecameVisible()
    {
        //�v���C���[����ʓ��ɖ߂��Ă����Ƃ�
        //�Q�[���I�[�o�[�܂ł̃^�C�}�[�����Z�b�g
        DestroyPlayer = 0;
    }
    void FadeOut()
    {
        alpha += 0.01f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if (alpha >= 1)
        {
            FadeOutTorF = false;
        }
    }
}
