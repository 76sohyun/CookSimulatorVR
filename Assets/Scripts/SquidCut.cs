using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SquidCut : MonoBehaviour
{
    public GameObject SquidDie;
    private int cutCount = 0;
    [SerializeField] private int Cut;

    private bool isCook = false;
  
    void Update()
    {
        if (!isCook && cutCount >= Cut)
        {
            Cook();
        }
    }

    private void Cook()
    {
        isCook = true;
        Instantiate(SquidDie, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Knife")
        {
            cutCount++;
        }
    }
}
