# GestionChantier – Solution Visual Studio (.NET 8 / WinForms / MySQL)

## 1. Créer la base de données
1. Démarrez MySQL (XAMPP / WAMP / MySQL Server).
2. phpMyAdmin → onglet **SQL** → collez le contenu de `GestionChantier_MySQL.sql` → **Exécuter**.
   (ou en ligne de commande : `mysql -u root < GestionChantier_MySQL.sql`)
   Le script crée la base `dbGestionChantierKetsia` : 14 tables, 73 procédures stockées, jeu de données.

## 2. Ouvrir le projet
1. Ouvrez `GestionChantier.sln` avec **Visual Studio 2022** (charge de travail « Développement de bureau .NET »).
2. Le package NuGet **MySql.Data** est restauré automatiquement au premier build.
3. Si besoin, adaptez la chaîne de connexion dans `GestionChantier/DataAccess/Connexion.cs`
   (par défaut : localhost, port 3306, utilisateur `root`, mot de passe vide).
4. **F5** pour lancer.

## 3. Comptes de démonstration
| Identifiant | Mot de passe  | Rôle         | Droits                                   |
|-------------|---------------|--------------|------------------------------------------|
| admin       | Admin@2026    | Admin        | Tout + gestion des utilisateurs          |
| gestion     | Gestion@2026  | Gestionnaire | Ajout / modification / suppression       |
| consult     | Consult@2026  | Consultant   | Lecture seule, impression, export        |

## 4. Architecture
- `Models/` : une classe par table (+ colonnes d'affichage issues des jointures).
- `DataAccess/` : `Connexion`, `DbHelper`, un DAO par table (Create, ReadAll, ReadById, Update, Delete) qui appelle les procédures stockées `sp_*`, et `StatsDAO` (statistiques).
- `UInterface/` : FrmXxxList + FrmXxxDetail pour chaque table (colonnes des grilles définies dans le Designer), connexion, fenêtre principale, tableau de bord, impression.

## 5. Fonctionnalités ajoutées côté interface
Connexion sécurisée (mots de passe salés SHA-256) et rôles · tableau de bord (KPI + 3 graphiques) · recherche instantanée et tri par colonne · impression avec aperçu (et PDF via « Microsoft Print to PDF ») · fiche chantier imprimable · facture d'achat imprimable · export CSV/Excel · lignes d'achat par achat · changement de mot de passe · messages d'erreur clairs (clés étrangères, règles de gestion).

## 6. Remarque sur le schéma
Les types des services de travail (`Interne` / `Externe`) et les statuts de chantier (`Planifié`, `En cours`, `Suspendu`, `Terminé`) sont des valeurs proposées dans les listes déroulantes : adaptez-les dans `Models`/Designer si votre énoncé en impose d'autres.
