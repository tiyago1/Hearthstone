using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MagicClass : PlayerClass
{
	#region Fields

    //public List<Card> Cards = new List<Card>();
    //public CardDeckUIElement CardDeckUIElement;

	#endregion //Fields

    #region Public Method

    public override void Initialize()
    {
        CardDeckUIElement = this.transform.GetChild(1).GetComponent<CardDeckUIElement>();
        BattleFieldUIManager = this.transform.GetChild(2).GetComponent<BattleFieldUIManager>();
        CardConfirmationPanel.OnCardConfimated += CardConfirmationPanel_OnCardConfimated;
    }

    public override void SetCard(Card card)
    {
        Cards.Add(card);
        CardDeckUIElement.InsantiateCard(card);
    }

    #endregion // Public Method 

    #region Private Method


    #endregion // Private Method

    #region Abilities

    public void SpellAbility()
    {
         
    }

    #endregion // Abilities

    #region Events

    private void CardConfirmationPanel_OnCardConfimated(int index)
    {
        BattleFieldUIManager.PutBattleField(Cards[index]);
        Cards.RemoveAt(index);
    }

    #endregion // Events
}
