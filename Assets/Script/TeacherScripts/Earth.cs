using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earth : MyObject
{
    private List<GameObject> _listEarth = new List<GameObject>();

    // Start is called before the first frame update
    new public void Start()
    {
        MakeGraound(new Vector3(0, -8, 0));
    }
    private void MakeGraound(Vector3 position)
    {
        var obj = new GameObject("E");
        obj.transform.position = position;
        base.Start(obj);
        _spr.drawMode = SpriteDrawMode.Sliced;
        _spr.size = new Vector2(10, 10);
        _spr.sortingOrder = -1;
        _rigidbody.useGravity = false;
        _rigidbody.mass = 10000f;
        _rigidbody.drag = 0;
        _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        //Continuous Dynamic：お互いが動くオブジェクトで、移動速度が速いときに用いる。
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        
        _listEarth.Add(obj);
    }
    protected override void AddCollider(GameObject obj)
    {

        var boxCollider = obj.gameObject.AddComponent<BoxCollider>();
        boxCollider.size = new Vector3(10, 8.7f, 10);
    }

    // Update is called once per frame
    void Update()
    {
        bool center = false;
        bool left = false;
        bool right = false;

        float centerX = 0f;
        //どれだけの距離の地面が表示されねばならないか割り出す
        foreach (var obj in _listEarth)
        {
            float diff
              = obj.transform.position.x - _camera.transform.position.x;
            if (diff > -5 && diff < 5)
            {
                center = true;
                centerX = obj.transform.position.x;
            }
            if (diff <= -5 && diff > -15)
            {
                left = true;
            }
            if (diff >= 5 && diff < 15)
            {
                right = true;
            }
        }
        //表示すべき地面を生成する
        //不要かもしれないが書いておく
        if (center == false)
        {
            MakeGraound(new Vector3(_camera.transform.position.x, -8, 0));
            centerX = _camera.transform.position.x;
        }
        if(left == false)
        {
            MakeGraound(new Vector3(centerX-10, -8, 0));
        }
        if (right == false)
        {
            MakeGraound(new Vector3(centerX + 10, -8, 0));
        }

        //割り出された地面たちがカメラからある程度離れたら消す
        //カメラからある程度離れたら消す
        for(int i = _listEarth.Count-1; i >= 0; i--)
        {
           float myXposition =
                _listEarth[i].gameObject.transform.position.x;
            float cameraXposition
                     = _camera.transform.position.x;
            float diff = cameraXposition - myXposition;
            if(diff < -20||diff>20)
            {
                Destroy(_listEarth[i]);
                _listEarth.RemoveAt(i);
            }
        }

    }
}
