using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // 입력시스템

[RequireComponent(typeof(Animator))] // 스크립트 추가할 때 게임 개체에 애니메이터 연결되었는지 확인
public class AnimatorHandConteroller : MonoBehaviour
{
    //입력 작업에 대한 참조
    public InputActionReference gripInputActionReference; //물체 잡기
    public InputActionReference triggerInputActionReference; //방아쇠 당기기

    private Animator _handAnimator; //애니메이터 참조
    private float _gripValue; // 그립 값 참조
    private float _triggerValue; // 트리거 값 참조
    
    void Start()
    {
        _handAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        AnimateGrip();
        AnimateTrigger();
    }

    private void AnimateGrip()
    {
        _gripValue = gripInputActionReference.action.ReadValue<float>(); // float 값을 읽고 저장
        _handAnimator.SetFloat("Grip", _gripValue); // 애니메이터를 가져와서 그립 매개변수에 대한 float값을 Grip값으로 설정
    }

    private void AnimateTrigger()
    {
        _triggerValue = triggerInputActionReference.action.ReadValue<float>(); // float 값을 읽고 저장
        _handAnimator.SetFloat("Trigger", _triggerValue); // 애니메이터를 가져와서 그립 매개변수에 대한 float값을 Trigger값으로 설정
    }
}
