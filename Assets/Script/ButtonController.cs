using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    public void GameExit()
    {
        Debug.Log("GameExit Called");
        Application.Quit();
    }
}
