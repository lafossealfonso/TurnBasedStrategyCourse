using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBusyUI : MonoBehaviour
{

    [SerializeField] private Animator refreshIcon;

    private void Start()
    {
        //subscribes to OnBusyChanged from Unit ActionSystem
        UnitActionSystem.Instance.OnBusyChanged += UnitActionSystem_OnBusyChanged;
        refreshIcon.SetTrigger("isNotRefreshing");
        Hide();
        //refreshIcon.SetBool("isRefreshing", false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
        refreshIcon.SetTrigger("isRefreshing");

    } 

    private void Hide()
    {
        refreshIcon.SetTrigger("isNotRefreshing");
        gameObject.SetActive(false);
        //refreshIcon.SetBool("isRefreshing", false);
    }

    private void UnitActionSystem_OnBusyChanged(object sender, bool isBusy)
    {
        if (isBusy)
        {
            Show();
        }

        else
        {
            Hide();
        }
    }
}
