App de Notas - .NET MAUI

Una aplicación moderna de toma de notas multiplataforma desarrollada con **.NET MAUI 9**.

Características principales:
- Crear, editar y eliminar notas
- Marcar notas como favoritas (★)
- Vista de notas favoritas y todas las notas
- Soporte claro/oscuro (light/dark mode)
- Diseño limpio y moderno con tarjetas redondeadas y sombras sutiles
- Floating Action Button (FAB) para crear notas rápidamente
- Interfaz consistente en todas las pantallas (lista, creación, edición)

## Tecnologías utilizadas

- **.NET 9** + **.NET MAUI**
- XAML para la interfaz (sin usar Frame – migrado a Border)
- AppThemeBinding para soporte nativo light/dark mode
- CollectionView + DataTemplate para listas de notas
- Binding y MVVM básico (puedes extenderlo fácilmente)
- Controles personalizados (StarCheckBox para favorito)

## Requisitos

- **.NET 9 SDK** (recomendado: última versión preview o RTM de .NET 9)
- Visual Studio 2022 (17.12 o superior) con workload **.NET Multi-platform App UI development**
- Android SDK / emulador o dispositivo físico
- Xcode (para iOS/macOS) o Windows para probar en Windows

## Instalación y ejecución

1. Clona el repositorio:

   git clone https://github.com/tu-usuario/app-notas-maui.git
   cd app-notas-maui

Restaura los paquetes:Bashdotnet restore
Compila y ejecuta (elige la plataforma deseada):Bash# Para Android (emulador o dispositivo)
dotnet build -t:Run -f net9.0-android

# Para Windows
dotnet build -t:Run -f net9.0-windows10.0.19041.0

# Para iOS (en Mac)
dotnet build -t:Run -f net9.0-iosO simplemente abre la solución en Visual Studio y selecciona el proyecto + plataforma.
