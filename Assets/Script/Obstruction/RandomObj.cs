using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObj : MonoBehaviour
{

    [SerializeField]
    List<GameObject> enemyList;

    [SerializeField]
    private Camera _camera;

    [SerializeField]
    Transform pos;
    [SerializeField]
    Transform pos2;

    [SerializeField]
    int generateFrame = 30;

    [SerializeField]
    Transform posBome;
    [SerializeField]
    Transform pos2Bome;

    float minX, maxX, minY, maxY;

    float minXBome, maxXBome, minYBome, maxYBome;
    int frame = 0;

    // Update is called once per frame
    void Update()
    {
        //ƒ‰ƒ“ƒ_ƒ€‚Å–WŠQƒAƒCƒeƒ€‚ð—Ž‚Æ‚·
         ++frame;
        if(frame > generateFrame)
        {
            frame = 0;
            int index = Random.Range(0, enemyList.Count);
            switch(index)
            {
                case 0:
                    float posX = Random.Range(minX, maxX);
                    float posY = Random.Range(minY, maxY);
                    Instantiate(enemyList[0], new Vector3(posX, posY, 0), Quaternion.identity);
                    break;
                case 1:
                    float posXBome = Random.Range(minXBome, maxXBome);
                    float posYBome = Random.Range(minYBome, maxYBome);
                    Instantiate(enemyList[1], new Vector3(posXBome, posYBome, 0), Quaternion.identity);
                    break;
            }
        }
        minX = Mathf.Min(pos.position.x, pos2.position.x);
        maxX = Mathf.Max(pos.position.x, pos2.position.x);
        minY = Mathf.Min(pos.position.y, pos2.position.y);
        maxY = Mathf.Max(pos.position.y, pos2.position.y);

        minXBome = Mathf.Min(posBome.position.x, pos2Bome.position.x);
        maxXBome = Mathf.Max(posBome.position.x, pos2Bome.position.x);
        minYBome = Mathf.Min(posBome.position.y, pos2Bome.position.y);
        maxYBome = Mathf.Max(posBome.position.y, pos2Bome.position.y);
    }

}
