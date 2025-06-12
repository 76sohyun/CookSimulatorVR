using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // �Է½ý���

[RequireComponent(typeof(Animator))] // ��ũ��Ʈ �߰��� �� ���� ��ü�� �ִϸ����� ����Ǿ����� Ȯ��
public class AnimatorHandConteroller : MonoBehaviour
{
    //�Է� �۾��� ���� ����
    public InputActionReference gripInputActionReference; //��ü ���
    public InputActionReference triggerInputActionReference; //��Ƽ� ����

    private Animator _handAnimator; //�ִϸ����� ����
    private float _gripValue; // �׸� �� ����
    private float _triggerValue; // Ʈ���� �� ����
    
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
        _gripValue = gripInputActionReference.action.ReadValue<float>(); // float ���� �а� ����
        _handAnimator.SetFloat("Grip", _gripValue); // �ִϸ����͸� �����ͼ� �׸� �Ű������� ���� float���� Grip������ ����
    }

    private void AnimateTrigger()
    {
        _triggerValue = triggerInputActionReference.action.ReadValue<float>(); // float ���� �а� ����
        _handAnimator.SetFloat("Trigger", _triggerValue); // �ִϸ����͸� �����ͼ� �׸� �Ű������� ���� float���� Trigger������ ����
    }
}
