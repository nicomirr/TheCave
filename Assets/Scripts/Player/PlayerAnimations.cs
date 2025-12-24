using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private readonly int DEATH_HASH = Animator.StringToHash("death");

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable()
    {
        GameEvents.OnPlayerDeath += FireDeathAnimation;
    }

    private void OnDisable()
    {
        GameEvents.OnPlayerDeath -= FireDeathAnimation;
    }

    private void FireDeathAnimation()
    {
        _animator.SetTrigger(DEATH_HASH);
    }
}
