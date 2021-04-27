using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ByrjunarTakki : MonoBehaviour//klasi
{
    public void Takki()//breyta
    {
        SceneManager.LoadScene(0);//færir yfir í fyrsta borð leiksinss
    }
    public void Endir()//breyta
    {
        SceneManager.LoadScene(0);// færir yfir í byrjunarsenuna
    }

}