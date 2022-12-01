using UnityEngine;

public class AnimationsHandler : MonoBehaviour
{
    private Animator _animator;
    private Locomotion _locomotion;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _locomotion = GetComponent<Locomotion>();
    }

    private void Update()
    {
        ProcessValueVelocity();
    }

    private void ProcessValueVelocity()
    {
        float time = 5f;
        float temVelocity = Mathf.MoveTowards(_animator.GetFloat("Velocity"), _locomotion.AmountVelocity, time * Time.deltaTime);
        _animator.SetFloat("Velocity", temVelocity);
    }
}
