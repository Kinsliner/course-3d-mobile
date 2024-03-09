using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEffect : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float fadeSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lineRenderer == null)
        {
            return;
        }

        // 淡出LineRenderer的顏色
        Color startColor = lineRenderer.startColor;
        Color endColor = lineRenderer.endColor;
        startColor.a -= Time.deltaTime * fadeSpeed;
        endColor.a -= Time.deltaTime * fadeSpeed;
        lineRenderer.startColor = startColor;
        lineRenderer.endColor = endColor;

        // 淡出LineRenderer的寬度
        lineRenderer.startWidth = Mathf.Lerp(0.1f, 0f, Time.deltaTime * fadeSpeed);
        lineRenderer.startWidth = Mathf.Max(0, lineRenderer.startWidth);
        lineRenderer.endWidth = Mathf.Lerp(0.1f, 0f, Time.deltaTime * fadeSpeed);
        lineRenderer.endWidth = Mathf.Max(0, lineRenderer.endWidth);
    }
}
