# Mon_Assistant_Catalys Rattrapage !

Contributeurs
* Joris Guerrier
* Mathieu Keromnes
* Damien Lasnier

## Documentation d'installation et d'utilisation du projet 

Initialisez le repo git avec 

> git init

Pour initialiser le projet, tirer la dernière branche release disponible. 

> git pull "[Nom_De_La_Branche]"

La dernière branche Release est désormais sur votre machine

## Documentation d'utilisation du repo GIT

Le git est mis en place de façon à adopter une stratégie de branches et de merges. La branche principale, _Main_ contiendra le code à jour et fonctionnel de l'application. 

Schéma des branches

* Master
  * Release_N_Description (incrémentation du nombre en fct des releases sorties)
     * Branches de dév
  

Les branches de dév fonctionne de la façon suivante : 

* Nommage : Nom_Utilisateur/Description

 > La description doit être concise et tenir en quelques mots. Exemple : "MKE/CREATE_UI_Chatbot"
 > La description se précède d'un mot clef : CREATE / UPDATE / FIX (en cas de bug à corriger) 

 * Fonctionnement : Chaque branche doit correspondre à une évolution / Mise en place / Correction / Etc. Par Un et un seul utilisateur.

Pour commit vos modifiaction **__PENSEZ à RÉCUPÉRER LA DERNIERE VERSION DE L'APPLICATION ! DEPUIS LA BRANCHE RELEASE__**

> git pull 
__/!\ BRANCHE RELEASE PAS LA VOTRE !!__ 

, créez une nouvelle branche à votre nom (CF : Nom des branches de dév)

> git checkout "[Nom_De_La_Branche]"

votre branche a été créée, vérifiez vos mises à jour avec

> git status

ajoutez les modification pour les commit

> git add [Nom_des_fichiers / * pour tout]

Commitez vos modifiaction 

> git commit -m "Message de commit"

Ajoutez vos modifications au Repo git 

> git push 

Il est possible que le push plante, pour contrer cela, exécutez 

> git push --set-upstream origin "[Nom_De_Branche]"

