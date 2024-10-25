using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BomeClea : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer BomeImag;
     Animator Bomeanime;

    public AudioSource BoomAudio;
    float Timer;
    private void Start()
    {
        Bomeanime = GetComponent<Animator>();
        BoomAudio.Stop();
    }
    void Update()
    {
        Bomeanime.SetBool("BomeAnimeBool", true);
        Timer += Time.deltaTime;
        Debug.Log(Timer);
        if (Timer > 3)
        {

            syoukasen cs = GameObject.Find("Player").GetComponent<syoukasen>();
            
            cs.Explosion();
            BoomAudio.Play();
            Destroy(this.gameObject);
            Timer = 0;
        }
    }
    void OnCollisionStay(Collision colBom)
    {


    }
}
