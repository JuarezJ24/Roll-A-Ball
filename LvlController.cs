using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlController : MonoBehaviour
{
    public void MiniGame()
    {
        SceneManager.LoadScene("MiniGame");
    }
    public void MiniGame2()
    {
        SceneManager.LoadScene("MiniGame2");
    }
}
