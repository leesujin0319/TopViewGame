using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownController
{
    private Camera _camera;
    private void Awake()
    {
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        // Debug.Log("OnLook" + value.ToString());
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        if (newAim.magnitude >= .9f)
        // Vector ���� �Ǽ��� ��ȯ
        {
            // ���콺�� ĳ������ ������ �ִ��� ������ �ִ����� �Ǵ��Ͽ� �������� �����մϴ�.
            if (newAim.x < 0)
            {
                // ���콺�� ĳ������ ������ ���� ��
                transform.localScale = new Vector3(-1f, 1f, 1f); // �¿� ����
            }
            else
            {
                // ���콺�� ĳ������ ������ ���� ��
                transform.localScale = new Vector3(1f, 1f, 1f); // ���� ����
            }
            CallLookEvent(newAim);
        }
    }

    public void OnFire(InputValue value)
    {
        
    }
 }
