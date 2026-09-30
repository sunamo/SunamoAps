---
schema_version: 2
type: library
file_count: 177
delete_recommendation_percent: 5
generated_date: 2026-09-30
generated_time: 16:42:18
---

## Description

Knihovna "All Projects Search" (APS) pro hromadné vyhledávání a operace napříč všemi projekty a solutions v `E:\vs*`, vyčleněná z monolitu `SunamoDevCode`. Obsahuje algoritmy pro mazání dočasných souborů ze solution, konfiguraci a nastavení hledání a podporu pluginů (`ApsPluginHelper`).
Balíček je self-contained: kód dříve referencovaných balíčků (DevCodeBase, SolutionsIndexer, MsBuild, DevCodeCore, CSharp) je zkopírován do `_sunamo\` a zeštíhlen jen na skutečně používané členy (internal), takže nereferencuje jiné Sunamo balíčky.
