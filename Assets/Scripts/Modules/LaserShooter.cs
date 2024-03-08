using System.Collections.Generic;
using UnityEngine;

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

    private List<GameObject> lasers = new List<GameObject>();

    public override void Shoot(GameObject prefab)
    {
        if (weapon == null)
            return;

        if (prefab == null)
            return;

        if (weapon.shootPoint == null)
            return;

        GameObject laserObj = Instantiate(prefab, weapon.shootPoint.position, Quaternion.identity);

        RaycastHit hit;
        if (Physics.Raycast(weapon.shootPoint.position, weapon.shootPoint.forward, out hit))
        {
            Vector3 direction = hit.point - weapon.shootPoint.position;
            laserObj.transform.forward = direction.normalized;
        }
        else
        {
            laserObj.transform.forward = weapon.shootPoint.forward;
        }

        // get the line renderer component
        LineRenderer lineRenderer = laserObj.GetComponent<LineRenderer>();
        if (lineRenderer != null)
        {
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

        lasers.RemoveAll(laser => laser == null);

        foreach (GameObject laser in lasers)
        {
            var lineRenderer = laser.GetComponent<LineRenderer>();
            if (lineRenderer != null)
            {
                // fade out the laser
                Color startColor = lineRenderer.startColor;
                Color endColor = lineRenderer.endColor;
                startColor.a -= Time.deltaTime * 10;
                endColor.a -= Time.deltaTime * 10;
                lineRenderer.startColor = startColor;
                lineRenderer.endColor = endColor;
                lineRenderer.startWidth = Mathf.Lerp(0.1f, 0f, Time.deltaTime * 10);
                lineRenderer.startWidth = Mathf.Max(0, lineRenderer.startWidth);
                lineRenderer.endWidth = Mathf.Lerp(0.1f, 0f, Time.deltaTime * 10);
                lineRenderer.endWidth = Mathf.Max(0, lineRenderer.endWidth);



            }
        }
    }
}