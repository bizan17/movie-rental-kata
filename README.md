# Audit du Code - Movie Rental Kata

**Problèmes Identifiés** :
- Utilisation de constantes `int` pour les catégories de films au lieu d’un `enum` (pas de type safety)
- Absence de validation dans les constructeurs(accepte null, chaînes vides, valeurs invalides)
- `switch` complexe dans `Customer.statement()` (logique métier difficile à étendre)
- Classe `Customer` avec trop de responsabilités (calculs, formatage, gestion des locations), violation du Single Responsibility Principle
- Style Java avec getters/setters (`getPriceCode()`, `getTitle()`) au lieu de properties C#
- Structure de projet plate, sans séparation en couches
- Code dupliqué 
- Pas d'utilisation de constantes
- Pas de contrôle des valeurs dans les méthodes

**Solutions Implémentées** :
1. Migrer vers .NET 8.0
2. Remplacer les constantes int par enum
3. Ajouter des validations dans les constructeurs
4. Implémenter Strategy Pattern (éliminer le switch)
5. Remplacer les doubles par des decimals
6. Remplacer les getters/setters par properties C#
7. Organiser le projet en couches
8. Utiliser des constatntes
9. Ajout des tests pour le pricing
