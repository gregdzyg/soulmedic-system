# SoulMedic System

Projekt przygotowany w ramach zajęć z Projektowania Mobilnych Aplikacji Biznesowych.

Na ten moment projekt składa się z:

- backendu (.NET Web API)
- aplikacji mobilnej (React Native)
- bazy danych uruchamianej przez Docker + seeder danych testowych

---

## Co jest zrobione (Lab 1)

- layout aplikacji mobilnej (header + spójny wygląd)
- 2 widoki:
  - lista specjalistów
  - profil specjalisty
- pobieranie danych z backendu
- działająca baza w Dockerze

Aplikacja pozwala pobrać listę specjalistów i po kliknięciu wyświetlić ich szczegóły.

---

## Struktura projektu
soulmedic-system/
├── backend/
├── mobile/
├── docs/
└── README.md


---

## Wymagania

Do uruchomienia projektu potrzebne są:

- Docker Desktop
- Visual Studio / .NET SDK
- Node.js
- Android Studio (emulator) + Android SDK + JDK

---

## Ważna informacja (Android)

Aplikacja mobilna korzysta z adresu: http://10.0.2.2:5020/api

Jest to adres emulatora Android wskazujący na lokalny komputer.

Backend musi działać lokalnie na HTTP.

---

## Instrukcja uruchomienia (krok po kroku)

### 1. Uruchom Docker Desktop

Uruchom Docker Desktop i poczekaj aż się w pełni załaduje.

---

### 2. Uruchom bazę danych

Przejdź do katalogu:
backend/SoulMedic

Uruchom:
docker compose up -d


---

### 3. Uruchom backend

1. Otwórz projekt w Visual Studio
2. Uruchom aplikację
3. WAŻNE: użyj HTTP (nie HTTPS)

Backend powinien działać np. pod:
http://localhost:5020


---

### 4. Uruchom emulator Android

1. Otwórz Android Studio
2. Device Manager
3. Uruchom emulator
4. Poczekaj aż się w pełni uruchomi

---

### 5. Uruchom aplikację mobilną

Przejdź do katalogu:
mobile/SoulMedicMobile

Zainstaluj zależności:
npm install


Uruchom aplikację:
npx react-native run-android
