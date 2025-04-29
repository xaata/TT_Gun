using UnityEngine;

public interface IWeapon
{
    public float MinAngle { get; }
    public float MaxAngle { get; }
    public void OnPointerDown(Vector2 touchPosition);
    public void OnPointerUp(Vector2 touchPosition);
}
