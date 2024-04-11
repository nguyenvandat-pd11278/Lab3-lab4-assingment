using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject MenuChinh;
    public GameObject MenutrangPhuc;
    void Start()
    {
        HideMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (MenuChinh.activeSelf)
            {
                HideMenu();
            }
            else
            {
                ShowMenu();
            }
        }
    }

    void ShowMenu()
    {
        MenuChinh.SetActive(true);
        Time.timeScale = 0f; // Dừng thời gian trong trò chơi khi hiển thị menu
    }

    void HideMenu()
    {
        MenuChinh.SetActive(false);
        MenutrangPhuc.SetActive(false);
        Time.timeScale = 1f; // Khôi phục thời gian khi ẩn menu
    }
}
