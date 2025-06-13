using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenFried : MonoBehaviour
{
    [SerializeField] private float CookTimer;
    [SerializeField] private float BurnTimer;
    private float Timer;
    private bool isOil = false;
    private bool isCook = false;
    private bool isBurn = false;

    public GameObject FriedChicken;
    public LayerMask OilLayer;

    private void Update()
    {
        if (isOil && !isCook)
        {
            Timer += Time.deltaTime;

            if (Timer >= CookTimer)
            {
                Cook();
            }

            if (!isBurn && Timer >= BurnTimer)
            {
                isBurn = true;
                Destroy(gameObject);
            }
        }
    }

    private void Cook()
    {
        isCook = true;
        Instantiate(FriedChicken, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Oil")
        {
            isOil = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Oil")
        {
            isOil = false;
        }
    }
}
