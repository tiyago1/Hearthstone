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

    public Text Name;
    public Text Description;
    public Image CardImage;
    public NumberUIElement AttacDamage;
    public NumberUIElement Hp;
    public NumberUIElement ManaCost;

	#endregion //Fields
	
	#region Public Methods

    public void SetCardProperties(Card data)
    {
        mCardData = data;
        Name.text = data.Name;
        Description.text = data.Description;
        ManaCost.SetNumberImage(data.ManaCost);
        Debug.Log("mana Ç: " + data.ManaCost + " damage "+ data.AttackDamage + " hp : " + data.HP);

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
        Debug.Log(mIngameUIManager == null);
        this.GetComponent<Button>().onClick.AddListener(()=> mIngameUIManager.CardConfirmationPanel.SetCardData(mCardData));
    }

	#endregion // Public Methods
}
