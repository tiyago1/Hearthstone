using UnityEngine;
using System.Collections;

public class MinionAnimationStateController : MonoBehaviour
{
    #region Constants

    public const string GROW = "Grow";
    public const string SHRINK = "Shrink";
    public const string NORMAL = "Normal";

    #endregion // Constants

    #region Fields

    private Animator mAnimator;
    public bool IsGrowing { get; set; }
    public bool IsShrink { get; set; }

	#endregion //Fields
	
	#region Unity Methods

	private void Update () 
	{
	
	}
	
	#endregion //Unity Methods
	
	#region Public Methods
	
	public void Initialize()
	{
        mAnimator = this.GetComponent<Animator>();
	}

    public void Grow()
    {
        IsShrink = false;
        IsGrowing = true;
        mAnimator.SetTrigger(GROW);
    }

    public void Shrink()
    {
        IsGrowing = false;
        IsShrink = true;
        mAnimator.SetTrigger(SHRINK);
    }

	#endregion // Public Methods
	
	#region Private Methods
	
	private void SamplePrivateMethods()
	{
	
	}	
	
	#endregion //Private Methods
}
