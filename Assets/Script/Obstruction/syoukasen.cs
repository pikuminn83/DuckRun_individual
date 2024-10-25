using UnityEngine;
using Unity.VisualScripting;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine.Audio;

public class syoukasen : MonoBehaviour
{
    public GameObject player;
    //�X�N���v�g���Ŏg���܂킷
    private Vector2 targeting;
    [SerializeField]
    private AudioSource BomeFin;

    //public Camera cam;

    //public GameObject _Player;
    private float zoom;
    private void Start()
    {
        BomeFin.Stop();
    }
    void FixedUpdate()
    {
        
        targeting = (player.transform.position - this.transform.position).normalized;
    }

    void OnCollisionEnter(Collision collision)
    {
        //prefab�̓^�O�����ł���
        //���@�ɏՓˎ��̂݃R���[�`�����s
        if(collision.gameObject.CompareTag("Water"))
        {
            StartCoroutine("Damaged");
        }

    }
    public async void Explosion()
    {
        //                          SphereCastAll(���S, ���a, ����) 
        RaycastHit[] hits = Physics.SphereCastAll(transform.position,3.0f,Vector3.forward);

        foreach (var hit in hits)
        {
            GameObject[] hitObjects = hits.Select(hit => hit.collider.gameObject).ToArray();

            if (hit.collider.gameObject.CompareTag("Bome"))
            {
                Debug.Log($"���o���ꂽ�I�u�W�F�N�g {hit.collider.name}");
                Time.timeScale = 0;
                BomeFin.Play();

               // cam.transform.position = _Player.transform.position;
                
                await Task.Delay(1000);
                // �͂�������
                StartCoroutine("BomeDamaged");
            }

        }
    }
    IEnumerator Damaged()
    {
        int i = 0;
        while (i < 10)
        {
            yield return new WaitForSeconds(0.02f);
            player.transform.Translate(-1, 0.5f * 2, 0);
            i++;
        }

    }
    IEnumerator BomeDamaged()
    {
        int i = 0;
        while (i < 10)
        {
            Time.timeScale = 1;
            yield return new WaitForSeconds(0.02f);
            player.transform.Translate(-3, 0.5f * 3, 0);
            i++;
        }

    }
}
