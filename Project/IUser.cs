using Project;
using System.Net.Security;
using System.Windows;
using System.Windows.Input;

public interface IUser
{
    public void userr(string message)
    {
        MessageBox.Show(" " + message);
    }
}
