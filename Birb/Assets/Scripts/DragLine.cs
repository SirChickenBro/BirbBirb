using System;
using UnityEngine;

public class DragLine : MonoBehaviour
{
    LineRenderer _lr;
    Birb _bird;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _lr = GetComponent<LineRenderer>();
        _bird = FindObjectOfType<Birb>();
        
        Vector3 lineZeroPosition = new Vector3(
            _bird.transform.position.x,
            _bird.transform.position.y,
            -0.1f);
       
        _lr.SetPosition(0, _bird.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (_bird.IsDragging)
        {
            _lr.enabled = true;
            _lr.SetPosition(1, _bird.transform.position);
        }
        else
        {
            _lr.enabled = false;
        }
    }
}
