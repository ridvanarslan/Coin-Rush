using TMPro;
using UnityEngine;

public class Stair : MonoBehaviour
{
    [SerializeField] private int multiplierAmount;
    [SerializeField] private TextMeshPro multiplierAmountText;
    [SerializeField] private bool isLastStair;

    public bool IsLastStair => isLastStair;
    
    void Start()
    {
        multiplierAmountText.text = $"x{multiplierAmount}";
    }
}
