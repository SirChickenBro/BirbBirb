using System;
using UnityEngine;

public class chickenLine : MonoBehaviour
{
    LineRenderer _hlr;
    ChickenOfDoom _chicken;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _hlr = GetComponent<LineRenderer>();
        _chicken = FindObjectOfType<ChickenOfDoom>();

        Vector3 lineZeroPosition = new(
            _chicken.transform.position.x,
            _chicken.transform.position.y,
            -0.1f);

        _hlr.SetPosition(0, _chicken.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (_chicken.IsDragging)
        {
            _hlr.enabled = true;
            _hlr.SetPosition(1, _chicken.transform.position);
        }
        else
        {
            _hlr.enabled = false;
        }
    }
}