using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Combat___Health
{
    [RequireComponent(typeof(Health))]
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField] private Health health;
        [SerializeField] private GameObject healthBarParent;
        [SerializeField] private Image healthBarImage;
        [SerializeField, Tooltip("How long in seconds the healthbar shows when damage is taken.")] private float timeToShowHealthBarOnDamageTaken = 1.5f;

        private void Awake()
        {
            health.OnHealthUpdated += HandleHealthUpdated;
        }
        private void OnDestroy()
        {
            health.OnHealthUpdated -= HandleHealthUpdated;
        }

        private void HandleHealthUpdated(int currentHealth, int maxHealth)
        {
            StartCoroutine(ShowHealthBar());
            healthBarImage.fillAmount = (float)currentHealth / (float)maxHealth;
        }

        IEnumerator ShowHealthBar()
        {
            healthBarParent.SetActive(true);
            yield return new WaitForSeconds(timeToShowHealthBarOnDamageTaken);
            healthBarParent.SetActive(false);
        }

        private void OnMouseEnter()
        {
            healthBarParent.SetActive(true);
        }

        private void OnMouseExit()
        {
            healthBarParent.SetActive(false);
        }
    }
}