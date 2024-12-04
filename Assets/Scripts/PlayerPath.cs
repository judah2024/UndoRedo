using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerPath : MonoBehaviour
{
    public GameObject pathPointPrefab;
    public Transform pathTransform;

    public Vector3 offset;
    private Stack<GameObject> stkPath = new Stack<GameObject>();

    public LineRenderer lineRenderer;
    public List<Vector3> listPoint;

    private void Start()
    {
        AddPath(transform.position);
    }

    private void Update()
    {
        lineRenderer.SetPositions(listPoint.ToArray());
    }

    public void AddPath(Vector3 position)
    {
        if (pathPointPrefab == null)
        {
            Debug.Log("point Prefab is null!");
            return;
        }

        GameObject obj = Instantiate(pathPointPrefab, position + offset, Quaternion.identity);
        stkPath.Push(obj);

        if (pathTransform != null)
        {
            obj.transform.parent = pathTransform;
        }

        UpdatePathLine();
    }

    public void RemovePath()
    {
        GameObject obj = stkPath.Pop();
        Destroy(obj);

        UpdatePathLine();
    }
    
    void UpdatePathLine()
    {
        listPoint = stkPath.Select(x => x.transform.position).ToList();
        lineRenderer.positionCount = listPoint.Count;
    }
}
