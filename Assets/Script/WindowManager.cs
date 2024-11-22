using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    [SerializeField] GameObject PauseWindow;
    public bool pwflag;
    // Start is called before the first frame update
    void Start()
    {
        pwflag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) PauseWindowControll();
    }

    public void PauseWindowControll()
    {
        if (pwflag)
        {
            PauseWindow.SetActive(false);
            pwflag = false;
            Time.timeScale = 1;
        }
        else
        {
            PauseWindow.SetActive(true);
            pwflag = true;
            Time.timeScale = 0;
        }
    }
}
