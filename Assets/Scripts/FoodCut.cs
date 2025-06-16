using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCut : MonoBehaviour
{
    public GameObject[] FoodParts;
    private int hit;
    public LayerMask layerMask;

    private void OnCollisionEnter(Collision collision)
    {
        if (1 << collision.gameObject.layer == layerMask)
        {
            if(hit < FoodParts.Length)
            {
                Partactive(hit);
                hit++;
            }

            if(hit >= FoodParts.Length)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Partactive(int index)
    {
        GameObject gameObject = FoodParts[index];
        gameObject.SetActive(true);
        gameObject.transform.SetParent(null);
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.AddForce(Vector3.up * 1f, ForceMode.Impulse);
    }
}
