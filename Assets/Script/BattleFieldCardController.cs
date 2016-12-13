using UnityEngine;
using System.Collections;
using System;

public class BattleFieldCardController : MonoBehaviour 
{
	#region Fields

    public event Action<Card> SelectedMinion;
    private CardUIElement mCardUIElement;
    private Card mCardData;

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

	}

    //public void OnAnimationClicked()
    //{
    //    Animator.SetTrigger("Grow");
    //}

	#endregion // Public Methods
	
	#region Private Methods
	
	private void SamplePrivateMethods()
	{
	
	}	
	
	#endregion //Private Methods
}
