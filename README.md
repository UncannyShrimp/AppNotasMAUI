# App de Notas - .NET MAUI

Una aplicación moderna de toma de notas **multiplataforma** desarrollada con **.NET MAUI 9**.

## Características principales

- Crear, editar y eliminar notas
- Marcar notas como favoritas (★)
- Vista separada de notas favoritas y todas las notas
- Soporte completo claro/oscuro (light/dark mode)
- Diseño limpio y moderno con tarjetas redondeadas y sombras sutiles
- Floating Action Button (FAB) para crear notas rápidamente
- Interfaz consistente en todas las pantallas (lista, creación, edición)

## Tecnologías utilizadas

- .NET 9 + .NET MAUI
- XAML para la interfaz (sin usar Frame → migrado a Border)
- AppThemeBinding para soporte nativo light/dark mode
- CollectionView + DataTemplate para listas de notas
- Binding y patrón MVVM básico (fácil de extender)
- Controles personalizados (StarCheckBox para marcar favoritos)

## Requisitos

- **.NET 9 SDK** (recomendado: última versión preview o RTM de .NET 9)
- Visual Studio 2022 (17.12 o superior) con workload **.NET Multi-platform App UI development**
- Android SDK / emulador o dispositivo físico
- Xcode (para iOS/macOS) o Windows (para probar en Windows)

## Opciones de instalación / uso

Tienes **dos formas** principales de probar o usar la aplicación:

### Opción 1: Descargar e instalar el APK directamente (solo Android)

Puedes descargar la versión compilada más reciente aquí:

         - .\AppNotasNET\Releases APK\com.companyname.appnotasmaui.apk


(Última versión: carpeta `Releases APK` en el repositorio)

Solo descarga el archivo `.apk`, habilita "Orígenes desconocidos" o "Instalar apps desconocidas" en tu dispositivo Android y procede con la instalación.

### Opción 2: Compilar tú mismo (recomendado si quieres modificar o probar en otras plataformas)

1. Clona el repositorio

   ```bash
   git clone https://github.com/tu-usuario/app-notas-maui.git
   cd app-notas-maui

2. Restaura los paquetes
   ```bash
   dotnet restore
3. Compila y ejecuta (elige la plataforma que desees):
   ```Bash
   # Android (emulador o dispositivo conectado)
   dotnet build -t:Run -f net9.0-android

   # Windows
   dotnet build -t:Run -f net9.0-windows10.0.19041.0

   # iOS (solo en Mac con Xcode instalado)
   dotnet build -t:Run -f net9.0-ios

   # Windows
   dotnet build -t:Run -f net9.0-windows10.0.19041.0

   # iOS (solo en Mac con Xcode instalado)
   dotnet build -t:Run -f net9.0-ios
