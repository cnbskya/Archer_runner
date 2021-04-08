using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterIKSystem : MonoBehaviour
{
    public Animator animator; 
    [Range(0,1)]
    public float rightHandPositionWeight;
    [Range(0, 1)]
    public float rightHandRotationWeight;
    [Range(0, 1)]
    public float leftHandPositionWeight;
    [Range(0, 1)]
    public float leftHandRotationWeight;
    public float duration;
    [Header("IK Transforms")]
    public Transform rightHandTransform;
    public Transform leftHandTransform;

    private void Start()
	{
        animator = GetComponent<Animator>();
	}
    
	void OnAnimatorIK(int layerIndex)
    {
        // Right Hand
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandPositionWeight);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandRotationWeight);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandTransform.position);
        animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandTransform.rotation);

        //Left Hand
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, rightHandPositionWeight);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, rightHandRotationWeight);
        animator.SetIKPosition(AvatarIKGoal.RightHand, rightHandTransform.position);
        animator.SetIKRotation(AvatarIKGoal.RightHand, rightHandTransform.rotation);
    }

    
    public void IKWeightIncrease()
	{
        DOTween.To(x => rightHandPositionWeight = x, 0f, 1f, duration);
        DOTween.To(x => rightHandRotationWeight = x, 0f, 1f, duration);
        DOTween.To(x => leftHandPositionWeight = x, 0f, 1f, duration);
        DOTween.To(x => leftHandRotationWeight = x, 0f, 1f, duration);
    }

    public void IKWeightDecrease()
    {
        /*
        DOTween.To(x => rightHandPositionWeight = x, 1f, 0f, duration);
        DOTween.To(x => rightHandRotationWeight = x, 1f, 0f, duration);
        DOTween.To(x => leftHandPositionWeight = x, 1f, 0f, duration);
        DOTween.To(x => leftHandRotationWeight = x, 1f, 0f, duration);
        */
        rightHandPositionWeight = 0;
        rightHandRotationWeight = 0;
        leftHandPositionWeight = 0;
        leftHandRotationWeight = 0;
    }

}
