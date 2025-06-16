using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCut : MonoBehaviour
{
    public GameObject[] chickenParts;
    private int hit;
    public LayerMask layerMask;

    private void OnCollisionEnter(Collision collision)
    {
        if (1 << collision.gameObject.layer == layerMask)
        {
            if(hit < chickenParts.Length)
            {
                Partactive(hit);
                hit++;
            }

            if(hit >= chickenParts.Length)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Partactive(int index)
    {
        GameObject gameObject = chickenParts[index];
        gameObject.SetActive(true);
        gameObject.transform.SetParent(null);
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.AddForce(Vector3.up * 1f, ForceMode.Impulse);
    }
}
