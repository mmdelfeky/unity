using UnityEngine;
using System.Collections;

public class Validator : MonoBehaviour {

    public GameObject train;
    private GameObject car;
	
	// Update is called once per frame
    void Update()
    {
        if (car != null&&GameManager.Instance.count>=0)
        {
            if(!car.GetComponent<ContentChecker>().isEmpty)
                train.GetComponent<Mover>().move = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lion") || other.CompareTag("Fox") || other.CompareTag("Duck") || other.CompareTag("Croc"))
            return;
        car = other.gameObject;
        train.GetComponent<Mover>().move = false; ;
       
    }
}
