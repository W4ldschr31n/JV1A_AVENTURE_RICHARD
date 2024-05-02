# JV1A_AVENTURE_RICHARD

## THE LAST SEALS ##

Ce jeu est un protoype de zelda-like situé dans un univers d'apocalypse biblique. Le joueur incarne un agneau chargé de retrouver les sceaux de l'apocalypse afin de réinitialiser le monde

## Comment jouer ##

L'exécutable du jeu est disponible dans les releases ou bien ici: https://w4ldschr31n.itch.io/the-last-seals

Les contrôles sont customisables depuis le menu principal, et visibles à tout moment en jeu.

| Action      | Clavier/souris        | Manette (XBox)         |
|-------------|-----------------------|------------------------|
| Déplacement | ZQSD/Touches fléchées | Joystick gauche/ D-PAD |
| Interagir   | E                     | Bouton A               |
| Attaque 1   | U                     | Bouton X               |
| Attaque 2   | I                     | Bouton Y               |
| Attaque 3   | O                     | Bouton B               |
| Inventaire  | Tab                   | Start                  |

## Projet Unity ##
Vous pouvez télécharger le projet et l'ouvrir avec Unity (version 2022.3.21.f1). Pour lancer le jeu, il faut commencer sur la scène "SceneMenu".
Des scènes non chargées existent pour faire des tests précis de mécaniques : "SceneGauche", "SceneMilieu", "SceneDroite". Elles ne font pas partie du jeu final.
L'affichage de préférence est en 16/9 ou 1920*1080.

## Extras ##
Dans le dossier fourni par mail, se trouvent les attendus de rendu graphiques, notamment dans les dossiers:
- Assets/Personnages
- Assets/Props
- Assets/Tileset
- Assets/UI
- Menu
- Concept

Il y a également un fichier pdf de présentation du jeu et un dossier Captures pour des screenshots et une courte vidéo.

Amusez vous bien !


## Problèmes connus
- Dans la version du build, les contrôles claviers ont un affichage perturbant dans le menu de paramétrage tant qu'ils ne sont pas modifiés (dû à un test du système juste avant de build). Ils sont pourtant bien réglés sur les contrôles par défaut présentés ci-dessus.
- Le dialogue de retour du niveau 2 ne se comporte pas exactement comme les autres au niveau de son affichage
- Des petites collisions sont manquantes dans le niveau de fin
- D'après l'observation des playtests, la fin du niveau 2 n'est pas intuitive. Il faut libérer les 5 âmes présentes dans la zone, puis interagir avec le calice situé au milieu à gauche (là où le sol change). Le passage vers le sceau se libère et le joueur peut le récupérer pour ensuite revenir à la zone précédente grâce au portail à l'entrée

## Améliorations souhaitées
- Animation des âmes libérées et du calice
- Ecran de "fin" selon le choix du joueur plutôt que de revenir directement au menu
- Ré-équilibrer le lancer d'obole et la charge pour inciter le joueur à varier entre leurs utilisations
- Pouvoir générer la minimap à partir du layout réel du niveau et indiquer la position du joueur dessus

## Précisions par rapport au cahier des charges
- Les ennemis peuvent dropper des items différents selon la situation: rien si on n'a pas débloqué les oboles, des oboles si on les tue avec le jugement ou la charge, de la vie si on les tue avec un obole (l'idée étant d'avoir une complémentarité entre l'attaque au corps à corps qui peut faire perdre de la vie mais gagner des munitions, et l'attaque à distance qui consomme des munitions mais peut soigner)
- Dans la version finale, un seul item permet de débloquer une compétence quand on le ramasse (les autres compétences sont débloquées via les dialogues). Dans les fichiers du projet, il existe un prefab pour débloquer n'importe quelle compétence au ramassage: Assets/Prefabs/Drops/DropAbility qu'il faut associer avec un des ScriptableObject dans Assets/Data/Unlocks/\[Judgement/Obole/Charge\]Unlock. Il existe donc techniquement 3 items permettant de débloquer une compétence.
- Les scripts présents dans Assets/Samples/InputSystem/1.7.0/RebindingUI sont tirés de l'exemple par défaut donné par Unity pour utiliser le package officiel "InputSystem". Ils ont été modifiés et adaptés pour gérer l'overlap des binding (ne pas pouvoir attribuer la même touche à plusieurs actions).
- Les images des boutons de la manette étaient fournis avec cet exemple, ils n'ont pas été produits dans le cadre de ce projet.
