using UnityEngine;
using System.Collections;

public class InteractionController : MonoBehaviour
{
    public Transform Spawn;
    private Vector3 screenPoint;
    private Vector3 scanPos;
    private Vector3 offset;
    private bool isDragable;
    private bool isSetCorrectly;
    
    // Use this for initialization
    void Start()
    {
        isDragable = true;
        isSetCorrectly = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSetCorrectly)
            transform.position = new Vector3(Spawn.position.x, Spawn.position.y + 3, Spawn.position.z);
    }
    void OnMouseDown()
    {
        if (isDragable && !isSetCorrectly)
        {
            screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        }
    }

    void OnMouseDrag()
    {
        if (isDragable&&!isSetCorrectly)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
        else
        {
            transform.position = Spawn.position;

        }

    }

    void OnMouseUp()
    {
        
        transform.position = Spawn.position;
        isDragable = true;
    }

    void OnTriggerEnter(Collider other)
    {
        string[] cars = { "LionPlace", "CrocPlace", "DuckPlace", "FoxPlace" };
        if (other.CompareTag(gameObject.tag + "Place"))
        {
            isDragable = false;
            Spawn = other.gameObject.transform;
            gameObject.GetComponent<Collider>().enabled = false;
            GameManager.Instance.count--;
            isSetCorrectly = true;
            GameManager.Instance.GetComponents<AudioSource>()[2].Play();
            other.GetComponent<ContentChecker>().isEmpty = false;
            return;
        }

        for (int i = 0; i < cars.Length; i++)
        {
            if (other.CompareTag(cars[i]))
            {
                isDragable = false;
                //transform.position = Spawn.position;

                GameManager.Instance.GetComponents<AudioSource>()[1].Play();
                return;

            }
        }

    }

}
