using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardDeckUIElement : HearthBehaviour 
{
	#region Fields

    public GameObject CardPrefab;
    public List<CardUIElement> Cards;
    private int mCounter;

	#endregion //Fields
	
	#region Public Methods

    public void Initialize(InGameUIManager ingameUIManager)
    {
        base.Initialize(ingameUIManager);
        mCounter = 0;
    }

    public void InsantiateCard(Card data, bool isPlayerAgent = false)
    {
        GameObject card = Instantiate(CardPrefab, this.transform.position, Quaternion.identity) as GameObject;
        card.transform.SetParent(this.transform, false);    
        CardUIElement element = card.GetComponent<CardUIElement>();
        element.Initialize(mIngameUIManager);
        element.Index = mCounter;
        element.IsCardBackVisible = isPlayerAgent;
        element.SetCardProperties(data, element.Index);

        if (!isPlayerAgent)
            element.AddCardButtonListener(element.Index);
        else
            element.AddAgentCardButtonListener(element.Index);

        Cards.Add(element);
        mCounter++;
    }

    private void UpdateCardIndex()
    {
        mCounter = 0;
        Cards.ForEach(it => it.Index = mCounter++);
    }

    public void RemoveAtCardDeck(int index)
    {
        Destroy(Cards[index].gameObject);
        Cards.RemoveAt(index);
        UpdateCardIndex();

        for (int i = 0; i < Cards.Count; i++)
            Cards[i].AddCardButtonListener(i);
    }

	#endregion // Public Methods
}
