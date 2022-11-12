using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerIK : MonoBehaviour
{
    [SerializeField]
    bool _enableIK = true;

    [SerializeField]
    Transform _lookAt;

    [SerializeField]
    Transform _reachFor;

    Animator _animator;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void OnAnimatorIK()
    {
        if (!_animator)
            return;

        if (_enableIK)
        {
            if (_lookAt)
            {
                _animator.SetLookAtPosition(_lookAt.position);
                _animator.SetLookAtWeight(1f);
            }

            if (_reachFor)
            {
                _animator.SetIKPosition(AvatarIKGoal.RightHand, _reachFor.position);
                _animator.SetIKRotation(AvatarIKGoal.RightHand, _reachFor.rotation);
                _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
                _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);

                _animator.SetIKPosition(AvatarIKGoal.LeftHand, _reachFor.position);
                _animator.SetIKRotation(AvatarIKGoal.LeftHand, _reachFor.rotation);
                _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
                _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
            }

        }
        else
        {
            _animator.SetLookAtWeight(0);
            _animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0f);
            _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 0f);
            _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0f);
            _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0f);
        }
    }
}
