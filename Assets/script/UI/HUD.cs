using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Image prefabImage; 
    public Sprite[] prefabSprites;
    public Text TurretLoader;
    public Image healthBarImage;

    private Hero playerScript;

    void OnEnable()
    {
        Hero.OnTurretLoadChanged += UpdateTurretLoader;
        Hero.OnHealthChanged += UpdateHealthBar;
    }

    void OnDisable()
    {
        Hero.OnTurretLoadChanged -= UpdateTurretLoader;
        Hero.OnHealthChanged -= UpdateHealthBar;
    }
    void Start()
    {
        playerScript = FindObjectOfType<Hero>();
        UpdatePrefabImage();       
    }

    void Update()
    {
        if (Input.GetButtonDown("nextPrefab") || Input.GetButtonDown("prevPrefab"))
        {
            UpdatePrefabImage();
        }
    }

    void UpdatePrefabImage()
    {      
        if (playerScript.currentPrefabIndex >= 0 && playerScript.currentPrefabIndex < prefabSprites.Length)
        {
            prefabImage.sprite = prefabSprites[playerScript.currentPrefabIndex];
        }
    }

    private void UpdateTurretLoader(int newTurretLoad)
    {

        if (TurretLoader != null)
        {
            int TurretLoadValue = playerScript.TurretLoad;
            TurretLoader.text = " X " + TurretLoadValue;
        }
        else
        {
            Debug.LogWarning("La référence à l'objet Text n'est pas définie dans l'éditeur Unity.");
        }
    }

    private void UpdateHealthBar(float newHealth)
    {
        if (healthBarImage != null)
        {
            float fillAmount = newHealth / playerScript.maxHealth;
            healthBarImage.fillAmount = fillAmount;
        }
        else
        {
            Debug.LogWarning("La référence à l'objet Image pour la barre de vie n'est pas définie dans l'éditeur Unity.");
        }
    }
}
