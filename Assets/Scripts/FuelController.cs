using UnityEngine;
using UnityEngine.UI;

public class FuelController : MonoBehaviour
{
    public static FuelController instance;

    [SerializeField] private Image _fuelImage;                         // UI fuel bar image
    [SerializeField] private float _fuelDrainSpeed = 1f;  // Speed at which fuel drains
    [SerializeField] private float _maxFuelAmount = 100f;              // Maximum fuel capacity
    [SerializeField] private Gradient gradient;

    private float _currentFuelAmount;                                  // Current amount of fuel left

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        _currentFuelAmount = _maxFuelAmount;
        UpdateUI();
    }

    private void Update()
    {
        DecreaseFuel();

        // Update the UI
        UpdateUI();

        // Optional: Check if fuel has run out
        if (_currentFuelAmount <= 0f)
        {
            GameManager.instance.GameOver();
        }
    }

    private void UpdateUI()
    {
        // Update the fuel bar fill based on current fuel percentage
        _fuelImage.fillAmount = _currentFuelAmount / _maxFuelAmount;

        // Update the fuel bar color based on the gradient
        _fuelImage.color = gradient.Evaluate(_fuelImage.fillAmount);
    }

    private void DecreaseFuel()
    {
        _currentFuelAmount -= Time.deltaTime * _fuelDrainSpeed;

        // Clamp to 0 to avoid negative values
        _currentFuelAmount = Mathf.Clamp(_currentFuelAmount, 0f, _maxFuelAmount);
    }

    public void RefillFuel()
    {
        _currentFuelAmount = _maxFuelAmount;
        UpdateUI();
    }
}
