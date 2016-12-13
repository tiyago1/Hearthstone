using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CardGameTypes;

public class MagicClass : PlayerClass
{
	#region Fields

	#endregion //Fields

    #region Public Method

    public override void Initialize()
    {
        CardDeckUIElement = this.transform.GetChild(1).GetComponent<CardDeckUIElement>();
        BattleFieldUIManager = this.transform.GetChild(2).GetComponent<BattleFieldUIManager>();
        CardConfirmationPanel.OnPlayerCardConfimated += CardConfirmationPanel_OnCardConfimated;
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
        Card cardData = Cards[index];
        BattleFieldCardTypeCheck(cardData, index);
        Cards.RemoveAt(index);
    }

    private void BattleFieldCardTypeCheck(Card data, int index)
    {
        switch (data.CardType)
        {
            case CardType.Weapon:
                break;
            case CardType.Minion:
                BattleFieldUIManager.PutBattleField(Cards[index]);
                break;
            case CardType.Special:
                break;
            case CardType.Neutral:
                BattleFieldUIManager.PutBattleField(Cards[index]);
                break;
        }
    }

    #endregion // Events
}
