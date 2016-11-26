using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CardGameTypes;
using UnityEngine.UI;

public class CardUIElement : GuiPanel
{
	#region Fields

    private Card mCardData;

    public int Index;
    public Text Name;
    public Text Description;
    public Image CardImage;
    public NumberUIElement AttacDamage;
    public NumberUIElement Hp;
    public NumberUIElement ManaCost;

    public Animator Animator;
    public GameObject CardBackObject;
    public bool IsCardBackVisible;

	#endregion //Fields
	
	#region Public Methods

    public void SetCardProperties(Card data, int index)
    {
        Index = index;
        mCardData = data;
        Description.text = mCardData.Description;
        ManaCost.SetNumberImage(mCardData.ManaCost);
        Name.text = mCardData.Name;

        if (CardBackObject != null)
            CardBackObject.SetActive(IsCardBackVisible);

        if (data.HP != 0)
        {
            AttacDamage.gameObject.SetActive(true);
            Hp.gameObject.SetActive(true);
            AttacDamage.SetNumberImage(data.AttackDamage);
            Hp.SetNumberImage(data.HP);
        }
        else
        {
            AttacDamage.gameObject.SetActive(false);
            Hp.gameObject.SetActive(false);
        }
    }

    public void SetMinionProperties(Card data, int index)
    {
        Index = index;
        mCardData = data;
        AttacDamage.gameObject.SetActive(true);
        Hp.gameObject.SetActive(true);
        AttacDamage.SetNumberImage(data.AttackDamage);
        Hp.SetNumberImage(data.HP);

        AddMinionButtonListener(index);
    }

    public void AddCardButtonListener(int index)
    {
        this.GetComponent<Button>().onClick.AddListener(() => mIngameUIManager.PlayerCardConfirmationPanel.SetCardData(mCardData, index));
    }

    public void AddMinionButtonListener(int index)
    {
        if (mIngameUIManager != null)
        {
            this.GetComponent<Button>().onClick.AddListener(() => mIngameUIManager.PlayerBattleFieldUIManager.OnMinionSelected(index));
        }
    }


	#endregion // Public Methods

    #region Events

    public void OnOverButton()
    {
        Animator.SetTrigger("Visible");
    }

    public void OnExitButton()
    {
        Animator.SetTrigger("InVisible");
    }

    #endregion // Events
}
