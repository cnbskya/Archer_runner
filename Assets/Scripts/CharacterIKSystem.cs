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
        /*
        DOTween.To(x => rightHandPositionWeight = x, 1f, 0f, duration);
        DOTween.To(x => rightHandRotationWeight = x, 1f, 0f, duration);
        DOTween.To(x => leftHandPositionWeight = x, 1f, 0f, duration);
        DOTween.To(x => leftHandRotationWeight = x, 1f, 0f, duration);
        */
        rightBowPosition = 0;
        rightBowRotation = 0;
        leftBowPosition = 0;
        leftBowRotation = 0;
    }

    public void IKBalanceWeightIncrease()
	{
        DOTween.To(x => rightBalancePosition = x, 0f, .5f, duration);
        DOTween.To(x => rightBalanceRotation = x, 0f, .5f, duration);
        DOTween.To(x => leftBalancePosition = x, 0f, .5f, duration);
        DOTween.To(x => leftBalanceRotation = x, 0f, .5f, duration);
    }

    public void IKBalanceWeightDecrease()
    {
        DOTween.To(x => rightBalancePosition = x, .5f, 0f, duration - 0.5f);
        DOTween.To(x => rightBalanceRotation = x, .5f, 0f, duration - 0.5f);
        DOTween.To(x => leftBalancePosition = x, .5f, 0f, duration - 0.5f);
        DOTween.To(x => leftBalanceRotation = x, .5f, 0f, duration- 0.5f);
    }
}
