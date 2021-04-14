using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterIKSystem : MonoBehaviour
{
    [Header("Variables")]
    public float duration;
    public Animator animator;

    [Header("IK Bow Target Transforms")]
    public Transform rightHandBowTransform;
    public Transform leftHandBowTransform;

    [Header("Bow Position & Rotation")]
    [Range(0,1)]
    public float rightBowPosition;
    [Range(0, 1)]
    public float rightBowRotation;
    [Range(0, 1)]
    public float leftBowPosition;
    [Range(0, 1)]
    public float leftBowRotation;
    
    // ****************************************

    [Header("IK Balance Target Transforms")]
    public Transform rightHandBalanceTransform;
    public Transform leftHandBalanceTransform;

    [Header("Balance Position & Rotation")]
    [Range(0, 1)]
    public float rightBalancePosition;
    [Range(0, 1)]
    public float rightBalanceRotation;
    [Range(0, 1)]
    public float leftBalancePosition;
    [Range(0, 1)]
    public float leftBalanceRotation;

    // ****************************************

    private void Start()
	{
        animator = GetComponent<Animator>();
	}
    
	void OnAnimatorIK(int layerIndex)
    {
        // Right BOW Hand
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftBowPosition);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftBowRotation);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandBowTransform.position);
        animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandBowTransform.rotation);

        //Left BOW Hand
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, rightBowPosition);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, rightBowRotation);
        animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandBowTransform.position);
        animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandBowTransform.rotation);

        // Right Balance Hand
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftBalancePosition);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftBalanceRotation);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandBalanceTransform.position);
        animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandBalanceTransform.rotation);

        //Left Balance Hand
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, rightBalancePosition);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, rightBalanceRotation);
        animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandBalanceTransform.position);
        animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandBalanceTransform.rotation);
    }
    
    public void IKBowWeightIncrease()
	{
        DOTween.To(x => rightBowPosition = x, 0f, 1f, duration);
        DOTween.To(x => rightBowRotation = x, 0f, 1f, duration);
        DOTween.To(x => leftBowPosition = x, 0f, 1f, duration);
        DOTween.To(x => leftBowRotation = x, 0f, 1f, duration);
    }
	public void IKBowWeightDecrease()
    {
        
        DOTween.To(x => rightBowPosition = x, rightBowPosition, 0f, duration);
        DOTween.To(x => rightBowRotation = x, rightBowRotation, 0f, duration);
        DOTween.To(x => leftBowPosition = x, leftBowPosition, 0f, duration);
        DOTween.To(x => leftBowRotation = x, leftBowRotation, 0f, duration);
    }

    public void IKBalanceWeightIncrease()
	{
        DOTween.To(x => rightBalancePosition = x, rightBalancePosition, .5f, duration);
        DOTween.To(x => rightBalanceRotation = x, rightBalanceRotation, .5f, duration);
        DOTween.To(x => leftBalancePosition = x, leftBalancePosition, .5f, duration);
        DOTween.To(x => leftBalanceRotation = x, leftBalanceRotation, .5f, duration);
    }

    public void IKBalanceWeightDecrease()
    {
        DOTween.To(x => rightBalancePosition = x, rightBalancePosition, 0f, duration);
        DOTween.To(x => rightBalanceRotation = x, rightBalanceRotation, 0f, duration);
        DOTween.To(x => leftBalancePosition = x, leftBalancePosition, 0f, duration);
        DOTween.To(x => leftBalanceRotation = x, leftBalanceRotation, 0f, duration);
    }
}
