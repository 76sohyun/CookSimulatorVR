using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenCut : MonoBehaviour
{
    public GameObject[] chickenParts;
    [SerializeField] private int hit;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("충돌감지");
        if (collision.gameObject.layer == 7)
        {
            if(hit < chickenParts.Length)
            {
                Debug.Log("썰다");
                Partactive(hit);
                hit++;
            }
        }
    }

    private void Partactive(int index)
    {
        GameObject gameObject = chickenParts[index];
        gameObject.SetActive(true);
        gameObject.transform.SetParent(null);
        Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.AddForce(Vector3.up * 1f, ForceMode.Impulse);
    }
}
