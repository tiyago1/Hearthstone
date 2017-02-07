using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AiMagicClass : AiClass
{
    #region Fields

    #endregion //Fields

    #region Unity Methods

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CardDeckUIElement.Cards.Count > 0)
            {
                SelectCard();
            }
        }
    }

    #endregion // Unity Methods

    #region Public Method

    public override void Initialize()
    {
        CardDeckUIElement = this.transform.GetChild(1).GetComponent<CardDeckUIElement>();
        BattleFieldUIManager = this.transform.GetChild(2).GetComponent<BattleFieldUI>();
        CardConfirmationPanel.OnAgentCardConfirmated += CardConfirmationPanel_OnAgentCardConfirmated;
        base.Initialize();
    }

    public override void SetCard(Card card)
    {
        Cards.Add(card);
        CardDeckUIElement.InsantiateCard(card,true);
    }

    public int SelectedCardIndex()
    {
        List<CardUIElement> deckCards = CardDeckUIElement.Cards;
        return Random.Range(0,deckCards.Count);
    }

    public void SelectCard()
    {
        int selectedCardIndex = SelectedCardIndex();

        CardUIElement selectedCard = CardDeckUIElement.Cards[selectedCardIndex];
        Card cardData = selectedCard.CardData;

        switch (cardData.CardType)
        {
            case CardGameTypes.CardType.Weapon: Debug.Log("Weapon");
                return;
                //SelectCard();
                break;
            case CardGameTypes.CardType.Minion: Debug.Log("minion");
                 CardConfirmationPanel.SetCardData(cardData, selectedCard.Index);
                 CardConfirmationPanel.OnAgentCardConfirmatedClicked();
                break;
            case CardGameTypes.CardType.Special: Debug.Log("Special");
                return;//SelectCard();
                break;
            case CardGameTypes.CardType.Neutral: Debug.Log("Neutral");
                 CardConfirmationPanel.SetCardData(cardData, selectedCard.Index);
                 CardConfirmationPanel.OnAgentCardConfirmatedClicked();
                break;
        }
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

    private void CardConfirmationPanel_OnAgentCardConfirmated(int index)
    {
        BattleFieldUIManager.PutTheBattleField(Cards[index], true);
        Cards.RemoveAt(index);
    }

    #endregion // Events
}
