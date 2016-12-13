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

    public Card CardData;

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
        CardData = data;
        Description.text = CardData.Description;
        ManaCost.SetNumberImage(CardData.ManaCost);
        Name.text = CardData.Name;

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

    public void AddCardButtonListener(int index)
    {
        this.GetComponent<Button>().onClick.AddListener(() => mIngameUIManager.PlayerCardConfirmationPanel.SetCardData(CardData, index));
    }

    public void AddAgentCardButtonListener(int index)
    {
        this.GetComponent<Button>().onClick.AddListener(() => mIngameUIManager.EnemyCardConfirmationPanel.SetCardData(CardData, index)); // TO_DO : Nothing test. You must testing this.
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
