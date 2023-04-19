using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActionButtonUI : MonoBehaviour
{

    //[SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private Button button;
    [SerializeField] private GameObject selectedGameObject;
    [SerializeField] private Image moveIcon;
    [SerializeField] private Image spinIcon;
    [SerializeField] private Image shootIcon;
    


    private BaseAction baseAction;

    private void Awake()
    {
        spinIcon.enabled = false;
        moveIcon.enabled = false;
        shootIcon.enabled = false;
    }
    public void SetBaseAction(BaseAction baseAction)
    {
        this.baseAction = baseAction;
        //textMeshPro.text = baseAction.GetActionName().ToUpper();
        //checks for action name and assigns appropriate icon. They have to be enabled false on awake!
        if(baseAction.GetActionName() == "Move")
        {
           
            moveIcon.enabled = true;
        }

        else if(baseAction.GetActionName() == "Spin")
        {
            spinIcon.enabled = true;
        }

        else if(baseAction.GetActionName() == "Shoot")
        {
            shootIcon.enabled = true;
        }

        button.onClick.AddListener(() => {
            UnitActionSystem.Instance.SetSelectedAction(baseAction);
        });
    }

    public void UpdateSelectedVisual()
    {
        BaseAction selectedBaseAction = UnitActionSystem.Instance.GetSelectedAction();
        selectedGameObject.SetActive(selectedBaseAction == baseAction);

    }

}

