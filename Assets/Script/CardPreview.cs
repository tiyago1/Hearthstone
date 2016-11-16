using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class CardPreview : MonoBehaviour 
{
	#region Fields

    public List<Text> Texts = new List<Text>();

    private Card Card;

    public CardDeck CardDeck;

	#endregion //Fields
	
	#region Unity Methods
	
	private void Start () 
	{
		Initalize();
	}
	
	private void Update () 
	{
	
	}
	
	#endregion //Unity Methods
	
	#region Public Methods
	
	public void Initalize()
	{
        for (int i = 0; i < this.transform.childCount; i++)
		{
            Texts.Add(this.transform.GetChild(i).GetComponent<Text>());
		}

        Card card = (Card)CardDeck.WarriorMinion.FirstOrDefault(it => it.Name == "Developer");

        Texts[0].text = card.Name;
        Texts[1].text = card.AttackDamage.ToString();
        Texts[2].text = card.HP.ToString();
        Texts[3].text = card.ManaCost.ToString();
        Texts[4].text = card.Owner.ToString();
    }
	
	#endregion // Public Methods
	
	#region Private Methods
	
	private void SamplePrivateMethods()
	{
	
	}	
	
	#endregion //Private Methods
}
