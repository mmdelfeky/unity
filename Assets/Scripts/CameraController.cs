using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public BoxCollider2D Bounds;
    private float x;
    private float y;

	// Use this for initialization
	void Start () {
        var cameraHalfWidth = GetComponent<Camera>().orthographicSize * ((float)Screen.width / Screen.height);
        x = Bounds.bounds.min.x + cameraHalfWidth;
        y = Bounds.bounds.min.y + GetComponent<Camera>().orthographicSize;
        transform.position = new Vector3(x, y, transform.position.z);
	}
	
	
}
