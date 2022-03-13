using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject healthSlotPrefab;

    private int currentHealth = 0;
    private int maxHealth = 0;

    private CharacterHealth health;

    private List<HealthSlot> healthSlots;
    private SkullSlot skullSlot;

    void OnEnable()
    {
        CharacterHealth.onDamage += OnDamage;
        CharacterHealth.onHeal += OnHeal;
        CharacterHealth.onMaxHealthIncrease += OnMaxHealthIncrease;
        CharacterHealth.onDeath += OnDeath;
    }

    void OnDisable()
    {
        CharacterHealth.onDamage -= OnDamage;
        CharacterHealth.onHeal -= OnHeal;
        CharacterHealth.onMaxHealthIncrease -= OnMaxHealthIncrease;
        CharacterHealth.onDeath -= OnDeath;
    }

    public void OnDamage(int amount) 
    {
        int oldHealth = currentHealth;
        for (int i = 1; i <= amount; i++) 
        {
            if (healthSlots.Count > oldHealth - i)
            {
                healthSlots[oldHealth - i].OnDamage();
            }
        }

        UpdateHealth();
    }

    private void OnHeal(int amount) 
    {
        int oldHealth = currentHealth;
        for (int i = 0; i < amount; i++) 
        {
            if (healthSlots.Count > oldHealth + i)
            {
                healthSlots[oldHealth + i].OnHeal();
            }
        }

        UpdateHealth();
    }

    private void OnMaxHealthIncrease(int amount, bool heal)
    {
        int oldHealth = currentHealth;
        int oldMaxHealth = maxHealth;
        bool setNewSlotFull = false;
        if (oldHealth == oldMaxHealth && heal)
        {
            setNewSlotFull = true;
        }
        for (int i = 0; i < amount; i++)
        {
            AddSlot(setNewSlotFull);
        }

        if (heal)
        {
            OnHeal(amount);
        } 
        
        UpdateHealth();
    }

    private void OnDeath() 
    {
    }

    private void AddSlot(bool isSlotFull)
    {
        GameObject slotObj = Instantiate(healthSlotPrefab, new Vector3(0, 0, 0), Quaternion.identity, transform);
        Vector2 newSlotPos = healthSlots[healthSlots.Count - 1].GetComponent<RectTransform>().anchoredPosition;
        newSlotPos.x += healthSlots[healthSlots.Count - 1].GetComponent<RectTransform>().sizeDelta.x;
        slotObj.GetComponent<RectTransform>().anchoredPosition = newSlotPos;
        HealthSlot slot = slotObj.GetComponent<HealthSlot>();
        slot.SetState(isSlotFull);
        healthSlots.Add(slot);
    }

    private void UpdateHealth() 
    {
        currentHealth = (int) health.CurrentHealth;
        maxHealth = (int) health.MaxHealth;
        skullSlot.UpdateHealth(currentHealth, maxHealth);
    }

    void Awake()
    {
        healthSlots = GetComponentsInChildren<HealthSlot>().ToList();
        skullSlot = GetComponentInChildren<SkullSlot>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindWithTag("Player").GetComponent<CharacterHealth>();
        UpdateHealth();
        int extraSlotsRequired = maxHealth - healthSlots.Count;
        for (int i = 0; i < extraSlotsRequired; i++)
        {
            AddSlot(false);
        }
        for (int i = 0; i < healthSlots.Count; i++) 
        {
            if (healthSlots[i] != skullSlot) 
            {
                healthSlots[i].SetState(currentHealth - 1 >= i ? true : false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
