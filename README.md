# Parallel Prime Checker (.NET / C#)

Kleine Demo-Anwendung, die zeigt, wie man die Berechnung von Primzahlen
mit `Parallel.ForEach` parallelisieren kann.

- Generiert ein Array mit Zufallszahlen
- Zählt Primzahlen sequentiell und parallel
- Vergleicht die Laufzeiten

Tech:
- .NET 8
- C#
- `Parallel.ForEach`, `Stopwatch`

Build:
```bash
dotnet build
dotnet run --project ParallelPrimeChecker
```
