using System.Collections.Generic;
using System.Linq;
using Diplom.OtherClasses;
using Diplom.View;

namespace Diplom.VM
{
    public class StudentVM
    {
        //открыть список учеников
        private RelayCommand addStudent;

        //удалить ученика
        private RelayCommand deleteStudent;

        //открыть рейтинг
        private RelayCommand openRating;

        public StudentVM()
        {
            var dataContext = new DataContext2();
            students = dataContext.Students.ToList();
        }

        public IEnumerable<Students> students { get; set; }

        public Students selectedStudent { get; set; }

        public RelayCommand AddStudent
        {
            get
            {
                return addStudent ??
                       (addStudent = new RelayCommand(obj => { Transfer.GoTo("Добавить ученика"); }));
            }
        }

        public RelayCommand OpenRating
        {
            get
            {
                return openRating ??
                       (openRating = new RelayCommand(obj => { Transfer.GoTo("Рейтинг"); }));
            }
        }

        public RelayCommand DeleteStudent
        {
            get
            {
                return deleteStudent ??
                       (deleteStudent = new RelayCommand(obj =>
                       {
                           if (selectedStudent == null)
                           {
                               Mes.ErrorMes("Сначала выберите");
                               return;
                           }
                           var dataContext = new DataContext2();
                           dataContext.Students.Remove(dataContext.Students.Find(selectedStudent.Id));
                           dataContext.SaveChanges();
                           Transfer.GoTo("Ученики");
                           Mes.SucMes("Ученик успешно удален");
                       }));
            }
        }

        private RelayCommand changeCommand;
        public RelayCommand ChangeCommand
        {
            get
            {
                return changeCommand ??
                       (changeCommand = new RelayCommand(obj => {
                           if (selectedStudent == null)
                           {
                               Mes.ErrorMes("Сначала выберите");
                               return;
                           }
                           ManagerFrame.Frame.Navigate(new PageChangeStudent(selectedStudent.Id));
                       }));
            }
        }
    }
}