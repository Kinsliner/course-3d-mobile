using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEffect : MonoBehaviour
{
    public float destroyTime = 3;

    public int pieces = 5;

    public GameObject bodyPrefab;

    private List<GameObject> bodies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < pieces; i++)
        {
            //�H���ͦ���m
            Vector3 pos = transform.position + new Vector3(Random.Range(-1f, 1f),0, Random.Range(-1f, 1f));

            //�ͦ��Ͷ�
            GameObject body = Instantiate(bodyPrefab, pos, Quaternion.identity);

            //�[�J�M��
            bodies.Add(body);
        }

        StartCoroutine(DelayExplosion());
    }

    // ��������z��
    IEnumerator DelayExplosion()
    {
        yield return null;

        //�H�������z���O�q
        foreach (GameObject body in bodies)
        {
            body.GetComponent<Rigidbody>().AddExplosionForce(500, transform.position, 1, 1);
        }
    }


    // ����R��
    private void LateUpdate()
    {
        //�R���Ͷ�
        foreach (GameObject body in bodies)
        {
            Destroy(body, destroyTime);
        }

        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
