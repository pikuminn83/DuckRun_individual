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
    //タイマーの変数
    private float DestroyPlayer = 0f;

    public TextMeshProUGUI Textmeasure;

    //フェードアウト
    public GameObject Panelfade;   //フェードパネルの取得
    Image fadealpha;               //フェードパネルのイメージ取得変数
    private float alpha;           //パネルのalpha値取得変数
    private bool FadeOutTorF;          //フェードアウトのフラグ変数

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
        //　　　　　質量
        _rigidbody.mass = 50;
        _rigidbody.constraints
            = RigidbodyConstraints.FreezePositionZ
            | RigidbodyConstraints.FreezeRotationZ
            | RigidbodyConstraints.FreezeRotationX
            | RigidbodyConstraints.FreezeRotationY;
        //Continuous Dynamic：お互いが動くオブジェクトで、移動速度が速いときに用いる。
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        //カメラをplayerの子にする
        //_camera.transform.SetParent(this.transform);
        fadealpha = Panelfade.GetComponent<Image>(); //パネルのイメージ取得
        alpha = fadealpha.color.a;                 //パネルのalpha値を取得
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

        //プレイヤーのジャンプ
        if (Input.GetKey("w") && jumpCount == 0)
        {

            this._rigidbody.AddForce(Vector3.up * Jumpspeed * 100);
        }
        //プレイヤーの移動
        if (Input.GetKey("a"))
        {
            //瞬間的に力を加えて質量を無視する
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

        //Debug.Log("距離 : " + dis);
        if (FadeOutTorF == true)
        {
            FadeOut();
        }
    }
    //スコアの値を次のシーンに渡す
    //どのクラスからでもアクセスできてしまう為副作用が起こりうる。
    //静的メソッドの中で使用できるフィールドはstaticフィールドのみです。
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
        //1000で1秒500で0.5秒
        //0.25秒遅延をかける
        await Task.Delay(250);
        jumpCount = 1;
    }

    //カメラの画面外の処理
    void OnBecameInvisible()
    {
        DestroyPlayer += Time.time;
        //プレイヤーの死亡判定
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
    //カメラの画面内の処理
    void OnBecameVisible()
    {
        //プレイヤーが画面内に戻ってきたとき
        //ゲームオーバーまでのタイマーをリセット
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
