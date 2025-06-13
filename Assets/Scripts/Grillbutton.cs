using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grillbutton : MonoBehaviour
{
    public GameObject grill;
    public GameObject Nongrill;

    [SerializeField] private float OnAngle;
    [SerializeField] private float OffAngle;

    Vector3 CurAngle;
    private bool isOn = false;

    void Update()
    {
        CurAngle = transform.localEulerAngles;

        if(IsAngleClose(CurAngle.z, OffAngle) && isOn)
        {
            OffGrill();
        }

        if(IsAngleClose(CurAngle.z, OnAngle) && !isOn)
        {
            OnGrill();
        }
    }

    private void OnGrill()
    {
        isOn = true;
        grill.SetActive(true);
        Nongrill.SetActive(false);
    }

    private void OffGrill()
    {
        isOn = false;
        grill.SetActive(false);
        Nongrill.SetActive(true);
    }

    private bool IsAngleClose(float a, float b)
    {
        return Mathf.Abs(a - b) < 1f;
    }

}
