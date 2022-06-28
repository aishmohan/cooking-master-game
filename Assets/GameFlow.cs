using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    // Global variables
    
    public Transform customerObj;


    // Start is called before the first frame update
    void Start()
    {
        spawnCustomers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnCustomers()
    {
        for (int numPatron = 0; numPatron < 5; numPatron++)
        {
            Instantiate(customerObj, new Vector3(customerObj.position.x + (2.0f * numPatron), customerObj.position.y, customerObj.position.z), customerObj.rotation);
        }
        
    }
}
