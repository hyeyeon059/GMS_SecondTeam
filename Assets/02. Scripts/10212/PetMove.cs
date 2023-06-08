using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PetMove : MonoBehaviour
{

    private Vector3 clickPos;
    [SerializeField] private GameObject _shield;
    private Sequence seq;

    [SerializeField] private bool _onShield = false;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            clickPos = hit.point;
        }
        clickPos.y = transform.position.y;

        Move();
        OnShield();
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {


            transform.DOMove(clickPos, 2f);
        }
    }
    private void OnShield()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Tween t1 = _shield.transform.DOScale(new Vector3(3, 1, 0.5f), 1f);
            Tween t2 = _shield.transform.DOMove(transform.position + clickPos.normalized, 1f);
            _shield.transform.LookAt(clickPos);

            seq.Append(t1);
            seq.Join(t2);
        }
        if (Input.GetMouseButton(1)) 
        {

        }

        if (Input.GetMouseButtonUp(1))
        {
            Tween t1 = _shield.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 1f);
            Tween t2 = _shield.transform.DOMove(transform.position, 1f);
            seq.Append(t1);
            seq.Join(t2);
        }
    }
}
