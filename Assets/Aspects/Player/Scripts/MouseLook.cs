using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    [SerializeField] private RotationAxes _axes = RotationAxes.MouseXAndY;
    [SerializeField] private float _sensitivityHor = 9;
    [SerializeField] private float _sensitivityVer = 9;

    [SerializeField] private float _minimumVer = -45;
    [SerializeField] private float _maximumVer = 45;

    private float _rotationX = 0;

    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
    }

    void Update()
    {
        if (_axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * _sensitivityHor, 0);
        }
        else if (_axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _sensitivityVer;
            _rotationX = Mathf.Clamp(_rotationX, _minimumVer, _maximumVer);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else if(_axes == RotationAxes.MouseXAndY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * _sensitivityVer;
            _rotationX = Mathf.Clamp(_rotationX, _minimumVer, _maximumVer);

            float delta = Input.GetAxis("Mouse X") * _sensitivityHor;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
