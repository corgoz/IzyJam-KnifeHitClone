using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private ParticleSystem _coinBlastFX;
    private int _activeCoinIndex;
    private int _value;

    private void Awake()
    {
        _activeCoinIndex = Random.Range(0, transform.childCount - 1);
        _value = _activeCoinIndex + 1;
        transform.GetChild(_activeCoinIndex).gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Knife"))
        {
            GameManager.Singleton.GetCoin(_value);
            transform.GetChild(_activeCoinIndex).gameObject.SetActive(false);
            _coinBlastFX.Play();
            Destroy(gameObject, 2.0f);
        }
    }
}