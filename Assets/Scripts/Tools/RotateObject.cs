using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField]
    private float _xAxisRotation = 0.0f;
    [SerializeField]
    private float _yAxisRotation = 0.0f;
    [SerializeField]
    private float _zAxisRotation = 0.0f;
    [SerializeField]
    private float _speed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(_xAxisRotation, _yAxisRotation, _zAxisRotation, Space.Self);
    }
}
