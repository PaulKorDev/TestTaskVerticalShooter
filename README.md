# TestTaskVerticalShooter
# Current situation
Now I trying to fix bug related to the win window not appearing after destroying all enemies. I found the reason, I'm thinking how to solve it
## Content
* [Drafts](#drafts)
* [What patterns used](#What-patterns-used)
* [Where to start?](#where-to-start?)
* [Where were the difficulties?](#where-were-the-difficulties?)
* [Here's what else I'd like to upgrade in the game](#here's-what-else-I'd-like-to-upgrade-in-the-game)
* [How you can to expand my game](#how-you-can-to-expand-my-game)
* [What bugs can be:](#what-bugs-can-be:)
  
## Drafts
### Player
![image](https://github.com/user-attachments/assets/c41cb964-926d-4a3e-b051-592a64258538)
### Enemy
![image](https://github.com/user-attachments/assets/4862d700-0908-413d-a13c-494adeeb05bd)
### Factories
![image](https://github.com/user-attachments/assets/90dc6617-11a3-4126-b64b-02ec00f1899f)
### Enemy spawner
![image](https://github.com/user-attachments/assets/5919ca6b-f78c-477a-a9db-f70f4dc424e4)
### Object pools
![image](https://github.com/user-attachments/assets/cb836162-9ce4-4ae9-9cc2-720721122c20)

For enemy, I also will create object pool 
### EventBus Signals
![image](https://github.com/user-attachments/assets/bc4a2a9b-d309-46a6-b4cc-f2a1e73dee2b)
### Configs
![image](https://github.com/user-attachments/assets/cbd75a67-14cc-47b1-9f7a-132fe2816b30)
# What patterns used
  - Fabric (for bullets and enemies)
  - EntryPoint
  - ServiceLocator
  - StateMachine (for game)
  - ObjectPool (for bullets and enemies)
  - EventBus
  - Separate Logic and View
# Where to start?
Start from GameStateMachineHandler - it's like entry point. I develop with resolution 900x1600,so,on other resolution UI can be deformed. I bad adjust it.
# Where were the difficulties?
  - I spent a lot of time to create high quality architecture and at start I create big EntryPoinit with showing of loading screen and transit between scenes, but for this game it was unnecessarily, so I delete this from my final result.
  - I spen a lot of time to fix bugs
  - Some simple functionality turned out to be not so simple
  - After the little change I had to wait 4 minutes for the Unity load changes.
# Here's what else I'd like to upgrade in the game
I decide to finish the test task, but what else can upgrade:
  - Optimization
  - Background (I import tilemap from AssetStore but forget about it)
  - Rotation of player when shooting
  - Animation of hit for enemies
  - Most better physic of bullets
  - Some refactor code in Shooting folder (Towards the end I started making dirty code due to fatigue)
# How you can to expand my game
  - Add new enemies - I create very flexible architecture for this
  - Add new bullets - but need make class Bullet - abstract and some refactor code
  - Add new AttackModes for different behaviour
  - etc) 
# What bugs can be:
  - Sometimes, when you kill all enemies, you won't see the victory window => perhaps problem in Events
  - If play with horizontal resolution, UI will broke => need adjust anchors
