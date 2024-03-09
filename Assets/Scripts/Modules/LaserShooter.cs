using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaserShooter : WeaponShooter
{
    public LayerMask shootLayer; // 射線擊中的Layer

    [Header("擊中事件")]
    public UnityEvent<GameObject> OnHit;

    private List<GameObject> lasers = new List<GameObject>(); // 保存所有的雷射物件

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

        // 設定雷射物件的方向為武器的shootPoint的forward
        laserObj.transform.forward = weapon.shootPoint.forward;

        // 建立射線，出發點為武器的shootPoint，方向為shootPoint的forward
        var laserRay = new Ray(weapon.shootPoint.position, weapon.shootPoint.forward);

        // 判定射線是否有擊中物件，
        if (Physics.Raycast(laserRay, out RaycastHit hit, Mathf.Infinity, shootLayer))
        {
            // 觸發擊中事件
            OnHit?.Invoke(hit.collider.gameObject);
        }

        // 取得LineRenderer
        LineRenderer lineRenderer = laserObj.GetComponent<LineRenderer>();
        if (lineRenderer != null)
        {
            // 設定LineRenderer的起點與終點
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3.forward * 100);
        }

        // 保存雷射物件
        lasers.Add(laserObj);

        // 2秒後銷毀雷射物件
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