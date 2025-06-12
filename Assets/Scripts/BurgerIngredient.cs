using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerIngredient : MonoBehaviour
{

    public LayerMask Hamberger;
    [SerializeField] private bool isConbine;

    private void Update()
    {
        RayConbine();
    }

    private void RayConbine()
    {
        RaycastHit raycastHit;
        if(Physics.Raycast(transform.position, Vector3.down, out raycastHit, 0.05f, Hamberger))
        {
            GameObject downObj = raycastHit.collider.gameObject;
            Debug.Log("Ray hit: " + raycastHit.collider.name);

            if (!isConbine)
            {
                ConbineIng(downObj);
                Debug.Log("ÇÕÃÄÁü");
            }

        }
        Debug.DrawRay(transform.position, Vector3.down * 0.05f, Color.green);

    }

    private void ConbineIng(GameObject downObj)
    {
        transform.SetParent(downObj.transform);
        transform.localPosition = new Vector3(0, 0.2f, 0);
        isConbine = true;
    }
}
