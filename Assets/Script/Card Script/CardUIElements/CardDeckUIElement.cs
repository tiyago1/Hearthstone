using UnityEngine;
using System.Collections;

public class CardDeckUIElement : GuiPanel 
{
	#region Fields

    public GameObject CardPrefab;

	#endregion //Fields
	
	#region Public Methods

    public void InsantiateCard(Card data)
    {
        GameObject card = Instantiate(CardPrefab, this.transform.position, Quaternion.identity) as GameObject;
        card.transform.SetParent(this.transform, false);
        CardUIElement element = card.GetComponent<CardUIElement>();
        element.Initialize(mIngameUIManager);
        element.SetCardProperties(data);
    }

	#endregion // Public Methods
}
