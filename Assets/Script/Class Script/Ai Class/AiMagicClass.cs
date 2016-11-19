using UnityEngine;
using System.Collections;

public class AiMagicClass : AiClass
{
    #region Fields

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
        Debug.Log("AiMagicClass.SetCard");
        Cards.Add(card);
        CardDeckUIElement.InsantiateCard(card,true);
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
        Debug.Log("MagicClass.CardConfirmationPanel_OnCardConfimated index :" + index);
        Cards.RemoveAt(index);
    }

    #endregion // Events
}
