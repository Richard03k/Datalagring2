using CSharpConsole;

public class ProjectService
{
    public void AddProject(string name, string start, string end, string manager, string customer, string service, string status)
    {
        using var context = new DataBase();

        var lastProject = context.Contacts.OrderByDescending(p => p.ID).FirstOrDefault();
        int number = 0;

        if (lastProject != null && lastProject.ID.StartsWith("P-"))
        {
            var raw = lastProject.ID.Substring(2);
            if (int.TryParse(raw, out int result)) number = result + 1;
        }

        string id = $"P-{number}";
        var project = new Kontakter(name, start, end, manager, customer, service, status, id);
        context.Contacts.Add(project);
        context.SaveChanges();
    }

    public List<Kontakter> GetAllProjects()
    {
        using var context = new DataBase();
        return context.Contacts.ToList();
    }

    public Kontakter GetProjectByIndex(int index)
    {
        var all = GetAllProjects();
        return index >= 0 && index < all.Count ? all[index] : null;
    }

    public void UpdateProject(Kontakter project)
    {
        using var context = new DataBase();
        context.Contacts.Update(project);
        context.SaveChanges();
    }
}
