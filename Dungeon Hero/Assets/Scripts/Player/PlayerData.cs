using UnityEngine;
using System.Collections.Generic;

class PlayerData{
    public Vector2 position;
    public int health;
    public int maxHealth;
    public int coin;
    public int maxArmor;
    public int currentGun;
    public List<string> availableGun = new List<string>();
    public int savePoint;
    public int level = 1;

    public PlayerData(Vector2 position, PlayerController data, int savePoint, int level){
        this.position = position;
        this.health = data.CurrentHealth;
        this.maxHealth = data.MaxHealth;
        this.coin = data.Coin;
        this.currentGun = data.CurrentGun;
        this.maxArmor = data.MaxArmor;
        foreach(Gun gun in data.availableGun) {
            this.availableGun.Add(gun.weaponName);
        }
        this.savePoint = savePoint;
        this.level = level;
    }

}