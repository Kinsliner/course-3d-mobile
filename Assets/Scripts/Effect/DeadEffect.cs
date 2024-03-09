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
            //隨機生成位置
            Vector3 pos = transform.position + new Vector3(Random.Range(-1f, 1f),0, Random.Range(-1f, 1f));

            //生成屍塊
            GameObject body = Instantiate(bodyPrefab, pos, Quaternion.identity);

            //加入清單
            bodies.Add(body);
        }

        StartCoroutine(DelayExplosion());
    }

    // 延遲執行爆炸
    IEnumerator DelayExplosion()
    {
        yield return null;

        //隨機給予爆炸力量
        foreach (GameObject body in bodies)
        {
            body.GetComponent<Rigidbody>().AddExplosionForce(500, transform.position, 1, 1);
        }
    }


    // 延遲刪除
    private void LateUpdate()
    {
        //刪除屍塊
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
