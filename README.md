# Tossed Away
Summoned by his master Necromancer, our skeleton friend must venture below, into unknown crypts for... A cookbook?!?

# Mechanics
- Health is tied to your ranged attacks
- Pillars block the way in each map, use bones to activate them
- Enemies drop bones when defeated, and bones piles restore a health everyone once and awhile

# How To
## How to add a projectile
1. Create a GameObject and give it the name of the Projectile
1. Attach the `Projectile` and `ReturnToObjectPool` scripts to the GameObject
1. (Optional) Configure the projectiles values
1. Save the prefab

## How to add a ranged weapon
1. Create a script that inherits from the Weapon class
1. Create a GameObject named after whatever weapon you're creating
1. Attach the above weapon and the `ObjectPooler` scripts to the GameObject
1. (Optional) Configure the weapon values
1. Add the references to the Character weapon holder and projectile prefab.
1. Save the prefab

