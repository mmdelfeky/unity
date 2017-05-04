using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public GameObject retryButton;
    public GameObject menuButton;
    public Image winImage;
    public int count ;
    bool flag;
	// Use this for initialization
	void Start () {
        Instance = this;
        retryButton.SetActive(false);
        menuButton.SetActive(false);
        winImage.enabled = false;
        flag = false;
	}

	// Update is called once per frame
	void Update () {
        if (count == 0&&!flag)
        {
            retryButton.SetActive(true);
            winImage.enabled = true;
            menuButton.SetActive(true);
            GetComponents<AudioSource>()[0].Play();
            flag = true;
        }
	}

    public void GoToMenu()
    {
        Application.LoadLevel(0);
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }


    
}
