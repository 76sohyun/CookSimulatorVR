using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oilbutton : MonoBehaviour
{
    public GameObject Oil;

    [SerializeField] private float OnAngle;
    [SerializeField] private float OffAngle;

    Vector3 CurAngle;
    private bool isOn = false;

    void Update()
    {
        CurAngle = transform.localEulerAngles;

        if (IsAngleClose(CurAngle.z, OffAngle) && isOn)
        {
            OffOil();
        }

        if (IsAngleClose(CurAngle.z, OnAngle) && !isOn)
        {
            OnOil();
        }
    }

    private void OnOil()
    {
        isOn = true;
        Oil.SetActive(true);
    }

    private void OffOil()
    {
        isOn = false;
        Oil.SetActive(false);
    }

    private bool IsAngleClose(float a, float b)
    {
        return Mathf.Abs(a - b) < 1f;
    }

}
