using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Laser
{
    public GameObject GameObject { get; set; }
    public Vector3 Direction { get; set; }
    public float Speed { get; set; }

    private Vector3 startPoint;
    private LineRenderer lineRenderer;

    public Laser(GameObject gameObject, Vector3 direction, float speed)
    {
        GameObject = gameObject;
        Direction = direction;
        Speed = speed;
        startPoint = GameObject.transform.position;
        lineRenderer = GameObject.GetComponent<LineRenderer>();
    }

    public void Move()
    {
        // lincast from laser position to forward
        RaycastHit hit;
        Vector3 start = GameObject.transform.position;
        Vector3 end = start + Direction * Speed * Time.deltaTime;
        if (Physics.Linecast(start, end, out hit))
        {
            // if hit, destroy the laser
            Object.Destroy(GameObject);
        }
        else
        {
            // if not hit, move the laser
            GameObject.transform.position = end;
            lineRenderer.SetPosition(0, end);
            lineRenderer.SetPosition(1, startPoint);
        }
    }
}

public class LaserShooter : WeaponShooter
{
    public float laserSpeed = 100f;
    public float laserLifeTime = 2f;
    public LayerMask shootLayer;

    [Header("擊中事件")]
    public UnityEvent<GameObject> OnHit;

    private List<GameObject> lasers = new List<GameObject>();

    public override void Shoot(GameObject prefab)
    {
        if (weapon == null)
            return;

        if (prefab == null)
            return;

        if (weapon.shootPoint == null)
            return;

        // 產生雷射物件
        GameObject laserObj = Instantiate(prefab, weapon.shootPoint.position, Quaternion.identity);

        RaycastHit hit;
        var laserRay = new Ray(weapon.shootPoint.position, weapon.shootPoint.forward);
        if (Physics.Raycast(laserRay, out hit, Mathf.Infinity, shootLayer))
        {
            Vector3 direction = hit.point - weapon.shootPoint.position;
            laserObj.transform.forward = direction.normalized;
            OnHit?.Invoke(hit.collider.gameObject);
        }
        else
        {
            laserObj.transform.forward = weapon.shootPoint.forward;
        }

        // 取得LineRenderer
        LineRenderer lineRenderer = laserObj.GetComponent<LineRenderer>();
        if (lineRenderer != null)
        {
            // 設定LineRenderer的起點與終點
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3.forward * 100);
        }

        lasers.Add(laserObj);

        Destroy(laserObj, 2f);
    }

    private void Update()
    {
        if (lasers.Count == 0)
            return;

        // 移除已經被銷毀的laser
        lasers.RemoveAll(laser => laser == null);
    }
}