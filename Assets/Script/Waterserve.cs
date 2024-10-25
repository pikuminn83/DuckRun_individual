using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterserve : MonoBehaviour
{

    [SerializeField]
    List<GameObject>  enemyList;
    [SerializeField]
    Transform pos;
    [SerializeField]
    Transform pos2;
    [SerializeField]
    int generateFrame = 30;

    float minX, maxX, minY, maxY;
    int frame = 0;
    void Start()
    {
        maxX = Mathf.Max(pos.position.x, pos2.position.x);
        minX = Mathf.Min(pos.position.x, pos2.position.x);
        maxY = Mathf.Max(pos.position.y, pos2.position.y);
        minY = Mathf.Min(pos.position.y, pos2.position.y);
    }

    // �������Z���������ꍇ��FixedUpdate���g���̂���ʓI
    void Update()
    {
        ++frame;

        if(frame > generateFrame)
        {
            frame = 0;
            int index = Random.Range(0, enemyList.Count); 
            float posX = Random.Range(minX, maxX);
            float posY = Random.Range(minY, maxY);
            for(int i=0; i < 3;i++)
            {
             Instantiate(enemyList[i], new Vector3(posX, posY, 0), Quaternion.identity);
            }
        }


        maxX = Mathf.Max(pos.position.x, pos2.position.x);
        minX = Mathf.Min(pos.position.x, pos2.position.x);
        maxY = Mathf.Max(pos.position.y, pos2.position.y);
        minY = Mathf.Min(pos.position.y, pos2.position.y);
       
    }

}
/*�w�͂����Ƃ��͐��������Ƃ���List�̒��������㍶�����ɔ�΂����߂ɂǂ����邩��
�ŏ���Randam�@Range�ł�낤�Ƃ�����Randam�Ɉ��邽�߃o���o���̕����ɂƂђf�O
���݂�Instantiate�ň�����water���̂ɓ����X�N���v�g��\�邱�Ƃŉ���
 */