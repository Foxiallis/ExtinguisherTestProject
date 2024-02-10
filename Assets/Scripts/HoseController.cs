using UnityEngine;

public class HoseController : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public LineRenderer lineRenderer;
    public int curveResolution = 10;
    public float gravity = 1.0f;

    void Start()
    {
        lineRenderer.positionCount = curveResolution;
    }

    void Update()
    {
        DrawHoseWithGravity();
    }

    void DrawHoseWithGravity()
    {
        float distanceBetweenPoints = Vector3.Distance(startPoint.position, endPoint.position);

        float peakHeight = distanceBetweenPoints * gravity;

        for (int i = 0; i < curveResolution; i++)
        {
            float t = i / (float)(curveResolution - 1);
            Vector3 basePosition = Vector3.Lerp(startPoint.position, endPoint.position, t);

            float parabola = (-4 * peakHeight * t) + (4 * peakHeight * t * t);
            Vector3 finalPosition = new Vector3(basePosition.x, basePosition.y + parabola, basePosition.z);

            lineRenderer.SetPosition(i, finalPosition);
        }
    }
}