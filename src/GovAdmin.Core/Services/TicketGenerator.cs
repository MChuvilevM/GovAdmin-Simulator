using GovAdmin.Core.Models;

namespace GovAdmin.Core.Services;

public class TicketGenerator
{
    private static readonly string[] Titles = { 
        "Сервер упал, все пропало!", 
        "Воткнуть кабель в розетку", 
        "Почему интернет платный?",
        "Настройка VPN для начальника"
    };

    public Ticket Generate()
    {
        var random = new Random();
        return new Ticket
        {
            Title = Titles[random.Next(Titles.Length)],
            Priority = (TicketPriority)random.Next(3)
        };
    }
}
