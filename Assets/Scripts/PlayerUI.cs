using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{

    [SerializeField] private GameObject uiPannel;

    public void OpenUI()
    {
        uiPannel.SetActive(true);
    }

    public void CloseUI()
    {
        uiPannel.SetActive(false);
    }

}
