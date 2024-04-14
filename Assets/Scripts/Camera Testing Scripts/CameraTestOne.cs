using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTestOne : MonoBehaviour
{
    [SerializeField] private Transform _playerOneTransform;
    [SerializeField] private Transform _playerTwoTransform;

    [SerializeField] private float _yOffSet;
    [SerializeField] private float _minDistance;

    private float _xMin, _xMax, _yMin, _yMax, _zMin, _zMax;

    private void LateUpdate()
    {
        _xMin = _xMax = _playerOneTransform.position.x;
        _yMin = _yMax = _playerOneTransform.position.y;
        _zMin = _zMax = _playerOneTransform.position.z;

        if(_playerTwoTransform.position.x < _xMin)
        {
            _xMin = _playerTwoTransform.position.x;
        }

        if(_playerTwoTransform.position.x > _xMax)
        {
            _xMax = _playerTwoTransform.position.x;
        }

        if (_playerTwoTransform.position.y < _yMin)
        {
            _yMin = _playerTwoTransform.position.y;
        }

        if (_playerTwoTransform.position.y > _yMax)
        {
            _yMax = _playerTwoTransform.position.y;
        }

        if (_playerTwoTransform.position.z < _zMin)
        {
            _zMin = _playerTwoTransform.position.z;
        }

        if (_playerTwoTransform.position.z > _zMax)
        {
            _zMax = _playerTwoTransform.position.z;
        }

        float xMiddle = (_xMin + _xMax) / 2;
        float yMiddle = (_yMin + _yMax) / 2;
        float zMiddle = (_zMin + _zMax) / 2;

        float distanceX = _xMax - _xMin;
        float distanceZ = _zMax - _zMin;

        if(distanceX < _minDistance)
        {
            distanceX = _minDistance;
        }

        if (distanceZ < _minDistance)
        {
            distanceZ = _minDistance;
        }

        float distance = distanceX + distanceZ;

        transform.position = new Vector3(xMiddle, yMiddle + _yOffSet, zMiddle - distance);
    }

}
