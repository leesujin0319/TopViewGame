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
        // Vector 값을 실수로 변환
        {
            // 마우스가 캐릭터의 좌측에 있는지 우측에 있는지를 판단하여 스케일을 조정합니다.
            if (newAim.x < 0)
            {
                // 마우스가 캐릭터의 좌측에 있을 때
                transform.localScale = new Vector3(-1f, 1f, 1f); // 좌우 반전
            }
            else
            {
                // 마우스가 캐릭터의 우측에 있을 때
                transform.localScale = new Vector3(1f, 1f, 1f); // 원래 방향
            }
            CallLookEvent(newAim);
        }
    }

    public void OnFire(InputValue value)
    {
        
    }
 }
