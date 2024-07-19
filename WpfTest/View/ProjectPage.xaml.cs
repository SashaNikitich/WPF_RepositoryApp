using System.Windows;
using System.Windows.Controls;

namespace WpfTest.View
{
    public partial class ProjectPage : Page
    {
        public ProjectPage()
        {
            InitializeComponent();
        }

        public ProjectPage(Project project) : this()
        {
            DataContext = project;
        }
        
        private void DeleteProject_Btn(object sender, RoutedEventArgs e)
        {
            // Логика для удаления проекта
            var result = MessageBox.Show("Are you sure?", "Delete Project", MessageBoxButton.YesNo, MessageBoxImage.Warning);
    
            if (result == MessageBoxResult.Yes)
            {
                // Здесь вы можете добавить код для удаления проекта, например:
                // - Удалить проект из списка проектов
                // - Обновить интерфейс
                // - Сохранить изменения в базу данных, если необходимо
            }
        }
    }
}