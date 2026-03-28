using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Birb : MonoBehaviour
{
    private Vector2 _startPosition;
    [SerializeField] float _launchForce = 500;
    [SerializeField] float _maxDrag = 2;
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;

    public bool IsDragging { get; private set; }

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startPosition = _rb.position;
        _rb.isKinematic = true;
    }

    void OnMouseDown()
    {
        _sr.color = Color.red;
        IsDragging = true;
    }

    void OnMouseUp()
    {
        var currentPosition = _rb.position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();

        _rb.isKinematic = false;
        _rb.AddForce(direction * _launchForce);

        _sr.color = Color.white;
        IsDragging = false;
    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 desiredPosition = mousePosition;

        float distance = Vector2.Distance(desiredPosition, _startPosition);
        if (distance > _maxDrag)
        {
            Vector2 direction = desiredPosition - _startPosition;
            direction.Normalize();
            desiredPosition = _startPosition + (direction * _maxDrag);
        }

        if (desiredPosition.x > _startPosition.x)
            desiredPosition.x = _startPosition.x;

        _rb.position = desiredPosition;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetDelay());
    }
    IEnumerator ResetDelay()
    {
        yield return new WaitForSeconds(3);
        _rb.position = _startPosition;
        _rb.isKinematic = true;
        _rb.linearVelocity = Vector2.zero;
    }
}
