using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{

    [SerializeField] float yFloor;
    [SerializeField] GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < yFloor)
        {
            gameObject.transform.position = spawnPoint.transform.position;
            gameObject.transform.rotation = spawnPoint.transform.rotation;
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.isKinematic = false;
        }
        
    }
}
