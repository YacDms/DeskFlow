
# 🧠 DeskFlow – Votre assistant de productivité de bureau

**DeskFlow** est un assistant intelligent tout-en-un, conçu pour les professionnels du bureau souhaitant gagner en efficacité. Propulsé par .NET MAUI, il offre une expérience multiplateforme fluide et intègre progressivement des capacités d’**intelligence artificielle** pour automatiser, recommander et optimiser vos journées de travail.

## 🚀 Fonctionnalités principales

- ✅ **Gestion avancée de tâches** (priorités, échéances, statuts, catégories)
- 🔔 **Rappels intelligents** et notifications contextuelles
- 📝 **Bloc-notes rapide** avec reconnaissance de texte (OCR à venir)
- 📊 **Tableaux de bord de productivité** (temps de focus, tâches accomplies, interruptions)
- 🌐 **Synchronisation Cloud & Multi-appareils** (via API REST)
- 🎨 **Thèmes adaptatifs** : clair, sombre, automatique
- 📅 **Calendrier intégré** (vue agenda hebdomadaire/mensuelle)
- 🤖 **Fonctionnalités IA à venir** :
  - Suggestions de tâches basées sur l'historique et le contexte
  - Planification automatique de journée (IA de priorisation)
  - Résumés de notes générés par l’IA
  - Analyse des habitudes et recommandations personnalisées

## 🛠️ Technologies

- **.NET 8** + **.NET MAUI** (Windows, Android, iOS)
- **MVVM** (Model-View-ViewModel)
- **EF Core** (SQLite local / SQL Server pour API)
- **ASP.NET Core Web API** (pour la synchronisation cloud)
- **XAML** pour l’interface utilisateur
- **Dependency Injection**, **Navigation moderne avec Shell**
- **Swagger** pour tester l'API

## 📁 Structure du projet

```
DeskFlow/
├── DeskFlow.App/         # Application MAUI (UI + logique métier)
├── DeskFlow.Shared/      # Modèles, DTOs, services
├── DeskFlow.Api/         # API Web REST (.NET Core)
├── DeskFlow.Database/    # Contexte EF Core, Migrations
└── README.md
```

## 💻 Installation rapide

1. **Cloner le dépôt** :
```bash
git clone https://github.com/votre-utilisateur/deskflow.git
cd deskflow
```

2. **Ouvrir dans Visual Studio 2022+** (workload .NET MAUI installé)
3. Lancer le projet `DeskFlow.App` ou `DeskFlow.Api` selon besoin
4. Swagger est activé pour tester les endpoints de l'API

## 🌐 API REST (DeskFlow.Api)

- Authentification par JWT (à venir)
- Points de terminaison pour utilisateurs, tâches, notes, rappels
- Swagger UI disponible à l'adresse : `https://localhost:{port}/swagger`

## 📅 Roadmap

- [x] Architecture multi-projet
- [x] Base MAUI avec navigation Shell
- [x] API fonctionnelle avec EF Core
- [ ] Authentification + autorisation (JWT)
- [ ] Notifications push (Android & Windows)
- [ ] Intégration IA (suggestions, résumés, routines)
- [ ] Ajout d’un assistant vocal (Copilot intégré)
- [ ] Export PDF / Excel de l’activité

## 🤝 Contribution

Les contributions sont bienvenues ! 🚀

1. Fork du repo
2. Créer une branche `feature/ma-fonctionnalite`
3. Soumettre une Pull Request bien documentée

## 📜 Licence

MIT © 2025 – Projet DeskFlow

---

> DeskFlow – Augmentez votre focus, automatisez vos routines, et domptez votre journée.
