using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MyObject
{
    private List<GameObject> _listBackground = new List<GameObject>();

    // Start is called before the first frame update
    new public void Start()
    {
        MakeGraound(new Vector3(0, 1.0f, 0));
    }
    private void MakeGraound(Vector3 position)
    {
        var obj = new GameObject("B");
        obj.transform.position = position;
        base.Start(obj);
        _spr.drawMode = SpriteDrawMode.Sliced;
        _spr.size = new Vector2(10, 10);
        _spr.sortingOrder = -2;

        _rigidbody.useGravity = false;
        _rigidbody.constraints = RigidbodyConstraints.FreezeAll;

        _listBackground.Add(obj);
    }
    // Update is called once per frame
    void Update()
    {
        bool center = false;
        bool left = false;
        bool right = false;

        float centerX = 0f;
        //�ǂꂾ���̋����̒n�ʂ��\������˂΂Ȃ�Ȃ�������o��
        foreach (var obj in _listBackground)
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
        //�\�����ׂ��n�ʂ𐶐�����
        //�s�v��������Ȃ��������Ă���
        if (center == false)
        {
            MakeGraound(new Vector3(_camera.transform.position.x, 0.5f, 0));
            centerX = _camera.transform.position.x;
        }
        if (left == false)
        {
            MakeGraound(new Vector3(centerX - 10, 0.5f, 0));
        }
        if (right == false)
        {
            MakeGraound(new Vector3(centerX + 10, 0.5f, 0));
        }

        //����o���ꂽ�n�ʂ������J�������炠����x���ꂽ�����
        //�J�������炠����x���ꂽ�����
        for (int i = _listBackground.Count - 1; i >= 0; i--)
        {
            float myXposition =
                 _listBackground[i].gameObject.transform.position.x;
            float cameraXposition
                     = _camera.transform.position.x;
            float diff = cameraXposition - myXposition;
            if (diff < -20 || diff > 20)
            {
                Destroy(_listBackground[i]);
                _listBackground.RemoveAt(i);
            }
        }

    }
}
