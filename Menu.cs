using Spectre.Console;
namespace CarzCo;

public class Menu
{
    public void DisplayMenu()
    {
        var fruit = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("What's your [green]favorite fruit[/]?")
                .PageSize(10)
                .MoreChoicesText("[grey](Move up and down to reveal more fruits)[/]")
                .AddChoices(new[] {
                    "Vehicles", "Maintenance Record", "Reserved Vehicles",
                }));
    }
    
}