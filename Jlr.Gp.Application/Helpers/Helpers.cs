namespace Jlr.Gp.Application.Helpers;
public static class Helpers
{
    public static void SplitLastName(string lastName, out string fatherLastName, out string motherLastName)
    {
        fatherLastName = "";
        motherLastName = "";
        var index = lastName.IndexOf(' ');
        if (index == -1)
        {
            fatherLastName = lastName;
        }
        else
        {
            fatherLastName = lastName.Substring(0, index);
            motherLastName = lastName.Substring(index + 1);
        }
    }
}
