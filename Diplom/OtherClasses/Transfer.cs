﻿namespace Diplom
{
    using System.Windows;

    using Diplom.View;

    public static class Transfer
    {
        public static void GoTo(string namePage)
        {
            switch (namePage)
            {
                case "Главная":
                {
                    ManagerFrame.Frame.Navigate(new MainPage());
                    break;
                }
                case "Ученики":
                {
                    ManagerFrame.Frame.Navigate(new PageStudents());
                    break;
                }
                case "Мероприятия":
                {
                    ManagerFrame.Frame.Navigate(new PageEvents());
                    break;
                }
                case "Органы школьного совета":
                {
                    ManagerFrame.Frame.Navigate(new PageManagers());
                    break;
                }
                case "Добавить ученика":
                {
                    ManagerFrame.Frame.Navigate(new PageAddStudent());
                    break;
                }
                case "Рейтинг":
                {
                    ManagerFrame.Frame.Navigate(new PageRating());
                    break;
                }
                case "Добавить мероприятие":
                {
                    ManagerFrame.Frame.Navigate(new PageAddEvent());
                    break;
                }
                default:
                {
                    MessageBox.Show("Такой страницы еще нет");
                    break;
                }
            }
        }
    }
}