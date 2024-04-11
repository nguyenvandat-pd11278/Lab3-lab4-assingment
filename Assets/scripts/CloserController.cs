using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloserController : MonoBehaviour
{

    public GameObject trangPhuc;
    void Start()
    {
        UnityEngine.UI.Button button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(OnClick);
    }

    void OnClick()
    {
        HideMenu();
    }
    public void HideMenu()
    {
         trangPhuc.SetActive(false);
    }
}
