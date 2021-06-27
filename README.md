# personal project
 Side project. It is now a barren field. Soon it will be turned into a game. This project was created by using two patterns appropriately.   
 
 
 The first is the command pattern. It was created with reference to [WPF of .NET Framework](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/advanced/commanding-overview?view=netframeworkdesktop-4.8). All actions are stored in a buffer and executed according to the rules(there are no rules yet).
 
Secondly, I used mvp pattern to separate view and logic. The mvp pattern was implemented using [UniRx](https://github.com/neuecc/UniRx#model-view-reactivepresenter-pattern). 

Resources are managed using ScriptableObject. 

Using Unity's new [input system](https://github.com/Unity-Technologies/InputSystem), keyboards, virtual pads, and controllers are easily supported.

## System Requirements
- Unity 2020.3.11f1

## Packages
- [Input System](https://github.com/Unity-Technologies/InputSystem) (To Support virtual pad, keyboard and controller)

## Plugins
- [UniRx](https://github.com/neuecc/UniRx#model-view-reactivepresenter-pattern)
- [DOTween](https://github.com/Demigiant/dotween)
