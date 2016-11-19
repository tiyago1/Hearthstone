using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardDeckUIElement : GuiPanel 
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

    public void InsantiateCard(Card data, bool isCardBackVisible = false)
    {
        mCounter++;
        Debug.Log(mCounter);
        GameObject card = Instantiate(CardPrefab, this.transform.position, Quaternion.identity) as GameObject;
        card.transform.SetParent(this.transform, false);    
        CardUIElement element = card.GetComponent<CardUIElement>();
        element.Initialize(mIngameUIManager);
        element.Index = mCounter-1;
        Debug.Log("isCardBackVisible  :" + isCardBackVisible);
        element.IsCardBackVisible = isCardBackVisible;
        Debug.Log("element.IsCardBackVisible : " + element.IsCardBackVisible);
        element.SetCardProperties(data, element.Index);
        element.AddCardButtonListener(element.Index);
        Cards.Add(element);
    }

    public void RemoveAtCardDeck(int index)
    {
        Destroy(Cards[index].gameObject);
        Cards.RemoveAt(index);

        for (int i = 0; i < Cards.Count; i++)
            Cards[i].AddCardButtonListener(i);
    }

	#endregion // Public Methods
}
