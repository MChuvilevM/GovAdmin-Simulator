# GovAdmin-Simulator

![.NET 9](https://img.shields.io/badge/.NET-9.0-blueviolet?style=flat&logo=.net)
![Avalonia UI](https://img.shields.io/badge/Avalonia-11.2.0-blue?style=flat&logo=avalonia)
![Platform](https://img.shields.io/badge/Platform-Windows-0078D4?style=flat&logo=windows)

Desktop-симулятор управления IT-инфраструктурой, реализованный на .NET 9 и Avalonia UI.

## О проекте
Проект представляет собой симулятор администратора государственных IT-систем. Основной упор сделан на взаимодействие с инфраструктурными компонентами и автоматизацию процессов в рамках игровых механик.

## Технологический стек
*   **Framework:** .NET 9
*   **UI:** Avalonia UI (XAML/C#)
*   **Architecture:** Модульная структура с отдельным вычислительным ядром (`GovAdmin.Engine`)
*   **Platform:** Windows (x64)

## Структура решения
*   `GovAdmin.UI`: Основной проект пользовательского интерфейса.
*   `GovAdmin.Engine`: Библиотека логики, отвечающая за обработку игровых событий и состояний системы.

## Развертывание
1. Убедитесь, что установлен .NET 9.0 Desktop Runtime.
2. Для запуска из исходного кода используйте `dotnet run` в директории `src/GovAdmin.UI`.
3. Для сборки портативной версии используйте:
   ```bash
   dotnet publish -c Release -r win-x64 --self-contained
