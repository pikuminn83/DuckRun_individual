using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MyObject : MonoBehaviour
{
    [SerializeField]
    private Sprite _sprite;
    [SerializeField]
    protected SpriteRenderer _spr;
    [SerializeField]
    protected Rigidbody _rigidbody;
    [SerializeField]
    protected Camera _camera;
    // private float STEP = 5.0f;
    // Start is called before the first frame update
    protected void Start()
    {
        _rigidbody = this.gameObject.AddComponent<Rigidbody>();
        _rigidbody.constraints
            = RigidbodyConstraints.FreezeRotationX
            | RigidbodyConstraints.FreezeRotationY;
        _spr = this.gameObject.AddComponent<SpriteRenderer>();
        _spr.sprite = _sprite;

        AddCollider();
    }
    public void Start(GameObject obj)
    {
        _rigidbody = obj.AddComponent<Rigidbody>();
        _rigidbody.constraints
            = RigidbodyConstraints.FreezeRotationX
            | RigidbodyConstraints.FreezeRotationY;
        _spr = obj.AddComponent<SpriteRenderer>();
        _spr.sprite = _sprite;

        AddCollider(obj);
    }

    protected virtual void AddCollider()
    {
        var sphereCollider = this.gameObject.AddComponent<SphereCollider>();
        sphereCollider.radius = 0.085f;
    }
    protected virtual void AddCollider(GameObject obj)
    {
        //var sphereCollider = obj.AddComponent<SphereCollider>();
        //sphereCollider.radius = 0.0f;
    }
    
}
