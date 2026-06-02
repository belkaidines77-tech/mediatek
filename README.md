# MediaTek86 – Gestion du personnel et des absences


## 1. Présentation du contexte et but de l’application

MediaTek86 est une Entreprise de Services Numériques (ESN) spécialisée dans le développement informatique, l’infogérance et l’hébergement web.

L’application développée permet au responsable du personnel de :
- gérer les employés (ajout, modification, suppression)
- gérer les absences (ajout, modification, suppression) avec vérification des chevauchements

L’application respecte l’architecture **MVC** (Modèle – Vue – Contrôleur).

## 2. MCD (Modèle Conceptuel de Données)

Tables principales :
- `personnel` (idpersonnel, nom, prénom, tel, mail, idservice)
- `absence` (idpersonnel, datedebut, datefin, idmotif)
- `service` (idservice, nom)
- `motif` (idmotif, libelle)
- `responsable` (login = mediatek, pwd = mediatek86)

## 3. Interfaces

### Page de connexion
Formulaire avec les champs : login=responsable, Mot de passe= admin123

### Page de gestion du personnel
- Liste des employés
- Formulaire d’ajout / modification (nom, prénom, téléphone, email, service)
- Boutons : Ajouter, Modifier, Supprimer, Gérer les absences

### Page de gestion des absences
- Liste des absences d’un employé
- Popup d’ajout / modification (dates, motif)
- Boutons : Ajouter, Modifier, Supprimer


## 4. Diagramme de paquetages (architecture MVC)
