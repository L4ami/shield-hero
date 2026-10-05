# Shield Hero

![Unity 6](https://img.shields.io/badge/Unity-6000.6-000000?logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/C%23-MonoBehaviour-239120)
![URP 2D](https://img.shields.io/badge/Rendu-URP%202D-4B5563)
![Web](https://img.shields.io/badge/Web-jouable%20en%20ligne-2EA44F)

Jeu d'arcade 2D en vue du dessus, réalisé avec **Unity 6** et **C#**.

Un chevalier est encerclé par quatre gobelins archers dans une salle de donjon. Les flèches enflammées arrivent du haut, du bas, de la gauche ou de la droite : il faut tourner son bouclier du bon côté, au bon moment, pour les parer.

**Jouer en ligne : https://l4ami.github.io/shield-hero/** (clavier requis)<br>
**Documentation technique du code : [DOCUMENTATION.md](DOCUMENTATION.md)**

## Règles du jeu

1. Un gobelin choisi au hasard bande son arc : c'est le signal, il reste environ une seconde pour réagir.
2. Sa flèche part en ligne droite vers le chevalier, au centre de la salle.
3. Bouclier tourné vers la flèche : **parade, +100 points**. Sinon : **un cœur perdu**.
4. Le chevalier a 3 cœurs. À 0, la partie s'arrête.

## Commandes

| Action | Touches |
|---|---|
| Bouclier vers le haut | `W` ou `↑` |
| Bouclier vers le bas | `S` ou `↓` |
| Bouclier vers la gauche | `A` ou `←` |
| Bouclier vers la droite | `D` ou `→` |

Clavier AZERTY : utilisez les flèches directionnelles.

## Points techniques

- **Lanceur de flèches** : une seule flèche à la fois, pause aléatoire entre deux tirs, tireur choisi au hasard, animation de charge synchronisée avec le départ de la flèche.
- **Déplacement indépendant des performances** : les flèches avancent en unités par seconde grâce à `Time.deltaTime`, quelle que soit la fluidité de l'ordinateur.
- **Impact et parade** : zones de contact sur les 4 côtés du héros, comparaison entre le sens de la flèche et l'orientation du bouclier.
- **Animations 2D pilotées par le code** : planches de sprites découpées dans Unity, clips « attente » et « charge de l'arc » en 4 directions, lancés avec `Animator.Play`.
- **Interface** : cœurs (vert = restant, noir = perdu) et score en temps réel avec TextMesh Pro.
- **Map** : Tilemaps (sol, murs), décors et éclairage 2D (URP) pour l'ambiance de donjon.
- **Déploiement** : build WebGL publiée sur GitHub Pages, jouable sans rien installer.

## Ma contribution

Projet réalisé en binôme dans le cadre de ma formation au Geneva Institute of Technology (GIT), en septembre et octobre 2026. Ma part :

- Système de tir : `LanceurFleches.cs` et `Stats.cs`
- Déplacement des flèches et détection d'impact : `trajectoire.cs`
- Dégâts (un cœur perdu par flèche) et fin de partie à 0 cœur
- Animations des gobelins (attente + charge de l'arc, 4 directions) et du héros (attente, 4 directions)
- Map du donjon : tilemaps, décors et lumières 2D
- Publication : documentation, build Web et mise en ligne sur GitHub

## Stack technique

| Domaine | Outil |
|---|---|
| Moteur | Unity 6 (6000.6.3f1) |
| Langage | C# |
| Rendu | Universal Render Pipeline 2D, lumières 2D |
| Outils 2D | Sprite Editor, Tilemap, Animator |
| Interface | TextMesh Pro |
| Versionnage | Unity Version Control (travail en binôme), Git et GitHub (publication) |
| Plateforme | Web (WebGL), hébergée sur GitHub Pages |

## Structure du dépôt

```text
shield-hero/
├── Assets/
│   ├── Scenes/Dungeon.unity   ← la scène du jeu
│   ├── script/                ← tout le code C# (expliqué dans DOCUMENTATION.md)
│   ├── animation/             ← clips et Animator Controllers
│   ├── import/                ← planches de sprites (héros, gobelins, flèche)
│   └── Tuiles/                ← tuiles et palette de la map
├── Packages/                  ← paquets Unity utilisés
├── ProjectSettings/           ← réglages du projet
├── docs/                      ← version jouable (build WebGL servie par GitHub Pages)
├── media/                     ← captures de ce README
└── DOCUMENTATION.md           ← documentation technique du code
```

## Ouvrir le projet dans Unity

Les décors viennent d'un pack gratuit dont la licence interdit la redistribution : les images ne sont pas dans ce dépôt, seuls leurs réglages (`.meta`) y sont. Pour ouvrir le projet complet :

1. Installer **Unity 6000.6.3f1** avec Unity Hub.
2. Cloner le dépôt :
   ```bash
   git clone https://github.com/L4ami/shield-hero.git
   ```
3. Télécharger gratuitement [Pixel Art Top Down - Basic](https://cainos.itch.io/pixel-art-top-down-basic) (Cainos), puis copier ces 3 fichiers du dossier `Texture/` du pack vers le dossier `Assets/` du projet :
   `TX Props.png`, `TX Tileset Stone Ground.png`, `TX Tileset Wall.png`.
   À faire **avant** la première ouverture : sans les images, Unity supprime leurs `.meta` et la map perd ses tuiles.
4. Unity Hub → **Add** → **Add project from disk** → choisir le dossier `shield-hero`.
5. Ouvrir `Assets/Scenes/Dungeon.unity` et lancer **Play**.

Pour simplement jouer, pas besoin de Unity : [version en ligne](https://l4ami.github.io/shield-hero/).

## Pistes d'évolution

- Écran de fin de partie avec un bouton « Rejouer »
- Difficulté progressive (flèches plus rapides, pauses plus courtes)
- Cinématique de fin révélant le boss final (prévue dans le concept initial)
- Détection d'impact par colliders 2D plutôt que par coordonnées fixes

## Crédits et licence

- Décors (sol, murs, objets) : [Pixel Art Top Down - Basic](https://cainos.itch.io/pixel-art-top-down-basic) par **Cainos**, non inclus dans le dépôt (usage libre dans un jeu, redistribution interdite).
- Sprites du héros, des gobelins et des flèches : réalisés pour le projet.
- Moteur et TextMesh Pro : Unity Technologies.

Projet scolaire : code et sprites originaux © 2026 leurs auteurs, tous droits réservés. Les assets tiers restent soumis à leur propre licence.
