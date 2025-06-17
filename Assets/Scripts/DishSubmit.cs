using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DishSubmit : MonoBehaviour
{
    public string nextSceneName = "LastScene";
    public LayerMask ChickenSet;
    public LayerMask SquidSet;

    private bool isChickenSet = false;
    private bool isSquidSet = false;

    private void Update()
    {
        if(isChickenSet && isSquidSet)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (LayerMask.LayerToName(other.gameObject.layer) == "ChickenSet") 
        {
            isChickenSet = true;
        }

        if (LayerMask.LayerToName(other.gameObject.layer) == "SquidSet")
        {
            isSquidSet = true;
        }
    }
}
