using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CardDeck : MonoBehaviour 
{
	#region Fields

    public List<Card> MagicCards = new List<Card>(); // public Dictionary<string, List<Card>> MagicCards = new Dictionary<string, List<Card>>();

    public List<Card> MagicWeapon  = new List<Card>();
    public List<Card> MagicMinion  = new List<Card>();
    public List<Card> MagicSpecial = new List<Card>();

    public List<Card> HunterCards = new List<Card>();

    public List<Card> HunterWeapon = new List<Card>();
    public List<Card> HunterMinion = new List<Card>();
    public List<Card> HunterSpecial = new List<Card>();

    public List<Card> WarriorCards = new List<Card>();
                      
    public List<Card> WarriorWeapon = new List<Card>();
    public List<Card> WarriorMinion = new List<Card>();
    public List<Card> WarriorSpecial = new List<Card>();

	#endregion //Fields
	
	#region Unity Methods
	
	private void Awake () 
	{
		Initalize();
	}
	
	private void Update () 
	{
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
        //    Card crd = new Card();
        //    crd.Name = "ALİ";
        //    Cards.Add("Cv", crd);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
        //    Debug.Log(Cards["Cv"].Name);
        }
	}
	
	#endregion //Unity Methods
	
	#region Public Methods
	
	public void Initalize()
	{
        MagicWeapon.ForEach(it => MagicCards.Add(it));
        MagicMinion.ForEach(it => MagicCards.Add(it));
        MagicSpecial.ForEach(it => MagicCards.Add(it));

        HunterWeapon.ForEach(it => HunterCards.Add(it));
        HunterMinion.ForEach(it => HunterCards.Add(it));
        HunterSpecial.ForEach(it => HunterCards.Add(it));

        WarriorWeapon.ForEach(it => WarriorCards.Add(it));
        WarriorMinion.ForEach(it => WarriorCards.Add(it));
        WarriorSpecial.ForEach(it => WarriorCards.Add(it));
	}
	
	#endregion // Public Methods

}
