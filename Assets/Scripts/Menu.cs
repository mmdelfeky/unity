using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
 
    bool isQuit = false;
    void OnMouseEnter(){
	//change text color
	GetComponent<Renderer>().material.color=Color.red;
}

    void OnMouseExit(){
	//change text color
	GetComponent<Renderer>().material.color=Color.white;
}

    void OnMouseUp()
    {
        //is this quit
        if (isQuit == true)
        {
            //quit the game
            Application.Quit();
        }
        else
        {
            //load level
            Application.LoadLevel(1);
        }
    }
	void OnMouseDown()
	{
		if (name.Equals ("txt_Quit Game"))
			isQuit = true;
	}

   
}
