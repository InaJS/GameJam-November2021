using System;
using UnityEngine;
public class Health : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    public event Action OnDeath;
    public event Action<int, int> OnHealthUpdated;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        //Just for testing to make sure that we can actually take damage.
        if (Input.GetKeyDown(KeyCode.B))
        {
            DealDamage(10);
        }
    }

    //Method that we can use to deal damage to the entity.
    public void DealDamage(int damageAmount)
    {
        if (currentHealth == 0) return;
        currentHealth = Mathf.Max(currentHealth - damageAmount, 0); //Way to make sure health never becomes negative. 
        OnHealthUpdated?.Invoke(currentHealth, maxHealth);

        //If the entity dies, we raise an OnDeath event.
        if (currentHealth != 0) return;
        OnDeath?.Invoke(); 
    }

}
