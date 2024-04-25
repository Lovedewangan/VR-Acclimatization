using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reception_to_waiting : MonoBehaviour
{
    public GameObject waiting_portal;
    // Start is called before the first frame update
    void Start()
    {
        waiting_portal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        waiting_portal.SetActive(true);
    }
}
