using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMove : MonoBehaviour
{
    [SerializeField] private float _petSpeed = 3f;
    [SerializeField] private bool _isMoving = false;

    private Rigidbody _rb;
    private Vector3 _mousePosition;
    private Camera _mainCam;

    void Start()
    {
        _mainCam = Camera.main;

        _rb = GetComponent<Rigidbody>();
        _rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezeRotationY;
    }

    void Update()
    {
        PetMovement();
    }

    private void PetMovement()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                _mousePosition = hit.point;
                _isMoving = true;
            }
        }

        if (_isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, _mousePosition, _petSpeed * Time.deltaTime);

            if (transform.position == _mousePosition)
            {
                _isMoving = false;
            }
        }
    }
}
