using System.Windows;

namespace ellenorzo;

public partial class SubjectAdmin : Window
{
    public SubjectAdmin(List<Subjects.Subject> subjects)
    {
        InitializeComponent();
        Admin(subjects);
    }
    
    private void Admin(List<Subjects.Subject> subjects)
    {
        var admin = subjects
            .GroupBy(t => t.Grade)
            .Select(gradeGroup => new
            {
                Grade = gradeGroup.Key,
                GeneralHours = gradeGroup.Where(t => t.Type == "Közismereti").Sum(t => t.HourPerYear),
                VocationalHours = gradeGroup.Where(t => t.Type == "Szakmai").Sum(t => t.HourPerYear),
                GeneralSubjects = gradeGroup.Count(t => t.Type == "Közismereti"),
                VocationalSubjects = gradeGroup.Count(t => t.Type == "Szakmai")
            });
        
        foreach (var grade in admin)
        {
            lstKimutatas.Items.Add($"Évfolyam: {grade.Grade}");
            lstKimutatas.Items.Add($"  Közismereti órák: {grade.GeneralHours}");
            lstKimutatas.Items.Add($"  Szakmai órák: {grade.VocationalHours}");
            lstKimutatas.Items.Add($"  Közismereti tantárgyak: {grade.GeneralSubjects}");
            lstKimutatas.Items.Add($"  Szakmai tantárgyak: {grade.VocationalSubjects}");
            lstKimutatas.Items.Add("");
        }
    }
}