using System;
using UnityEngine;

public class heliosLine : MonoBehaviour
{
    LineRenderer _hlr;
    Helios _helios;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _hlr = GetComponent<LineRenderer>();
        _helios = FindObjectOfType<Helios>();

        Vector3 lineZeroPosition = new(
            _helios.transform.position.x,
            _helios.transform.position.y,
            -0.1f);

        _hlr.SetPosition(0, _helios.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (_helios.IsDragging)
        {
            _hlr.enabled = true;
            _hlr.SetPosition(1, _helios.transform.position);
        }
        else
        {
            _hlr.enabled = false;
        }
    }
}