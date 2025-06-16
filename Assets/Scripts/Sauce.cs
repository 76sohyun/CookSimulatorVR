using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sauce : MonoBehaviour
{
    public GameObject MainSauce;
    public LayerMask SauceLayer;

    private bool isSauce = false;
    private bool isCook = false;

   
    void Update()
    {
        if(isSauce && !isCook)
        {
            Cook();
        }
    }

    private void Cook()
    {
        isCook = true;
        Destroy(gameObject);
        Instantiate(MainSauce, transform.position, transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "Sauce")
        {
            isSauce = true;
        }
    }
}
