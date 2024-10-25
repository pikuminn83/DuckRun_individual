using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWall : MonoBehaviour
{

    [SerializeField] List<GameObject> WallList;    // �����I�u�W�F�N�g
    [SerializeField] Transform pos;                 // �����ʒu
    [SerializeField] Transform pos2;                // �����ʒu
    float minX, maxX, minY, maxY;                   // �����͈�

    int frame = 0;
    [SerializeField] int generateFrame = 30;        // ��������Ԋu

    void Start()
    {
        minX = Mathf.Min(pos.position.x, pos2.position.x);
        maxX = Mathf.Max(pos.position.x, pos2.position.x);
        minY = Mathf.Min(pos.position.y, pos2.position.y);
        maxY = Mathf.Max(pos.position.y, pos2.position.y);
    }

    void Update()
    {
        ++frame;

        if (frame > generateFrame)
        {
            frame = 0;

            // �����_���Ŏ�ނƈʒu�����߂�
            int index = Random.Range(0, WallList.Count);
            float posX = Random.Range(minX, maxX);
            float posY = Random.Range(minY, maxY);

            Instantiate(WallList[index], new Vector3(posX, posY, 0), Quaternion.identity);
        }
    }
}
