using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private Transform _allPlacesPoint;
    [SerializeField] private float _velocity;

    private Transform[] _places;
    private int _numberOfPlace;

    private void Start()
    {
        _places = new Transform[_allPlacesPoint.childCount];

        for (int i = 0; i < _allPlacesPoint.childCount; i++)
        {
            _places[i] = _allPlacesPoint.GetChild(i).GetComponent<Transform>();
        }
    }

    private void Update()
    {
        Transform currentPoint = _places[_numberOfPlace];
        transform.position = Vector3.MoveTowards(
            transform.position,
            currentPoint.position,
            _velocity * Time.deltaTime);

        if (transform.position == currentPoint.position)
        {
            NextPlaceTakerLogic();
        }
    }

    private void NextPlaceTakerLogic()
    {
        _numberOfPlace++;

        if (_numberOfPlace == _places.Length)
        {
            _numberOfPlace = 0;
        }

        Vector3 pointPosition = _places[_numberOfPlace].transform.position;
        transform.forward = pointPosition - transform.position;
    }
}