using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidBox : MonoBehaviour
{
    public GameObject SquidSet;
    public LayerMask Ikayaki;
    public LayerMask Leaf;

    private List<GameObject> ingredients = new List<GameObject>();

    private bool isCook = false;
    private bool isCombine = false;
    private bool hasIkayaki = false;
    private bool haslettuce = false;

    private void Update()
    {
        if (!isCook && isCombine)
        {
            Cook();
        }
    }

    private void Cook()
    {
        isCook = true;
        foreach (GameObject ingredient in ingredients)
        {
            Destroy(ingredient);
        }
        Destroy(gameObject);
        Instantiate(SquidSet, transform.position, transform.rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        string layerName = LayerMask.LayerToName(collision.gameObject.layer);

        if (layerName == "Ikayaki" && !hasIkayaki)
        {
            hasIkayaki = true;
            ingredients.Add(collision.gameObject);
            Debug.Log("ø¿¬°æÓ«’√º");
        }

        if (layerName == "Leaf" && !haslettuce)
        {
            haslettuce = true;
            ingredients.Add(collision.gameObject);
            Debug.Log("¿Ÿ «’√º");
        }

        if (hasIkayaki && haslettuce)
        {
            isCombine = true;
        }
    }
}
