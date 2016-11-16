using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumberUIElement : MonoBehaviour 
{
	#region Fields

    public Image Image;
    public Sprite[] Numbers; // 1-13

	#endregion //Fields
	
	#region Unity Methods
	
	private void Start () 
	{
		Initalize();
	}
	
	#endregion //Unity Methods
	
	#region Public Methods
	
	public void Initalize()
	{

	}

    public void SetNumberImage(int number)
    {
        if (number != 0)
            Image.sprite = Numbers[number - 1];
        else
            Image.sprite = Numbers[number];
    }

	#endregion // Public Methods
	
	#region Private Methods
	
	private void SamplePrivateMethods()
	{
	
	}	
	
	#endregion //Private Methods
}
