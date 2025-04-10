using CSharpConsole;

public class AccountService
{
    public List<Table2> GetAllAccounts()
    {
        using var context = new DataBase();
        return context.Table2.ToList();
    }

    public void AddAccount(string name)
    {
        using var context = new DataBase();
        var newUser = new Table2(name);
        context.Table2.Add(newUser);
        context.SaveChanges();
    }
}
