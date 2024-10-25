using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SliderManager : MonoBehaviour
{
    public Player Player;
    public GameObject _player;
    public GameObject _start;
    public GameObject _goal;
    public Slider _slider2D;

    private float PlayerDis;
    private float Dis;
    // Start is called before the first frame update
    void Start()
    {
        _slider2D = GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (_player.transform.position.y < -2)
        //{
            //スタートからプレイヤーまでの幅をDicetancで割り出す
             PlayerDis = Vector3.Distance(_goal.transform.position.normalized, _player.transform.position.normalized);
            //スタートからゴールまでの幅をDicetancで割り出す
             Dis = Vector3.Distance(_start.transform.position.normalized, _player.transform.position.normalized);

        //}
        Debug.Log( PlayerDis);
        _slider2D.value =  PlayerDis;

        if(_player.transform.position.x >= _goal.transform.position.x)
        {
            SceneManager.LoadScene("GameClea");
        }

    }
}
