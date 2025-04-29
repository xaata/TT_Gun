using UnityEngine;

public class BouncingProjectile : ProjectileBase
{
    [SerializeField] private float _speed = 12f;
    private int _maxBounceCount = 3;
    private int _currentBounceCount = 0;
    private Camera _camera;
    private Vector2 _min;
    private Vector2 _max;

    void Start()
    {
        _camera = Camera.main;
        var bl = _camera.ViewportToWorldPoint(Vector3.zero);
        var tr = _camera.ViewportToWorldPoint(Vector3.one);
        _min = bl; _max = tr;
    }

    void Update()
    {
        transform.position += (Vector3)(_direction * _speed * Time.deltaTime);

        Vector2 pos = transform.position;
        if (pos.x < _min.x || pos.x > _max.x)
        {
            _direction = new Vector2(-_direction.x, _direction.y);
            pos.x = Mathf.Clamp(pos.x, _min.x, _max.x);
            if(_currentBounceCount < _maxBounceCount) 
                _currentBounceCount++;
            else
                Destroy(gameObject);
        }
        if (pos.y < _min.y || pos.y > _max.y)
        {
            _direction = new Vector2(_direction.x, -_direction.y);
            pos.y = Mathf.Clamp(pos.y, _min.y, _max.y);
            if (_currentBounceCount < _maxBounceCount)
                _currentBounceCount++;
            else
                Destroy(gameObject);
        }
        transform.position = pos;
        transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg, Vector3.forward);
    }    
}
