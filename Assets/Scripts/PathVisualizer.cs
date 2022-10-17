using System;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PathVisualizer : MonoBehaviour
{
    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public void ClearPath()
    {
        _lineRenderer.positionCount = 1;
        
        Vector3[] positions = {Vector3.zero};
        
        _lineRenderer.SetPositions(positions);
    }

    public void AddPosition(Vector3 pos)
    {
        Vector3[] positions = new Vector3[_lineRenderer.positionCount + 1];
        _lineRenderer.GetPositions(positions);
        positions[positions.Length - 1] = pos;
        _lineRenderer.positionCount++;
        _lineRenderer.SetPositions(positions);
    }

    public void RemoveFirstPosition()
    {
        Vector3[] positions = new Vector3[_lineRenderer.positionCount];
        _lineRenderer.GetPositions(positions);
        Vector3[] nPositions = new Vector3[positions.Length - 1];
        Array.Copy(positions, 1, nPositions, 0, positions.Length - 1);
        _lineRenderer.positionCount--;
        _lineRenderer.SetPositions(nPositions);
    }
}