using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("StageRoom_SEJ");
    }
    public void Home()
    {
        SceneManager.LoadScene("WaitingRoom_SEJ");
    }
}
