using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MagicClass : PlayerClass
{
	#region Fields

    public List<Card> Cards = new List<Card>();
    public CardDeckUIElement CardDeckUIElement;

	#endregion //Fields

    #region Unity Method

    public void Start()
    {
        Initialize();
    }

    #endregion // Unity Method

    #region Public Method

    public override void SetCard(Card card)
    {
        Cards.Add(card);
        CardDeckUIElement.InsantiateCard(card);
    }

    #endregion // Public Method 

    #region Private Method

    private void Initialize()
    {
        CardDeckUIElement = this.transform.GetChild(1).GetComponent<CardDeckUIElement>();
    }

    #endregion // Private Method

    #region Abilities

    public void SpellAbility()
    {

    }

    #endregion // Abilities
}
