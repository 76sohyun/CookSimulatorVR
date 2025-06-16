using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBox : MonoBehaviour
{
    public GameObject ChickenSet;
    public LayerMask ChickenLeg;
    public LayerMask ChickenBreast;
    public LayerMask ChickenWing;
    public LayerMask Mustard;

    private List<GameObject> ingredients = new List<GameObject>();

    private bool isCook = false;
    private bool isCombine = false;
    private bool hasLeg = false;
    private bool hasBreast = false;
    private bool hasWing = false;
    private bool hasMustard = false;

    private void Update()
    {
        if(!isCook && isCombine)
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
        Instantiate(ChickenSet, transform.position, transform.rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        string layerName = LayerMask.LayerToName(collision.gameObject.layer);

        if (layerName == "ChickenLeg" && !hasLeg)
        {
            hasLeg = true;
            ingredients.Add(collision.gameObject);
        }

        if (layerName == "ChickenBreast" && !hasBreast)
        {
            hasBreast = true;
            ingredients.Add(collision.gameObject);
        }

        if (layerName == "ChickenWing" && !hasWing)
        {
            hasWing = true;
            ingredients.Add(collision.gameObject);
        }

        if (layerName == "Mustard" && !hasMustard)
        {
            hasMustard = true;
            ingredients.Add(collision.gameObject);
        }

        if (hasLeg && hasBreast && hasWing && hasMustard)
        {
            isCombine = true;
        }
    }
}
