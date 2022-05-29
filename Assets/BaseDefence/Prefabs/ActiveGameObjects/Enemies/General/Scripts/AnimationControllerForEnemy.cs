using System.Collections.Generic;
using UnityEngine;
using System;

public class AnimationControllerForEnemy
{
    public delegate void DisposableAnimationEnd();
    public event DisposableAnimationEnd DisposableAnimationEndEvent;

    private readonly Animator _animator;

    public int currentPriority { private get; set; }
    protected List<List<string>> _animationsWithPriority;
    private const string IS_ATTACKING = "isAttacking";

    public AnimationControllerForEnemy(Animator animator)
    {
        _animator = animator;
        _animationsWithPriority = new List<List<string>>
        {
            new List<string> { AnimationNamesForEnemy.WALK, AnimationNamesForEnemy.IDLE },
            new List<string> { AnimationNamesForEnemy.HURT, AnimationNamesForEnemy.ATTACK },
            new List<string> { AnimationNamesForEnemy.DEATH }
        };
    }


    public void ChangeAnimation(string animationName)
    {
        int priority = GetPriority(animationName);
        if (priority < currentPriority) return;

        currentPriority = priority;
        _animator.Play(animationName);
    }

    public void AE_DisposableAnimationEnd()
    {
        DisposableAnimationEndEvent?.Invoke();
    }

    public void SetIsAttacking(bool status) => _animator.SetBool(IS_ATTACKING, status);


    public bool GetIsAttacking() => _animator.GetBool(IS_ATTACKING);

    private int GetPriority(string animationName)
    {
        for (int i = 0; i < _animationsWithPriority.Count; i++)
            foreach (string name in _animationsWithPriority[i])
                if (name == animationName) return i;
        throw new Exception("Такой анимации нет");
    }
}
