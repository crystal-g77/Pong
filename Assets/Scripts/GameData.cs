
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public void setUseAI(bool useAI)
    {
        PlayerPrefs.SetInt("UseAI", useAI ? 1 : 0);
        PlayerPrefs.Save();
    }

    public bool getUseAI(out bool useAI)
    {
        if(!PlayerPrefs.HasKey("UseAI"))
        {
            useAI = false;
            return false;
        }

        useAI = PlayerPrefs.GetInt("UseAI") == 1;
        return true;
    }

    public void resetUseAI()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}
