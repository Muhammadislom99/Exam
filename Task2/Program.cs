// See https://aka.ms/new-console-template for more information

var clients = new List<Client>()
{
    new()
    {
        Id = Guid.NewGuid(),
        FullName = "Jane Doe",
        Appointments = new List<Appointment>()
        {
            new() { Date = DateTime.UtcNow.AddDays(-1) },
            new()
            {
                Date = DateTime.UtcNow.AddDays(2),
                IsCanceled = true
            },
            new() { Date = DateTime.UtcNow },
            new() { Date = DateTime.UtcNow.AddDays(1) }
        }
    },
    new()
    {
        Id = Guid.NewGuid(),
        FullName = "Shon Jobs",
        Appointments = new List<Appointment>()
        {
            new() { Date = DateTime.UtcNow.AddDays(-2) },
            new() { Date = DateTime.UtcNow.AddDays(2) },
            new() { Date = DateTime.UtcNow },
            new() { Date = DateTime.UtcNow.AddDays(3) }
        }
    },
};


var nextOrders1 = (from client in clients
        from appointment in client.Appointments
        where appointment.IsCanceled == false && appointment.Date > DateTime.UtcNow
        select new { FullName = client.FullName, Count = client.Appointments.Count })
    .Distinct().OrderByDescending(a => a.Count).ToList();

var nextOrder =
    (from client in clients
        let i = client.Appointments.Count(appointment =>
            appointment.IsCanceled == false && appointment.Date > DateTime.UtcNow)
        where i > 0
        select new { FullName = client.FullName, Count = i })
    .OrderByDescending(c => c.Count);

foreach (var client in nextOrder)
    Console.WriteLine($"{client.FullName} Count : {client.Count}");


public class Client
{
    public Guid Id { get; set; }
    public string FullName { get; set; }
    public List<Appointment> Appointments { get; set; }
}

public class Appointment
{
    public DateTime Date { get; set; }
    public bool IsCanceled { get; set; }
}