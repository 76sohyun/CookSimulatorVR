using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatCooked : MonoBehaviour
{
    [SerializeField] private float CookTimer;
    [SerializeField] private float BurnTimer;
    private float Timer;
    private bool isGrill = false;
    private bool isCook = false;
    private bool isBurn = false;

    public GameObject GrillMeat;
    public LayerMask grillLayer;

    private void Update()
    {
        if(isGrill && !isCook)
        {
            Timer += Time.deltaTime;

            if(Timer >= CookTimer)
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
        Instantiate(GrillMeat, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(LayerMask.LayerToName(collision.gameObject.layer) == "Grill")
        {
            isGrill = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Grill")
        {
            isGrill = false;
        }
    }

}
