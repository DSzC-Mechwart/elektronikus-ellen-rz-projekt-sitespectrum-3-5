using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace ellenorzo;

public partial class Subjects : Window
{
    List<Subject> subjects = new List<Subject>();
    public Subjects()
    {
        InitializeComponent();
        LoadStudents();
        LoadSubjects();
    }
    
    public class Subject
    {
        public string Name { get; set; }
        public int Grade { get; set; }
        public string Type { get; set; }
        public int HourPerWeek { get; set; }
        public int HourPerYear { get; set; }
    }
    
    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        var subject = new Subject
        {
            Name = txtSubjectName.Text,
            Grade = int.Parse(((ComboBoxItem)cmbGrade.SelectedItem).Content.ToString()),
            Type = ((ComboBoxItem)cmbType.SelectedItem).Content.ToString(),
            HourPerWeek = int.Parse(txtHourPerWeek.Text)
        };

        int weeksCount = 36;
        if (subject.Grade == 12)
        {
            weeksCount = subject.Type == "Közismereti" ? 31 : 36;
        }
        else if (subject.Grade == 13)
        {
            weeksCount = 31;
        }
        subject.HourPerYear = subject.HourPerWeek * weeksCount;

        subjects.Add(subject);
        SaveSubjectsToJSON();
        UpdateSubjectsList();
    }

    private void SaveSubjectsToJSON()
    {
        string json = JsonSerializer.Serialize(subjects);
        File.WriteAllText("subjects.json", json);
    }
    
    private void LoadSubjects()
    {
        if (File.Exists("subjects.json"))
        {
            string json = File.ReadAllText("subjects.json");
            subjects = JsonSerializer.Deserialize<List<Subject>>(json) ?? new List<Subject>();
        }
        UpdateSubjectsList();
    }
    

    private void UpdateSubjectsList()
    {
        lstSubjects.Items.Clear();
        foreach (var s in subjects)
        {
            lstSubjects.Items.Add($"{s.Name} - {s.Grade}. évfolyam - {s.Type} - Heti: {s.HourPerWeek} óra - Éves: {s.HourPerYear} óra");
        }
        cmbSubjects.ItemsSource = subjects;
        cmbSubjects.DisplayMemberPath = "Name";
    }
    
    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
        if (lstSubjects.SelectedItem != null)
        {
            int index = lstSubjects.SelectedIndex;
            subjects.RemoveAt(index);
            SaveSubjectsToJSON();
            UpdateSubjectsList();
        }
    }

    private void btnAdmin_Click(object sender, RoutedEventArgs e)
    {
        var admin = new SubjectAdmin(subjects);
        admin.Show();
    }
    
    private void LoadStudents()
    {
        cmbStudents.ItemsSource = MainWindow.students;
        cmbStudents.DisplayMemberPath = "Name";
        
    }
    
    private void btnAdd_Click(object sender, RoutedEventArgs e)
    {
        if (cmbStudents.SelectedItem == null)
        {
            MessageBox.Show("Kérjük, válassz ki egy tanulót!");
            return;
        }

        if (cmbSubjects.SelectedItem == null)
        {
            MessageBox.Show("Kérjük, válassz ki egy tantárgyat!");
            return;
        }

        var selectedStudent = cmbStudents.SelectedItem as MainWindow.Student;
        var selectedSubject = cmbSubjects.SelectedItem as Subject;

        if (selectedStudent != null && selectedSubject != null)
        {
            if (!selectedStudent.Subjects.Contains(selectedSubject))
            {
                selectedStudent.Subjects.Add(selectedSubject);
                UpdateStudentSubjects(selectedStudent);
                MainWindow.SaveStudents();
            }
            else
            {
                MessageBox.Show("Ez a tantárgy már hozzá van rendelve a tanulóhoz.");
            }
        }
    }


    private void UpdateStudentSubjects(MainWindow.Student student)
    {
        lstStudentSubjects.Items.Clear();
        foreach (var s in student.Subjects)
        {
            lstStudentSubjects.Items.Add($"{s.Name} - {s.Grade}. évfolyam - {s.Type}");
        }
    }

    private void CmbTanulok_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        UpdateStudentSubjects(cmbStudents.SelectedItem as MainWindow.Student);
    }
}